using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Honeycomb : MonoBehaviour
{
    [Range(1,4)]
    public int idPlayer = 1;

    public float triggerRadius = 5.0f;
    public float currentPolen = 0;
    public float maxPolenCapacity = 100;

    public float distanceSpawn = 0.0f;

    public List<GameObject> bees;
	
    void Start()
    {
        foreach(GameObject bee in bees)
        {
            bee.GetComponent<BeeIdle>().enabled = true;
            bee.GetComponent<BeeMovement>().enabled = false;
            bee.GetComponentInChildren<SphereCollider>().enabled = false;
        }
        if(bees.Count > 0)
            SwapBees(bees[0]);
    }

	void Update ()
    {
        if(currentPolen >= maxPolenCapacity)
        {
            Game.game.Win(idPlayer);
        }

        CheckTrigger();
        UpdateTextureOffset();
    }
    
    void SwapBees(GameObject entryBee)
    {
        //Entra una
        entryBee.GetComponent<BeeIdle>().enabled = true;
        entryBee.GetComponent<BeeMovement>().enabled = false;
        entryBee.GetComponentInChildren<SphereCollider>().enabled = false;

        //Sale otra
        int i = entryBee.GetComponent<BeeMovement>().type % 3;
        GameObject newBee = bees[i];
        newBee.GetComponent<BeeIdle>().enabled = false;
        newBee.GetComponent<BeeMovement>().enabled = true;
        newBee.GetComponentInChildren<SphereCollider>().enabled = true;

        newBee.transform.position = transform.position + (Vector3.zero - transform.position).normalized * distanceSpawn;
    }

    void UpdateTextureOffset()
    {
        float offsety = (1.0f - ((float)currentPolen / maxPolenCapacity)) * 0.5f;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0.0f, offsety);
    }

	void CheckTrigger()
	{
        foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (Vector3.Distance(transform.position, player.transform.position) < triggerRadius)
            {
                BeeMovement bee = player.GetComponent<BeeMovement>();
				if (Input.GetButtonDown ("Drop" + bee.GetIdPlayer ())) {
					DepositPolen (bee.GetPolen ());
				} else if (Input.GetButtonDown ("Swap" + bee.GetIdPlayer ())) 
				{
					SwapBees (player);
				}
            }
        }
	}

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }

	public void DepositPolen(int polen)
	{
		currentPolen += polen;
	}
}
