#pragma strict

private var buttonX : float;
private var buttonY : float;
private var buttonW : float;
private var buttonH : float;

var IP : String = "127.30.0.19";
var port : int = 25001;

var cubeChange : GameObject;

var hideStyle : GUIStyle;
static var hideFlag : boolean = false;

private var connectTimer : float;
private var attempts : int;

function Start() 
{
	buttonX = Screen.width * 0.05;
	buttonY = Screen.width * 0.05;
	buttonW = Screen.width * 0.1;
	buttonH = Screen.width * 0.1;
	connectTimer = 2.0;
	attempts = 0;
	IP = "172.30.0.19";
	port = 25001;	
	hideFlag = true;
	if(PlayerPrefs.GetString("isServer") == "true")
		Network.InitializeServer(32, 25001, !Network.HavePublicAddress());
	else
		Network.Connect(PlayerPrefs.GetString("IP"),port);
		
	//Cursor.visible = false;
	
}

function OnGUI()
{
	if(GUI.Button(Rect(Screen.width - buttonX - buttonW,buttonY,buttonW,buttonH), "Hide",hideStyle))
	{
		hideFlag = !hideFlag;
	}
	if(!hideFlag)
	{
		IP = GUI.TextField (Rect (buttonX * 1.2 + buttonW,buttonY,buttonW,buttonH*0.3), IP, 25);
		if (Network.peerType == NetworkPeerType.Disconnected)
		{
			GUI.Label(Rect(buttonX*2,buttonY,buttonW,buttonH), "Attempt" + attempts);
			if(GUI.Button(Rect(buttonX,buttonY,buttonW,buttonH), "Start Client"))
			{
				Network.Connect(IP,port);
			}
			
			if(GUI.Button(Rect(buttonX,buttonY *1.2 + buttonH,buttonW,buttonH), "Start Server"))
			{
				//Network.incomingPassword = "HolyMoly";    );    
				Network.InitializeServer(32, 25001, !Network.HavePublicAddress());
			}
		
		}
		else
		{
			if (Network.peerType == NetworkPeerType.Client)
			{
				GUI.Label(Rect(buttonX,buttonY,buttonW,buttonH), "Client");
				if(GUI.Button(Rect(buttonX,buttonY *1.2 + buttonH,buttonW,buttonH), "Logout"))
				{
					Network.Disconnect(250);
				}
				if(GUI.Button(Rect(buttonX,buttonY *1.2 + buttonH * 2.0,buttonW,buttonH), "Change Color"))
				{
					GetComponent.<NetworkView>().RPC("AskColor", RPCMode.Server);
				}			
			}
			if (Network.peerType == NetworkPeerType.Server)
			{
				GUI.Label(Rect(buttonX,buttonY,buttonW,buttonH), "Server");
				GUI.Label(Rect(buttonX,buttonY + buttonH *0.5,buttonW,buttonH), "Connections" + Network.connections.Length);
				if(GUI.Button(Rect(buttonX,buttonY *1.2 + buttonH,buttonW,buttonH), "Logout"))
				{
					Network.Disconnect(250);
				}		
			}
		}
	}
}

function Update() 
{	
	if(connectTimer > 0)
		connectTimer -=Time.deltaTime;
	else
	{
		if (Network.peerType == NetworkPeerType.Disconnected)
		{
			if(PlayerPrefs.GetString("isServer") == "true")
				Network.InitializeServer(32, 25001, !Network.HavePublicAddress());
			else
				Network.Connect(PlayerPrefs.GetString("IP"),port);
		} 
		connectTimer = 2.0;
		attempts++;
	}
}


@RPC
function AskColor()
{
	if(Network.isServer)
	{
		GetComponent.<NetworkView>().RPC("ChangeColor",RPCMode.All);
	}
}

@RPC
function ChangeColor()
{
	cubeChange.GetComponent.<Renderer>().material.color = Color.green;
}

@RPC
function PlaySound()
{
	//GetComponent<AudioSource>().Play();
}

function OnServerInitialized()
{
	Debug.Log("Server Initialized");
}