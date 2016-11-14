#pragma strict
var rotationSpeed : float = 100.0;
var rotation1 : Quaternion;

function Awake () 
{
	rotationSpeed = 1.0;
}

function Update () 
{

	if(Network.isServer)
	{
		var rotation : float = Input.GetAxis ("Horizontal") * rotationSpeed;
		//transform.Rotate (0, rotation, 0);
		transform.RotateAround (Vector3(0,0,5.3), Vector3.up, 10 * Time.deltaTime);
		if(rotation != 0)
		{
			rotation1 = gameObject.transform.rotation;
			GetComponent.<NetworkView>().RPC("SendMovement", RPCMode.OthersBuffered,  rotation1);
		}
	}
	
}

@RPC
function SendMovement( rotation1 : Quaternion)
{
    gameObject.transform.rotation = rotation1;
}