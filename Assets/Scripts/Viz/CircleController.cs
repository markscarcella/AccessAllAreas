using UnityEngine;
using System.Collections;

public class CircleController : MonoBehaviour {

	// Use this for initialization

	private SpriteRenderer mySpriteRender;

	void Start () {
		//Destroy(this, 2.0f);
		mySpriteRender = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		ShrinkCircle ();
		MakeTransparent ();
	}

	void ShrinkCircle()
	{
		transform.localScale -= new Vector3 (Time.deltaTime * 0.2f, Time.deltaTime * 0.2f, Time.deltaTime * 0.2f);

		if (transform.localScale.x < 0.0)
		{
			Destroy (gameObject);
		}
	}

	void MakeTransparent()
	{

		mySpriteRender.material.color = new Color(mySpriteRender.material.color.r,mySpriteRender.material.color.g,mySpriteRender.material.color.b,mySpriteRender.material.color.a - Time.deltaTime * 0.2f);
	}
}
