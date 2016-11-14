#pragma strict

public var myStyle : GUIStyle;
public var myHeadingStyle : GUIStyle;
public var hideStyle : GUIStyle;

public var startScene : String;

private var isServer : boolean;
private var ip : String;


function Start () 
{

	hideStyle.normal.textColor.a = 0.0;
	myStyle.fontSize = Screen.height * 0.03;
	myHeadingStyle.fontSize = Screen.height * 0.06;
	
	//variables
	if(PlayerPrefs.HasKey("isServer"))
	{
		if(PlayerPrefs.GetString("isServer") == "true")
			isServer = true;
		else
			isServer = false;
	}
	else
		isServer = true;
		
	if(PlayerPrefs.HasKey("IP"))
		ip = PlayerPrefs.GetString("IP");
	else	
		ip = "172.29.0.19";

}

function Update () 
{
	
	
}

function OnGUI()
{
	GUI.Label(Rect(0,0,Screen.width,Screen.height*0.4),"" + "Thinkspace Media",myHeadingStyle);
	//GUI.Label(Rect(0,0,Screen.height *0.1,Screen.height *0.1),"" + Mathf.Round(countDown).ToString());
	if(GUI.Button(Rect(Screen.height *0.025,Screen.height *0.225,Screen.height *0.1,Screen.height *0.05), "Client/Server"))
		isServer = !isServer;
	if(isServer)
		GUI.Label(Rect(Screen.height *0.15,Screen.height *0.225,Screen.height *0.1,Screen.height *0.05), "Server",myStyle);	
	else
		GUI.Label(Rect(Screen.height *0.15,Screen.height *0.225,Screen.height *0.1,Screen.height *0.05), "Client",myStyle);	
			
	
	GUI.Label(Rect(Screen.height *0.025,Screen.height *0.325,Screen.height *0.1,Screen.height *0.05),"IP: ", myStyle);
	ip = GUI.TextField (Rect (Screen.height *0.125,Screen.height *0.325,Screen.height *0.2,Screen.height *0.05), ip, 25,myStyle);	

		
	if(GUI.Button(Rect(Screen.width - Screen.height *0.1,Screen.height *0.9,Screen.height *0.1,Screen.height *0.1), "Start"))
	{
		//save varaibles
		PlayerPrefs.SetString("IP", ip);
		if(isServer)
		{
			PlayerPrefs.SetString("isServer", "true");
			Application.LoadLevel("BasicConnection");
			}
		else
		{
			PlayerPrefs.SetString("isServer", "false");
			Application.LoadLevel(startScene);
			}
	}



}