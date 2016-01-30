using UnityEngine;
using System.Collections;

public class BeeMovement : MonoBehaviour
{
	public int type;
    public float rotSpeed;
    public float speed;
	public int capacity;
    private Rigidbody rb;
	private int idPlayer;
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        float inputx = Input.GetAxis("Horizontal");
        float inputz = Input.GetAxis("Vertical");
        
        transform.position += new Vector3(inputx, 0.0f, inputz) * speed * Time.deltaTime;

        /*Quaternion rot = Quaternion.Lerp(transform.rotation, 
                                         Quaternion.LookRotation(new Vector3(inputx, 0.0f, inputz), Vector3.up), 
                                         Time.deltaTime * rotSpeed);
        */

        transform.LookAt(transform.position + new Vector3(inputx, 0.0f, inputz));
         
		if (Input.GetButton("Recolect")) Debug.Log("Recolect");
    }

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag.Equals ("Player")) 
			if (col.gameObject.GetComponent<BeeMovement> ().type < type) 
				GetComponent<BeeFall> ().Fall ();
	}

	public int GetIdPlayer()
	{
		return idPlayer;
	}
}