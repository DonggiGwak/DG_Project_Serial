using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_SharpExample
{
    public partial class MainForm : Form
    {
        public delegate void SerialReceiveDelegate(byte[] msg);
        public SerialReceiveDelegate serialReceiveDelegate;

        DG_Serial dg_serial = new DG_Serial();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string[] portNums = SPort.GetPortsList();

            for(int i = 0; i < portNums.Count(); i++)
            {
                com_portNum.Items.Add(portNums[i]);
            }
            com_portNum.SelectedIndex = 2;

            dg_serial = new DG_Serial(this);
            serialReceiveDelegate += new SerialReceiveDelegate(SerialReceiveMethod);
        }

        private void btn_serialOpen_Click(object sender, EventArgs e)
        {
            if(SPort.OpenPorts(serialPort, Convert.ToString(com_portNum.SelectedItem), 9600))
            {
                btn_serialOpen.Text = "닫기";
            }
            else
            {
                btn_serialOpen.Text = "열기";
            }
        }

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //버퍼에 모든 변수 이동
            dg_serial.buffer_length += serialPort.Read(dg_serial.buffer, dg_serial.buffer_length, serialPort.BytesToRead);
            dg_serial.Read();
        }

        private void SerialReceiveMethod(byte[] msg)
        {
            string str = "";
            for(int i = 0; i < msg[1]; i++)
            {
                str += Convert.ToString(msg[i] + " ");
            }
            listBox_serialRcv.Items.Add(str);
        }

        private void btn_array_test_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void btn_sample_Click(object sender, EventArgs e)
        {
            string TEST = "567";
            byte[] bSend = Send(TEST);
            serialPort.Write(bSend, 0, bSend.Length);
        }

        private byte[] Send(string msg)
        {
            byte[] bMsg = Encoding.ASCII.GetBytes(msg);
            byte Len = Convert.ToByte(bMsg.Count() + 3);

            byte[] bSend = new byte[Len];

            bSend[0] = SPort.sSTX();
            bSend[1] = Len;
            Buffer.BlockCopy(bMsg, 0, bSend, 2, bMsg.Count());
            bSend[Len - 1] = SPort.sETX();

            return bSend;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btn_sample_Click(sender, e);
        }
    }
}
