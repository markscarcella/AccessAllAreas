#pragma strict

var minecraftShots : Texture[];
var TSARShots : Texture[];
var arrowShots : Texture[];
var progShots : Texture[];
var TSARLogo : Texture;
var TSQRLogo : Texture;
var storeLogo : Texture;
var myObjects : GameObject[];

var index : int;
var currentIndex : int;

var Timer : float;
var counterInterface : float;

function Start () 
{
	Timer = 0;
	index = 0;
	currentIndex = 0;
	counterInterface = 0;

}

function OnGUI()
{
	if(index == 0)//TS Logo
	{
		myObjects[0].active = true;
		myObjects[1].active = false;
		myObjects[2].active = false;
		myObjects[3].active = false;
		if(PlayerPrefs.GetInt("Screen")==1)
		{
			GUI.DrawTexture(Rect(0,Screen.height-Screen.width*0.35,Screen.width*0.35,Screen.width*0.35), TSARLogo, ScaleMode.ScaleToFit, true, 0.0f);
			GUI.DrawTexture(Rect(0,Screen.height-Screen.width*0.70,Screen.width*0.35,Screen.width*0.35), storeLogo, ScaleMode.ScaleToFit, true, 0.0f);
		}
		if(PlayerPrefs.GetInt("Screen")==3)
			GUI.DrawTexture(Rect(Screen.width- Screen.width*0.35,Screen.height-Screen.width*0.35,Screen.width*0.35,Screen.width*0.35), TSQRLogo, ScaleMode.ScaleToFit, true, 0.0f);

		
	}
	else if(index == 1)//TSAR
	{
		if(PlayerPrefs.GetInt("Screen")==1)
			GUI.DrawTexture(Rect(0,0+Screen.height*counterInterface,Screen.width,Screen.height), TSARShots[0], ScaleMode.ScaleAndCrop, true, 0.0f);
		else if(PlayerPrefs.GetInt("Screen")==2)
			GUI.DrawTexture(Rect(0,0+Screen.height*counterInterface,Screen.width,Screen.height), TSARShots[1], ScaleMode.ScaleAndCrop, true, 0.0f);
		if(PlayerPrefs.GetInt("Screen")==3)
			GUI.DrawTexture(Rect(0,0+Screen.height*counterInterface,Screen.width,Screen.height), TSARShots[2], ScaleMode.ScaleAndCrop, true, 0.0f);	
		if(counterInterface==0)
		{
			myObjects[0].active = false;
			myObjects[1].active = true;
			myObjects[2].active = false;
			myObjects[3].active = false;
		}
	}
	else if(index == 2)//Dragon
	{
		myObjects[0].active = false;
		myObjects[1].active = true;
		myObjects[2].active = false;
		myObjects[3].active = false;
		if(PlayerPrefs.GetInt("Screen")==1)
		{
			GUI.DrawTexture(Rect(0,Screen.height-Screen.width*0.35,Screen.width*0.35,Screen.width*0.35), TSARLogo, ScaleMode.ScaleToFit, true, 0.0f);
			GUI.DrawTexture(Rect(0,Screen.height-Screen.width*0.70,Screen.width*0.35,Screen.width*0.35), storeLogo, ScaleMode.ScaleToFit, true, 0.0f);
		}		
		if(PlayerPrefs.GetInt("Screen")==3)
			GUI.DrawTexture(Rect(Screen.width- Screen.width*0.35,Screen.height-Screen.width*0.35,Screen.width*0.35,Screen.width*0.35), TSQRLogo, ScaleMode.ScaleToFit, true, 0.0f);
	}
	else if(index == 3)//Minecraft
	{
		if(PlayerPrefs.GetInt("Screen")==1)
			GUI.DrawTexture(Rect(0,0+Screen.height*counterInterface,Screen.width,Screen.height), minecraftShots[0], ScaleMode.ScaleAndCrop, true, 0.0f);
		else if(PlayerPrefs.GetInt("Screen")==2)
			GUI.DrawTexture(Rect(0,0+Screen.height*counterInterface,Screen.width,Screen.height), minecraftShots[1], ScaleMode.ScaleAndCrop, true, 0.0f);
		if(PlayerPrefs.GetInt("Screen")==3)
			GUI.DrawTexture(Rect(0,0+Screen.height*counterInterface,Screen.width,Screen.height), minecraftShots[2], ScaleMode.ScaleAndCrop, true, 0.0f);
		if(counterInterface==0)
		{
			myObjects[0].active = false;
			myObjects[1].active = false;
			myObjects[2].active = true;
			myObjects[3].active = false;
		}
	
	}
	else if(index == 4)//dragon
	{
		myObjects[0].active = false;
		myObjects[1].active = false;
		myObjects[2].active = true;
		myObjects[3].active = false;
		if(PlayerPrefs.GetInt("Screen")==1)
		{
			GUI.DrawTexture(Rect(0,Screen.height-Screen.width*0.35,Screen.width*0.35,Screen.width*0.35), TSARLogo, ScaleMode.ScaleToFit, true, 0.0f);
			GUI.DrawTexture(Rect(0,Screen.height-Screen.width*0.70,Screen.width*0.35,Screen.width*0.35), storeLogo, ScaleMode.ScaleToFit, true, 0.0f);
		}
		if(PlayerPrefs.GetInt("Screen")==3)
			GUI.DrawTexture(Rect(Screen.width- Screen.width*0.35,Screen.height-Screen.width*0.35,Screen.width*0.35,Screen.width*0.35), TSQRLogo, ScaleMode.ScaleToFit, true, 0.0f);
	}
	else if(index == 5)//arrows
	{
		if(PlayerPrefs.GetInt("Screen")==1)
			GUI.DrawTexture(Rect(0,0+Screen.height*counterInterface,Screen.width,Screen.height), arrowShots[0], ScaleMode.ScaleAndCrop, true, 0.0f);
		else if(PlayerPrefs.GetInt("Screen")==2)
			GUI.DrawTexture(Rect(0,0+Screen.height*counterInterface,Screen.width,Screen.height), arrowShots[1], ScaleMode.ScaleAndCrop, true, 0.0f);
		if(PlayerPrefs.GetInt("Screen")==3)
			GUI.DrawTexture(Rect(0,0+Screen.height*counterInterface,Screen.width,Screen.height), arrowShots[2], ScaleMode.ScaleAndCrop, true, 0.0f);
		if(counterInterface==0)
		{
			myObjects[0].active = false;
			myObjects[1].active = false;
			myObjects[2].active = false;
			myObjects[3].active = true;
		}
		
	}
	else if(index == 6)//Train
	{
		myObjects[0].active = false;
		myObjects[1].active = false;
		myObjects[2].active = false;
		myObjects[3].active = true;
		if(PlayerPrefs.GetInt("Screen")==1)
		{
			GUI.DrawTexture(Rect(0,Screen.height-Screen.width*0.35,Screen.width*0.35,Screen.width*0.35), TSARLogo, ScaleMode.ScaleToFit, true, 0.0f);
			GUI.DrawTexture(Rect(0,Screen.height-Screen.width*0.70,Screen.width*0.35,Screen.width*0.35), storeLogo, ScaleMode.ScaleToFit, true, 0.0f);
		}
		if(PlayerPrefs.GetInt("Screen")==3)
			GUI.DrawTexture(Rect(Screen.width- Screen.width*0.35,Screen.height-Screen.width*0.35,Screen.width*0.35,Screen.width*0.35), TSQRLogo, ScaleMode.ScaleToFit, true, 0.0f);
	}
	else if(index == 7)//scratch
	{
		if(PlayerPrefs.GetInt("Screen")==1)
			GUI.DrawTexture(Rect(0,0+Screen.height*counterInterface,Screen.width,Screen.height), progShots[0], ScaleMode.ScaleAndCrop, true, 0.0f);
		else if(PlayerPrefs.GetInt("Screen")==2)
			GUI.DrawTexture(Rect(0,0+Screen.height*counterInterface,Screen.width,Screen.height), progShots[1], ScaleMode.ScaleAndCrop, true, 0.0f);
		if(PlayerPrefs.GetInt("Screen")==3)
			GUI.DrawTexture(Rect(0,0+Screen.height*counterInterface,Screen.width,Screen.height), progShots[2], ScaleMode.ScaleAndCrop, true, 0.0f);
		if(counterInterface==0)
		{
			myObjects[0].active = false;
			myObjects[1].active = false;
			myObjects[2].active = false;
			myObjects[3].active = true;
		}
		
	}
	
}

function Update () 
{
	if(Network.isServer)
	{
		timerUpdate();
	}

}

function timerUpdate()
{
	Timer += Time.deltaTime;
	if(Timer >0 && Timer <1.0)
	{
		counterInterface = 1.0-Timer;
		Debug.Log("Calling ET");
		Debug.Log("Counter: " + Timer + " " +counterInterface);
	}
	else if(Timer >14 && Timer <15)
		counterInterface = 1.0-(15.0-Timer);
	else if (Timer >= 15)
		counterInterface = 1.0;
	else
		counterInterface = 0.0;
	GetComponent.<NetworkView>().RPC("SendInterfaceCounter", RPCMode.Server, counterInterface);
	
	if(Timer > 15)
	{
		Timer = 0;
		currentIndex ++;
		if(currentIndex > 7)
			currentIndex = 0;
		index = currentIndex;
		GetComponent.<NetworkView>().RPC("SendIndex", RPCMode.Server, index);
	}
	
	Debug.Log("Timer: " + Timer + " " +counterInterface);
}


@RPC
function SendIndex(amt : int)
{
	index = amt;
}

@RPC
function SendInterfaceCounter(amt : float)
{
	counterInterface = amt;
}