using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat_Event_UI_Manager : MonoBehaviour
{
    public Song.UI_DungeonSelect_Manager dungeonSelectManager;
    public TownManager townManager;
    public e_CombatManager combatManager;
    public InGame_Player_Script inGame_Player_Script;
    public CombatCameraControll combatCameraControll;
    public SkillActiveManager skillActiveManager;
    public ShopManager shopManager;
    public ShopEquipScripts shopEquipScripts;
    public Shin.EquipDetailTable equipDetailTable;
    public List<Button> Go_Back_Btn = new List<Button>();



    public GameObject HeroStatusInfo_Panel;
    public List<Text> HeroStatInfo_Text = new List<Text>();
    // 0 �̸� 1 ���� 2 Atk 3 DEF 4 CIR 5 ACC 6 AGI 7 SPEED 8 HP 9 MP

    //HpBar에 관한 변수
    public GameObject Bars;
    public List<GameObject> Defalt_Hero_Hp_Bar = new List<GameObject>();
    public List<GameObject> Hero_HP_Bar = new List<GameObject>();
    public List<GameObject> Defalt_Enemy_Hp_Bar = new List<GameObject>();
    public List<GameObject> Enemy_HP_Bar = new List<GameObject>();
    public List<Vector2> Hero_Hp_Bar_Pos = new List<Vector2>();
    public List<Vector2> Enemy_Hp_Bar_Pos = new List<Vector2>();

    //턴과 관련됨
    public Text TurnText;
    public GameObject TurnTextImg;


    public Button MiniMapCommingBtn;
    public Text IngameText;
    public Text EnemySkillNameText;

    public Button[] Yes_No_Button = new Button[2];
    bool isMiniMapOn = false;
    public GameObject EventUIPanal;
    public Text EventText;



    public GameObject GameClearPanal;
    public List<Text> PartyMemberNameList = new List<Text>();
    public GameObject ClearReward_Create_Point;
    public GameObject GameClearReward_Equip_Image;
    public List<GameObject> ImageSaveList = new List<GameObject>();

    //승패 관련
    public Image Victory_Fail_Image;
    public Sprite VictorySprite;
    public Sprite FailSprite;

    //데미지 관련
    public GameObject DamageText;
    public Animator TextAnim;



    public GameObject Current_Attack_Unit;

    //스킬Info관련
    public Image Skill_Info_UI;
    public List<Text> SkillInfo_Text = new List<Text>(); // 0 �̸� 2 ATK 3 Type 4 pram 5 BuffTime
    public List<Image> SKillInfo_Image = new List<Image>();

    public GameObject Player_Targeting;


    public GameObject goldImage;

    public void Go_Back_On()
    {
        Go_Back_Btn[0].gameObject.SetActive(true);
        Go_Back_Btn[1].gameObject.SetActive(true);
        if (townManager.Week == 1)
        {

        }
    }
    public void Go_Back_Off()
    {
        Go_Back_Btn[0].gameObject.SetActive(false);
        Go_Back_Btn[1].gameObject.SetActive(false);
    }

    public void MinimapGuide()
    {
        if (!combatManager.isCombat)
        {
            if (inGame_Player_Script.isRoom)
            {
                IngameText.rectTransform.anchoredPosition = new Vector2(-44, 316);
                IngameText.text = "�ٸ� �������� �̵��� ���� �̴ϸ��� �����ּ���";
            }

        }
    }

    public void BattleStart()
    {
        IngameText.rectTransform.anchoredPosition = new Vector2(0, 316);
        IngameText.text = "���� ����!";
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

        for (int i = 0; i < combatManager.myParty.Count; i++)
        {
            CurrentHeroStat = combatManager.myParty[i].GetComponent<StatScript>();
            PartyMemberNameList[i].text = CurrentHeroStat.myStat.Name + "  " + CurrentHeroStat.PreviousLv + "  -> " + CurrentHeroStat.myStat.Lv;
        }

        if (combatManager.isGameOver)
        {
            Debug.Log("���ӿ���");
            Victory_Fail_Image.sprite = FailSprite;

        }
        else
        {
            Victory_Fail_Image.sprite = VictorySprite;

        }
        if (!combatManager.isGameOver)
        {
            //townManager.DungeonClearCount[dungeonSelectManager.DungeonType]++; ���������� �ּ�ó��

            GameObject GoldPrefab;
            int RndGold = Random.Range(1, combatManager.DungeonDifficulty * 100); // ���� Ŭ���� �� ��� ��差
            for (int i = 0; i < combatManager.DungeonDifficulty; i++)
            {
                int RndIdx = Random.Range(1, shopManager.equipList.Count);
                GameObject CurrentCreateImgae;
                GameObject InvantoryCreatePrefab;

                CurrentCreateImgae = Instantiate(GameClearReward_Equip_Image);
                CurrentCreateImgae.GetComponent<Image>().sprite = equipDetailTable.sprite[RndIdx]; // shopManager.equipList[RndIdx].transform.GetChild(1).GetComponent<Image>().sprite;
                CurrentCreateImgae.gameObject.transform.SetParent(ClearReward_Create_Point.transform);
                CurrentCreateImgae.transform.localScale = new Vector3(1, 1, 1); // �̹��� ������ ����
                ImageSaveList.Add(CurrentCreateImgae);


                InvantoryCreatePrefab = Instantiate(shopManager.equipList[RndIdx]);
                shopManager.hasEquipList.Add(InvantoryCreatePrefab);
                InvantoryCreatePrefab.transform.SetParent(shopManager.inventory.transform);
                InvantoryCreatePrefab.transform.localPosition = shopManager.inventory.transform.localPosition;
                InvantoryCreatePrefab.transform.localScale = new Vector3(1, 1, 1);
            }

            goldImage.transform.GetChild(0).GetComponent<Text>().text = RndGold.ToString(); //��� �̹��� ���
            GoldPrefab = Instantiate(goldImage);
            GoldPrefab.gameObject.transform.SetParent(ClearReward_Create_Point.transform);
            GoldPrefab.gameObject.transform.localScale = new Vector3(1, 1, 1);

            shopManager.DungeonClearItemSave(RndGold);  // ���� ��� ������Ʈ

            for (int i = 0; i < shopManager.hasItemList.Count; i++)  // �κ��丮�� ������ �ű�� Yoon
            {
                shopManager.hasItemList[i].transform.SetParent(shopManager.inventory.transform);
                shopManager.hasItemList[i].transform.localPosition = shopManager.inventory.transform.localPosition;
                shopManager.hasItemList[i].transform.localScale = new Vector3(1, 1, 1);
            }
            for (int i = 0; i < shopManager.hasEquipList.Count; i++)
            {
                shopManager.hasEquipList[i].transform.SetParent(shopManager.inventory.transform);
                shopManager.hasEquipList[i].transform.localPosition = shopManager.inventory.transform.localPosition;
                shopManager.hasEquipList[i].transform.localScale = new Vector3(1, 1, 1);
            }
            shopManager.ItemSave(); // ���� ������, ���, ��� ���� ���� 0414 Yoon
            shopManager.heroManager._Save();
            PlayerPrefs.SetInt("Week", townManager.Week + 1);
            
        }

    }
    public void GameClearPanalUp()
    {
        for (int i = 0; i < combatManager.myParty.Count; i++)
        {
            PartyMemberNameList[i].text = "";
        }

        for (int i = ImageSaveList.Count - 1; i >= 0; i--)
        {
            ImageSaveList.RemoveAt(i);
            //Destroy(ImageSaveList[i]);
        }
        GameClearPanal.GetComponent<Image>().rectTransform.DOAnchorPos(new Vector2(0, 1090), 1f);


    }


}
