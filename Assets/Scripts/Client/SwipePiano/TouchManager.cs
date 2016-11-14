using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour {

	public GameObject touchTrail;

	int crntTouchCount;

	// Use this for initialization
	void Start () {
		crntTouchCount = Input.touchCount;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > crntTouchCount)
		{
			for (int i = crntTouchCount; i < Input.touchCount; i++)
			{
				GameObject clone = Instantiate(touchTrail) as GameObject;
				clone.GetComponent<TouchTrail>().touchIdx = i;
			}
		}
		crntTouchCount = Input.touchCount;
	}
}
