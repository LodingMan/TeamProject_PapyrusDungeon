using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HeroPrefabInfo : MonoBehaviour  //UI상에서 고용할 수 있는 영웅에 대한 정보
{                                            // 고용되면 고용된 영웅 리스트에 HeroClass형으로 자료가 들어가고 이 컴포넌트가 달린 인포창은 제거됨
    public int index;
    public HeroStats heroStats;
    public Text textHeroName;
    public Text textHeroLv;
    public Text textHeroIndex;
    public CreateHeroPrefabs createHeroPrefabs;  //createHeroUIPrefab으로 변경희망
    public Button hireBtn;
    public CreateHiredPrefabs hiredHeroScrollView;
    public HiredHeroMgr hiredHeroMgr;

    public GameObject createHeroPrefab;
    public GameObject currentSelectHeroPrefab;

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

        currentSelectHeroPrefab = Instantiate(createHeroPrefab);

        currentSelectHeroPrefab.GetComponent<HeroStatsLoad>().InitStat(index);



        gameObject.SetActive(false);
        Destroy(gameObject);
    }


}
