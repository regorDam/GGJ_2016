using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class ButtonPanel : MonoBehaviour {

    [HideInInspector]
    public string buttonName;

    [HideInInspector]
    public GameObject player;

    [HideInInspector]
    public Color buttonFillColor;

    [HideInInspector]
    public int maxFillSteps;

    [HideInInspector]
    public int fillSteps = 0;

    void Start ()
    {
    }
	
	void Update ()
    {
        transform.FindChild("ButtonFill").GetComponent<Image>().color = Game.game.GetUserColor(player.GetComponent<BeeMovement>().GetIdPlayer());
        if (fillSteps < maxFillSteps)
        {
            GetComponent<RectTransform>().anchoredPosition =
            Camera.main.WorldToScreenPoint(player.transform.position);

            if (Input.GetButtonDown(buttonName))
            {
                ++fillSteps;
                GetComponent<Animator>().SetTrigger("Pressed");
                transform.FindChild("ButtonFill").GetComponent<Image>().fillAmount = ((float)fillSteps) / maxFillSteps;
                Debug.Log(((float)fillSteps) / maxFillSteps);
            }
            
            if (fillSteps >= maxFillSteps)
            {
                DestroySelf();
            }
        }
	}

    public void OnAttachToWentOutOfTrigger() //Called when the attachTo(normally the player), went out of the trigger, this must be destroyed
    {
        DestroySelf();
    }

    private void DestroySelf()
    {
        player.SendMessage("OnCurrentButtonPanelDestroyed");
        Destroy(gameObject);
    }
}
