using UnityEngine;
using System.Collections;

public class NoteFloatOffPlay : MonoBehaviour {

	private float timeToDestroy = 3.0f;

	private bool isFlying = false;

	private float amtLeft = 0.0f;
	private float amtRight = 0.0f;
	// Use this for initialization
	void Start () 
	{
		amtLeft = Random.Range (0.0f, 1.0f);
		amtRight = Random.Range (0.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isFlying)
		{
			timeToDestroy -= Time.deltaTime;
			transform.position += new Vector3 (amtRight * Time.deltaTime * 1.0f, Time.deltaTime* 1.0f, amtLeft * Time.deltaTime * 1.0f);
			if (timeToDestroy < 0)
			{
				Destroy (this);
			}
		}
	}

	public void StartDeath()
	{
		isFlying = true;
		Debug.Log ("Starting Death");
	}
}
