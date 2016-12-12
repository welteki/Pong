int switchStateLeft = 0;
int switchStateRight = 0;
int inByte = 0;

void setup() {
  Serial.begin(9600);
  while(!Serial) {
    ;
  }

  pinMode(8,OUTPUT);
  pinMode(4,OUTPUT);
  pinMode(5,OUTPUT);
  pinMode(10,INPUT);
  pinMode(11,INPUT);
}

void loop() {
  if(Serial.available() > 0) {
    inByte = Serial.read();

    if (inByte == 'A') {
      digitalWrite(4,HIGH);
      delay(100);
      digitalWrite(4,LOW);
      tone(8, 600, 100);
    }
  
    else if (inByte == 'B') {
      digitalWrite(5,HIGH);
      delay(100);
      digitalWrite(5,LOW);
      tone(8, 200, 100);
    }

    else if (inByte == 'C') {
      switchStateLeft = digitalRead(10);
      switchStateRight = digitalRead(11);
      Serial.write(switchStateLeft);
      Serial.write(switchStateRight);
    }
  }
}
 


