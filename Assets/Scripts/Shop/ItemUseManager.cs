using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//==================================================================================================//
// 전체적인 아이템, 장비 사용 및 착용 시 필요한 스크립트 입니다. 03-28 윤성근
//==================================================================================================//
public class ItemUseManager : MonoBehaviour //영웅을 선택해서 선택한 영웅의 스텟을 바꾸는 스크립트입니다. 03-27윤성근
{
    public Stat stats;
    public GameObject tentCam;
    public Equip[] equips = new Equip[2];
    public GameObject selectHero;
    public int partyNum = -1;
    public string heroName; //현재 선택된 오브젝트의 이름
    public bool isActive = false; // 중복 클릭 방지를 위한 bool값 입니다.
    public bool alreadySelect = false;
    public Song.UI_DungeonSelect_Manager dgMgr;
    public GameObject[] guildMgr = new GameObject[3];
    public quick_outline.quick_outline outline;

    private void Start()
    {
        partyNum = -1;
    }




    void Update()
    {
        if (dgMgr.isTent && !alreadySelect)
        {
            guildMgr = GameObject.Find("GuildManager").GetComponent<Song.GuildManager>().Party_Hero_Member;

            if (Input.GetMouseButtonDown(0)) // 오브젝트 클릭 시 정보 가져오는 스크립트입니다. 추후에 터치로 바꿀 예정입니다.
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out hit))
                {
                    if (hit.transform.gameObject.tag == "Player") // 레이를 쏴서 태그가 Player이면 그 오브젝트의 정보를 가져옵니다.
                    {                                             // 그 후에 ItemScripts에 있는 함수에 따라서 정보를 변경합니다.
                        heroName = hit.transform.gameObject.name;
                        selectHero = hit.transform.gameObject;
                        StartCoroutine(FindIndexMethod());
                        isActive = true;
                        alreadySelect = true;
                        stats = hit.transform.gameObject.GetComponent<StatScript>().myStat;
                        equips = hit.transform.gameObject.GetComponent<EquipScript>().myEquip;
                        outline = hit.transform.gameObject.GetComponent<quick_outline.quick_outline>();
                        outline.enabled = true;
                        Debug.Log("{" + heroName + "} 를 선택 하셨습니다.");
                    }


                }
            }
        }

        if (dgMgr.isTent && alreadySelect)
        {
            guildMgr = GameObject.Find("GuildManager").GetComponent<Song.GuildManager>().Party_Hero_Member;
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out hit))
                {
                    if (hit.transform.gameObject.tag != "Player")
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
            }
            
        }

        switch (partyNum) 
        {
            case -1:
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



}
