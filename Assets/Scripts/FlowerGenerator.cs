using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlowerGenerator : MonoBehaviour
{
    private List<GameObject> generatedFlowers;
    private float time;

    public int numFlowers;
    public GameObject flowerPrefab;
    public GameObject floor;
	public int retry = 100;

    void Start()
    {
        time = 0.0f;
        generatedFlowers = new List<GameObject>();
        SpawnFlowers();
    }

    void Update()
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
                randomPosition.y = floor.transform.position.y + floor.GetComponent<Renderer>().bounds.extents.y;
                randomPosition.z = Random.Range(-extents.z, extents.z);

				flower.transform.position = randomPosition + transform.position;
				flower.transform.rotation = Quaternion.AngleAxis(Random.Range(0,360),Vector3.up);

                foreach (GameObject other in generatedFlowers)
                {
                    if (flower.GetComponentInChildren<Renderer>().bounds.Intersects(other.GetComponentInChildren<Renderer>().bounds))
                    {
                        free = false;
                        break;
                    }
                }
                ++x;
            }
            while (!free && x < retry);

            if (!free) Destroy(flower);
            else generatedFlowers.Add(flower);
        }
    }

    public float[] GetFlowerPlayerIdProbabilities()
    {
        float totalPolen = 0.0f;
        float[] probPlayers = new float[4];
        foreach (GameObject nestObj in GameObject.FindGameObjectsWithTag("HoneyComb"))
        {
            totalPolen = Mathf.Max(nestObj.GetComponent<Honeycomb>().currentPolen, totalPolen);
        }
        
        foreach (GameObject nestObj in GameObject.FindGameObjectsWithTag("HoneyComb"))
        {
            int playerId = nestObj.GetComponent<Honeycomb>().idPlayer;
            Debug.Log(playerId + ": " + nestObj.GetComponent<Honeycomb>().currentPolen);
            probPlayers[playerId-1] = (totalPolen - (nestObj.GetComponent<Honeycomb>().currentPolen)) / totalPolen;
        }
        return probPlayers;
    }
}