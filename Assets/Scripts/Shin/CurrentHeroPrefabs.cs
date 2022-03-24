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
        hiredHeroMgr = GameObject.Find("HiredHeroMgr").GetComponent<HiredHeroMgr>(); // hiredHeroMgr�� HiredheroData ����Ʈ�� �ҷ����� ���ؼ�.
        
        
    }

    public void UIAwake()
    {
        hiredHeroMgr._HiredHeroLoad();
        prefabList = new GameObject[hiredHeroMgr.HiredheroData.Count];
        Debug.Log(hiredHeroMgr.HiredheroData.Count);
        for (int i = 0; i < hiredHeroMgr.HiredheroData.Count; i++) // List�� ������ŭ UI�������� ����.
        {
            Debug.Log(hiredHeroMgr.HiredheroData[i].name);
            prefabList[i] = Instantiate(prefab, gameObject.transform) as GameObject;
        }
    }

    
}
