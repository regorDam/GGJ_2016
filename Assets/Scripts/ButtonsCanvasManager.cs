using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonsCanvasManager : MonoBehaviour
{
    public GameObject buttonPanelFlowerPrefab;
    public GameObject buttonPanelHoneycombPrefab;

    public GameObject CreateButtonPanel(string key, string buttonName, GameObject player, IButtonPanelHoneyProvider honeyProvider)
    {
        GameObject bp = Instantiate(buttonPanelFlowerPrefab,
                                    Vector3.zero,
                                    new Quaternion()) as GameObject;

        Text panelText = bp.GetComponentInChildren<Text>();
        panelText.text = key;

        bp.transform.parent = transform;
        bp.GetComponent<ButtonPanel>().honeyProvider = honeyProvider;
        bp.GetComponent<ButtonPanel>().buttonName = buttonName;
        bp.GetComponent<ButtonPanel>().player = player;
        return bp;
    }
}
