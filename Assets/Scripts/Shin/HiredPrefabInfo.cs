using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiredPrefabInfo : MonoBehaviour
{
    public CreateHiredPrefabs createHiredPrefabs;
    public Button hireBtn;
    public Text textHeroName;
    public Text textHeroLv;
    public Text textHeroIndex;
    public HeroClass heroData; // 이 스크립트에 저장해놓을 heroClass 데이터.
    public GameObject[] HeroPrefab;
    public GameObject hero;
    int a = -1;
    void Start()
    {
        createHiredPrefabs = transform.parent.GetComponent<CreateHiredPrefabs>();
        hireBtn = transform.GetChild(0).GetComponent<Button>();
        textHeroName = transform.GetChild(2).GetComponent<Text>();
        textHeroLv = transform.GetChild(3).GetComponent<Text>();
        textHeroIndex = transform.GetChild(4).GetComponent<Text>();

        heroData = createHiredPrefabs.heroData;

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
        // heroData를 토대로 받아온걸로 여기서 오브젝트프리팹 생성.
    }


}
