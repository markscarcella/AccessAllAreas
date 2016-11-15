using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeyboardInstrument : MonoBehaviour {

	Note[] scale = {Note.C4, Note.D4, Note.E4, Note.F4, Note.G4, Note.A4, Note.B4, Note.C5, Note.D5};
	NetworkManager networkManager;
	int selectedButton = 0;
	public Button[] buttons;

	void Awake()
	{
		for (int i=0; i<9; i++)
		{
			buttons[i].image.color = new Color(56/255f, 89/255f, 118/255f);
		}
		buttons[selectedButton].image.color = new Color(247/255f, 147/255f, 30/255f);
	}

	// Use this for initialization
	void Start () {
		networkManager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			buttons[selectedButton].image.color = new Color(56/255f, 89/255f, 118/255f);
			selectedButton += 1;
			if (selectedButton > buttons.Length - 1)
			{
				selectedButton = 0;
			}
			buttons[selectedButton].image.color = new Color(247/255f, 147/255f, 30/255f);
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			ButtonNote(selectedButton);
		}
	}

	public void ButtonNote(int note)
	{
		Message message = new Message(InstrumentType.Piano, scale[note], 255);
		networkManager.PlayNote(message);
	}
}
