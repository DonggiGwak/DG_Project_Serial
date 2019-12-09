#include "DG_SerialArduino.h";

/*
 * DG Serial Example Source Code
 * by DG Gwak
 */

DG_Serial dg_serial;

void setup() {
  // put your setup code here, to run once:
  dg_serial.begin(115200);
}

void loop() {
  // put your main code here, to run repeatedly:
  if (dg_serial.available())
  {
    int len  = dg_serial.length;    
    char bufRcv[len - 3];   //Only Data without STX, LEN and ETX
    dg_serial.read(bufRcv); //Copy Data
    
    char bufRcv_all[len]; //All Data
    dg_serial.read_all(bufRcv_all); //Copy Data

    //---- 수신 처리 예제 -----//
    // 1. 받은 문자 Return
    String str;    
    //(1) 
    //str = String(bufRcv); dg_serial.print(str);
    //(2) 
    //dg_serial.print(bufRcv);
    //(3)
    //for(int i = 2; i < len - 1; i++)
    //{
    //  str += bufRcv_all[i];
    //}
    //dg_serial.print(str);

    // 2. 단일 문자 처리
    //(1) 
    //switch(bufRcv_all[2])
    //{
    //  case 'A':
    //    dg_serial.print('a');
    //    break;
    //}
    //(2)
    //switch(bufRcv[0])
    //{
    //  case 'B':
    //      dg_serial.print('b');
    //    break;
    //}

    // 3. 숫자 처리
    //Number
    // 수신 메세지 -> STX, LEN, [NUMBER], ETX 일때
    //(1) int
    //int value = String(bufRcv).toInt();
    //dg_serial.print(value);
    //(2) float
    //float value = String(bufRcv).toFloat();
    //dg_serial.print(value);
    
    // 4. 좌표 처리
    //str = String(bufRcv);
    //String X, Y, Z;
    //dg_serial.Split(&X, &Y, &Z, str, ',');
    //Serial.println(X);
    //Serial.println(Y);
    //Serial.println(Z);
  }

  //송신처리 예제
  //1. 숫자 보내기
  int Num = 32;
  dg_serial.print(Num);
  //2. 문자 보내기
  char ch = 'A';
  dg_serial.print(ch);
  //3. 문자열 보내기
  String str = "KIRO";
  dg_serial.print(str);
  delay(1000); 
}
