using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateHeroPrefabs : MonoBehaviour
{
    public GameObject prefab;
    public GameObject[] prefabList;
    public int index;
    public int[] indexs;
    // Start is called before the first frame update

    private void Awake()
    {
        for (int i = 0; i < prefabList.Length; i++)
        {
            indexs[i] = -1;
        }
    }
    public void CreatePrefabs()
    {
        index = Random.Range(0, prefabList.Length);
        for (int i = 0; i < prefabList.Length; i++)
        {
            prefabList[i] = Instantiate(prefab, gameObject.transform) as GameObject;
            indexs[i] = index;
        }

    }
}
