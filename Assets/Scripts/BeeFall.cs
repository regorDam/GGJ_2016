using UnityEngine;
using System.Collections;

public class BeeFall : MonoBehaviour 
{
	public float timeLeft;
	public float speed = 1;
	float time;
	Vector3 pos;
	Rigidbody rigidbody;
	bool returnPos;

	// Use this for initialization
	void Start () 
	{
		pos = transform.position;
		rigidbody = transform.GetComponent<Rigidbody> ();
		time = timeLeft;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!rigidbody.isKinematic) 
		{
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0) {
				//transform.position = pos;
				Kinematic();
				timeLeft = time;
				returnPos = true;
			}
		}
		else if (returnPos && transform.position.y < pos.y) 
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, pos, step);
		}
			

	}

	void Kinematic()
	{
		rigidbody.isKinematic = !rigidbody.isKinematic;
	}
}
