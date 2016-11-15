using UnityEngine;
using System.Collections;

public class BarProgress : MonoBehaviour {

	public NetworkManager networkManager;
	BeatCounter beatCounter;

	float height;
	float startX;

	Note[] scale = {Note.C4, Note.D4, Note.E4, Note.F4, Note.G4, Note.A4, Note.B4, Note.C5};

	// Use this for initialization
	void Start () {
		networkManager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();

		beatCounter = GameObject.Find("BeatCounter").GetComponent<BeatCounter>();
		beatCounter.Start();

		height = Camera.main.orthographicSize * 2.0f;
		startX = Camera.main.orthographicSize * Screen.width / Screen.height;
		transform.localScale = new Vector2(transform.localScale.x, height);
		transform.position = new Vector2(-startX, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2(Mathf.Lerp(-startX, startX, (float)beatCounter.BarProgress), 0.0f);
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		if (beatCounter.Beat)
		{
			foreach (var contact in coll.contacts)
			{
				int note = (int)Camera.main.WorldToScreenPoint(contact.point).y * 8 / Screen.height;
				Message message = new Message(InstrumentType.Drum, scale[note], 128);
				Debug.Log(message.ToString());
				networkManager.GetComponent<NetworkView>().RPC("PlayNote", RPCMode.Server, message.ToString());
//				#if UNITY_ANDROID||UNITY_IOS
//				Handheld.Vibrate();
//				#endif
			}
		}
	}
}
