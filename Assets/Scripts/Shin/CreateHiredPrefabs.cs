using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHiredPrefabs : MonoBehaviour
{
    public GameObject prefab;
    public int prefabCnt;
    public GameObject[] prefabList;
    public HeroStats heroStats;
    int i = 0;

    private void Start()
    {
        heroStats = GameObject.Find("GameMgr").GetComponent<HeroStats>();
        prefabList = new GameObject[prefabCnt];
    }
    public void CreatePrefabs()
    {
        // 정보 넣기
        prefabList[i++] = Instantiate(prefab, gameObject.transform) as GameObject;
    }
}
