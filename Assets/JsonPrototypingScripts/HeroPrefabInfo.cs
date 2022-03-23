using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HeroPrefabInfo : MonoBehaviour
{
    public int index;
    public HeroStats heroStats;
    public Text textHeroName;
    public Text textHeroLv;
    public Text textHeroIndex;
    public CreateHeroPrefabs createHeroPrefabs;
    public Button hireBtn;
    public CreateHiredPrefabs hiredHeroScrollView;
    public HiredHeroMgr hiredHeroMgr;

    void Awake()
    {
        heroStats = GameObject.Find("GameMgr").GetComponent<HeroStats>();
        hiredHeroScrollView = GameObject.Find("HiredHireList").GetComponent<CreateHiredPrefabs>();
        hiredHeroMgr = GameObject.Find("HiredHeroMgr").GetComponent<HiredHeroMgr>();
        hireBtn = transform.GetChild(0).GetComponent<Button>();
        textHeroName = transform.GetChild(2).GetComponent<Text>();
        textHeroLv = transform.GetChild(3).GetComponent<Text>();
        textHeroIndex = transform.GetChild(4).GetComponent<Text>();
        createHeroPrefabs = transform.parent.GetComponent<CreateHeroPrefabs>();

       
        index = createHeroPrefabs.index;
        textHeroName.text = heroStats.heroName[index];
        textHeroLv.text = "lv : "+ heroStats.lv[index].ToString();
        textHeroIndex.text = "Index : " + index;
        
        hireBtn.onClick.AddListener(HireFunction); // 영입 버튼 누르면 함수 호출.
        
    }

    public void HireFunction() //영입 버튼 누르면
    {
        hiredHeroMgr.HiredheroData.Add(new HeroClass(heroStats.index[index], heroStats.heroName[index], heroStats.job[index], heroStats.lv[index], heroStats.hp[index], heroStats.mp[index], heroStats.atk[index], heroStats.def[index], heroStats.cri[index],
            heroStats.acc[index],heroStats.agi[index], heroStats.weapon[index], heroStats.armor[index], heroStats.skill01[index], heroStats.skill02[index], heroStats.skill03[index], heroStats.skill04[index], heroStats.skill05[index]));

        // 스탯 등 정보를 HiredHeroList에 add.
        //hiredHeroMgr._HiredHeroSave(); // json 저장.

        hiredHeroScrollView.CreatePrefabs();

        gameObject.SetActive(false);
        Destroy(gameObject);
    }


}
