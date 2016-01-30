using UnityEngine;
using System.Collections;

public class BeeIdle : MonoBehaviour
{
    private static float time = 0.0f;

    public GameObject point;

    public float offsetHeight;
    public float offset;
    public float rotSpeed;
    public float radius;

    private Vector3 lastPos;

	void Start ()
    {
        lastPos = transform.position;
    }
	
	void Update ()
    {
        GetComponentInChildren<Renderer>().material.SetColor("_UserColor", Game.game.GetUserColor(GetComponent<BeeMovement>().idPlayer));

        time += Time.deltaTime;
        lastPos = transform.position;
        Vector3 nextPos = point.transform.position +
                          new Vector3(Mathf.Sin(time * rotSpeed + offset) * radius, offsetHeight, -Mathf.Cos(time * rotSpeed + offset) * radius);
        transform.position = nextPos;
        transform.LookAt(nextPos + (nextPos - lastPos));
    }
}
