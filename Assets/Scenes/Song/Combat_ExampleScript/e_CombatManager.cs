using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_CombatManager : MonoBehaviour
{
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    public Enemy_Stat_Table enemy_Stat_Table = new Enemy_Stat_Table();
    public Enemy_Sequence_Table enemy_Sequence_Table = new Enemy_Sequence_Table();
    public SKillTable sKillTable = new SKillTable();


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
    public GameObject CurrentCreateEnemy;

    public Vector3 FirstHeroCreatePos = new Vector3(-3000, 0, 0);
    public Vector3 FirstEnemyCreatePos = new Vector3(-2997, 0, 0);

    public bool isCombat;



    public List<skill> currentActiveSkillList = new List<skill>(); // Ȯ���Ϸ��� ����������. �پ��� EnemySkillSelect�� �ٽ� �־������.


    public void Init_Dungeon_Party()
    {
        for(int i = 0; i < 3; i++)
        {
            myParty.Add(guildManager.Party_Hero_Member[i]);

            
        }
        myParty[0].transform.position = FirstHeroCreatePos;
        myParty[0].transform.rotation = Quaternion.Euler(0, 90, 0);

        for (int i = 0; i < myParty.Count-1; i++)
        {
            myParty[i + 1].transform.position = FirstHeroCreatePos - new Vector3(1.5f * (i+1), 0, 0);
            myParty[i + 1].transform.rotation = Quaternion.Euler(0, 90, 0);
        }


    }



    //������ ���۵Ǹ� �� ��ġ ���̺��� �������� �� �����;ߵ�. 
    //Dictionary�� �����Ѵٰ� �����Ѵٸ�, 1�������� �ϸ� ������, ���̷���, �������, 2�������� �ϸ� �ں�Ʈ , ��, ��� �̷��� 3���� �����λ�������ߵ�

    public void EnemyInit()
    {
        isCombat = true;
        List<int> Sequence_Rnd = new List<int>();
        int SequenceSaveNumber = Random.Range(0, enemy_Sequence_Table.Enemy_Sequence.Count);

        for (int i = 0; i < enemy_Sequence_Table.Enemy_Sequence[SequenceSaveNumber].Length; i++)
        {
            Sequence_Rnd.Add(enemy_Sequence_Table.Enemy_Sequence[SequenceSaveNumber][i]);
        }


        int SkillNumber = 0;
        Debug.Log(Sequence_Rnd.Count);
        for(int i = 0; i < Sequence_Rnd.Count; i++)
        {
            switch (Sequence_Rnd[i])
            {
                case 0:
                    CurrentCreateEnemy = Instantiate(enemyPrefabs[0]);
                    CurrentCreateEnemy.GetComponent<StatScript>().myStat = enemy_Stat_Table.Enemys[Sequence_Rnd[i]];
                    SkillNumber = 0;
                    break;
                case 1:
                    CurrentCreateEnemy = Instantiate(enemyPrefabs[1]);
                    CurrentCreateEnemy.GetComponent<StatScript>().myStat = enemy_Stat_Table.Enemys[Sequence_Rnd[i]];
                    SkillNumber = 3;

                    break;
                case 2:
                    CurrentCreateEnemy = Instantiate(enemyPrefabs[2]);
                    CurrentCreateEnemy.GetComponent<StatScript>().myStat = enemy_Stat_Table.Enemys[Sequence_Rnd[i]];
                    SkillNumber = 6;

                    break;
                default:
                    break;
            }

            for(int j = 0; j < 3; j++)
            {
                CurrentCreateEnemy.GetComponent<SkillScript>().mySkills[j] = sKillTable.skillTable_Dictionary[SkillNumber + j + 100];
            }

            CurrentCreateEnemy.transform.position = FirstEnemyCreatePos + new Vector3(1.5f * i, 0, 0);
            CurrentCreateEnemy.transform.rotation = Quaternion.Euler(0, -90, 0);

            enemys.Add(CurrentCreateEnemy);

        }
        



  //      TurnStart();

    }
    public void TurnStart() //������ ���۵Ǹ� ��� ������ �ӵ��� ���� �־�� �ϹǷ� 6ĭ ¥�� �迭�� ��� ������Ʈ�� �����ִ´�. 
    {



        for (int i = 0; i < myParty.Count; i++)
        {
            if (myParty[i] != null)
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

        if(myParty.Count == 0)
        {
            isCombat = false;
            return;
        }
        else if(enemys.Count == 0)
        {
            isCombat = false;
            return;
        }

        SpeedComparison();
    }

    public void SpeedComparison()
    {
        Debug.Log("�ӵ����");
        for (int i = speedComparisonArray.Count - 1; i > 0; i--) // ���� �������� ����
            for (int j = 0; j < i; j++)
                if (speedComparisonArray[j].GetComponent<StatScript>().myStat.Speed < speedComparisonArray[j + 1].GetComponent<StatScript>().myStat.Speed)
                    Swap(speedComparisonArray, j, j + 1);

        NextMove();

    }
    // ������� �ؼ� ���� �ҷ����� ���� ���� ������ ĳ���Ͱ� ����������� �ߴ�. ���� �迭�� ������� �����ϱ⸸ �ϸ� �ȴ�. 

    public void NextMove() //�迭�� ���� �տ��ִ³��� �ൿ ����
    {
        if (speedComparisonArray.Count == 0)
        {
            TurnStart();
            return;
        }



        if (speedComparisonArray[0].tag == "Player")//�÷��̾���
        {


            for (int i = 0; i < myParty.Count; i++)
            {
                if (myParty[i] == speedComparisonArray[0])
                {
                    currentActiveHeroIndex = i;

                }
            }
            StartCoroutine(SkillUISetting());
        }
        if (speedComparisonArray[0].tag == "Enemy")
        {


            StartCoroutine(EnemyActive());




        }

    }

    public void EnemySkillSelect(GameObject target)
    {
        List<int> ListRemoveAgree = new List<int>();
        int FailCnt = 0;
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


        for (int i = 0; i < currentActiveSkillList.Count; i++) //�ϴ� ����� ��ų ����Ʈ��ŭ �ݺ�
        {

            for (int j = 0; j < myParty.Count; j++) //�ش� ��ų�� EnemyPosition�� �ε����� Ȯ���� �ϴµ� �� ��Ƽ�� ������ ����ŭ�� Ȯ�� (�����ڰ� 1���̸� 1��ĭ�� Ȯ��)
            {

                if (currentActiveSkillList[i].EnemyPosition[j] == -1)
                {
                    FailCnt++;
                }
            }
            if (FailCnt == myParty.Count)
            {
                ListRemoveAgree.Add(i);
            }
            FailCnt = 0;

        }

        for (int i = ListRemoveAgree.Count; i > 0; i--)
        {
            currentActiveSkillList.RemoveAt(ListRemoveAgree[i - 1]);
        }

        // �� ���� for�������� ���� ����� �� �ִ� ��ġ, ���� ����Ҽ� �ִ� ��ų���� �������� ����� �ִ� ��ų���� ã�Ƴ� ����Ʈ �ȿ� ��Ƴ�����.
        // ���� ��ų�� ���ߵ�.
        if (currentActiveSkillList.Count == 0) //����� ��ų�� ���ٸ�
        {
            //�ƹ�ư ����ϴ³���
        }

        SaveSkill = currentActiveSkillList[Random.Range(0, currentActiveSkillList.Count)];
        Debug.Log("����� ��ų ����! ��ų�� �̸��� " + SaveSkill.Name);

    }

    public void EnemySkillUse()
    {
        int UseIndex;
        while(true)
        {
            UseIndex = SaveSkill.EnemyPosition[Random.Range(0, (myParty.Count))];
            if (UseIndex == -1)
            {
                continue;
            }
            break;
        }

        SkillResultInit(myParty[UseIndex]);
        
        Debug.Log("��󿡰� ��ų ��� �Ϸ�! ����� " + myParty[UseIndex]);

    }




    public void SkillResultInit(GameObject target)
    {
        if(speedComparisonArray[0].tag == "Player")
        {
            Damage += (SaveSkill.ATK + speedComparisonArray[0].GetComponent<StatScript>().myStat.Atk +
                speedComparisonArray[0].GetComponent<EquipScript>().myEquip[0].Atk + speedComparisonArray[0].GetComponent<EquipScript>().myEquip[1].Atk);
        }
        else
        {
            Damage += (SaveSkill.ATK + speedComparisonArray[0].GetComponent<StatScript>().myStat.Atk);
        }

        if (speedComparisonArray[0].tag == "Player")
        {
            Damage -= target.GetComponent<StatScript>().myStat.Def;

        }
        else
        {
            Damage -= target.GetComponent<StatScript>().myStat.Def
                 + speedComparisonArray[0].GetComponent<EquipScript>().myEquip[0].Def + speedComparisonArray[0].GetComponent<EquipScript>().myEquip[1].Def;

        }


        if (Random.Range(0, 100) < speedComparisonArray[0].GetComponent<StatScript>().myStat.Cri)
        {
            Damage += (int)(Damage / 2);
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

    IEnumerator SkillUISetting()
    {
        yield return new WaitForSeconds(3);

        Debug.Log(speedComparisonArray[0] + " �� ��ųUI���");

        skillActiveManager.GetComponent<RectTransform>().anchoredPosition = Camera.main.WorldToScreenPoint(speedComparisonArray[0].transform.position);  //��ġ ���ɹ����� UI�� ���� ������ �÷��̾�� �Ű��ְ�
                                                                                                                                                         //�ƿ����� �׷��ְ�
        skillActiveManager.SkillActiveOn(speedComparisonArray[0].GetComponent<SkillScript>().mySkills); //��ų�� ������ �����
                                                                                                        //UI�ʿ��� ��ųâ ����ְ� �巡��&������� saveSkill�� ��ų �Ķ���Ͱ� �־���

    }

    IEnumerator EnemyActive()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("�ൿ�� ���� ��� ���� �Ϸ�");
        for (int i = 0; i < enemys.Count; i++)
        {
            if (enemys[i] == speedComparisonArray[0])
            {
                currentActiveHeroIndex = i; //��ų�� ����� ������ ��ġ��ȣ
                Debug.Log("�ൿ�� �����" + speedComparisonArray[0] + "�ε�����" + currentActiveHeroIndex);

            }
        }

        yield return new WaitForSeconds(3);
        EnemySkillSelect(speedComparisonArray[0]); //�� �Լ��� ȣ��ǰ� �� �ڿ��� SaveSkill�� Enemy�� ����� ��ų�� ����Ǿ��ִ�. 
        yield return new WaitForSeconds(3);
        
        EnemySkillUse();


    }
}
