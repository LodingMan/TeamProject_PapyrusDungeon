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
        Debug.Log("��� �ɹ��� HP�� ������!");
        combat_Event_UI_Manager.EventText.text = "�뺴�� �Ѹ��� ��ٴ��� �û糳�� ��������" +
            " ������� �߰����� �����մϴ�.\n\n" + combatManager.myParty[rndHero_Index].name + "�� HP�� 10 �����մϴ�";

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

        combat_Event_UI_Manager.EventText.text = "�뺴�� �Ѹ��� ���� ��⸦ ã�ҽ��ϴ�." +
           "�뺴�� �߰��� ������ �绡�� �Ծȿ� ���ֽܳ��ϴ�.\n\n" + combatManager.myParty[rndHero_Index].name + "�� HP�� 10 �����մϴ�";

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

        combat_Event_UI_Manager.EventText.text = "�뺴�� ��ġ�� ������ �κη��� �ֽ��ϴ�." +
           "������ ������� ���ø��ϴ�.\n\n" + combatManager.myParty[rndHero_Index].name + "�� AGI�� 3 �����մϴ�";

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
        Debug.Log("�ƹ��ϵ� �Ͼ�� ����");
    //    combat_Event_UI_Manager.EventUIPanal.SetActive(false);
        combat_Event_UI_Manager.EventUIPanal.GetComponent<Image>().rectTransform.DOAnchorPos(new Vector2(0, -360), 1);


        combat_Event_UI_Manager.Go_Back_On();
    }


}
