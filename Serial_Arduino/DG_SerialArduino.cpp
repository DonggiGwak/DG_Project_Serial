#include "DG_SerialArduino.h";

void DG_Serial::begin(long baudrate)
{
	Serial.begin(baudrate);
	Serial.setTimeout(10);
}

void DG_Serial::print(char arrChr[])
{
  String str = arrChr;
  int len = str.length();
  Serial.write(STX);
  Serial.write(len + 3);
  Serial.print(str);
  Serial.write(ETX);
}
void DG_Serial::print(String str)
{
  int len = str.length();
  Serial.write(STX);
  Serial.write(len + 3);
  Serial.print(str);
  Serial.write(ETX);
}
void DG_Serial::print(char chr)
{
    Serial.write(STX);
    Serial.write(4);
    Serial.write(chr);
    Serial.write(ETX);
}
void DG_Serial::print(int value)
{
  String str = (String)value;
  int len = str.length();
  Serial.write(STX);
  Serial.write(len + 3);
  Serial.print(str);
  Serial.write(ETX);
}
void DG_Serial::print(float value)
{
  String str = (String)value;
  int len = str.length();
  Serial.write(STX);
  Serial.write(len + 3);
  Serial.print(str);
  Serial.write(ETX);
}

bool DG_Serial::available()
{
  while (Serial.available())
  {
    _buffer[buffer_length] = Serial.read();
    buffer_length++;
  }

  while (buffer_length > 0)
  {
    if (_buffer[0] == STX)
    {
      if (buffer_length >= 2)
      {
        data_length = _buffer[1];
        if (buffer_length >= data_length)
        {
          if (_buffer[data_length - 1] == ETX)
          {
            memset(ReceiveData, 0, sizeof(char)*BUFFER_SIZE);
            memcpy(ReceiveData, _buffer, data_length * sizeof(char));
            buffer_length -= data_length;
            length = ReceiveData[1];
            return true;
          }
          else
          {
            memmove(_buffer, _buffer + sizeof(char), BUFFER_SIZE - 1);
            buffer_length--;
          }
          continue;
        }
      }
      break;
    }
    else
    {
      memmove(_buffer, _buffer + sizeof(char), BUFFER_SIZE - 1);
      buffer_length--;
    }
  }
  return false;
}

bool DG_Serial::read_all(char *arrChr)
{
  memcpy(arrChr, ReceiveData, length * sizeof(char)); 
  return true;
}

bool DG_Serial::read(char *arrChr)
{
  memcpy(arrChr, ReceiveData + sizeof(char)*2, (length - 3) * sizeof(char));
  return true;
}

 void DG_Serial::Split(String *X, String *Y, String *Z, String src, char cSplit)
 {
    int idx = 0;
    idx = src.indexOf(cSplit);
    if(idx < 0)
    return;

    //--X--//
    *X = src.substring(0, idx);
    src.remove(0, idx + 1);
    
    idx = src.indexOf(cSplit);
    if(idx < 0)
    return;

    //--Y--//
    *Y = src.substring(0, idx);
    src.remove(0, idx + 1);

    //--Z--//
    idx = src.length();
    *Z = src.substring(0, idx);
 }
