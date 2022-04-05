using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Passage_Event : MonoBehaviour
{
    public Combat_Event_UI_Manager combat_Event_UI_Manager;


    public void Passage_HpDown_Event()
    {
        combat_Event_UI_Manager.Yes_No_Button[0].onClick.AddListener(Party_Hp_Down);
        combat_Event_UI_Manager.Yes_No_Button[1].onClick.AddListener(None_Event);
    }
    public void Party_Hp_Down()
    {
        Debug.Log("모든 맴버의 HP가 감소함!");
    }










    public void None_Event()
    {
        Debug.Log("아무일도 일어나지 않음");
    }


}
