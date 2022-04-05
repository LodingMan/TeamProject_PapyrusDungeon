using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Combat_Event_UI_Manager : MonoBehaviour
{
    public e_CombatManager combatManager;
    public InGame_Player_Script inGame_Player_Script;
    public CombatCameraControll combatCameraControll;

    public List<Button> Go_Back_Btn = new List<Button>();
    public Button MiniMapCommingBtn;
    public Text IngameText;

    public Button[] Yes_No_Button = new Button[2];
    bool isMiniMapOn = false;
    public GameObject EventUIPanal;



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

    public void MinimapGuide()
    {
        if(!combatManager.isCombat)
        {
            if(inGame_Player_Script.isRoom)
            {
                IngameText.rectTransform.anchoredPosition = new Vector2(-44, 316);
                IngameText.text = "다른 지역으로 이동을 위해 미니맵을 눌러주세요";
            }

        }
    }

    public void BattleStart()
    {
        IngameText.rectTransform.anchoredPosition = new Vector2(0, 316);
        IngameText.text = "전투 시작!";
    }


    public void TextClear()
    {
        IngameText.text = "";
    }

}
