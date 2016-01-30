using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class ButtonPanel : MonoBehaviour {

    [HideInInspector]
    public string buttonName;

    [HideInInspector]
    public GameObject player;

    [HideInInspector]
    public IButtonPanelHoneyProvider honeyProvider;

    [HideInInspector]
    public Color buttonFillColor;

    [HideInInspector]
    public float maxFillSteps;

    [HideInInspector]
    public float fillSteps = 0;

    void Start ()
    {
    }
	
	void Update ()
    {
        maxFillSteps = honeyProvider.GetMaxPanelButtonSteps();
        fillSteps = maxFillSteps - honeyProvider.GetCurrentPanelButtonSteps();

        transform.FindChild("ButtonFill").GetComponent<Image>().color = Game.game.GetUserColor(player.GetComponent<BeeMovement>().GetIdPlayer());

        if (fillSteps < maxFillSteps)
        {
            GetComponent<RectTransform>().anchoredPosition =
                                        Camera.main.WorldToScreenPoint(player.transform.position);

            if (Input.GetButtonDown(buttonName))
            {
                GetComponent<Animator>().SetTrigger("Pressed");
                transform.FindChild("ButtonFill").GetComponent<Image>().fillAmount = fillSteps / maxFillSteps;
            }
            if (fillSteps >= maxFillSteps) DestroySelf();
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
