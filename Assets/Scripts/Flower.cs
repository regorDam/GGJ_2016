using UnityEngine;
using System.Collections;

public class Flower : MonoBehaviour
{
    [Range(1, 4)]
    public int idPlayer = 1;

    public int polen;
    public float cooldown;

    private bool blossomed;
    public float blossomSpeed;
    public Vector3 minScale;

    private float time;

	void Start ()
    {
        UnBlossom();
        idPlayer = Random.Range(0, 4);
        cooldown = Random.Range(2.0f, 7.0f);
	}
	
	void Update ()
    {
        time += Time.deltaTime;
        if(time > cooldown)
        {
            Blossom();
        }

        if(blossomed && transform.localScale.x < 1.0f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, Time.deltaTime * blossomSpeed); //Grow
        }
        else if(!blossomed)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, minScale, Time.deltaTime * blossomSpeed); //Shrink
        }

        GetComponentInChildren<Renderer>().material.color = Game.game.GetUserColor(idPlayer);
    }

    void OnTriggerStay(Collider col)
    {
        if (col.transform.parent != null)
        {
            if (col.transform.parent.gameObject.tag.Equals("Player"))
            {
                BeeMovement bee = col.transform.parent.gameObject.GetComponent<BeeMovement>();
                Debug.Log(bee.GetIdPlayer());
                if (Input.GetButtonDown("Recolect"+bee.GetIdPlayer()))
                {
                    Recollect(bee);
                    UnBlossom();
                }
 
            }
        }
    }

    void Recollect(BeeMovement bee)
    {
        bee.AddPolen(polen);
        if (bee.idPlayer == idPlayer)
        {
            bee.AddPolen(polen);
        }
    }

    void Blossom()
    {
        blossomed = true;
    }

    void UnBlossom()
    {
        blossomed = false;
        time = 0.0f;
    }
}
