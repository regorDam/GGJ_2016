using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
    public static Game game;
    public List<Color> userColors;

	void Start ()
    {
	    game = this;
	}
	
	void Update ()
    {
	
	}

    public Color GetUserColor(int userid)
    {
        return userColors[userid];
    }
}
