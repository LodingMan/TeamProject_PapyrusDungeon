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

    public skill SaveSkill; //��ų ������� ��ų ����
    public int currentActiveHeroIndex; //���� ��ų�� ����� ����ΰ� ���°�� ��ġ�ϴ��� 


    int Damage;


    public List<skill> currentActiveSkillList = new List<skill>(); // Ȯ���Ϸ��� ����������. �پ��� EnemySkillSelect�� �ٽ� �־������.


    public void Init_Dungeon_Party()
    {
        //�ϴ� �����Դٰ� �����Ѵ�. 
    }



    //������ ���۵Ǹ� �� ��ġ ���̺��� �������� �� �����;ߵ�. 
    //Dictionary�� �����Ѵٰ� �����Ѵٸ�, 1�������� �ϸ� ������, ���̷���, �������, 2�������� �ϸ� �ں�Ʈ , ��, ��� �̷��� 3���� �����λ�������ߵ�
    private void Start()
    {
        for (int i = 0; i < CreateEnemyPool.Count; i++)//�ϴ� �׳� �迭 �������°ɷ� �ϴµ� ���߿��� �� �迭�� ���� ��ġ ���̺� �ִ� ���� �����ͼ� ä������ �ȴٴ°�. 
        {
            enemys.Add(Instantiate(CreateEnemyPool[i], new Vector3((i + 1) * 2, 0, 0), transform.rotation)); //��ġ�� �ӽô�.  �̷��� �����Ǵ°� CombatStart���� ó���Ǿ�� �Ѵ� start�� �ƴ϶�. 
        }                                                                                                    //combatstart���� enemyInit�Լ��� �ϳ� �ļ� ���� ó���ϴ°� �´°� ����. 

    }

    public void TurnStart() //������ ���۵Ǹ� ��� ������ �ӵ��� ���� �־�� �ϹǷ� 6ĭ ¥�� �迭�� ��� ������Ʈ�� �����ִ´�. 
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
        for (int i = speedComparisonArray.Count - 1; i > 0; i--) // ���� �������� ����
            for (int j = 0; j < i; j++)
                if (speedComparisonArray[j].GetComponent<StatScript>().myStat.Speed < speedComparisonArray[j + 1].GetComponent<StatScript>().myStat.Speed)
                    Swap(speedComparisonArray, j, j + 1);

        NextMove();

    }
// ������� �ؼ� ���� �ҷ����� ���� ���� ������ ĳ���Ͱ� ����������� �ߴ�. ���� �迭�� ������� �����ϱ⸸ �ϸ� �ȴ�. 

    public void NextMove() //�迭�� ���� �տ��ִ³��� �ൿ ����
    {
        if(speedComparisonArray.Count == 0)
        {
            TurnStart();
        }


        if (speedComparisonArray[0].tag == "Player")//�÷��̾���
        {


            for (int i = 0; i<myParty.Count; i++)
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
        if (speedComparisonArray[0].tag == "Enemy")
        {
            Debug.Log("tset");

            for (int i = 0; i < enemys.Count; i++)
            {
                if (enemys[i] == speedComparisonArray[0])
                {
                    currentActiveHeroIndex = i; //��ų�� ����� ������ ��ġ��ȣ
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

        for(int i = 0; i < currentActiveSkillList.Count; i++) //�ϴ� ����� ��ų ����Ʈ��ŭ �ݺ�
        {
            for(int j = 0; j <myParty.Count; j++) //�ش� ��ų�� EnemyPosition�� �ε����� Ȯ���� �ϴµ� �� ��Ƽ�� ������ ����ŭ�� Ȯ�� (�����ڰ� 1���̸� 1��ĭ�� Ȯ��)
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
        // �� ���� for�������� ���� ����� �� �ִ� ��ġ, ���� ����Ҽ� �ִ� ��ų���� �������� ����� �ִ� ��ų���� ã�Ƴ� ����Ʈ �ȿ� ��Ƴ�����. 
        // ���� ��ų�� ���ߵ�.
        if (currentActiveSkillList.Count == 0)
        {
            //�ƹ�ư ����ϴ³���
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
            Debug.Log("ȸ��!");
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
