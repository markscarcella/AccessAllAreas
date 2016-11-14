using UnityEngine;
using System.Collections;

public class ContollerKinect : MonoBehaviour {


	public Transform leftHand; 
	public Transform rightHand;
	public Transform head; 
	public Transform hip;
	public Transform leftFoot;
	public Transform rightFoot;

	public GameObject[] notes;

	public GameObject noteRightHand;
	public GameObject noteLeftHand;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (leftHand != null)
		{
			CheckLeftHand ();

		} 
		else if(noteLeftHand != null)
		{
			noteLeftHand.GetComponent<NoteFloatOffPlay> ().StartDeath ();
			noteLeftHand = null;
		}
		if (rightHand != null)
		{
			CheckRightHand ();

		} 
		else if(noteRightHand != null)
		{
			noteRightHand.GetComponent<NoteFloatOffPlay> ().StartDeath ();
			noteRightHand = null;
		}

	}

	void CheckLeftHand()
	{
		if (leftHand.position.y < hip.position.y && noteLeftHand == null)
		{
			noteLeftHand = Instantiate (notes [Random.Range(0,3)], leftHand.position, Quaternion.identity) as GameObject;
		}

		if (leftHand.position.y > head.position.y && noteLeftHand != null)
		{
			noteLeftHand.GetComponent<NoteFloatOffPlay> ().StartDeath ();
			noteLeftHand = null;
		}

		if (noteLeftHand != null)
		{
			noteLeftHand.transform.position = leftHand.position;
		}
	}

	void CheckRightHand()
	{
		if (rightHand.position.y < hip.position.y && noteRightHand == null)
		{
			noteRightHand = Instantiate (notes [Random.Range(0,3)], rightHand.position, Quaternion.identity) as GameObject;

		}

		if (rightHand.position.y > head.position.y && noteRightHand != null)
		{
			noteRightHand.GetComponent<NoteFloatOffPlay> ().StartDeath ();
			noteRightHand = null;
		}

		if (noteRightHand != null)
		{
			noteRightHand.transform.position = rightHand.position;
		}
	}
}
