using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HiredPrefabInfo : MonoBehaviour
{
    public UI_CreateHiredPrefabs UI_createHiredPrefabs;
    public Button hireBtn;
    public Text textHeroName;
    public Text textHeroLv;
    public Text textHeroIndex;
    public HeroClass heroData; // �� ��ũ��Ʈ�� �����س��� heroClass ������.
    public GameObject[] HeroPrefab;
    public GameObject hero;
    int a = -1;
    void Start()
    {
        UI_createHiredPrefabs = transform.parent.GetComponent<UI_CreateHiredPrefabs>();
        hireBtn = transform.GetChild(0).GetComponent<Button>();
        textHeroName = transform.GetChild(2).GetComponent<Text>();
        textHeroLv = transform.GetChild(3).GetComponent<Text>();
        textHeroIndex = transform.GetChild(4).GetComponent<Text>();

        heroData = UI_createHiredPrefabs.heroData;

        gameObject.name = heroData.stats.name;
        textHeroIndex.text = "Index : " + heroData.index;
        textHeroLv.text = "Lv : " + heroData.stats.lv;
        textHeroName.text = heroData.stats.name;

        switch (heroData.stats.job)
        {
            case "Babarian":
                a = 0;
                break;
            case "Archer":
                a = 1;
                break;
            case "Knight":
                a = 2;
                break;
            case "Barristan":
                a = 3;
                break;
            case "Mage":
                a = 4;
                break;
            case "Porter":
                a = 5;
                break;
            default:
                break;
        }

        hero = Instantiate(HeroPrefab[a]);
        hero.name = heroData.stats.name;
        // heroData�� ���� �޾ƿ°ɷ� ���⼭ ������Ʈ������ ����.
    }


}
