void setup(){
 size(800, 500); 
 stroke(150, 0, 255);
}

void draw(){
 background(64);
 
 float time = millis()/1000.0;
 
 
 float t = sin(time*20) * 9 + 11;
 strokeWeight(t);
 
 ellipse(width/2, height/2, 400, 400);
}
