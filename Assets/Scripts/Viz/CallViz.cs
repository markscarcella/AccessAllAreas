using UnityEngine;
using System.Collections;

public class CallViz : MonoBehaviour {

	public string type = "circles";

	private float timeToNote = 0.5f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		RandomNoteGenerator ();
	}

	void RandomNoteGenerator()
	{
		timeToNote -= Time.deltaTime;

		if (timeToNote < 0.0f)
		{
			AddNote (Random.Range (0, 10), Random.Range (0, 100), Random.Range (0, 255));
			if (Random.Range (0, 10) < 5)
			{
				AddNote (Random.Range (0, 10), Random.Range (0, 100), Random.Range (0, 255));
				if (Random.Range (0, 10) < 5)
				{
					AddNote (Random.Range (0, 10), Random.Range (0, 100), Random.Range (0, 255));
				}
			}
			timeToNote = Random.Range (0.0f, 1.0f);
		}
	}

	public void AddNote(int instrument, int note, int velocity)
	{
		if (type == "circles")
		{

			GetComponent<VizCircles> ().VizNote (instrument, note, velocity);
		}
	}
}
