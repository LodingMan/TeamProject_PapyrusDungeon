using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HeroPrefabInfo : MonoBehaviour
{
    public int index;
    public TotalHeroMgr hero;
    public Text textHeroName;
    public Text textHeroLv;
    public Text textHeroIndex;
    public CreateHeroPrefabs createHeroPrefabs;
    public Button hireBtn;
    public CreateHiredPrefabs createHiredPrefabs;
    public HiredHeroMgr hiredHeroMgr;

    void Awake()
    {
        hero = GameObject.Find("GameMgr").GetComponent<TotalHeroMgr>();
        createHiredPrefabs = GameObject.Find("HiredHireList").GetComponent<CreateHiredPrefabs>();
        hiredHeroMgr = GameObject.Find("HiredHeroMgr").GetComponent<HiredHeroMgr>();
        createHeroPrefabs = transform.parent.GetComponent<CreateHeroPrefabs>();
        hireBtn = transform.GetChild(0).GetComponent<Button>();
        textHeroName = transform.GetChild(2).GetComponent<Text>();
        textHeroLv = transform.GetChild(3).GetComponent<Text>();
        textHeroIndex = transform.GetChild(4).GetComponent<Text>();

        index = createHeroPrefabs.index;
        textHeroName.text = hero.heroData[index].stats.name;
        textHeroLv.text = "lv : " + hero.heroData[index].stats.lv;
        textHeroIndex.text = "Index : " + index;
        
        hireBtn.onClick.AddListener(HireFunction); // 영입 버튼 누르면 함수 호출.
        
    }

    public void HireFunction() //영입 버튼 누르면
    {
        hiredHeroMgr.HiredheroData.Add(hero.heroData[index]);

        createHiredPrefabs.CreatePrefabs(hiredHeroMgr.HiredheroData[createHiredPrefabs.cnt]);
        

        gameObject.SetActive(false);
        Destroy(gameObject);
    }


}
