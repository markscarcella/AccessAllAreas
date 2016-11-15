using UnityEngine;
using System.Collections;

public class Drum : MonoBehaviour {

	float accelerometerUpdateInterval = 1.0f / 60.0f;
	// The greater the value of LowPassKernelWidthInSeconds, the slower the filtered value will converge towards current input sample (and vice versa).
	float lowPassKernelWidthInSeconds = 1.0f;
	// This next parameter is initialized to 2.0 per Apple's recommendation, or at least according to Brady! ;)
	public float shakeDetectionThreshold = 1.5f;

	private float lowPassFilterFactor;
	private Vector3 lowPassValue;
	private Vector3 acceleration;
	private Vector3 deltaAcceleration;

	bool playNote;

	NetworkManager networkManager;

	void Start()
	{
		networkManager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
		lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
		lowPassValue = Vector3.zero;
		shakeDetectionThreshold *= shakeDetectionThreshold;
		lowPassValue = Input.acceleration;
		playNote = false;
	}

	void Update()
	{
		acceleration = Input.acceleration;
		lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
		deltaAcceleration = acceleration - lowPassValue;

		if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold)
		{
			playNote = true;
		}
		else if (playNote)
		{
			playNote = false;
			byte velocity = (byte)map(deltaAcceleration.sqrMagnitude, shakeDetectionThreshold, 10.0f, 0, 255);
			Message message = new Message(InstrumentType.Drum, Note.Tuned, velocity);
			networkManager.PlayNote(message);
		}
	}

	float map(float s, float a1, float a2, float b1, float b2)
	{
		return b1 + (s-a1)*(b2-b1)/(a2-a1);
	}
}
