using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonsCanvasManager : MonoBehaviour
{
    public GameObject buttonPanelFlowerPrefab;
    public GameObject buttonPanelHoneycombPrefab;

    void Start ()
    {
	    
	}
	
	void Update ()
    {
	
	}

    public GameObject CreateButtonPanelFlower(string key, string buttonName, GameObject player, GameObject flower)
    {
        GameObject bp = Instantiate(buttonPanelFlowerPrefab,
                                    Vector3.zero,
                                    new Quaternion()) as GameObject;

        Text panelText = bp.GetComponentInChildren<Text>();
        panelText.text = key;

        bp.transform.parent = transform;
        bp.GetComponent<ButtonPanel>().buttonName = buttonName;
        bp.GetComponent<ButtonPanel>().player = player;
        return bp;
    }

    public GameObject CreateButtonPanelHoneycomb(string key, string buttonName, GameObject player, GameObject honeycomb)
    {
        GameObject bp = Instantiate(buttonPanelHoneycombPrefab,
                                    Vector3.zero,
                                    new Quaternion()) as GameObject;

        Text panelText = bp.GetComponentInChildren<Text>();
        panelText.text = key;

        bp.transform.parent = transform;
        bp.GetComponent<ButtonPanel>().buttonName = buttonName;
        bp.GetComponent<ButtonPanel>().player = player;
        return bp;
    }
}
