using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroSkills : MonoBehaviour
{
    public HeroManager heroSkillData;
    public int skillDmg;
    public int skillMp;
    public int skillCoolTime;
    public float curTime;
    public string heroName;
    public Button[] skillBtn = new Button[5];



    private void Start()
    {
        heroSkillData = GameObject.Find("GameMgr").GetComponent<HeroManager>();
        for (int i = 0; i < skillBtn.Length; i++)
        {
            skillBtn[i] = GameObject.Find("SkillBtn"+i).GetComponent<Button>();
        }

    }
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                heroName = hit.transform.gameObject.tag;
                HeroCheck();
            }


           
        }
    }

    public void HeroCheck()
    {
        if (heroSkillData.isLoaded)
        {

            switch (heroName)
            {
                case "Barbarian":
                    if (heroName == gameObject.tag)
                    {

                    }

                    break;

                case "Archer":
                    if (heroName == gameObject.tag)
                    {

                    }

                    break;
                case "Knight":
                    if (heroName == gameObject.tag)
                    {

                    }

                    break;
                case "Barristan":
                    if (heroName == gameObject.tag)
                    {

                    }

                    break;
                case "Mage":
                    if (heroName == gameObject.tag)
                    {

                    }

                    break;
                case "Porter":
                    if (heroName == gameObject.tag)
                    {

                    }

                    break;

                default:
                    break;
            }
        }




    }

    public void playSkill1()
    {

    }
    public void playSkill2()
    {

    }
    public void playSkill3()
    {

    }
    public void playSkill4()
    {

    }
    public void playSkill5()
    {

    }

}
