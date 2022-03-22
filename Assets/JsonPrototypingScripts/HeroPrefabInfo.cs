using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;

public class HeroPrefabInfo : MonoBehaviour
{
    public HeroStats heroStats;
    public Text textHeroName;
    public Text textHeroLv;
    public Text textHeroIndex;
    public CreateHeroPrefabs createHeroPrefabs;
    public int index;
    public HiringHeroList hiringHeroList;
    public Button hireBtn;
    public CreateHiredPrefabs hiredHeroScrollView;

    void Awake()
    {
        heroStats = GameObject.Find("GameMgr").GetComponent<HeroStats>();
        hiringHeroList = GameObject.Find("HiringHeroMgr").GetComponent<HiringHeroList>();
        hiredHeroScrollView = GameObject.Find("HiredHireList").GetComponent<CreateHiredPrefabs>();
        hireBtn = transform.GetChild(0).GetComponent<Button>();
        textHeroName = transform.GetChild(2).GetComponent<Text>();
        textHeroLv = transform.GetChild(3).GetComponent<Text>();
        textHeroIndex = transform.GetChild(4).GetComponent<Text>();
        createHeroPrefabs = transform.parent.GetComponent<CreateHeroPrefabs>();

        createHeroPrefabs.index = Random.Range(0, createHeroPrefabs.prefabList.Length);
        index = createHeroPrefabs.index;
        textHeroName.text = heroStats.heroName[createHeroPrefabs.index];
        textHeroLv.text = heroStats.lv[createHeroPrefabs.index].ToString();
        textHeroIndex.text = "Index : " + createHeroPrefabs.index;
        
        hireBtn.onClick.AddListener(HireFunction); // 영입 버튼 누르면 함수 호출.
        
    }

    public void HireFunction() //영입 버튼 누르면
    {
        // 스탯 등 정보를 HiringHeroList에 add.
        hiringHeroList.hiringHeroes.Add(new HeroesClass(heroStats.heroName[index], heroStats.lv[index], heroStats.hp[index], heroStats.mp[index], heroStats.atk[index], 
            heroStats.def[index], heroStats.cri[index], heroStats.acc[index], heroStats.agi[index], heroStats.weapon[index], heroStats.armor[index]));

        gameObject.SetActive(false); // 영웅영입 버튼의 parent를 Destroy => 고용가능한 영웅 리스트에서 삭제. or 비활성화

        hiringHeroList.InstantiateInfo();
        hiredHeroScrollView.CreatePrefabs();
        
    }

}
