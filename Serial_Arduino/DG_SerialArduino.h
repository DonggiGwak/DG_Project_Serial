/* DG Project by DG
 * Ver 1.0.1 Update 19-11-12
 */ 

#pragma once
#include <Arduino.h>;

#define STX 0x02
#define ETX 0x03
#define BUFFER_SIZE 128

class DG_Serial
{
public:
  int length = 0;

	void begin(long baudrate);
  bool available();
  void print(String str);
  void print(char chr);
  void print(char arrChr[]);
  void print(int value);
  void print(float value);

  bool read(char *arrChr);
  bool read_all(char *arrChr);

  void Split(String *X, String *Y, String *Z, String src, char cSplit); 

private:
	char ReceiveData[BUFFER_SIZE];

private:
	char _buffer[BUFFER_SIZE];
	int buffer_length = 0;
	int data_length = 0;
	void ReadSentence();
};
