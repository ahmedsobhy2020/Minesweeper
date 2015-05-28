
// encoder var --------
int avenc = 0; 
int y =1;
int x =1;
int encoderPin1 = 2;
int encoderPin2 = 3;
volatile long encoderValue1 = 0;
volatile long encoderValue = 0;
 float count1 = 0 ;
 float count = 0;

//---------------------

int pw = 127;


//---------------------
int dir=25;
int dir1=24;
int dir2=22;
int dir3=23;
int pwm=4;
int pwm1=5 ;
int pwm2=7;
int pwm3=6 ;
int v = 0;
//---------------------



//---------------------

// metal var ----------

long pulseCount = 0;   
unsigned long pulseTime,lastTime;
double power, elapsedkWh;
int ppwh = 1; //1000 pulses/kwh = 1 pulse per wh

//---------------------

void setup()
{
  Serial.begin(115200);

  // encoder var
  pinMode(encoderPin1, INPUT); 
  pinMode(encoderPin2, INPUT);
  digitalWrite(encoderPin1, HIGH); //turn pullup resistor on
  digitalWrite(encoderPin2, HIGH); //turn pullup resistor on
  attachInterrupt(0, updateEncoder, CHANGE); 
  attachInterrupt(1, updateEncoder1, CHANGE);
  //---------------------

  // metal var ----------


  //---------------------


  //--------------
  
pinMode(dir,OUTPUT);
pinMode(pwm,OUTPUT);
pinMode(dir1,OUTPUT);
pinMode(pwm1,OUTPUT);
pinMode(dir2,OUTPUT);
pinMode(pwm2,OUTPUT);
pinMode(dir3,OUTPUT);
pinMode(pwm3,OUTPUT);

  //-----------------

}



void loop()
{

  //-----------------------
  loop ;

  v = Serial.read();
  if (v =='w'){
    digitalWrite(dir,LOW);
    digitalWrite(dir1,LOW);
    digitalWrite(dir2,HIGH);
    digitalWrite(dir3,HIGH);
      
    analogWrite(pwm,pw);
   analogWrite(pwm1,pw);
    analogWrite(pwm2,pw);
    analogWrite(pwm3,pw);

  }
  else if (v =='s'){
  
    digitalWrite(dir,HIGH);
    digitalWrite(dir1,HIGH);
    digitalWrite(dir2,LOW);
    digitalWrite(dir3,LOW);
    
    analogWrite(pwm,pw);
    analogWrite(pwm1,pw);
    analogWrite(pwm2,pw);
    analogWrite(pwm3,pw);
  }

    else if (v =='d') {
    digitalWrite(dir,LOW);
    digitalWrite(dir1,LOW);
    digitalWrite(dir2,LOW);
    digitalWrite(dir3,LOW);
    
    analogWrite(pwm,pw);
    analogWrite(pwm1,pw);
    analogWrite(pwm2,pw);
    analogWrite(pwm3,pw);
  }
  
  
  else if (v =='a'){
    digitalWrite(dir,HIGH);
    digitalWrite(dir1,HIGH);
    digitalWrite(dir2,HIGH);
    digitalWrite(dir3,HIGH);
    
    analogWrite(pwm,pw);
    analogWrite(pwm1,pw);
    analogWrite(pwm2,pw);
    analogWrite(pwm3,pw);
    
  }
  
 else if (v =='p'){
    analogWrite(pwm,0);
    analogWrite(pwm1,0);
    analogWrite(pwm2,0);
    analogWrite(pwm3,0);
  }

 else if (v =='n'){
   pw = 70;
  }
   else if (v =='m'){
   pw = 127;
  }
   else if (v =='k'){
   pw = 190;
  }
   else if (v =='l'){
   pw = 255;
  }
  else if (v =='r'){
  
  attachInterrupt(0, updateEncoder, CHANGE); 
  attachInterrupt(1, updateEncoder1, CHANGE);
    
  }
    else if (v =='t'){
  
  detachInterrupt(0);
  detachInterrupt(1);
    
  }
  else if (v =='z'){
    Serial.print("C"); 
      Serial.print("0");
       delay(100);
     }
  else if (v =='y'){
  
      Serial.print("C"); 
      Serial.print("1");
       delay(100);
      Serial.print("A"); 
      Serial.print(avenc);  //Serial.print(encoderValue); 
       delay(100);
      Serial.print("D");
      Serial.print(y);  
       delay(100);
      Serial.print("E");
      Serial.print(x); 
      delay(100); 
    
  }
   else if (v =='u'){
  
      Serial.print("C"); 
      Serial.print("3");
       delay(100);
      Serial.print("A"); 
      Serial.print(avenc);  //Serial.print(encoderValue); 
       delay(100);
      Serial.print("D");
      Serial.print(y);  
       delay(100);
      Serial.print("E");
      Serial.print(x); 
      delay(100); 
    
  }
  
  avenc = (count+count1)/2;
  if (avenc >= 2450)
   {
    y++;
    avenc=0;
    count1=0;
    count=0;
    //encoderValue=0;
   if (y >= 20)
    {
      x++;
      y=0;
    }
    }
  

  }
  //---------------------


// encoder functions -----

void updateEncoder(){
  int MSB = digitalRead(encoderPin1); //MSB = most significant bit
  if(MSB==1){ 
    encoderValue ++; 
    count ++ ;
            }


}
void updateEncoder1(){
  int MSB1 = digitalRead(encoderPin2); //MSB = most significant bit

   if(MSB1==1){ 
    encoderValue1 ++; 
    count1 ++ ;
}
}


