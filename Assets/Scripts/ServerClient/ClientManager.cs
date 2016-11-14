using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClientManager : MonoBehaviour {

	public Text debugOnScreen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayNoteVelocity(Message message)
	{
		// send note and velocity to server
		debugOnScreen.text = message.ToString();
	}
}
