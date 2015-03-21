push_speed=5
jump_height=5
is_grounded=place_empty(x,y-1)

if (is_grounded){
    if (argument1==0){ 
        physics_apply_force(x,y,argument0*push_speed*100,0);
        current_direction=argument0;
        }
    else if(!place_empty(x,y+1)){
        physics_apply_impulse(x,y,0,argument1*jump_height*100);
        }
    }

     
