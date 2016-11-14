#pragma strict

private var buttonX : float;
private var buttonY : float;
private var buttonW : float;
private var buttonH : float;

private var numberString : String = "38";

function Start() 
{
	buttonX = Screen.width * 0.05;
	buttonY = Screen.width * 0.05;
	buttonW = Screen.width * 0.1;
	buttonH = Screen.width * 0.1;
	PlayerPrefs.SetInt("Screen",2);
	
}

function OnGUI()
{
	
	numberString = PlayerPrefs.GetString("Offset");
	if(parseInt(numberString)<0)
		PlayerPrefs.SetInt("Screen",1);
	else if(parseInt(numberString)>0)
		PlayerPrefs.SetInt("Screen",3);
	
}

function Update () 
{
 	if(Network.isClient)
 	{
 		transform.localEulerAngles = Vector3(0,parseInt(numberString),0);
	}
}