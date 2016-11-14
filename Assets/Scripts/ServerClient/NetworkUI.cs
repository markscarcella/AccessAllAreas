using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NetworkUI : MonoBehaviour {

	public string startScene;
	public Text toggleServerClient;
	public Text ipTextBox;
	bool isServer;
	
	// Use this for initialization
	void Start () {
		isServer = true;
		toggleServerClient.text = "Server";
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ToggleClientServer()
	{
		if (isServer)
		{
			isServer = false;
			toggleServerClient.GetComponent<Text>().text = "Client";
		}
		else
		{
			isServer = true;
			toggleServerClient.text = "Server";
		}
	}

	public void Connect()
	{
		//save varaibles
		PlayerPrefs.SetString("IP", ipTextBox.text);
		if (isServer)
		{
			PlayerPrefs.SetString("isServer", "true");
			GetComponent<NetworkManager>().Connect();
			Application.LoadLevel("BasicConnection");
		}
		else
		{
			PlayerPrefs.SetString("isServer", "false");
			GetComponent<NetworkManager>().Connect();
			Application.LoadLevel(startScene);
		}

	}
}
