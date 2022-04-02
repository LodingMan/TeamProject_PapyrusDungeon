using UnityEngine;

public class e_CombatManager : MonoBehaviour
{
    public GameObject[] myParty = new GameObject[3];
    public GameObject[] CreateEnemyPool = new GameObject[3];
    public GameObject[] enemys = new GameObject[3];

    public GameObject[] speedComparisonArray = new GameObject[6];

    public Song.HeroManager heroManager;
    public Song.GuildManager guildManager;

    public SkillActiveManager skillActiveManager;
    public Target_Panal_Script enemyTargetScript;

    public skill SaveSkill; //스킬 사용자의 스킬 저장
    public int currentActiveHeroIndex; //현재 스킬을 사용할 히어로가 몇번째에 위치하는지 


    int Damage;

    public void Init_Dungeon_Party()
    {
        //일단 가져왔다고 가정한다. 
    }



    //전투가 시작되면 적 배치 테이블에서 랜덤으로 적 가져와야됨. 
    //Dictionary로 관리한다고 가정한다면, 1번가져와 하면 슬라임, 스켈레톤, 웨어울프, 2번가져와 하면 코볼트 , 골렘, 고블린 이렇게 3마리 단위로생성해줘야됨
    private void Start()
    {
        for (int i = 0; i < CreateEnemyPool.Length; i++)//일단 그냥 배열 가져오는걸로 하는데 나중에는 이 배열이 몬스터 배치 테이블에 있는 값을 가져와서 채워져야 된다는것. 
        {
            enemys[i] = Instantiate(CreateEnemyPool[i], new Vector3((i + 1) * 2, 0, 0), transform.rotation); //위치도 임시다.  이렇게 생성되는건 CombatStart에서 처리되어야 한다 start가 아니라. 
        }

    }

    public void CombatStart() //전투가 시작되면 모든 유닛의 속도를 비교해 주어야 하므로 6칸 짜리 배열에 모든 오브젝트를 때려넣는다. 
    {
        for (int i = 0; i < myParty.Length; i++)
        {
            speedComparisonArray[i] = myParty[i];

        }
        for (int j = 0; j < 3; j++)
        {
            speedComparisonArray[j+3] = enemys[j];
        }

        SpeedComparison();
    }

    public void SpeedComparison()
    {
        for (int i = speedComparisonArray.Length - 1; i > 0; i--) // 버블 오름차순 정렬
            for (int j = 0; j < i; j++)
                if (speedComparisonArray[j].GetComponent<StatScript>().myStat.Speed < speedComparisonArray[j + 1].GetComponent<StatScript>().myStat.Speed)
                    Swap(speedComparisonArray, j, j + 1);

        NextMove();

    }
// 여기까지 해서 적을 불러오고 가장 먼저 진행할 캐릭터가 정해지기까지 했다. 이제 배열의 순서대로 진행하기만 하면 된다. 

    public void NextMove() //배열의 가장 앞에있는놈의 행동 시작
    {

        if(speedComparisonArray[0].tag == "Player")//플레이어라면
        {

            for(int i = 0; i<myParty.Length; i++)
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
    }

    public void SkillResultInit(GameObject target)
    {
        Debug.Log("Result");
        Damage += (SaveSkill.ATK + speedComparisonArray[0].GetComponent<StatScript>().myStat.Atk + 
            speedComparisonArray[0].GetComponent<EquipScript>().myEquip[0].Atk + speedComparisonArray[0].GetComponent<EquipScript>().myEquip[1].Atk);

        Damage -= target.GetComponent<StatScript>().myStat.Def;

        if(Random.Range(0, speedComparisonArray[0].GetComponent<StatScript>().myStat.Acc) < target.GetComponent<StatScript>().myStat.Agi)
        {
            Debug.Log("회피!");
            return;
        }
        if (Random.Range(0, 100) < speedComparisonArray[0].GetComponent<StatScript>().myStat.Cri)
        {
            Damage += (int)(Damage/2);
            Debug.Log("Crit!");
        }

        target.GetComponent<StatScript>().myStat.HP -= Damage;
        Damage = 0;
    }







    void Swap(GameObject[] arr, int num1, int num2)
    {
        GameObject tmp = arr[num1];
        arr[num1] = arr[num2];
        arr[num2] = tmp;
    }

}
