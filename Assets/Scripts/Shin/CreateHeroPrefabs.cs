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
    
    public int index;
    int[] exist;
    int i, k;

    // Start is called before the first frame update

    private void Start()
    {
        heroStats = GameObject.Find("GameMgr").GetComponent<HeroStats>();
        prefabCnt = heroStats.dataLength;
        prefabList = new GameObject[prefabCnt];

        exist = new int[prefabCnt];
        for (int j = 0; j < exist.Length; j++)
        {
            exist[j] = -1;
        }
    }

    public void CreatePrefabs()
    {
        if (i == prefabCnt)
        {
            return;
        }
        bool isOver = false;
        index = Random.Range(0, prefabCnt);
        for (int j = 0; j < exist.Length; j++) 
        {
            if (index == exist[j])
            {
                isOver = true;
            }
        }

        if (isOver == true)
        {
            CreatePrefabs();
        }
        else // �ߺ��� �ƴϸ�
        {
            prefabList[i++] = Instantiate(prefab, gameObject.transform) as GameObject;
            exist[k++] = index;
        }

    }
}
