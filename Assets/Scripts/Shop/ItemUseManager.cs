using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//==================================================================================================//
// ��ü���� ������, ��� ��� �� ���� �� �ʿ��� ��ũ��Ʈ �Դϴ�. 03-28 ������
//==================================================================================================//
public class ItemUseManager : MonoBehaviour //������ �����ؼ� ������ ������ ������ �ٲٴ� ��ũ��Ʈ�Դϴ�. 03-27������
{
    public GameObject tentCam;
    public GameObject selectHero;
    public Stat stats;
    public Equip[] equips = new Equip[2];
    public skill[] mySkills = new skill[3];
    public int partyNum = -1;
    public string heroName; //���� ���õ� ������Ʈ�� �̸�
    public bool isActive = false; // �ߺ� Ŭ�� ������ ���� bool�� �Դϴ�.
    public bool alreadySelect = false;
    public Song.UI_DungeonSelect_Manager dgMgr;
    public UI_Tweening_Manager twMgr;
    public GameObject[] guildMgr = new GameObject[3];
    public quick_outline.quick_outline outline;

    // Shin
    public Shin.SkillDetailTable skillDetailTable;
    public Image[] equips_icon;
    public Image[] skills_icon;

    private void Start()
    {
        partyNum = -1;
        skillDetailTable = GameObject.Find("SkillDetailManager").GetComponent<Shin.SkillDetailTable>();
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
            partyNum = -1;
        }
        
        switch (partyNum)
        {
            case -1:
                BackToSelect();
                tentCam.transform.position = new Vector3(-37.2f, 1f, -131.1f);
                tentCam.transform.rotation = Quaternion.Euler(-9.234f, 130.35f, 0f);
                break;
            case 0:

                tentCam.transform.position = new Vector3(-34f, 1.3f, -133f);
                tentCam.transform.rotation = Quaternion.Euler(-3f, 51f, 0f);
                break;
            case 1:

                tentCam.transform.position = new Vector3(-34.4f, 1.25f, -134f);
                tentCam.transform.rotation = Quaternion.Euler(-2.2f, 111f, 0f);
                break;

            case 2:

                tentCam.transform.position = new Vector3(-34.4f, 1.2f, -134f);
                tentCam.transform.rotation = Quaternion.Euler(-4.6f, 193f, 0f);
                break;
        }
    }

    public void SelectHero()
    {
        if (dgMgr.isTent && !alreadySelect)
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
                        for (int i = 0; i < equips.Length; i++)
                        {
                            // ������������ ��� ���� ���� ������ => �� equipsi[i].Index�� null�̸� ����ó��.
                            //equips_icon[i].sprite = ����̹������̺�.sprite
                        }
                        for (int i = 0; i < mySkills.Length; i++) // ��ų �ε���
                        {
                            skills_icon[i].sprite = skillDetailTable.sprite[mySkills[i].Index];
                        }
                        twMgr.UI_HeroStat_Tent_PanelPos_On_Off(); // Shin. ���⿡ Tent_HeroPanel�� tween�ϵ���.
                        //heroname�� �̿��Ͽ� UI���� ����. Shin.
                        
                    }


                }
            }
        }
    }
}
