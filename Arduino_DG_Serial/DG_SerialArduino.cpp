#include "DG_SerialArduino.h";

void DG_Serial::begin(long baudrate)
{
	Serial.begin(baudrate);
	Serial.setTimeout(10);
}

bool DG_Serial::Read()
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
