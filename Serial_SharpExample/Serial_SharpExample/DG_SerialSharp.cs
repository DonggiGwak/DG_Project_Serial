/* DG Project by DG
 * Ver 1.0.0 Update 19-11-11 bbae bbae ro day 
 */ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

//Serial Port의 이벤트는 메인 폼에서 관리
//데이터를 저장, 버퍼, 읽기 처리 등만 관리
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

class DG_Serial
{
    Serial_SharpExample.MainForm mainForm;

    //개별 데이터 관리를 위함
    public byte[] buffer = new byte[1024];   //수신 데이터 버퍼
    public int buffer_length = 0;
    public int data_length = 0;
    public byte[] RcvSentence = new byte[1024];  //하나의 온전한 데이터


    public DG_Serial()
    {

    }
    public DG_Serial(Serial_SharpExample.MainForm _mainForm)
    {
        mainForm = _mainForm;
    }

    public void Read()
    {
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
                            ReadSentence();
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
    }

    public void ReadSentence()
    {
        //완벽한 문자열이 들어오면 여기가 불립니다.
        //for(int i = 0; i < RcvOneSentence[1]; i++)
        //{
        //    Console.Write(RcvOneSentence[i] + " ");
        //}
        //Console.WriteLine();

        byte[] bSubSentence = new byte[RcvSentence[1]];
        Buffer.BlockCopy(RcvSentence, 0, bSubSentence, 0, RcvSentence[1]);

        mainForm.Invoke(mainForm.serialReceiveDelegate, new Object[] { bSubSentence });
    }

    public byte[] Send(string msg)
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
}