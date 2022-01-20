// Animate 3 electrons orbiting around a nucleus.
// Each electron should follow a path and match
// colors with its respective path.

// Don't use rotate()
// Use vectors and trigonometry

float angle = atan2(0,150);
float mag = sqrt(150*150 + 0);

void setup(){
  size(400, 400);
  
}
void draw(){
  
  drawBackground();
  
  
  ///////////////// START YOUR CODE HERE:
  noStroke();
  
  
  //(x,y) coordinate of a typical ellipse
  float redX = mag * cos(angle);
  float redY = mag * sin(angle);
  
  //(x,y) coordinates of ellipse rotated at an angle of 2PI/3
  float greenX = 150*cos(angle)*cos(2*PI/3) - 50*sin(angle)*sin(2*PI/3);
  float greenY = 150*cos(angle)*sin(2*PI/3) + 50*sin(angle)*cos(2*PI/3);
  
  //(x,y) coordinates of ellipse rotated at an angle of 4PI/3
  float blueX = 150 * cos(angle) * cos(4*PI/3) - 50 * sin(angle) * sin(4*PI/3);
  float blueY = 150 * cos(angle) * sin(4*PI/3) + 50 * sin(angle) * cos(4*PI/3);
  
  pushMatrix();
  translate(200,200);
  fill(255,100,100);
  ellipse(redX,redY/3,20,20);
  fill(100,255,100);
  ellipse(greenX,greenY,20,20);
  fill(100,100,255);
  ellipse(blueX,blueY,20,20);
  
  angle+=.01;
  
  popMatrix();
  
  

  
  ///////////////// END YOUR CODE HERE
  
}
void drawBackground(){
  background(0);
  noStroke();
  fill(255);
  ellipse(200,200,50,50);
  noFill();
  strokeWeight(5);
  
  pushMatrix();
  translate(200,200);
  stroke(255,100,100);
  ellipse(0,0,300,100);
  popMatrix();
  
  pushMatrix();
  translate(200,200);
  rotate(PI/1.5);
  stroke(100,255,100);
  ellipse(0,0,300,100);
  popMatrix();
  
  pushMatrix();
  translate(200,200);
  rotate(2*PI/1.5);
  stroke(100,100,255);
  ellipse(0,0,300,100);
  popMatrix();
}
