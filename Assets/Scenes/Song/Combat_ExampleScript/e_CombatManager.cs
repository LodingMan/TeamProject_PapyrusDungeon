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
        //�ϴ� �����Դٰ� �����Ѵ�. 
    }

    //������ ���۵Ǹ� �� ��ġ ���̺��� �������� �� �����;ߵ�. 
    //Dictionary�� �����Ѵٰ� �����Ѵٸ�, 1�������� �ϸ� ������, ���̷���, �������, 2�������� �ϸ� �ں�Ʈ , ��, ��� �̷��� 3���� �����λ�������ߵ�
    private void Start()
    {
        for (int i = 0; i < enemys.Length; i++)//�ϴ� �׳� �迭 �������°ɷ� �ϴµ� ���߿��� �� �迭�� ���� ��ġ ���̺� �ִ� ���� �����ͼ� ä������ �ȴٴ°�. 
        {
            Instantiate(enemys[i], new Vector3((i + 1) * 2, 0, 0), transform.rotation); //��ġ�� �ӽô�. 
        }

    }

    public void CombatStart() //������ ���۵Ǹ� ��� ������ �ӵ��� ���� �־�� �ϹǷ� 6ĭ ¥�� �迭�� ��� ������Ʈ�� �����ִ´�. 
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
        for (int i = speedComparisonArray.Length - 1; i > 0; i--) // ���� �������� ����
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
