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
    public void CreatePrefabs(HeroClass heroClass)
    {
        heroData = heroClass; // ���� �ֱ�.
        prefabList[i] = Instantiate(prefab, gameObject.transform) as GameObject; // �� �� prefablist[i]�� �����Ǹ鼭 HiredPrefabInfo�� start�� ����.
        i++; cnt++;
    }
}
