using UnityEngine;
using System.Collections;

public class Honeycomb : MonoBehaviour
{
    [Range(1,4)]
    public int idPlayer = 1;

    public float triggerRadius = 5.0f;
    public float currentPolen = 0;
    public float maxPolenCapacity = 100;

	void Start ()
    {
	    
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
                if (Input.GetButtonDown("Drop" + bee.GetIdPlayer()))
                {
                    DepositPolen(bee.GetPolen());
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
