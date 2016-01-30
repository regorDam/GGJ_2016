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
   
    private Vector3 pos;
    private Rigidbody rb;
    private float time;
    private int polen = 0;

    void Start()
    {
        pos = transform.position;
        rb = transform.GetComponent<Rigidbody>();
        time = timeLeft;
    }


    void Update ()
    {
        /*Quaternion rot = Quaternion.Lerp(transform.rotation, 
                                         Quaternion.LookRotation(new Vector3(inputx, 0.0f, inputz), Vector3.up), 
                                         Time.deltaTime * rotSpeed);
        */

        if (rb.useGravity)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                timeLeft = time;
                rb.useGravity = false;
            }
        }
        else if (transform.position.y < pos.y)
        {
            Vector3 moveDir = (pos - transform.position).normalized;
            rb.velocity = moveDir * recoverySpeed * Time.deltaTime;
        }
        else
        {
            float inputx = Input.GetAxis("Horizontal" + idPlayer);
            float inputz = Input.GetAxis("Vertical" + idPlayer);
            rb.velocity = new Vector3(inputx, 0.0f, inputz).normalized * speed;

            if (inputx != 0 || inputz != 0)
            {
                transform.LookAt(transform.position + new Vector3(inputx, 0.0f, inputz));
            }


            if (Input.GetButton("Recolect" + idPlayer)) Debug.Log("Recolect" + idPlayer);
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
        rb.useGravity = true;
    }

    public void AddPolen(int polen)
    {
        this.polen += polen;
        if(this.polen > capacity)
        {
            this.polen = capacity;
        }

        Debug.Log("polen : "+this.polen);
    }
}