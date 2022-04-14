using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//==================================================================================================//
// ��ü���� ������, ��� ��� �� ���� �� �ʿ��� ��ũ��Ʈ �Դϴ�. 03-28 ������
//==================================================================================================//
public class ItemUseManager : MonoBehaviour //������ �����ؼ� ������ ������ ������ �ٲٴ� ��ũ��Ʈ�Դϴ�. 03-27������
{
    public GameObject tentCam;
    public GameObject selectHero;
    public GameObject tentInven;
    public Stat stats;
    public Equip[] equips = new Equip[2];
    public skill[] mySkills = new skill[3];
    public int partyNum = -1;
    public string heroJob;
    public string heroName; //���� ���õ� ������Ʈ�� �̸�
    public bool isActive = false; // �ߺ� Ŭ�� ������ ���� bool�� �Դϴ�.
    public bool alreadySelect = false;
    public Song.UI_DungeonSelect_Manager dgMgr;
    public UI_Tweening_Manager twMgr;
    public GameObject[] guildMgr = new GameObject[3];
    public quick_outline.quick_outline outline;
    public ShopManager shopMgr;

    // Shin
    public Shin.SkillDetailTable skillDetailTable;
    public Shin.EquipDetailTable equipDetailTable;
    public Shin.HeroImageTable heroImageTable;
    public Image[] equips_icon;
    public Image[] skills_icon;
    public GameObject heroStat;
    public GameObject statusUI;
    public Text TentText01;

    private void Start()
    {
        partyNum = -1;
    }




    void Update()
    {
        SelectHero();
        CamMove();
    }


    IEnumerator FindIndexMethod()
    {
        for (int i = 0; i < guildMgr.Length; i++)
        {
            if (guildMgr[i].name == heroName)
            {
                partyNum = Array.FindIndex(guildMgr, element => element == selectHero);
            }
        }
        yield return new WaitForEndOfFrame();
    }

    public void BackToSelect()
    {
        if (dgMgr.isTent && alreadySelect)
        {

            if (outline)
            {
                outline.enabled = false;
            }

            for (int i = 0; i < shopMgr.hasItemList.Count; i++)
            {
                if (shopMgr.hasItemList[i].transform.GetChild(1).GetComponent<Button>().gameObject.activeSelf)
                {
                    shopMgr.hasItemList[i].transform.GetChild(1).GetComponent<Button>().gameObject.SetActive(false);
                }

            }

            for (int i = 0; i < shopMgr.hasEquipList.Count; i++)
            {
                if (shopMgr.hasEquipList[i].transform.GetChild(1).GetComponent<Button>().gameObject.activeSelf)
                {
                    shopMgr.hasEquipList[i].transform.GetChild(1).GetComponent<Button>().gameObject.SetActive(false);
                }

            }

            partyNum = -1;
            isActive = false;
            stats = null;
            equips = null;
            heroName = null;
            alreadySelect = false;

        }
    }

