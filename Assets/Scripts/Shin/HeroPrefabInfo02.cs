using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HeroPrefabInfo02 : MonoBehaviour
{
    public int index;
    public TotalHeroMgr heroStats;
    public Text textHeroName;
    public Text textHeroLv;
    public Text textHeroIndex;
    public CurrentHeroStats02 currentHeroStats02;
    public Button hireBtn;
    public HiredHeroMgr hiredHeroMgr;

    void Start()
    {
        heroStats = GameObject.Find("GameMgr").GetComponent<TotalHeroMgr>();
        hiredHeroMgr = GameObject.Find("HiredHeroMgr").GetComponent<HiredHeroMgr>();
        currentHeroStats02 = GetComponent<CurrentHeroStats02>();
        hireBtn = transform.GetChild(0).GetComponent<Button>();
        textHeroName = transform.GetChild(2).GetComponent<Text>();
        textHeroLv = transform.GetChild(3).GetComponent<Text>();
        textHeroIndex = transform.GetChild(4).GetComponent<Text>();

        gameObject.name = currentHeroStats02.heroName;

        index = currentHeroStats02.index;
        textHeroName.text = currentHeroStats02.heroName;
        textHeroLv.text = "lv : " + currentHeroStats02.lv;
        textHeroIndex.text = "Index : " + index;

    }

}
