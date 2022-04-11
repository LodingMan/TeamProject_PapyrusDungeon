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
    public ShopManager shopManager;
    public ShopEquipScripts shopEquipScripts;
    public Shin.EquipDetailTable equipDetailTable;
    public List<Button> Go_Back_Btn = new List<Button>();

    public Button MiniMapCommingBtn;
    public Text IngameText;
    public Text EnemySkillNameText;

    public Button[] Yes_No_Button = new Button[2];
    bool isMiniMapOn = false;
    public GameObject EventUIPanal;

    public GameObject GameClearPanal;
    public List<Text> PartyMemberNameList = new List<Text>();
    public GameObject ClearReward_Create_Point;
    public GameObject GameClearReward_Equip_Image;
    public List<GameObject> ImageSaveList = new List<GameObject>();




    public GameObject Current_Attack_Unit;

    public Image Skill_Info_UI;
    public List<Text> SkillInfo_Text = new List<Text>(); // 0 이름 2 ATK 3 DEF
    public List<Image> SKillInfo_Image = new List<Image>();

    public GameObject Player_Targeting;


    public Vector2 anchorPer;
    public float minusPer_Width;
    public float minusPer_Height;
    public Text TestUI;

    public List<GameObject> ScaleReFactoring = new List<GameObject>();
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
        StatScript CurrentHeroStat;
        GameClearPanal.GetComponent<Image>().rectTransform.DOAnchorPos(new Vector2(0, 0), 1f);

        for(int i = 0; i < combatManager.myParty.Count; i++)
        {
            CurrentHeroStat = combatManager.myParty[i].GetComponent<StatScript>();
            PartyMemberNameList[i].text = CurrentHeroStat.myStat.Name + "  " + CurrentHeroStat.PreviousLv + "  -> " + CurrentHeroStat.myStat.Lv;
        }


        for(int i = 0; i < combatManager.DungeonDifficulty; i++)
        {
            int RndIdx = Random.Range(1, shopManager.equipList.Count);
            GameObject CurrentCreateImgae;
            GameObject InvantoryCreatePrefab;

            CurrentCreateImgae = Instantiate(GameClearReward_Equip_Image);
            CurrentCreateImgae.GetComponent<Image>().sprite = equipDetailTable.sprite[RndIdx]; // shopManager.equipList[RndIdx].transform.GetChild(1).GetComponent<Image>().sprite;
            CurrentCreateImgae.gameObject.transform.SetParent(ClearReward_Create_Point.transform);
            ImageSaveList.Add(CurrentCreateImgae);


            InvantoryCreatePrefab = Instantiate(shopManager.equipList[RndIdx]);
            shopManager.hasEquipList.Add(InvantoryCreatePrefab);
            InvantoryCreatePrefab.transform.SetParent(shopManager.inventory.transform);
            InvantoryCreatePrefab.transform.localPosition = shopManager.inventory.transform.localPosition;


            InvantoryCreatePrefab.transform.localScale = new Vector3(1, 1, 1);
        }
    }
    public void GameClearPanalUp()
    {
        for (int i = 0; i < combatManager.myParty.Count; i++)
        {
            PartyMemberNameList[i].text = "";
        }

        for(int i = ImageSaveList.Count-1; i >= 0; i--)
        {
            ImageSaveList.RemoveAt(i);
            //Destroy(ImageSaveList[i]);
        }
        GameClearPanal.GetComponent<Image>().rectTransform.DOAnchorPos(new Vector2(0, 1090), 1f);


    }


}