    public void CamMove()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
        if (twMgr.StackCount <= 1)
        {

            partyNum = -1;

        }
        }

        switch (partyNum)
        {
            case -1:
                BackToSelect();
                tentCam.transform.position = new Vector3(-37.2f, 1f, -131.1f);
                tentCam.transform.rotation = Quaternion.Euler(-9.234f, 130.35f, 0f);
                break;
            case 0:

                tentCam.transform.position = new Vector3(-34.62f, 1f, -132.96f);
                tentCam.transform.rotation = Quaternion.Euler(-9.234f, 71.647f, 0f);
                break;
            case 1:

                tentCam.transform.position = new Vector3(-34.21f, 1.35f, -133.44f);
                tentCam.transform.rotation = Quaternion.Euler(-8.695f, 133.147f, 3.122f);
                break;

            case 2:

                tentCam.transform.position = new Vector3(-34.79f, 1.15f, -133.43f);
                tentCam.transform.rotation = Quaternion.Euler(-9.234f, 191.353f, 0f);
                break;
        }
    }

    public void SelectHero()
    {
        if (dgMgr.isTent && !alreadySelect && twMgr.isTentOption == false)
        {
            guildMgr = GameObject.Find("GuildManager").GetComponent<Song.GuildManager>().Party_Hero_Member;

            if (Input.GetMouseButtonDown(0)) // ������Ʈ Ŭ�� �� ���� �������� ��ũ��Ʈ�Դϴ�. ���Ŀ� ��ġ�� �ٲ� �����Դϴ�.
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out hit))
                {
                    if (hit.transform.gameObject.tag == "Player") // ���̸� ���� �±װ� Player�̸� �� ������Ʈ�� ������ �����ɴϴ�.
                    {                                             // �� �Ŀ� ItemScripts�� �ִ� �Լ��� ���� ������ �����մϴ�.
                        heroName = hit.transform.gameObject.name;
                        selectHero = hit.transform.gameObject;
                        StartCoroutine(FindIndexMethod());
                        twMgr.UI_Inventory_Tent_PanelPos_On_Off();
                        isActive = true;
                        alreadySelect = true;
                        stats = hit.transform.gameObject.GetComponent<StatScript>().myStat;
                        equips = hit.transform.gameObject.GetComponent<EquipScript>().myEquip;
                        mySkills = hit.transform.gameObject.GetComponent<SkillScript>().mySkills; // Shin
                        outline = hit.transform.gameObject.GetComponent<quick_outline.quick_outline>();
                        outline.enabled = true;
                        Debug.Log("{" + heroName + "} �� ���� �ϼ̽��ϴ�.");
                        InitEquip();

                        //Shin.  
                        heroStat.name = stats.Name;
                        heroStat.transform.GetChild(0).name = stats.Job;
                        heroStat.transform.GetChild(1).GetComponent<Text>().text = stats.Name;
                        heroStat.transform.GetChild(2).GetComponent<Text>().text = "HP : " + stats.HP + " / " + stats.MAXHP;
                        heroStat.transform.GetChild(3).GetComponent<Text>().text = "MP : " + stats.MP + " / " + stats.MAXMP;
                        switch (stats.Job)
                        {
                            case "Babarian":
                                heroStat.transform.GetChild(0).GetComponent<Image>().sprite = heroImageTable.sprite[0];
                                break;
                            case "Archer":
                                heroStat.transform.GetChild(0).GetComponent<Image>().sprite = heroImageTable.sprite[1];
                                break;
                            case "Knight":
                                heroStat.transform.GetChild(0).GetComponent<Image>().sprite = heroImageTable.sprite[2];
                                break;
                            case "Barristan":
                                heroStat.transform.GetChild(0).GetComponent<Image>().sprite = heroImageTable.sprite[3];
                                break;
                            case "Mage":
                                heroStat.transform.GetChild(0).GetComponent<Image>().sprite = heroImageTable.sprite[4];
                                break;
                            case "Porter":
                                heroStat.transform.GetChild(0).GetComponent<Image>().sprite = heroImageTable.sprite[5];
                                break;
                            default:
                                break;

                        }
                        statusUI.GetComponent<Shin.Tent_HeroStatusInit>().heroPrefab = selectHero;
                        statusUI.GetComponent<Shin.Tent_HeroStatusInit>().sprite = heroStat.transform.GetChild(0).GetComponent<Image>().sprite;

                        TentText01.gameObject.SetActive(false);
                    }

                }
            }
        }
    }

    public void InitEquip() // 04.03 Shin. image input function. tent�� �� ��ų,��� �ٲ�� �� �Լ� ȣ��.
    {
        for (int i = 0; i < equips.Length; i++)
        {
            equips_icon[i].sprite = equipDetailTable.sprite[equips[i].Index];
        }
        for (int i = 0; i < mySkills.Length; i++) // ��ų �ε���
        {
            skills_icon[i].sprite = skillDetailTable.sprite[mySkills[i].Index];
        }
    }


    public void DungeonInit()
    {
        partyNum = -1;
        isActive = false;
        stats = null;
        equips = null;
        heroName = null;
        alreadySelect = false;
    }
}
