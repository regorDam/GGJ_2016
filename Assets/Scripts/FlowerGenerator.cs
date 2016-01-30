using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlowerGenerator : MonoBehaviour
{
    private List<GameObject> generatedFlowers; 
    private float time;

    public int numFlowers;
    public GameObject flowerPrefab;
     
	void Start()
    {
        time = 0.0f;
        generatedFlowers = new List<GameObject>();
        SpawnFlowers();
    }
	
	void Update ()
    {
        time += Time.deltaTime;
	}

    void SpawnFlowers()
    {
        for (int i = 0; i < numFlowers; ++i)
        {
            int x = 0;
            Vector3 extents = GetComponent<BoxCollider>().bounds.extents;
            bool free = true;
            
            GameObject flower = Instantiate(flowerPrefab, Vector3.zero, new Quaternion()) as GameObject;
            do
            {
                Vector3 randomPosition = new Vector3();
                randomPosition.x = Random.Range(-extents.x, extents.x);
                randomPosition.z = Random.Range(-extents.z, extents.z);

                flower.transform.position = randomPosition;

                foreach(GameObject other in generatedFlowers)
                {
                    if(flower.GetComponent<BoxCollider>().bounds.Intersects(other.GetComponent<BoxCollider>().bounds))
                    {
                        free = false;
                        break;
                    }
                }
                ++x;
            }
            while (!free && x < 1000);
            
            if (!free) Destroy(flower);
            else generatedFlowers.Add(flower);
        }
    }
}
