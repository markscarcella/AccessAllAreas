using UnityEngine;
using System.Collections.Generic;

public class Instrument
{
    public Instrument(InstrumentType type)
    {
        InstrumentType = type;

        var clips = Resources.LoadAll<AudioClip>("Sounds/" + type);
        for(Note note = Note.A0; note <= Note.C8; note++)
        {
            int index = (int)note - (int)Note.A0;
            notes[note] = clips[index %= clips.Length];
        }
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

    private Dictionary<Note, AudioClip> notes = new Dictionary<Note, AudioClip>();
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
        Note n = note.Note;
        if(n == Note.Tuned)
        {
            n = (Note)Random.Range((int)Note.A0, (int)Note.C8);
        }
        var clip = notes[n];

        AudioSource audioSource = GameObject.Find("Band").AddComponent<AudioSource>();
        audioSource.volume = note.Velocity / 255f;
        audioSource.clip = clip;
        audioSource.Play();

        //AudioSource source = new AudioSource();
        //source.PlayOneShot(clip, note.Velocity / 255f);
    }

    public void AddMessage(Message message)
    {
        messages.Enqueue(new MessageInfo(message));
    }
}
