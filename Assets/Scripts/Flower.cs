using UnityEngine;
using System.Collections;

public class Flower : MonoBehaviour
{
    [Range(1, 4)]
    public int idPlayer = 1;

    [HideInInspector]
    public float originalPolen;
    public float polen;
    public float cooldown;

    private bool blossomed;
    public float blossomSpeed;
    public Vector3 minScale;

    private float time;

	void Start ()
    {
        originalPolen = polen;
        UnBlossom();
        idPlayer = Random.Range(1, 5);
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
                if (!bee.falling && !bee.recovering && Input.GetButtonDown("Recolect" + bee.GetIdPlayer()))
                {

                    Recollect(bee);
                    if(polen <= 0) UnBlossom();
                }
 
            }
        }
    }

    void Recollect(BeeMovement bee)
    {
        if (bee.idPlayer == idPlayer) polen -= 0.5f;
        else polen -= 1;
        bee.AddPolen(1);
    }

    void Blossom()
    {
        polen = originalPolen; 
        blossomed = true;
    }

    void UnBlossom()
    {
        blossomed = false;
        time = 0.0f;
    }
}
