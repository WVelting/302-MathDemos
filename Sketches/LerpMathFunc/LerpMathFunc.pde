void setup(){
   size(500,500);
}

void draw(){
   background(128);
   
   float d = mapAgainstTheMachine(mouseX, 0, width, 10, 400) ;
   ellipse(width/2, height/2, d, d);
}

float lerpAgainstTheMachine(float min, float max, float p){
  //what is the math??
  return (max - min) * p + min; //range times percent added to min 
}

float mapAgainstTheMachine(float val, float inMin, float inMax, float outMin, float outMax){
  
  // 1. figure out the p
  float p = (val - inMin)/(inMax - inMin);
  //2. lerp using the p
  
  
  return lerpAgainstTheMachine(outMin, outMax, p);
  
}
