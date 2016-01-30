using UnityEngine;
using System.Collections;

public class Flower : MonoBehaviour
{
    public int polen;
    public float cooldown;

	void Start ()
    {
        GetComponent<Renderer>().material.color = Color.blue;
	}
	
	void Update ()
    {
	    
	}
}
