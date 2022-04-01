using UnityEngine;

public class e_CombatManager : MonoBehaviour
{
    public GameObject[] myParty = new GameObject[3];
    public GameObject[] enemys = new GameObject[3];

    public Stat[] speedComparisonArray = new Stat[6];
    public Song.HeroManager heroManager;
    public Song.GuildManager guildManager;

    public void Init_Dungeon_Party()
    {
        //일단 가져왔다고 가정한다. 
    }

    //전투가 시작되면 적 배치 테이블에서 랜덤으로 적 가져와야됨. 
    //Dictionary로 관리한다고 가정한다면, 1번가져와 하면 슬라임, 스켈레톤, 웨어울프, 2번가져와 하면 코볼트 , 골렘, 고블린 이렇게 3마리 단위로생성해줘야됨
    private void Start()
    {
        for (int i = 0; i < enemys.Length; i++)//일단 그냥 배열 가져오는걸로 하는데 나중에는 이 배열이 몬스터 배치 테이블에 있는 값을 가져와서 채워져야 된다는것. 
        {
            Instantiate(enemys[i], new Vector3((i + 1) * 2, 0, 0), transform.rotation); //위치도 임시다. 
        }

    }

    public void CombatStart() //전투가 시작되면 모든 유닛의 속도를 비교해 주어야 하므로 6칸 짜리 배열에 모든 오브젝트를 때려넣는다. 
    {
        for (int i = 0; i < myParty.Length; i++)
        {
            speedComparisonArray[i] = myParty[i].GetComponent<StatScript>().myStat;

        }
        for (int j = 0; j < 3; j++)
        {
            speedComparisonArray[j+3] = enemys[j].GetComponent<StatScript>().myStat;
        }

        SpeedComparison();
    }

    public void SpeedComparison()
    {
        for (int i = speedComparisonArray.Length - 1; i > 0; i--) // 버블 오름차순 정렬
            for (int j = 0; j < i; j++)
                if (speedComparisonArray[j].Speed < speedComparisonArray[j + 1].Speed)
                    Swap(speedComparisonArray, j, j + 1);
    }

    void Swap(Stat[] arr, int num1, int num2)
    {
        Stat tmp = arr[num1];
        arr[num1] = arr[num2];
        arr[num2] = tmp;
    }

}
