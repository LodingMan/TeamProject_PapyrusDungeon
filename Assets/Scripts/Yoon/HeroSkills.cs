using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroSkills : MonoBehaviour
{
    public HeroStats heroSkillData;
    public int skillDmg;
    public int skillMp;
    public int skillCoolTime;
    public float curTime;
    public string heroName;
    public Button[] skillBtn = new Button[5];

    public bool isListenersinit = false;
    public bool isActive = false;



    private void Start()
    {
        heroSkillData = GameObject.Find("GameMgr").GetComponent<HeroStats>();

        for (int i = 0; i < skillBtn.Length; i++)
        {
            skillBtn[i] = GameObject.Find("SkillBtn" + i).GetComponent<Button>();
        }


    }
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray.origin,ray.direction, out hit))
            {
                string heroName2 = hit.transform.gameObject.tag;
                if (heroName2 == gameObject.tag)
                {
                    heroName = heroName2;
                    isActive = true;
                    HeroCheck();
                }
                else
                {
                    isActive = false;
                    skillDmg = 0;
                    skillMp = 0;
                    skillCoolTime = 0;
                    SkillBtnClear();
                }

            }

           
        }
    }

    public void HeroCheck()
    {

        if (isActive)
        {

            switch (heroName)
            {
                case "Barbarian":
                    if (heroName == gameObject.tag)
                    {
                        SkillBtnClear();
                        SkillBtnSelect();
                    }

                    break;

                case "Archer":
                    if (heroName == gameObject.tag)
                    {
                        SkillBtnClear();
                        SkillBtnSelect();
                    }

                    break;
                case "Knight":
                    if (heroName == gameObject.tag)
                    {
                        SkillBtnClear();
                        SkillBtnSelect();
                    }

                    break;
                case "Barristan":
                    if (heroName == gameObject.tag)
                    {
                        SkillBtnClear();
                        SkillBtnSelect();
                    }

                    break;
                case "Mage":
                    if (heroName == gameObject.tag)
                    {
                        SkillBtnClear();
                        SkillBtnSelect();
                    }

                    break;
                case "Porter":
                    if (heroName == gameObject.tag)
                    {
                        SkillBtnClear();
                        SkillBtnSelect();
                    }

                    break;

                default:
                    break;
            }
        }




    }

    public void playerSkill1()
    {
        if (isActive)
        {

            switch (heroName)
            {
                case "Barbarian":
                    if (heroName == gameObject.tag)
                    {
                        int i = 0;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("바바리안 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;

                case "Archer":
                    if (heroName == gameObject.tag)
                    {
                        int i = 5;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("아처 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Knight":
                    if (heroName == gameObject.tag)
                    {
                        int i = 10;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("기사 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Barristan":
                    if (heroName == gameObject.tag)
                    {
                        int i = 15;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("중보병 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Mage":
                    if (heroName == gameObject.tag)
                    {
                        int i = 20;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("마법사 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Porter":
                    if (heroName == gameObject.tag)
                    {
                        int i = 25;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("짐꾼 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;

                default:
                    break;
            }
        }

    }
    public void playerSkill2()
    {
        if (isActive)
        {

            switch (heroName)
            {
                case "Barbarian":
                    if (heroName == gameObject.tag)
                    {
                        int i = 1;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("바바리안 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;

                case "Archer":
                    if (heroName == gameObject.tag)
                    {
                        int i = 6;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("아처 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Knight":
                    if (heroName == gameObject.tag)
                    {
                        int i = 11;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("기사 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Barristan":
                    if (heroName == gameObject.tag)
                    {
                        int i = 16;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("중보병 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Mage":
                    if (heroName == gameObject.tag)
                    {
                        int i = 21;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("마법사 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Porter":
                    if (heroName == gameObject.tag)
                    {
                        int i = 26;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("짐꾼 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;

                default:
                    break;
            }
        }

    }
    public void playerSkill3()
    {
        if (isActive)
        {

            switch (heroName)
            {
                case "Barbarian":
                    if (heroName == gameObject.tag)
                    {
                        int i = 2;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("바바리안 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;

                case "Archer":
                    if (heroName == gameObject.tag)
                    {
                        int i = 7;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("아처 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Knight":
                    if (heroName == gameObject.tag)
                    {
                        int i = 12;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("기사 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Barristan":
                    if (heroName == gameObject.tag)
                    {
                        int i = 17;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("중보병 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Mage":
                    if (heroName == gameObject.tag)
                    {
                        int i = 22;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("마법사 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Porter":
                    if (heroName == gameObject.tag)
                    {
                        int i = 27;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("짐꾼 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;

                default:
                    break;
            }
        }
    }
    public void playerSkill4()
    {
        if (isActive)
        {

            switch (heroName)
            {
                case "Barbarian":
                    if (heroName == gameObject.tag)
                    {
                        int i = 3;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("바바리안 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;

                case "Archer":
                    if (heroName == gameObject.tag)
                    {
                        int i = 8;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("아처 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Knight":
                    if (heroName == gameObject.tag)
                    {
                        int i = 13;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("기사 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Barristan":
                    if (heroName == gameObject.tag)
                    {
                        int i = 18;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("중보병 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Mage":
                    if (heroName == gameObject.tag)
                    {
                        int i = 23;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("마법사 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Porter":
                    if (heroName == gameObject.tag)
                    {
                        int i = 28;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("짐꾼 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;

                default:
                    break;
            }
        }
    }
    public void playerSkill5()
    {
        if (isActive)
        {

            switch (heroName)
            {
                case "Barbarian":
                    if (heroName == gameObject.tag)
                    {
                        int i = 4;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("바바리안 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;

                case "Archer":
                    if (heroName == gameObject.tag)
                    {
                        int i = 9;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("아처 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Knight":
                    if (heroName == gameObject.tag)
                    {
                        int i = 14;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("기사 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Barristan":
                    if (heroName == gameObject.tag)
                    {
                        int i = 19;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("중보병 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Mage":
                    if (heroName == gameObject.tag)
                    {
                        int i = 24;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("마법사 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Porter":
                    if (heroName == gameObject.tag)
                    {
                        int i = 29;
                        //스킬
                        skillDmg = heroSkillData.heroSkills[i].dmg;
                        skillMp = heroSkillData.heroSkills[i].mp;
                        skillCoolTime = heroSkillData.heroSkills[i].cooltime;
                        Debug.Log("짐꾼 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;

                default:
                    break;
            }
        }
    }

    public void SkillBtnSelect()
    {
            skillBtn[0].onClick.AddListener(playerSkill1);
            skillBtn[1].onClick.AddListener(playerSkill2);
            skillBtn[2].onClick.AddListener(playerSkill3);
            skillBtn[3].onClick.AddListener(playerSkill4);
            skillBtn[4].onClick.AddListener(playerSkill5);
            isListenersinit = true;

    }

    public void SkillBtnClear()
    {
        if (isListenersinit)
        {
            for (int j = 0; j < skillBtn.Length; j++)
            {
                if (skillBtn[j].onClick != null)
                {
                    skillBtn[j].onClick.RemoveAllListeners();
                    isListenersinit = false;
                }
            }
        }
    }

}
