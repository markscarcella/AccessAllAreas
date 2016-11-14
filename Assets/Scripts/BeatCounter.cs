using UnityEngine;
using System;

public class BeatCounter : MonoBehaviour
{
    public int BeatsPerBar = 4;
    public int BeatsPerMinute = 60;
    public float BeatSync = 0.25f;

    public int BeatCount;
    public double BeatProgress;
    public int BarCount;
    public double BarProgress;

    public bool Beat;

    public double LastBeatTime;
    public double NextBeatTime;

    public double BarLength
    {
        get
        {
            return BeatsPerBar * TimeSpan.FromMinutes(1.0 / BeatsPerMinute).TotalSeconds;
        }
    }

    public void Start()
    {
        BeatCount = 0;
        LastBeatTime = Time.time;
        NextBeatTime = LastBeatTime + TimeSpan.FromMinutes(1.0 / BeatsPerMinute).TotalSeconds;
	}
	
	public void Update()
    {
        Beat = Time.time > NextBeatTime;
        if(Beat)
        {
            BeatCount++;
            LastBeatTime = NextBeatTime;
            NextBeatTime += TimeSpan.FromMinutes(1.0 / BeatsPerMinute).TotalSeconds;
        }
        BeatProgress = (Time.time - LastBeatTime) / TimeSpan.FromMinutes(1.0 / BeatsPerMinute).TotalSeconds;

        BarCount = BeatCount / BeatsPerBar;
        BarProgress = (BeatCount % BeatsPerBar + BeatProgress) / BeatsPerBar;
    }
}
