using UnityEngine;
using System.Collections;

public class ButtonPanelFlower : ButtonPanel
{
    public GameObject flower;

	void Update ()
    {
        maxFillSteps = (int)(flower.GetComponent<Flower>().originalPolen);
        fillSteps = (int)(flower.GetComponent<Flower>().polen);
    }
}
