
// encoder var --------
int avenc = 0; 
int y =1;
int x =1;
int encoderPin1 = 18;
int encoderPin2 = 19;
int encoderPin3 = 20;
int encoderPin4 = 21;
volatile long encoderValue = 0;
volatile long encoderValue1 = 0;
volatile long encoderValue2 = 0;
volatile long encoderValue3 = 0;
 float count = 0;
 float count1 = 0;
 float count2 = 0;
 float count3 = 0;
int atachpin = 2;
int dtachpin = 3;
int atach = 0;
int dtach = 0;
//---------------------




// metal var ----------
int metalpin = A0 ;
int metalvalue = 0 ;


//---------------------



void setup()
{
  Serial.begin(115200);

  // encoder var
  pinMode(12, OUTPUT); 
  pinMode(encoderPin1, INPUT); 
  pinMode(encoderPin2, INPUT);
  pinMode(encoderPin3, INPUT); 
  pinMode(encoderPin4, INPUT);
  digitalWrite(encoderPin1, HIGH); //turn pullup resistor on
  digitalWrite(encoderPin2, HIGH); //turn pullup resistor on
  digitalWrite(encoderPin3, HIGH); //turn pullup resistor on
  digitalWrite(encoderPin4, HIGH); //turn pullup resistor on
  attachInterrupt(5, updateEncoder, CHANGE); 
  attachInterrupt(4, updateEncoder1, CHANGE);
  attachInterrupt(3, updateEncoder2, CHANGE); 
  attachInterrupt(2, updateEncoder3, CHANGE);
  //---------------------

  // metal var ----------


  //---------------------


}



void loop()
{
metalvalue = analogRead(metalpin);
atach = digitalRead(atachpin);
dtach = digitalRead(dtachpin);
int countf =  count + count1 ;
int countb = count2 + count3 ;
avenc = (countf + countb)/4;


 
  if (avenc >= 2353)
   {
    y++;
    avenc=0;
    count=0;
    count1=0;
    count2=0;
    count3=0;
  
    
    //encoderValue=0;
   if (y >= 21)
    {
      x++;
      y=1;
    }
    }
 
  
  if (atach == 1){
  
  attachInterrupt(5, updateEncoder, CHANGE); 
  attachInterrupt(4, updateEncoder1, CHANGE);
  attachInterrupt(3, updateEncoder2, CHANGE); 
  attachInterrupt(2, updateEncoder3, CHANGE);
    
  }
    else if (dtach == 1){
  
  detachInterrupt(5);
  detachInterrupt(4);
  detachInterrupt(3);
  detachInterrupt(2);
    
  }
  else if (metalvalue >400){
digitalWrite(12,HIGH) ;
delay(1000);
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
} else if (metalvalue <150){
    digitalWrite(12,LOW) ;
     Serial.print("C"); 
      Serial.print("0");
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
  
  else {
  digitalWrite(12,LOW) ;
  }
   /* else if (v =='z'){
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
    
  }*/

   // Serial.println(avenc);
  //  Serial.println(count1);
   // Serial.println(countb);
   // Serial.println(count2);
//Serial.println(count3);
  // Serial.println(x);
  //  Serial.println(y);
// delay(500);
  //Serial.print(encoderValue); 
  

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
void updateEncoder2(){
  int MSB2 = digitalRead(encoderPin3); //MSB = most significant bit
  if(MSB2==1){ 
    encoderValue2 ++; 
    count2 ++ ;
            }


}

void updateEncoder3(){
  int MSB3 = digitalRead(encoderPin4); //MSB = most significant bit
  if(MSB3==1){ 
    encoderValue3 ++; 
    count3 ++ ;
            }


}


