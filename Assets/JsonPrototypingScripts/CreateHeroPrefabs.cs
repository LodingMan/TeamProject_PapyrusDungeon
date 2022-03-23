using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateHeroPrefabs : MonoBehaviour
{
    public GameObject prefab;
    public int prefabCnt;
    public GameObject[] prefabList;
    public HeroStats heroStats;
    public int maxIndex;
    public int index;

    // Start is called before the first frame update

    private void Start()
    {
        heroStats = GameObject.Find("GameMgr").GetComponent<HeroStats>();
        prefabList = new GameObject[prefabCnt];
        maxIndex = heroStats.dataLength;
    }

    public void CreatePrefabs()
    {
        for (int i = 0; i < prefabList.Length; i++)
        {
            index = Random.Range(0, maxIndex);
            prefabList[i] = Instantiate(prefab, gameObject.transform) as GameObject;
        }
        
    }
}
