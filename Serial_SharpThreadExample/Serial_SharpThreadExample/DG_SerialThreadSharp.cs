using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;

//MainForm
using Serial_SharpThreadExample;

public class DG_SerialThreadSharp
{
    //Declear Serial
    private MainForm mainForm = new MainForm();
    private List<Serial> lSerials = new List<Serial>();
    private UInt32 serialCnt = 0;

    private Thread thread = null;
    public DG_SerialThreadSharp()
    {
        thread = new Thread(new ThreadStart(ThreadMethod));        
    }

    public void ThreadMethod()
    {
        byte[] arrByte;

        if (lSerials[0].Read())
        {
            //Copy Sentence
            arrByte = new byte[lSerials[0].RcvSentence[1]];
            Buffer.BlockCopy(lSerials[0].RcvSentence, 0, arrByte, 0, lSerials[0].RcvSentence[1]);

            for (int i = 0; i < lSerials[0].RcvSentence[1]; i++)
            {
                Console.Write(arrByte[i] + " ");
            }
            Console.WriteLine("");

            //mainForm.Invoke(mainForm.Delegate, new Object[] { lSerials[0].ReadSentence() };
        }

        for (int i = 0; i < serialCnt; i++)
        {
            if (lSerials[i].Read())
            {

                
            }
        }
    }

    public class Serial
    {
        //Declear Serial
        private MainForm mainForm = new MainForm();

        SerialPort serialPort = new SerialPort();
        private byte[] buffer = new byte[1024];
        private int buffer_length = 0;
        private int data_length = 0;

        public byte[] RcvSentence = new byte[1024];

        public Serial()
        {

        }

        public bool Read()
        {
            buffer_length += serialPort.Read(buffer, buffer_length, serialPort.BytesToRead);

            while (buffer_length > 0)   //버퍼가 다 없어 질때까지 
            {
                if (buffer[0] == SPort.sSTX())
                {
                    if (buffer_length >= 2)
                    {
                        data_length = buffer[1];
                        if (buffer_length >= data_length)   //버퍼의 크기가 데이터의 길이보다 클때만
                        {
                            if (buffer[data_length - 1] == SPort.sETX())
                            {
                                //OneData로 복사
                                Array.Clear(RcvSentence, 0, 1024);
                                Buffer.BlockCopy(buffer, 0, RcvSentence, 0, data_length);

                                //복사 후 데이터는 삭제 후 이동
                                Buffer.BlockCopy(buffer, data_length, buffer, 0, 1024 - data_length);
                                buffer_length -= data_length;
                                return true;
                            }
                            else
                            {
                                //ETX 위치가 맞지 않음 1개씩 OffSet
                                Buffer.BlockCopy(buffer, 1, buffer, 0, 1023);
                                buffer_length--;
                            }
                            continue;
                        }
                        break;
                    }
                    else
                        break;
                }
                else
                {
                    //Momory Offset
                    Buffer.BlockCopy(buffer, 1, buffer, 0, 1023);
                    buffer_length--;
                }
            }
            return false;
        }

        public virtual void ReadSentence()
        {
            //문장을 넘겨야함.
            byte[] bSubSentence = new byte[RcvSentence[1]];
            Buffer.BlockCopy(RcvSentence, 0, bSubSentence, 0, RcvSentence[1]);

        }
    }
}

class SPort
{
    public static byte sSOH() { return 0x01; }
    public static byte sSTX() { return 0x02; }
    public static byte sETX() { return 0x03; }
    public static byte sEOT() { return 0x04; }
    public static byte sENQ() { return 0x05; }
    public static byte sACK() { return 0x06; }
    public static byte sNAK() { return 0x15; }
    public static string sCRLF() { return "\r\n"; }

    public static string[] GetPortsList()
    {
        List<string> serialportlist = new List<string>();
        serialportlist.Clear();
        foreach (string comport in SerialPort.GetPortNames())
        {
            serialportlist.Add(comport);
        }
        return serialportlist.ToArray();
    }

    public static bool OpenPorts(SerialPort sport, string portnum, int baudRate)
    {
        if (!sport.IsOpen)
        {
            try
            {
                //SerialPort 초기설정
                sport.PortName = portnum;
                sport.BaudRate = baudRate;
                sport.DataBits = 8;
                sport.Parity = Parity.None;
                sport.StopBits = StopBits.One;
                sport.ReceivedBytesThreshold = 1;
                sport.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
        else
        {
            try
            {
                sport.Close();
                return false;
            }
            catch
            {
                return false;
            }
        }
    }

    public static bool ClosePorts(SerialPort sport)
    {
        if (sport.IsOpen)
        {
            sport.Close();
            return true;
        }
        else
            return false;
    }

    public static void Send(SerialPort sport, byte[] msg)
    {
        sport.Write(msg, 0, msg[1]);
    }
}