using UnityEngine;
using System.Collections;

public class Flower : MonoBehaviour
{
    public int userid;
    public int polen;
    public float cooldown;

	void Start ()
    {
        userid = Random.Range(0, 4);
	}
	
	void Update ()
    {
        GetComponent<Renderer>().material.color = Game.game.GetUserColor(userid);
    }
}
