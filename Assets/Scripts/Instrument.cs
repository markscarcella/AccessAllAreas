using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public class Instrument
{
    public Instrument(InstrumentType type)
    {
        InstrumentType = type;
    }

    private struct MessageInfo
    {
        public MessageInfo(Message message)
        {
            TimeStamp = Time.time;
            Note = message.Note;
            Velocity = message.Velocity;
        }

        public float TimeStamp;
        public Note Note;
        public byte Velocity;
    }

    private AudioSource[] notes = new AudioSource[Enum.GetValues(typeof(Note)).OfType<Note>().Cast<int>().Max()];
    private Queue<MessageInfo> messages = new Queue<MessageInfo>();

    public bool Quantise = true;
    public InstrumentType InstrumentType;
    
	public void Update(BeatCounter counter, double beatThreshold)
    {
        while(messages.Count > 0)
        {
            var m = messages.Peek();
            if(Quantise)
            {
                if(counter.Beat && m.TimeStamp <= counter.LastBeatTime)
                {
                    if(counter.LastBeatTime - m.TimeStamp < beatThreshold)
                    {
                        PlayNote(m);
                    }
                    messages.Dequeue();
                }
                else if(m.TimeStamp > counter.LastBeatTime)
                {
                    if(m.TimeStamp - counter.LastBeatTime < beatThreshold)
                    {
                        PlayNote(m);
                    }
                    messages.Dequeue();
                }
                else
                {
                    break;
                }
            }
            else
            {
                PlayNote(m);
                messages.Dequeue();
            }
        }
	}

    private void PlayNote(MessageInfo note)
    {
        Debug.Log(note);
    }

    public void AddMessage(Message message)
    {
        messages.Enqueue(new MessageInfo(message));
    }
}
