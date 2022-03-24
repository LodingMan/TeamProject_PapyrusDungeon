using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HeroPrefabInfo : MonoBehaviour  //UI�󿡼� ����� �� �ִ� ������ ���� ����
{                                            // ���Ǹ� ���� ���� ����Ʈ�� HeroClass������ �ڷᰡ ���� �� ������Ʈ�� �޸� ����â�� ���ŵ�
    public int index;
    public HeroStats heroStats;
    public Text textHeroName;
    public Text textHeroLv;
    public Text textHeroIndex;
    public CreateHeroPrefabs createHeroPrefabs;  //createHeroUIPrefab���� �������
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
        
        hireBtn.onClick.AddListener(HireFunction); // ���� ��ư ������ �Լ� ȣ��.
        
    }

    public void HireFunction() //���� ��ư ������
    {
        hiredHeroMgr.HiredheroData.Add(new HeroClass(heroStats.index[index], heroStats.heroName[index], heroStats.job[index], heroStats.lv[index], heroStats.hp[index], heroStats.mp[index], heroStats.atk[index], heroStats.def[index], heroStats.cri[index],
            heroStats.acc[index],heroStats.agi[index], heroStats.weapon[index], heroStats.armor[index], heroStats.skill01[index], heroStats.skill02[index], heroStats.skill03[index], heroStats.skill04[index], heroStats.skill05[index]));

        // ���� �� ������ HiredHeroList�� add.
        //hiredHeroMgr._HiredHeroSave(); // json ����.

        hiredHeroScrollView.CreatePrefabs();

        currentSelectHeroPrefab = Instantiate(createHeroPrefab);

        currentSelectHeroPrefab.GetComponent<HeroStatsLoad>().InitStat(index);



        gameObject.SetActive(false);
        Destroy(gameObject);
    }


}
