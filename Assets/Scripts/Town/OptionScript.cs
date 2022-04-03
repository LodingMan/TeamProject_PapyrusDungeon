using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionScript : MonoBehaviour
{
    public GameObject optionPanel;
    public bool isOn = false;



    public void OptionPanel_On_Off()
    {
        if (!isOn)
        {
            isOn = true;
            optionPanel.SetActive(true);
        }
        else
        {
            isOn = false;
            optionPanel.SetActive(false);
        }
    }
}
