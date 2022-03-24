using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHiredPrefabs : MonoBehaviour
{
    public GameObject prefab;
    public int prefabCnt;
    public GameObject[] prefabList;
    public HeroClass heroData;
    
    public int i = 0;
    public int cnt;

    private void Start()
    {
        prefabList = new GameObject[prefabCnt];
    }
    public void CreatePrefabs(HeroClass heroClass) // 고용된 영웅 UI 프리팹 생성.
    {
        heroData = heroClass; // 정보 넣기.
        prefabList[i] = Instantiate(prefab, gameObject.transform) as GameObject; // 이 때 prefablist[i]가 생성되면서 HiredPrefabInfo의 start가 실행.
        i++; cnt++;
    }
}
