/* DG Project by DG
 * Ver 1.0.0 Update 19-11-11 bbae bbae ro day 
 */ 

#pragma once
#include <Arduino.h>;

#define STX 0x02
#define ETX 0x03
#define BUFFER_SIZE 128

class DG_Serial
{
public:
	void begin(long baudrate);
	bool Read();
	char ReceiveData[BUFFER_SIZE];

private:
	char _buffer[BUFFER_SIZE];
	int buffer_length = 0;
	int data_length = 0;
	void ReadSentence();
};
