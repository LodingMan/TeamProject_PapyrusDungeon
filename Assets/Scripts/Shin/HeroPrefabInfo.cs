using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HeroPrefabInfo : MonoBehaviour
{
    public int index;
    public TotalHeroMgr heroStats;
    public Text textHeroName;
    public Text textHeroLv;
    public Text textHeroIndex;
    public CreateHeroPrefabs createHeroPrefabs;
    public Button hireBtn;
    public CreateHiredPrefabs createHiredPrefabs;
    public HiredHeroMgr hiredHeroMgr;

    void Awake()
    {
        heroStats = GameObject.Find("GameMgr").GetComponent<TotalHeroMgr>();
        createHiredPrefabs = GameObject.Find("HiredHireList").GetComponent<CreateHiredPrefabs>();
        hiredHeroMgr = GameObject.Find("HiredHeroMgr").GetComponent<HiredHeroMgr>();
        createHeroPrefabs = transform.parent.GetComponent<CreateHeroPrefabs>();
        hireBtn = transform.GetChild(0).GetComponent<Button>();
        textHeroName = transform.GetChild(2).GetComponent<Text>();
        textHeroLv = transform.GetChild(3).GetComponent<Text>();
        textHeroIndex = transform.GetChild(4).GetComponent<Text>();

        index = createHeroPrefabs.index;
        //textHeroName.text = heroStats.heroName[index];
        //textHeroLv.text = "lv : "+ heroStats.lv[index].ToString();
        textHeroIndex.text = "Index : " + index;
        
        hireBtn.onClick.AddListener(HireFunction); // 영입 버튼 누르면 함수 호출.
        
    }

    public void HireFunction() //영입 버튼 누르면
    {
        /*hiredHeroMgr.HiredheroData.Add(new HeroClass(heroStats.index[index], heroStats.heroName[index], heroStats.job[index], heroStats.lv[index], heroStats.hp[index], heroStats.mp[index], heroStats.atk[index], heroStats.def[index], heroStats.cri[index],
            heroStats.acc[index],heroStats.agi[index], heroStats.weapon[index], heroStats.armor[index], heroStats.skill01[index], heroStats.skill02[index], heroStats.skill03[index], heroStats.skill04[index], heroStats.skill05[index]));*/

        createHiredPrefabs.CreatePrefabs(hiredHeroMgr.HiredheroData[createHiredPrefabs.cnt]);
        

        gameObject.SetActive(false);
        Destroy(gameObject);
    }


}
