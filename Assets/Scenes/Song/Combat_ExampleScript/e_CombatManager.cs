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

    public skill SaveSkill; //��ų ������� ��ų ����
    public int currentActiveHeroIndex; //���� ��ų�� ����� ����ΰ� ���°�� ��ġ�ϴ��� 


    int Damage;

    public void Init_Dungeon_Party()
    {
        //�ϴ� �����Դٰ� �����Ѵ�. 
    }



    //������ ���۵Ǹ� �� ��ġ ���̺��� �������� �� �����;ߵ�. 
    //Dictionary�� �����Ѵٰ� �����Ѵٸ�, 1�������� �ϸ� ������, ���̷���, �������, 2�������� �ϸ� �ں�Ʈ , ��, ��� �̷��� 3���� �����λ�������ߵ�
    private void Start()
    {
        for (int i = 0; i < CreateEnemyPool.Length; i++)//�ϴ� �׳� �迭 �������°ɷ� �ϴµ� ���߿��� �� �迭�� ���� ��ġ ���̺� �ִ� ���� �����ͼ� ä������ �ȴٴ°�. 
        {
            enemys[i] = Instantiate(CreateEnemyPool[i], new Vector3((i + 1) * 2, 0, 0), transform.rotation); //��ġ�� �ӽô�.  �̷��� �����Ǵ°� CombatStart���� ó���Ǿ�� �Ѵ� start�� �ƴ϶�. 
        }

    }

    public void CombatStart() //������ ���۵Ǹ� ��� ������ �ӵ��� ���� �־�� �ϹǷ� 6ĭ ¥�� �迭�� ��� ������Ʈ�� �����ִ´�. 
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
        for (int i = speedComparisonArray.Length - 1; i > 0; i--) // ���� �������� ����
            for (int j = 0; j < i; j++)
                if (speedComparisonArray[j].GetComponent<StatScript>().myStat.Speed < speedComparisonArray[j + 1].GetComponent<StatScript>().myStat.Speed)
                    Swap(speedComparisonArray, j, j + 1);

        NextMove();

    }
// ������� �ؼ� ���� �ҷ����� ���� ���� ������ ĳ���Ͱ� ����������� �ߴ�. ���� �迭�� ������� �����ϱ⸸ �ϸ� �ȴ�. 

    public void NextMove() //�迭�� ���� �տ��ִ³��� �ൿ ����
    {

        if(speedComparisonArray[0].tag == "Player")//�÷��̾���
        {

            for(int i = 0; i<myParty.Length; i++)
            {
                if(myParty[i] == speedComparisonArray[0])
                {
                    currentActiveHeroIndex = i;

                }
            }
            skillActiveManager.GetComponent<RectTransform>().anchoredPosition = Camera.main.WorldToScreenPoint(speedComparisonArray[0].transform.position);  //��ġ ���ɹ����� UI�� ���� ������ �÷��̾�� �Ű��ְ�
            //�ƿ����� �׷��ְ�
            skillActiveManager.SkillActiveOn(speedComparisonArray[0].GetComponent<SkillScript>().mySkills); //��ų�� ������ �����
            //UI�ʿ��� ��ųâ ����ְ� �巡��&������� saveSkill�� ��ų �Ķ���Ͱ� �־���
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
            Debug.Log("ȸ��!");
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
