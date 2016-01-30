using UnityEngine;
using System.Collections;

public class BeeMovement : MonoBehaviour
{
    [Range(1, 4)]
    public int idPlayer = 1;

    [Range(1, 3)]
    public int type = 1;
    public int capacity;

    public float rotSpeed;
    public float speed;
    public float recoverySpeed;
	
    public float timeLeft;

    private bool falling = false;
    private bool recovering = false;
   
    private Vector3 returnPosition;
    private Rigidbody rb;
    private float time;
    private int polen = 0;

    void Start()
    {
        returnPosition = transform.position;
        rb = transform.GetComponent<Rigidbody>();
        time = timeLeft;
    }


    void Update ()
    {
        /*Quaternion rot = Quaternion.Lerp(transform.rotation, 
                                         Quaternion.LookRotation(new Vector3(inputx, 0.0f, inputz), Vector3.up), 
                                         Time.deltaTime * rotSpeed);
        */

        if (falling)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                timeLeft = time;
                falling = false;
                recovering = true;
                rb.useGravity = false;
            }
            Debug.Log(idPlayer + ": " + "Falling");
        }

        if (!falling && !recovering) //Enable input
        {
            Debug.Log(idPlayer + ": " + "Flying");
            float inputx = Input.GetAxis("Horizontal" + idPlayer);
            float inputz = Input.GetAxis("Vertical" + idPlayer);
            rb.velocity = new Vector3(inputx, 0.0f, inputz).normalized * speed;

            if (inputx != 0 || inputz != 0)
                transform.LookAt(transform.position + new Vector3(inputx, 0.0f, inputz));

            if (Input.GetButtonDown("Recolect" + idPlayer))
                Debug.Log("Recolect" + idPlayer);
        }

        if (transform.position.y < returnPosition.y && !falling)
        {
            if(recovering) //Esta subiendo de la caida
            {
                Debug.Log(idPlayer + ": " + "Returning");
                Vector3 moveDir = (returnPosition - transform.position).normalized;
                rb.velocity = moveDir * recoverySpeed * Time.deltaTime;
            }
            else //se ha movido un poco abajo al colisionar con otra abeja, pero no esta cayendo
            {
                rb.velocity += Vector3.up * recoverySpeed * Time.deltaTime;
            }
        }

        if (transform.position.y >= returnPosition.y)
        {
            rb.velocity += new Vector3(0.0f, -rb.velocity.y, 0.0f); //Quitamos velocidad en y
            recovering = false;
        }

        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.material.color = Game.game.GetUserColor(idPlayer);
        }
    }

	void OnCollisionEnter(Collision col)
	{
        GameObject other = col.gameObject;
        if (other.tag.Equals ("Player") && idPlayer != other.GetComponent<BeeMovement>().idPlayer) 
			if (other.GetComponent<BeeMovement> ().type < type) 
				Fall();
	}

	public int GetIdPlayer()
	{
		return idPlayer;
	}

    private void Fall()
    {
        falling = true;
        rb.useGravity = true;
        returnPosition = transform.position;
    }

    public void AddPolen(int polen)
    {
        this.polen += polen;
        if(this.polen > capacity)
        {
            this.polen = capacity;
        }
    }

	public int GetPolen()
	{
		return polen;
	}
}