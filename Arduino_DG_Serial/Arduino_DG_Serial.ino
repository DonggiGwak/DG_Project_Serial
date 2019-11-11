#include "DG_SerialArduino.h";

DG_Serial dg_serial;

void setup() {
	// put your setup code here, to run once:
	dg_serial.begin(9600);
	//memset(_buffer, 0, sizeof(char)*BUFFER_SIZE);
	//memset(RcvOneSentence, 0, sizeof(char)*BUFFER_SIZE);
}

void loop() {
  // put your main code here, to run repeatedly:
	if (dg_serial.Read())
	{
		for (int i = 0; i < dg_serial.ReceiveData[1]; i++)
			Serial.print(dg_serial.ReceiveData[i]);
	}
}
