var flySpeed:float = 0.5;
var shift : boolean;
var ctrl : boolean;
var accelerationAmount : float = 3;
var accelerationRatio : float = 1;
var slowDownRatio : float = 0.5;
function Start(){
	Screen.lockCursor=true;
}
function Update()
{
	transform.Rotate(Vector3.up*Input.GetAxis("Mouse X"),Space.World);
	transform.Rotate(Vector3.right*Input.GetAxis("Mouse Y"),Space.World);
    if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
    {
        shift = true;
        flySpeed *= accelerationRatio;
    }
   
    if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
    {
        shift = false;
        flySpeed /= accelerationRatio;
    }
    if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
    {
        ctrl = true;
        flySpeed *= slowDownRatio;
    }
    if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
    {
        ctrl = false;
        flySpeed /= slowDownRatio;
    }
    if (Input.GetAxis("Vertical") != 0)
    {
        transform.Translate(-transform.forward * flySpeed * Input.GetAxis("Vertical"));
    }
    if (Input.GetAxis("Horizontal") != 0)
    {
        transform.Translate(-transform.right * flySpeed * Input.GetAxis("Horizontal"));
    }
    if (Input.GetKey(KeyCode.E))
    {
        transform.Translate(transform.up * flySpeed*0.5f);
    }
    else if (Input.GetKey(KeyCode.Q))
    {
        transform.Translate(-transform.up * flySpeed*0.5f);
    }
}