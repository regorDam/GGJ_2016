﻿using UnityEngine;
using System.Collections;

public class Honeycomb : MonoBehaviour
{
    [Range(1,4)]
    public int idPlayer = 1;

    public int currentPolen = 0;
    public int maxPolenCapacity = 100;

	void Start ()
    {
	
	}
	
	void Update ()
    {
        float offsety = (1.0f - ((float)currentPolen / maxPolenCapacity)) * 0.5f;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0.0f, offsety);
	}
}
