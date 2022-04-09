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
    public SkillActiveManager skillActiveManager;

    public List<Button> Go_Back_Btn = new List<Button>();
    public List<Text> SkillInfo_Text = new List<Text>();
    public List<Image> SKillInfo_Image = new List<Image>();
    public Button MiniMapCommingBtn;
    public Text IngameText;
    public Text EnemySkillNameText;

    public Button[] Yes_No_Button = new Button[2];
    bool isMiniMapOn = false;
    public GameObject EventUIPanal;

    public GameObject GameClearPanal;

    public GameObject Current_Attack_Unit;
    public Image Skill_Info_UI;
    public GameObject Player_Targeting;


    public Vector2 anchorPer;
    public float minusPer_Width;
    public float minusPer_Height;
    public Text TestUI;

    public List<GameObject> ScaleReFactoring = new List<GameObject>();

    private void Start()
    {
        
    }




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

    public void CurrentAttack_Move()
    {
        // Current_Attack_Unit.rectTransform.anchoredPosition = skillActiveManager.GetComponent<Image>().rectTransform.anchoredPosition;
        Current_Attack_Unit.transform.position = combatManager.speedComparisonArray[0].transform.position + new Vector3(0, 1.7f, 0);
        Current_Attack_Unit.gameObject.SetActive(true);
        Current_Attack_Unit.GetComponent<DOTweenAnimation>().DORestart();

    }

    public void GameClearPanalDown()
    {
        GameClearPanal.GetComponent<Image>().rectTransform.DOAnchorPos(new Vector2(0, 0), 1f);

    }


}
