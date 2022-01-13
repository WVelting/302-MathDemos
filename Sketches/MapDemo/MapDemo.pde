void setup(){
  size(500,500);
}

void draw(){
  background(128);
  
  //float p = mouseX/(float) width;
  //float radians = lerp(0,PI,p); //angle in Radians
  float radians = map(mouseX, 0, width, 0, PI); //angle in Radians
  
  pushMatrix();
  translate(width/2, height/2);
  rotate(radians);
  rect(-200, -200, 400, 400);
  popMatrix();
  
}
