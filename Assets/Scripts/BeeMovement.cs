using UnityEngine;
using System.Collections;

public class BeeMovement : MonoBehaviour
{
    public float rotSpeed;
    public float speed;
    private Rigidbody rb;

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
         
        if (Input.GetButton("Recolect"))
        {
            Debug.Log("Recolect");
        }
    }
}
