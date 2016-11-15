using UnityEngine;
using System.Collections;

public class BackingBeat : MonoBehaviour
{
    private BeatCounter beat;
    private Band band;

	void Start()
    {
        beat = GameObject.Find("BeatCounter").GetComponent<BeatCounter>();
        band = GameObject.Find("Band").GetComponent<Band>();
	}
	
	void Update()
    {
	    if(beat.Beat)
        {
            switch(beat.BeatCount % beat.BeatsPerBar)
            {
                case 0:
                    band.AddMessage(new Message(InstrumentType.Drum, Note.Cs4, 128));
                    break;
                default:
                    band.AddMessage(new Message(InstrumentType.Drum, Note.E4, 255));
                    break;
            }
        }
	}
}
