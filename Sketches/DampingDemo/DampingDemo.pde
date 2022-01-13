//damping demo
//asymptotic easing
//exponential slide

// 3 circles' x positions:
float x1, x2, x3;

//circle #2's velocity;
float v2;

void setup(){
 size(500, 500, P2D); 
  
}

void draw(){
  background(128);
  
  if(x1 < mouseX) x1= x1+ (mouseX - x1)/25;
  else x1 = x1 - (x1 - mouseX)/25;
  
  // physics to move circle two
  
  if(x2 < mouseX) v2 ++;
  else v2 --;
  
  v2*= .99;
  
  x2 += v2; //euler integration
  
  // use damping:
  //each tick move 50% to target...whoops I already did this while playing with circle one
  
  //x3 += (mouseX - x3)/10;
  
  x3 = lerp(x3, mouseX, .1);
  
  //draw circles
  ellipse(x1, height/4, 25, 25);
  ellipse(x2, height/2, 25, 25);
  ellipse(x3, height*3/4, 25, 25);
  
  
}
