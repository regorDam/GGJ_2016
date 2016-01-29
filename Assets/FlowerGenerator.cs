using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlowerGenerator : MonoBehaviour
{
    private List<GameObject> generatedFlowers; 
    private float time;

    public float flowerPeriode;
    public GameObject flowerPrefab;
     
	void Start()
    {
        time = 0.0f;
	}
	
	void Update ()
    {
        time += Time.deltaTime;
        if (time >= flowerPeriode)
        {
            time = 0.0f;
            SpawnFlower();
        }
	}

    void SpawnFlower()
    {
        Vector3 extents = GetComponent<BoxCollider>().bounds.extents;
        bool colliding = false;
        GameObject flower;

        do
        {
            Vector3 randomPosition = new Vector3();
            randomPosition.x = Random.Range(-extents.x, extents.x);
            randomPosition.z = Random.Range(-extents.z, extents.z);

            flower = Instantiate(flowerPrefab, randomPosition, new Quaternion()) as GameObject;

            foreach(GameObject other in generatedFlowers)
            {
                if(flower.GetComponent<BoxCollider>().bounds.Intersects(other.GetComponent<BoxCollider>().bounds))
                {
                    colliding = true;
                    break;
                }
            }

        }
        while (colliding);

        generatedFlowers.Add(flower);
    }
}
