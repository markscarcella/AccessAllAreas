using UnityEngine;
using System.Collections;

public class TouchTrail : MonoBehaviour {

	BeatCounter beatCounter;

	public int touchIdx;
	public TrailRendererWith2DCollider trailRenderer;

	// Use this for initialization
	void Start () {
		trailRenderer = GetComponent<TrailRendererWith2DCollider>();
		beatCounter = GameObject.Find("BeatCounter").GetComponent<BeatCounter>();
		trailRenderer.lifeTime = (float)beatCounter.BarLength;
	}
	
	// Update is called once per frame
	void Update () {
		if (touchIdx < Input.touchCount)
		//if (Input.GetMouseButtonDown(0))
		{
			Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.touches[touchIdx].position);
			//Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			transform.position = new Vector3(touchPos.x, touchPos.y, 0.0f);
			//trailRenderer.startWidth = Camera.main.WorldToViewportPoint(transform.position).y;
			//trailRenderer.trailMaterial.color = Color.HSVToRGB(Camera.main.WorldToViewportPoint(transform.position).y, 0.5f, 1.0f);
			trailRenderer.trailMaterial.color = new Color(217/255f, 94/255f, 64/255f);
		}	
		else
		{
			touchIdx = 99;
			Destroy(gameObject, 8.0f);
		}
	}
}
