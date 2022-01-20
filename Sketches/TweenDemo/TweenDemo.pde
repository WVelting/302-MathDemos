

float xStart = 20;
float xEnd = 780;


float timeCurrent = 0;
float timeTotal = 3;

void setup(){
 size(800, 500); 
}

void draw(){
 background(64); 
 
 timeCurrent = millis()/1000.0;
  
 float p = timeCurrent/timeTotal;

 p = constrain(p, 0, 1);
 
 float x = lerp(xStart, xEnd, p);
 
 ellipse(x, height/2, 30, 30);
}

void mousePressed(){
  timeCurrent = 0;
  
  
}
