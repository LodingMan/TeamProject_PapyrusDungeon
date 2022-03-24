using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentHeroPrefabs : MonoBehaviour
{
    public HiredHeroMgr hiredHeroMgr;
    public GameObject prefab;
    public GameObject[] prefabList;

    private void Start()
    {
        hiredHeroMgr = GameObject.Find("HiredHeroMgr").GetComponent<HiredHeroMgr>(); // hiredHeroMgr의 HiredheroData 리스트를 불러오기 위해서.
        
        
    }

    public void UIAwake()
    {
        hiredHeroMgr._HiredHeroLoad();
        prefabList = new GameObject[hiredHeroMgr.HiredheroData.Count];
        Debug.Log(hiredHeroMgr.HiredheroData.Count);
        for (int i = 0; i < hiredHeroMgr.HiredheroData.Count; i++) // List의 갯수만큼 UI프리팹을 만듬.
        {
            Debug.Log(hiredHeroMgr.HiredheroData[i].name);
            prefabList[i] = Instantiate(prefab, gameObject.transform) as GameObject;
        }
    }

    
}
