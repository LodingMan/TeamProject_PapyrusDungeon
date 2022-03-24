using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHiredPrefabs : MonoBehaviour
{
    public GameObject prefab;
    public GameObject[] prefabList; //이미 고용된 영웅들 Info 리스트
    int i = 0;
    public void CreatePrefabs() // 생성할 정보에 맞는 매개변수가 필요하다. 
    {
        // 정보 넣기
        prefabList[i++] = Instantiate(prefab, gameObject.transform) as GameObject;
    }
}
