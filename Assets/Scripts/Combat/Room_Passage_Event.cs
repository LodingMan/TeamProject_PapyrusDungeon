using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Room_Passage_Event : MonoBehaviour
{
    public Combat_Event_UI_Manager combat_Event_UI_Manager;
    public e_CombatManager combatManager;



    public void Passage_HpDown_Event()
    {
        int rndHero_Index = Random.Range(0, combatManager.myParty.Count);
        // combat_Event_UI_Manager.EventUIPanal.SetActive(true);
        combat_Event_UI_Manager.EventUIPanal.GetComponent<Image>().rectTransform.DOAnchorPos(new Vector2(0, 360), 1);
        Debug.Log("모든 맴버의 HP가 감소함!");
        combat_Event_UI_Manager.EventText.text = "용병중 한명이 길바닥을 꼴사납게 구르지만" +
            " 동료들은 발걸음을 재촉합니다.\n\n" + combatManager.myParty[rndHero_Index].name + "의 HP가 10 감소합니다";

        combatManager.myParty[rndHero_Index].GetComponent<StatScript>().myStat.HP -= 10;
        if (combatManager.myParty[rndHero_Index].GetComponent<StatScript>().myStat.HP <= 0)
        {
            combatManager.myParty[rndHero_Index].GetComponent<StatScript>().myStat.HP = 1;
        }
        combatManager.BarUpdate();


        combat_Event_UI_Manager.Yes_No_Button[0].onClick.AddListener(EventPanel_Up);
    }

    public void Passage_HpUp_Event()
    {
        int rndHero_Index = Random.Range(0, combatManager.myParty.Count);
        combat_Event_UI_Manager.EventUIPanal.GetComponent<Image>().rectTransform.DOAnchorPos(new Vector2(0, 360), 1);

        combat_Event_UI_Manager.EventText.text = "용병중 한명이 말린 고기를 찾았습니다." +
           "용병은 발견한 음식을 재빨리 입안에 구겨넣습니다.\n\n" + combatManager.myParty[rndHero_Index].name + "의 HP가 10 증가합니다";

        combatManager.myParty[rndHero_Index].GetComponent<StatScript>().myStat.HP += 10;
        if (combatManager.myParty[rndHero_Index].GetComponent<StatScript>().myStat.HP > combatManager.myParty[rndHero_Index].GetComponent<StatScript>().myStat.MAXHP)
        {
            combatManager.myParty[rndHero_Index].GetComponent<StatScript>().myStat.HP = combatManager.myParty[rndHero_Index].GetComponent<StatScript>().myStat.MAXHP;
        }
        combatManager.BarUpdate();


        combat_Event_UI_Manager.Yes_No_Button[0].onClick.AddListener(EventPanel_Up);
    }

    public void Passage_AgiUp_Event()
    {
        int rndHero_Index = Random.Range(0, combatManager.myParty.Count);
        combat_Event_UI_Manager.EventUIPanal.GetComponent<Image>().rectTransform.DOAnchorPos(new Vector2(0, 360), 1);

        combat_Event_UI_Manager.EventText.text = "용병의 발치에 인형이 널부러져 있습니다." +
           "영웅은 어린시절을 떠올립니다.\n\n" + combatManager.myParty[rndHero_Index].name + "의 AGI가 3 증가합니다";

        combatManager.myParty[rndHero_Index].GetComponent<StatScript>().myStat.Agi += 3;
        combatManager.BarUpdate();


        combat_Event_UI_Manager.Yes_No_Button[0].onClick.AddListener(EventPanel_Up);
    }






    public void EventPanel_Up()
    {
   
       // combat_Event_UI_Manager.EventUIPanal.SetActive(false);
        combat_Event_UI_Manager.EventUIPanal.GetComponent<Image>().rectTransform.DOAnchorPos(new Vector2(0, -360), 1);



        combat_Event_UI_Manager.Go_Back_On(); 
    }











    public void None_Event()
    {
        Debug.Log("아무일도 일어나지 않음");
    //    combat_Event_UI_Manager.EventUIPanal.SetActive(false);
        combat_Event_UI_Manager.EventUIPanal.GetComponent<Image>().rectTransform.DOAnchorPos(new Vector2(0, -360), 1);


        combat_Event_UI_Manager.Go_Back_On();
    }


}
