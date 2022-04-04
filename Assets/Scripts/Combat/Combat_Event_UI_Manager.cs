using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat_Event_UI_Manager : MonoBehaviour
{

    public List<Button> Go_Back_Btn = new List<Button>();

    public void Go_Back_On()
    {
        Go_Back_Btn[0].gameObject.SetActive(true);
        Go_Back_Btn[1].gameObject.SetActive(true);
    }
    public void Go_Back_Off()
    {
        Go_Back_Btn[0].gameObject.SetActive(false);
        Go_Back_Btn[1].gameObject.SetActive(false);
    }
}
