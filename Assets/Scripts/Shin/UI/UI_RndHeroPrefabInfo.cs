using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_RndHeroPrefabInfo : MonoBehaviour
{
    public int index;
    public TotalHeroMgr hero;
    public Text textHeroName;
    public Text textHeroLv;
    public Text textHeroIndex;
    public UI_CreateHeroPrefabs UI_createHeroPrefabs;
    public Button hireBtn;
    public UI_CreateHiredPrefabs UI_createHiredPrefabs;
    public HiredHeroMgr hiredHeroMgr;

    void Awake()
    {
        hero = GameObject.Find("GameMgr").GetComponent<TotalHeroMgr>();
        UI_createHiredPrefabs = GameObject.Find("HiredHireList").GetComponent<UI_CreateHiredPrefabs>();
        hiredHeroMgr = GameObject.Find("HiredHeroMgr").GetComponent<HiredHeroMgr>();
        UI_createHeroPrefabs = transform.parent.GetComponent<UI_CreateHeroPrefabs>();
        hireBtn = transform.GetChild(0).GetComponent<Button>();
        textHeroName = transform.GetChild(2).GetComponent<Text>();
        textHeroLv = transform.GetChild(3).GetComponent<Text>();
        textHeroIndex = transform.GetChild(4).GetComponent<Text>();

        index = UI_createHeroPrefabs.index;
        textHeroName.text = hero.heroData[index].stats.name;
        textHeroLv.text = "lv : " + hero.heroData[index].stats.lv;
        textHeroIndex.text = "Index : " + index;
        
        hireBtn.onClick.AddListener(HireFunction); // 영입 버튼 누르면 함수 호출.
        
    }

    public void HireFunction() //영입 버튼 누르면
    {
        //add하기 전에 load를 해서 먼저 크기만큼 hiredherodata에 저장해놓고 나서 add
        
        if (hiredHeroMgr.HiredheroData.Count == 0) // 파일안에 내용이 없으면
        {
        }
        else //있으면
        {
            hiredHeroMgr._HiredHeroLoad();
        }
        hiredHeroMgr.HiredheroData.Add(hero.heroData[index]);
        hiredHeroMgr._HiredHeroSave();

        UI_createHiredPrefabs.CreatePrefabs(hiredHeroMgr.HiredheroData[UI_createHiredPrefabs.cnt]);
        

        gameObject.SetActive(false);
        Destroy(gameObject);
    }


}
