using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHiredPrefabs : MonoBehaviour
{
    public GameObject prefab;
    public GameObject[] prefabList; //�̹� ���� ������ Info ����Ʈ
    int i = 0;
    public void CreatePrefabs() // ������ ������ �´� �Ű������� �ʿ��ϴ�. 
    {
        // ���� �ֱ�
        prefabList[i++] = Instantiate(prefab, gameObject.transform) as GameObject;
    }
}
