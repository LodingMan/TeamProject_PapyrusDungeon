using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_CurrentHeroPrefabInfo : MonoBehaviour
{
    public int index;
    public TotalHeroMgr heroStats;
    public Text textHeroName;
    public Text textHeroLv;
    public Text textHeroIndex;
    public UI_CurrentHeroStats UI_currentHeroStats;
    public Button hireBtn;
    public HiredHeroMgr hiredHeroMgr;

    void Start()
    {
        heroStats = GameObject.Find("GameMgr").GetComponent<TotalHeroMgr>();
        hiredHeroMgr = GameObject.Find("HiredHeroMgr").GetComponent<HiredHeroMgr>();
        UI_currentHeroStats = GetComponent<UI_CurrentHeroStats>();
        hireBtn = transform.GetChild(0).GetComponent<Button>();
        textHeroName = transform.GetChild(2).GetComponent<Text>();
        textHeroLv = transform.GetChild(3).GetComponent<Text>();
        textHeroIndex = transform.GetChild(4).GetComponent<Text>();

        gameObject.name = UI_currentHeroStats.heroName;

        index = UI_currentHeroStats.index;
        textHeroName.text = UI_currentHeroStats.heroName;
        textHeroLv.text = "lv : " + UI_currentHeroStats.lv;
        textHeroIndex.text = "Index : " + index;

    }

}
