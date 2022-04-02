using UnityEngine;
using System.Collections.Generic;

public class e_CombatManager : MonoBehaviour
{
    public List<GameObject> myParty = new List<GameObject>();
    public List<GameObject> CreateEnemyPool = new List<GameObject>();
    public List<GameObject> enemys = new List<GameObject>();

    public List<GameObject> speedComparisonArray = new List<GameObject>();

    public Song.HeroManager heroManager;
    public Song.GuildManager guildManager;

    public SkillActiveManager skillActiveManager;
    public Target_Panal_Script enemyTargetScript;

    public skill SaveSkill; //스킬 사용자의 스킬 저장
    public int currentActiveHeroIndex; //현재 스킬을 사용할 히어로가 몇번째에 위치하는지 


    int Damage;


    public List<skill> currentActiveSkillList = new List<skill>(); // 확인하려고 꺼내놓은것. 다쓰고 EnemySkillSelect에 다시 넣어놓을것.


    public void Init_Dungeon_Party()
    {
        //일단 가져왔다고 가정한다. 
    }



    //전투가 시작되면 적 배치 테이블에서 랜덤으로 적 가져와야됨. 
    //Dictionary로 관리한다고 가정한다면, 1번가져와 하면 슬라임, 스켈레톤, 웨어울프, 2번가져와 하면 코볼트 , 골렘, 고블린 이렇게 3마리 단위로생성해줘야됨
    private void Start()
    {
        for (int i = 0; i < CreateEnemyPool.Count; i++)//일단 그냥 배열 가져오는걸로 하는데 나중에는 이 배열이 몬스터 배치 테이블에 있는 값을 가져와서 채워져야 된다는것. 
        {
            enemys.Add(Instantiate(CreateEnemyPool[i], new Vector3((i + 1) * 2, 0, 0), transform.rotation)); //위치도 임시다.  이렇게 생성되는건 CombatStart에서 처리되어야 한다 start가 아니라. 
        }                                                                                                    //combatstart보다 enemyInit함수를 하나 파서 따로 처리하는게 맞는것 같다. 

    }

    public void TurnStart() //전투가 시작되면 모든 유닛의 속도를 비교해 주어야 하므로 6칸 짜리 배열에 모든 오브젝트를 때려넣는다. 
    {
        for (int i = 0; i < myParty.Count; i++)
        {
            if(myParty[i] != null)
            {
                speedComparisonArray.Add(myParty[i]);

            }

        }
        for (int j = 0; j < enemys.Count; j++)
        {

            if (enemys[j] != null)
            {
                speedComparisonArray.Add(enemys[j]);
            }
        }

        SpeedComparison();
    }

    public void SpeedComparison()
    {
        for (int i = speedComparisonArray.Count - 1; i > 0; i--) // 버블 오름차순 정렬
            for (int j = 0; j < i; j++)
                if (speedComparisonArray[j].GetComponent<StatScript>().myStat.Speed < speedComparisonArray[j + 1].GetComponent<StatScript>().myStat.Speed)
                    Swap(speedComparisonArray, j, j + 1);

        NextMove();

    }
// 여기까지 해서 적을 불러오고 가장 먼저 진행할 캐릭터가 정해지기까지 했다. 이제 배열의 순서대로 진행하기만 하면 된다. 

    public void NextMove() //배열의 가장 앞에있는놈의 행동 시작
    {
        if(speedComparisonArray.Count == 0)
        {
            TurnStart();
        }


        if (speedComparisonArray[0].tag == "Player")//플레이어라면
        {


            for (int i = 0; i<myParty.Count; i++)
            {
                if(myParty[i] == speedComparisonArray[0])
                {
                    currentActiveHeroIndex = i;

                }
            }
            skillActiveManager.GetComponent<RectTransform>().anchoredPosition = Camera.main.WorldToScreenPoint(speedComparisonArray[0].transform.position);  //터치 가능범위와 UI를 턴을 진행할 플레이어에게 옮겨주고
            //아웃라인 그려주고
            skillActiveManager.SkillActiveOn(speedComparisonArray[0].GetComponent<SkillScript>().mySkills); //스킬의 정보를 띄워줌
            //UI쪽에서 스킬창 띄워주고 드래그&드롭으로 saveSkill에 스킬 파라미터값 넣어줌

           
        }
        if (speedComparisonArray[0].tag == "Enemy")
        {
            Debug.Log("tset");

            for (int i = 0; i < enemys.Count; i++)
            {
                if (enemys[i] == speedComparisonArray[0])
                {
                    currentActiveHeroIndex = i; //스킬을 사용할 유닛의 위치번호
                    Debug.Log(i);

                }
            }

         EnemySkillSelect(speedComparisonArray[0]);


        }

    }

    public void EnemySkillSelect(GameObject target)
    {
        bool isListInitAgree = false;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (target.GetComponent<SkillScript>().mySkills[i].MyPosition[j] == currentActiveHeroIndex)
                {
                    currentActiveSkillList.Add(target.GetComponent<SkillScript>().mySkills[i]);
                }
            }
        }

        for(int i = 0; i < currentActiveSkillList.Count; i++) //일단 사용할 스킬 리스트만큼 반복
        {
            for(int j = 0; j <myParty.Count; j++) //해당 스킬의 EnemyPosition의 인덱스를 확인을 하는데 내 파티의 생존자 수만큼만 확인 (생존자가 1명이면 1번칸만 확인)
            {
                Debug.Log("Continue");

                if (currentActiveSkillList[i].EnemyPosition[j] == -1)
                {
                    continue;
                }
                else
                {
                    isListInitAgree = true;
                  //  target.GetComponent<SkillScript>().mySkills[i].EnemyPosition[j]
                }
            }
            if(!isListInitAgree)
            {
                currentActiveSkillList.RemoveAt(i);
            }
            else
            {
                isListInitAgree = false;
            }
        }
        // 이 위의 for문까지가 내가 사용할 수 있는 위치, 내가 사용할수 있는 스킬들중 범위내에 대상이 있는 스킬들을 찾아내 리스트 안에 담아놓은것. 
        // 이제 스킬을 골라야됨.
        if (currentActiveSkillList.Count == 0)
        {
            //아무튼 취소하는내용
        }

       SaveSkill = currentActiveSkillList[Random.Range(0, currentActiveSkillList.Count)];

    }


    public void SkillResultInit(GameObject target)
    {
        Damage += (SaveSkill.ATK + speedComparisonArray[0].GetComponent<StatScript>().myStat.Atk + 
            speedComparisonArray[0].GetComponent<EquipScript>().myEquip[0].Atk + speedComparisonArray[0].GetComponent<EquipScript>().myEquip[1].Atk);

        Damage -= target.GetComponent<StatScript>().myStat.Def;

        if (Random.Range(0, 100) < speedComparisonArray[0].GetComponent<StatScript>().myStat.Cri)
        {
            Damage += (int)(Damage/2);
            Debug.Log("Crit!");
        }

        if (Random.Range(0, speedComparisonArray[0].GetComponent<StatScript>().myStat.Acc) < target.GetComponent<StatScript>().myStat.Agi)
        {
            Debug.Log("회피!");
            Damage = 0;
        }

        target.GetComponent<StatScript>().myStat.HP -= Damage;
        Damage = 0;
        speedComparisonArray.RemoveAt(0);

        NextMove();

    }







    void Swap(List<GameObject> arr, int num1, int num2)
    {
        GameObject tmp = arr[num1];
        arr[num1] = arr[num2];
        arr[num2] = tmp;
    }

}
