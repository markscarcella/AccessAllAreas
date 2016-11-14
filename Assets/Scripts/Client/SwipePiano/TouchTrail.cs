using UnityEngine;
using System.Collections;

public class TouchTrail : MonoBehaviour {

	BeatCounter beatCounter;

	public int touchIdx;
	public TrailRenderer trailRenderer;

	// Use this for initialization
	void Start () {
		trailRenderer = GetComponent<TrailRenderer>();
		beatCounter = GameObject.Find("BeatCounter").GetComponent<BeatCounter>();
		trailRenderer.time = (float)beatCounter.BarLength;
	}
	
	// Update is called once per frame
	void Update () {
		if (touchIdx < Input.touchCount)
		{
			Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.touches[touchIdx].position);
			transform.position = new Vector3(touchPos.x, touchPos.y, 0.0f);
			//trailRenderer.startWidth = Camera.main.WorldToViewportPoint(transform.position).y;
			trailRenderer.material.color = Color.HSVToRGB(Camera.main.WorldToViewportPoint(transform.position).y, 0.5f, 1.0f);
		}	
		else
		{
			touchIdx = 99;
			//Destroy(gameObject, .0f);
		}
	}
}
