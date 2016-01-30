using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class ButtonPanel : MonoBehaviour {

    [HideInInspector]
    public string buttonName;

    [HideInInspector]
    public GameObject attachTo;

    public Color buttonFillColor;
    public int maxFillSteps;
    private int fillSteps = 0;

    void Start ()
    {
        transform.FindChild("ButtonFill").GetComponent<Image>().color = buttonFillColor;
    }
	
	void Update ()
    {
        GetComponent<RectTransform>().anchoredPosition =
            Camera.main.WorldToScreenPoint(attachTo.transform.position);

        if (Input.GetButtonDown(buttonName))
        {
            ++fillSteps;
            GetComponent<Animator>().SetTrigger("Pressed");
            transform.FindChild("ButtonFill").GetComponent<Image>().fillAmount = ((float)fillSteps) / maxFillSteps;
        }

        if (fillSteps >= maxFillSteps)
        {
            DestroySelf();
        }
	}

    public void OnAttachToWentOutOfTrigger() //Called when the attachTo(normally the player), went out of the trigger, this must be destroyed
    {
        DestroySelf();
    }

    private void DestroySelf()
    {
        attachTo.SendMessage("OnCurrentButtonPanelDestroyed");
        Destroy(this);
    }
}
