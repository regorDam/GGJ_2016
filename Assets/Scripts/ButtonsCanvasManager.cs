using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonsCanvasManager : MonoBehaviour
{
    public GameObject buttonPanelPrefab;

	void Start ()
    {
	    
	}
	
	void Update ()
    {
	
	}

    public GameObject CreateButtonPanel(string key, string buttonName, GameObject attachTo, int fillSteps)
    {
        GameObject bp = Instantiate(buttonPanelPrefab,
                                    Vector3.zero,
                                    new Quaternion()) as GameObject;

        Text panelText = bp.GetComponentInChildren<Text>();
        panelText.text = key;

        bp.transform.parent = transform;
        bp.GetComponent<ButtonPanel>().buttonName = buttonName;
        bp.GetComponent<ButtonPanel>().attachTo = attachTo; 
        return bp;
    }
}
