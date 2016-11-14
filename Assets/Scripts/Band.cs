using UnityEngine;
using System;
using System.Linq;

public class Band : MonoBehaviour
{
    private Instrument[] instruments = new Instrument[Enum.GetValues(typeof(InstrumentType)).OfType<InstrumentType>().Cast<int>().Max()];

	public void Start()
    {
	    for(int i = 0; i < instruments.Length; i++)
        {
            instruments[i] = new Instrument((InstrumentType)i);
        }
	}
	
	public void Update()
    {
        var counter = GameObject.Find("BeatCounter").GetComponent<BeatCounter>();
        for(int i = 0; i < instruments.Length; i++)
        {
            instruments[i].Update(counter, TimeSpan.FromMinutes(counter.BeatSync / counter.BeatsPerMinute).TotalSeconds);
        }
	}

    public void AddMessage(string message)
    {
        AddMessage(Message.FromString(message));
    }
    public void AddMessage(Message message)
    {
        instruments[(int)message.Instrument].AddMessage(message);
    }
}
