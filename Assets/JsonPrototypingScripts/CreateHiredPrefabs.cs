using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHiredPrefabs : MonoBehaviour
{
    public GameObject prefab;
    public GameObject[] prefabList;
    int i = 0;
    public void CreatePrefabs()
    {
        // ���� �ֱ�
        prefabList[i++] = Instantiate(prefab, gameObject.transform) as GameObject;
    }
}
