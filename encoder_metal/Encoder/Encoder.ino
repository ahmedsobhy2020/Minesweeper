
int encoderPin1 = 2;
int encoderPin2 = 3;

volatile long encoderValue = 0;
volatile long encoderValue1 = 0;

float rev = 0;
float count = 0 ;
float rev1 = 0;
float count1 = 0 ;


void setup() {
  Serial.begin (115200);

  pinMode(encoderPin1, INPUT); 
  pinMode(encoderPin2, INPUT); 
  digitalWrite(encoderPin1, HIGH); 
  digitalWrite(encoderPin2, HIGH);
  attachInterrupt(0, updateEncoder, CHANGE); 
 attachInterrupt(1, Encoder, CHANGE);
}

void loop(){ 
 
rev= (count/2000.0);
   
  Serial.println(encoderValue);
  Serial.println(encoderValue1);
  delay(1000); //just here to slow down the output, and show it will work  even during a delay
}


void updateEncoder(){
  int MSB = digitalRead(encoderPin1); //MSB = most significant bit
  if(MSB==1){ encoderValue ++; count ++ ;}
 
 
}

void Encoder(){
  int MSB1 = digitalRead(encoderPin2); //MSB = most significant bit
  if(MSB1==1) { encoderValue1 ++; count1 ++; }
 
}
