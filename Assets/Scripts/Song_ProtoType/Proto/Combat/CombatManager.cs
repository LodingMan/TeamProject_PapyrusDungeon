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

    //이 스킬 버튼 3개가 Csv에 저장된 스킬셋으로 가져와야됨, 숫자를 참조해서.
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

        // 원래라면 CombatStart가 자동으로 실행
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


        for (int i = activeOrder.Count - 1; i > 0; i--) // 버블 오름차순 정렬
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
        Debug.Log("첫번째 유닛입니다 :::" + activeOrder[ActiveUnitIndex].name);
        UnitArrow.transform.position = activeOrder[ActiveUnitIndex].transform.position + new Vector3(0, 2, 0);

        //이게 아니라 현재 마법사가 가지고 있는 스킬 데이터를 넣어주는게 맞는듯 하다. 
        // activeOrder[ActiveUnityIndex]의 Mage스크립트에서 스킬을 가져와야 한다는 것이다. 
        // 스킬을 가져왔다면 연산을 해야 하는데 SkillBtn에 MageSkillActive 기능이 있는데 
        // 해당 스킬의 계수는 플레이어의 스테이터스와 연관이 있다. 
        // 스킬을 사용하기전에 플레이어의 공격력 스킬의 계수, 적의 방어력을 잘 계산해서 값을 낸다. 
        // 스킬이 사용되면 해당 값을 대상으로 지정한 적에게 적용시킨다. 
        // 스킬이 사용되려면 적을 지정해야 하는데 MageKillActive가 호출되면 적을 클릭할 수 있도록 스킬에 범위 내에 존재하는 대상의 클릭 가능 Bool값을 true로 변경해준다.
        // 혹은 EventTrigger를 활성화 시켜준다. 
        // 그리고 적을 클릭하면 MageSkillUse함수가 호출된다. 
        // 이렇게 되려면 그냥 여기에다가 SkillActive같은 함수 하나 만들어서 대상을 선택하게 한 뒤 적을 클릭하면 MageSkillActive가 사용되서 결과값을 적에게 적용시키면 되겠다. 

        SkillListInit(activeOrder[ActiveUnitIndex].GetComponent<MageScript>().skillCsvExample);

        //첫번째 유닛의 스킬 UI 활성화
        foreach (GameObject skillbtn in SkillBtn) skillbtn.SetActive(true);

        Debug.Log(activeOrder[ActiveUnitIndex] + "의 스킬을 선택하세요");

        //이후에 스킬 버튼 누르면 대상 선택창 출력됨

    }

    public void SaveSkill()
    {
        SaveSkillNumber = activeOrder[ActiveUnitIndex].GetComponent<MageScript>().skillCsvExample[1];
        Debug.Log("대상을 지정해 주세요");
        
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
    //csv숫자로 해당 스킬의 정보를 가져오는 함수 필요. 

    public void SkillUse()
    {
        Debug.Log(activeOrder[ActiveUnitIndex] + "의 스킬발동!");
    }



    void Swap(List<GameObject> arr, int num1, int num2)
    {
        GameObject tmp = arr[num1];
        arr[num1] = arr[num2];
        arr[num2] = tmp;
    }


}
