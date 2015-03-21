var file,inst_num,n0=0,n1=0,inst;
file = "savefile.ini"
if file_exists(file) file_delete(file)
ini_open(file)
inst_num=instance_number(objSaver)
while inst_num>0{
    inst=instance_find(objSaver,inst_num-1)
    ini_write_real("save",string(n0)+string(n1),inst.object_index)
    n1+=1
    ini_write_real("save",string(n0)+string(n1),inst.x)
    n1+=1
    ini_write_real("save",string(n0)+string(n1),inst.y)
    inst_num-=1
    n0+=1
    n1=0
    }
ini_close();
if file_exists(file)
    show_message_async("Saved!")   
