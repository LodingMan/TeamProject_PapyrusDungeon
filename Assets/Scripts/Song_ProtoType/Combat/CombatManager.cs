using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    public GameObject[] Players = new GameObject[3];
    public GameObject[] Enemys = new GameObject[3];

    public List<GameObject> testEnemyPool;
    public List<GameObject> testSkillPool;

    public List<GameObject> activeOrder;

    public GameObject UnitArrow;

    public int SaveSkillNumber;

    public GameObject SelectButton;

    //�� ��ų ��ư 3���� Csv�� ����� ��ų������ �����;ߵ�, ���ڸ� �����ؼ�.
    public GameObject[] SkillBtn = new GameObject[3];

    public int ActiveUnitIndex = 0;

    public int turn = 0;

    public int[] csvExample = { 0, 1, 2 };

    public int[] skillLength = { 1, 3 };
    void Start()
    {
        EnemyListInit(csvExample);
        for(int i = 0; i < testSkillPool.Count; i++)
        {
            testSkillPool[i].SetActive(false);
        }

        // ������� CombatStart�� �ڵ����� ����
    }

    public void CombatStart()
    {
        speedSetting();

        firstSelect();

    }

    public void EnemyListInit(int[] enemys)
    {
        for (int i = 0; i < 3; i++)
        {
            switch (enemys[i])
            {
                case 0:
                    Enemys[i] = testEnemyPool[0];
                    break;
                case 1:
                    Enemys[i] = testEnemyPool[1];
                    break;
                case 2:
                    Enemys[i] = testEnemyPool[2];

                    break;
                case 3:

                    break;
                default:
                    break;
            }
        }
    }

    public void SkillListInit(int[] skills)
    {
        for (int i = 0; i < 3; i++)
        {
            switch (skills[i])
            {
                case 0:
                    SkillBtn[i] = testSkillPool[0];
                    break;
                case 1:
                    SkillBtn[i] = testSkillPool[1];
                    break;
                case 2:
                    SkillBtn[i] = testSkillPool[2];

                    break;
                case 3:

                    break;
                default:
                    break;
            }
        }
    }

    public void speedSetting()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (i == 0)
                {
                    activeOrder.Add(Players[j]);
                }
                else
                {
                    activeOrder.Add(Enemys[j]);
                }
            }
        }


        for (int i = activeOrder.Count - 1; i > 0; i--) // ���� �������� ����
            for (int j = 0; j < i; j++)
            {
                if(activeOrder[j].GetComponent<UnitSatus>().speed < activeOrder[j + 1].GetComponent<UnitSatus>().speed)
                {
                    Swap(activeOrder, j, j + 1);
                }
            }


    }


    public void firstSelect()
    {
        turn++;
        Debug.Log("ù��° �����Դϴ� :::" + activeOrder[ActiveUnitIndex].name);
        UnitArrow.transform.position = activeOrder[ActiveUnitIndex].transform.position + new Vector3(0, 2, 0);

        //�̰� �ƴ϶� ���� �����簡 ������ �ִ� ��ų �����͸� �־��ִ°� �´µ� �ϴ�. 
        // activeOrder[ActiveUnityIndex]�� Mage��ũ��Ʈ���� ��ų�� �����;� �Ѵٴ� ���̴�. 
        // ��ų�� �����Դٸ� ������ �ؾ� �ϴµ� SkillBtn�� MageSkillActive ����� �ִµ� 
        // �ش� ��ų�� ����� �÷��̾��� �������ͽ��� ������ �ִ�. 
        // ��ų�� ����ϱ����� �÷��̾��� ���ݷ� ��ų�� ���, ���� ������ �� ����ؼ� ���� ����. 
        // ��ų�� ���Ǹ� �ش� ���� ������� ������ ������ �����Ų��. 
        // ��ų�� ���Ƿ��� ���� �����ؾ� �ϴµ� MageKillActive�� ȣ��Ǹ� ���� Ŭ���� �� �ֵ��� ��ų�� ���� ���� �����ϴ� ����� Ŭ�� ���� Bool���� true�� �������ش�.
        // Ȥ�� EventTrigger�� Ȱ��ȭ �����ش�. 
        // �׸��� ���� Ŭ���ϸ� MageSkillUse�Լ��� ȣ��ȴ�. 
        // �̷��� �Ƿ��� �׳� ���⿡�ٰ� SkillActive���� �Լ� �ϳ� ���� ����� �����ϰ� �� �� ���� Ŭ���ϸ� MageSkillActive�� ���Ǽ� ������� ������ �����Ű�� �ǰڴ�. 

        SkillListInit(activeOrder[ActiveUnitIndex].GetComponent<MageScript>().skillCsvExample);

        //ù��° ������ ��ų UI Ȱ��ȭ
        foreach (GameObject skillbtn in SkillBtn) skillbtn.SetActive(true);

        Debug.Log(activeOrder[ActiveUnitIndex] + "�� ��ų�� �����ϼ���");

        //���Ŀ� ��ų ��ư ������ ��� ����â ��µ�

    }

    public void SaveSkill()
    {
        SaveSkillNumber = activeOrder[ActiveUnitIndex].GetComponent<MageScript>().skillCsvExample[1];
        Debug.Log("����� ������ �ּ���");
        
        for(int i = 0; i < 3; i++)
        {
            foreach (int skill in skillLength)
            {
                if (skill == i)
                {
                    Enemys[i].GetComponent<EnemyScript>().SelectChild.SetActive(true);
                }
             }
        }
      

    }
    //csv���ڷ� �ش� ��ų�� ������ �������� �Լ� �ʿ�. 

    public void SkillUse()
    {
        Debug.Log(activeOrder[ActiveUnitIndex] + "�� ��ų�ߵ�!");
    }



    void Swap(List<GameObject> arr, int num1, int num2)
    {
        GameObject tmp = arr[num1];
        arr[num1] = arr[num2];
        arr[num2] = tmp;
    }


}
