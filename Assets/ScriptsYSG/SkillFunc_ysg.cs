using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillFunc_ysg : MonoBehaviour
{

    public int LV;
    public int ATK;
    public int DEF;
    public int MyPosition;
    public int EnemyPosition;
    public string heroName;

    public Button[] skillBtn = new Button[5];
    public bool isListenersinit = false;
    public bool isActive = false;


    void Start()
    {
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

                if (Physics.Raycast(ray.origin, ray.direction, out hit))
                {

                    string name = hit.transform.gameObject.tag;

                if (name == gameObject.tag)
                {
                    heroName = name;
                    isActive = true;
                    HeroCheck();
                }
                else
                {
                    isActive = false;
                    ATK = 0;
                    DEF = 0;
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
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;
                        Debug.Log("바바리안 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;

                case "Archer":
                    if (heroName == gameObject.tag)
                    {
                        int i = 0;
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;

                        Debug.Log("아처 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Knight":
                    if (heroName == gameObject.tag)
                    {
                        int i = 0;
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;

                        Debug.Log("기사 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Barristan":
                    if (heroName == gameObject.tag)
                    {
                        int i = 0;
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;

                        Debug.Log("중보병 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Mage":
                    if (heroName == gameObject.tag)
                    {
                        int i = 0;
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;

                        Debug.Log("마법사 1번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Porter":
                    if (heroName == gameObject.tag)
                    {
                        int i = 0;
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;

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
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;
                        Debug.Log("바바리안 2번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;

                case "Archer":
                    if (heroName == gameObject.tag)
                    {
                        int i = 1;
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;

                        Debug.Log("아처 2번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Knight":
                    if (heroName == gameObject.tag)
                    {
                        int i = 1;
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;

                        Debug.Log("기사 2번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Barristan":
                    if (heroName == gameObject.tag)
                    {
                        int i = 1;
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;

                        Debug.Log("중보병 2번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Mage":
                    if (heroName == gameObject.tag)
                    {
                        int i = 1;
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;

                        Debug.Log("마법사 2번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Porter":
                    if (heroName == gameObject.tag)
                    {
                        int i = 1;
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;

                        Debug.Log("짐꾼 2번 스킬");
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
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;
                        Debug.Log("바바리안 3번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;

                case "Archer":
                    if (heroName == gameObject.tag)
                    {
                        int i = 2;
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;
                        Debug.Log("아처 3번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Knight":
                    if (heroName == gameObject.tag)
                    {
                        int i = 2;
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;
                        Debug.Log("기사 3번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Barristan":
                    if (heroName == gameObject.tag)
                    {
                        int i = 2;
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;
                        Debug.Log("중보병 3번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Mage":
                    if (heroName == gameObject.tag)
                    {
                        int i = 2;
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;
                        Debug.Log("마법사 3번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Porter":
                    if (heroName == gameObject.tag)
                    {
                        int i = 2;
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;
                        Debug.Log("짐꾼 3번 스킬");
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
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;
                        Debug.Log("바바리안 4번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;

                case "Archer":
                    if (heroName == gameObject.tag)
                    {

                        int i = 3;
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;
                        Debug.Log("아처 4번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Knight":
                    if (heroName == gameObject.tag)
                    {
                        int i = 3;
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;
                        Debug.Log("기사 4번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Barristan":
                    if (heroName == gameObject.tag)
                    {
                        int i = 3;
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;
                        Debug.Log("중보병 4번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Mage":
                    if (heroName == gameObject.tag)
                    {
                        int i = 3;
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;
                        Debug.Log("마법사 4번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Porter":
                    if (heroName == gameObject.tag)
                    {
                        int i = 3;
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;
                        Debug.Log("짐꾼 4번 스킬");
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
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;
                        Debug.Log("바바리안 5번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;

                case "Archer":
                    if (heroName == gameObject.tag)
                    {
                        int i = 4;
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;
                        Debug.Log("아처 5번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Knight":
                    if (heroName == gameObject.tag)
                    {
                        int i = 4;
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;

                        Debug.Log("기사 5번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Barristan":
                    if (heroName == gameObject.tag)
                    {
                        int i = 4;
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;
                        Debug.Log("중보병 5번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Mage":
                    if (heroName == gameObject.tag)
                    {
                        int i = 4;
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;
                        Debug.Log("마법사 5번 스킬");
                        SkillBtnClear();
                        isActive = false;
                    }

                    break;
                case "Porter":
                    if (heroName == gameObject.tag)
                    {
                        int i = 4;
                        ATK = gameObject.GetComponent<SkillScript>().skills[i].ATK;
                        DEF = gameObject.GetComponent<SkillScript>().skills[i].DEF;
                        Debug.Log("짐꾼 5번 스킬");
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
