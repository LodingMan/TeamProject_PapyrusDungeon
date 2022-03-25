using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentHeroPrefabs : MonoBehaviour
{
    public static int j = 0;
    public HiredHeroMgr hiredHeroMgr;
    public GameObject prefab;
    public GameObject[] prefabList;
    
    GameObject[] child;
    
    private void Start()
    {
        hiredHeroMgr = GameObject.Find("HiredHeroMgr").GetComponent<HiredHeroMgr>(); // hiredHeroMgr�� HiredheroData ����Ʈ�� �ҷ����� ���ؼ�.
        
    }

    public void UIAwake()
    {
        hiredHeroMgr._HiredHeroLoad();
        prefabList = new GameObject[hiredHeroMgr.HiredheroData.Count];
        //Debug.Log(hiredHeroMgr.HiredheroData.Count);
        if (j >= hiredHeroMgr.HiredheroData.Count) return;

        for (int i = 0; i < hiredHeroMgr.HiredheroData.Count; i++) // List�� ������ŭ UI�������� ����.
        {
            prefabList[i] = Instantiate(prefab, gameObject.transform) as GameObject;
        }
    }

    public void UIPrefabDestroy()
    {
        child = new GameObject[prefabList.Length];
        for (int i = 0; i < prefabList.Length; i++)
        {
            child[i] = transform.GetChild(i).gameObject;
            Destroy(child[i]);
        }
        j = 0;
    }
    
}
