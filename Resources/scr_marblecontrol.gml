push_speed=5
jump_height=5
is_grounded=place_empty(x,y-1)
pushing_left=keyboard_check(vk_left)
pushing_right=keyboard_check(vk_right)
direction_pushing=-pushing_left
if (pushing_right)direction_pushing=1

current_direction=-pushing_left
if (pushing_right) current_direction=1

trying_jump=keyboard_check(vk_up)
if (is_grounded){
    if (!trying_jump){ 
        physics_apply_force(x,y,direction_pushing*push_speed*100,0);
        
        }
    else if(!place_empty(x,y+1) and trying_jump){
        physics_apply_impulse(x,y,0,-jump_height*100);
        }
    }
if (current_direction!=0 and keyboard_check(vk_down) and health>99){
physics_apply_impulse(x,y,current_direction*1000,0);
health=0;
}
