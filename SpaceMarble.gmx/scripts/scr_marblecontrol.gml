push_speed=10
jump_height=5
height=32
//global.is_grounded=place_empty(x,y-height)
pushing_left=keyboard_check(ord("A"))
pushing_right=keyboard_check(ord("D"))
direction_pushing=-pushing_left
if (pushing_right)direction_pushing=1

current_direction=-pushing_left
if (pushing_right) current_direction=1
if (global.is_grounded) global.jump_number=0

//if health<100 push_speed*=5
trying_jump=keyboard_check_pressed(ord("W"))
if trying_jump show_debug_message(string(global.jump_number))
    if (direction_pushing!=0 and global.is_grounded){ 
        physics_apply_force(x,y,direction_pushing*push_speed*100,0);
    }
    if(global.jump_number<2 and trying_jump){
        physics_apply_impulse(x,y,0,-jump_height*100);
        global.jump_number+=1
        effect_create_below(ef_smoke,x,y,5,c_gray)
        }
if (current_direction!=0 and keyboard_check(vk_space) and health>99){
physics_apply_impulse(x,y,current_direction*1000,0);
health=0;
}
global.is_grounded=0