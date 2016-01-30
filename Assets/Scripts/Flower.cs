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

    private bool blossomed;
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
        float[] probs = GameObject.Find("FlowerGenerator").GetComponent<FlowerGenerator>().GetFlowerPlayerIdProbabilities();
        float probTotal = 0.0f; foreach(float f in probs) probTotal += f;

        Debug.Log("probs: " + probs[0] + ", " + probs[1] + ", " + probs[2] + ", " + probs[3]);
        float p = Random.Range(0.0f, probTotal);
        if (p <= probs[0])      idPlayer = 1;
        else if (p <= probs[1]) idPlayer = 2;
        else if (p <= probs[2]) idPlayer = 3;
        else if (p <= probs[3]) idPlayer = 4;

        Debug.Log("idPlayer: " + idPlayer);

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
