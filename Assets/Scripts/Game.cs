using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

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

    public void Win(int idPlayer)
    {
        Debug.Log("Player " + idPlayer + " has won!");
        SceneManager.LoadScene("WinMenu");
    }
}
