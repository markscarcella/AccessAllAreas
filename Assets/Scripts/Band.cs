using UnityEngine;
using System;
using System.Collections.Generic;

public class Band : MonoBehaviour
{
    private Dictionary<InstrumentType, Instrument> instruments = new Dictionary<InstrumentType, Instrument>();

	void Start()
    {
        foreach(InstrumentType instrument in Enum.GetValues(typeof(InstrumentType)))
        {
            instruments[instrument] = new Instrument(instrument);
        }
    }
	
	void Update()
    {
        var counter = GameObject.Find("BeatCounter").GetComponent<BeatCounter>();
        foreach(var item in instruments.Values)
        {
            item.Update(counter, TimeSpan.FromMinutes(counter.BeatSync / counter.BeatsPerMinute).TotalSeconds);
        }
	}

    public void AddMessage(string message)
    {
        AddMessage(Message.FromString(message));
    }
    public void AddMessage(Message message)
    {
        instruments[message.Instrument].AddMessage(message);
    }
}
