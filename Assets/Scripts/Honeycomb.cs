using UnityEngine;
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
        if(currentPolen >= maxPolenCapacity)
        {
            Game.game.Win(idPlayer);
        }

        UpdateTextureOffset();
    }

    void UpdateTextureOffset()
    {
        float offsety = (1.0f - ((float)currentPolen / maxPolenCapacity)) * 0.5f;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0.0f, offsety);
    }

	void OnTriggerStay(Collider col)
	{
		if (col.transform.parent != null)
		{
			if (col.transform.parent.gameObject.tag.Equals("Player"))
			{
				BeeMovement bee = col.transform.parent.gameObject.GetComponent<BeeMovement>();
				Debug.Log(bee.GetIdPlayer());
				if (Input.GetButtonDown("Drop"+bee.GetIdPlayer()))
				{
					DepositPolen(bee.GetPolen());
				}

			}
		}
	}


	public void DepositPolen(int polen)
	{
		currentPolen += polen;
	}
}
