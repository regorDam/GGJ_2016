using UnityEngine;
using System.Collections;

public class BeeIdle : MonoBehaviour {

	public GameObject point;
	public float angle;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.RotateAround (point.transform.position,Vector3.up, angle);
	}
}
