using UnityEngine;
using System.Collections;

public class Flower : MonoBehaviour, IButtonPanelHoneyProvider
{
    [Range(1, 4)]
    public int idPlayer = 1;

    [HideInInspector]
    public float originalPolen;
    public float polen;
    public float cooldown;

    public bool blossomed;
    public float blossomSpeed;
    public Vector3 minScale;

    private GameObject playerOver = null;

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
        if(time > cooldown && !blossomed)
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

        if (playerOver != null)
        {
            BeeMovement bee = playerOver.GetComponent<BeeMovement>();
            if (!bee.falling && !bee.recovering && Input.GetButtonDown("Recolect" + bee.GetIdPlayer()))
            {
                BeeMovement bee = col.transform.parent.gameObject.GetComponent<BeeMovement>();
                //Debug.Log(bee.GetIdPlayer());
                if (Input.GetButtonDown("Recolect"+bee.GetIdPlayer()))
                {
                    Recollect(bee);
                    UnBlossom();
                }
 
                Recollect(bee);
                if (polen <= 0) UnBlossom();
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.parent != null && col.transform.parent.gameObject.tag.Equals("Player"))
            playerOver = col.transform.parent.gameObject;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.transform.parent != null && col.transform.parent.gameObject.tag.Equals("Player") && playerOver == col.transform.parent.gameObject)
            playerOver = null;
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

    float IButtonPanelHoneyProvider.GetCurrentPanelButtonSteps()
    {
        return polen;
    }

    float IButtonPanelHoneyProvider.GetMaxPanelButtonSteps()
    {
        return originalPolen;
    }
}
