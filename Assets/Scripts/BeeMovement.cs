using UnityEngine;
using System.Collections;

public class BeeMovement : MonoBehaviour
{
	public int type;
    public float rotSpeed;
    public float speed;
	public int capacity;
	public int idPlayer;

    private Rigidbody rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
		float inputx = Input.GetAxis("Horizontal" + idPlayer);
		float inputz = Input.GetAxis("Vertical" + idPlayer);
        
        transform.position += new Vector3(inputx, 0.0f, inputz) * speed * Time.deltaTime;

        /*Quaternion rot = Quaternion.Lerp(transform.rotation, 
                                         Quaternion.LookRotation(new Vector3(inputx, 0.0f, inputz), Vector3.up), 
                                         Time.deltaTime * rotSpeed);
        */

        transform.LookAt(transform.position + new Vector3(inputx, 0.0f, inputz));
         
		if (Input.GetButton("Recolect" + idPlayer)) Debug.Log("Recolect" + idPlayer);
    }

	void OnCollisionEnter(Collision col)
	{
        GameObject other = col.gameObject;
        if (other.tag.Equals ("Player") && idPlayer != other.GetComponent<BeeMovement>().idPlayer) 
			if (other.GetComponent<BeeMovement> ().type < type) 
				GetComponent<BeeFall> ().Fall();
	}

	public int GetIdPlayer()
	{
		return idPlayer;
	}
}