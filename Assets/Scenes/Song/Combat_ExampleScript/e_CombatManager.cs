using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_CombatManager : MonoBehaviour
{
    public List<GameObject> enemyPrefabs = new List<GameObject>();  //랜덤으로 생성될 에너미 종류
    public Enemy_Stat_Table enemy_Stat_Table = new Enemy_Stat_Table();  // 에너미 프리펩에 맞는 에너미 스텟 부여
    public Enemy_Sequence_Table enemy_Sequence_Table = new Enemy_Sequence_Table(); //에너미 배치를 정해주는 테이블
    public SKillTable sKillTable = new SKillTable(); //스킬테이블


    public List<GameObject> myParty = new List<GameObject>(); //GuildManager에서 가져온 PartyHero를 담은 배열
    //public List<GameObject> CreateEnemyPool = new List<GameObject>(); //
    public List<GameObject> enemys = new List<GameObject>(); //생성한 에너미 3마리가 들어감. 

    public List<GameObject> speedComparisonArray = new List<GameObject>(); //속도계산 배열 해당 리스트의 0번째가 현재 행동중인 유닛

    public Song.HeroManager heroManager;
    public Song.GuildManager guildManager;
    public Combat_Event_UI_Manager combat_Event_UI_Manager;
    public Target_Panal_Script target_Panal_Script;
    public Combat_Effect_Manager combat_Effect_Manager;
    public SkillActiveManager skillActiveManager;
    public Target_Panal_Script enemyTargetScript;

    public skill SaveSkill; //스킬 사용자의 스킬 저장
    public int currentActiveUnitIndex; //현재 스킬을 사용할 히어로가 몇번째에 위치하는지 

    public Camera CombatCamera;
    public Canvas CombatCanvas;
    public Canvas Skill_Targeting_Canvas;
    public Transform CanvasTransform;


    int Damage; //총 합산 데미지
    public GameObject CurrentCreateEnemy;

    public Vector3 FirstHeroCreatePos = new Vector3(-3000, 0, 0);
    public Vector3 FirstEnemyCreatePos = new Vector3(-2997, 0, 0);

    public bool isCombat;

    public List<skill> currentActiveSkillList = new List<skill>(); // 확인하려고 꺼내놓은것. 다쓰고 EnemySkillSelect에 다시 넣어놓을것.

    public PostProcessingController ppCon; // ����Ʈ ���μ��� ��Ʈ�ѷ�

    Ray ray;
    RaycastHit hit;

    private void Update()
    {
        if (CombatCamera.gameObject.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = CombatCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray.origin, ray.direction, out hit))
                {
                    switch(hit.transform.gameObject.name)
                    {
                        case "Skill1": skillActiveManager.Skill1();
                            break;
                        case "Skill2": skillActiveManager.Skill2();
                            break;
                        case "Skill3": skillActiveManager.Skill3();
                            break;
                        case "None": skillActiveManager.SkillNone();
                            break;

                        case "Target1":
                            hit.transform.gameObject.GetComponent<DOTweenAnimation>().DORestart();
                            StartCoroutine(HeroAttackDlay(hit.transform.gameObject.GetComponent<Enemy_Target_Script>().This_TargetObject));
                            break;
                        case "Target2":
                            hit.transform.gameObject.GetComponent<DOTweenAnimation>().DORestart();
                            StartCoroutine(HeroAttackDlay(hit.transform.gameObject.GetComponent<Enemy_Target_Script>().This_TargetObject));
                            break;
                        case "Target3":
                            hit.transform.gameObject.GetComponent<DOTweenAnimation>().DORestart();
                            StartCoroutine(HeroAttackDlay(hit.transform.gameObject.GetComponent<Enemy_Target_Script>().This_TargetObject));
                            break;
                        default:
                            break;
                    }

                    

                    Debug.Log(hit.transform.gameObject.name);
                }
            }
        }

    }


    public void Init_Dungeon_Party()
    {
        for (int i = 0; i < 3; i++)
        {
            myParty.Add(guildManager.Party_Hero_Member[i]);


        }
        myParty[0].transform.position = FirstHeroCreatePos;
        myParty[0].transform.rotation = Quaternion.Euler(0, 90, 0);

        for (int i = 0; i < myParty.Count - 1; i++)
        {
            myParty[i + 1].transform.position = FirstHeroCreatePos - new Vector3(1.5f * (i + 1), 0, 0);
            myParty[i + 1].transform.rotation = Quaternion.Euler(0, 90, 0);
        }


    }
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
        for (int i = 0; i < Sequence_Rnd.Count; i++)
        {

            switch (Sequence_Rnd[i])
            {
                case 0:
                    CurrentCreateEnemy = Instantiate(enemyPrefabs[0]);

                    CurrentCreateEnemy.GetComponent<StatScript>().myStat = new Stat(enemy_Stat_Table.Enemys[Sequence_Rnd[i]]);
                    SkillNumber = 0;
                    break;
                case 1:
                    CurrentCreateEnemy = Instantiate(enemyPrefabs[1]);

                    CurrentCreateEnemy.GetComponent<StatScript>().myStat = new Stat(enemy_Stat_Table.Enemys[Sequence_Rnd[i]]);
                    SkillNumber = 3;

                    break;
                case 2:
                    CurrentCreateEnemy = Instantiate(enemyPrefabs[2]);

                    CurrentCreateEnemy.GetComponent<StatScript>().myStat = new Stat(enemy_Stat_Table.Enemys[Sequence_Rnd[i]]);
                    SkillNumber = 6;

                    break;
                default:
                    break;
            }

            for (int j = 0; j < 3; j++)
            {
                CurrentCreateEnemy.GetComponent<SkillScript>().mySkills[j] = sKillTable.skillTable_Dictionary[SkillNumber + j + 100];
            }

            CurrentCreateEnemy.transform.position = FirstEnemyCreatePos + new Vector3(1.5f * i, 0, 0);
            CurrentCreateEnemy.transform.rotation = Quaternion.Euler(0, -90, 0);

            enemys.Add(CurrentCreateEnemy);

        }




        TurnStart();

    }
    public void TurnStart() //전투가 시작되면 모든 유닛의 속도를 비교해 주어야 하므로 6칸 짜리 배열에 모든 오브젝트를 때려넣는다. 
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

        if (myParty.Count == 0)
        {
            isCombat = false;
            return;
        }
        else if (enemys.Count == 0)
        {
            isCombat = false;
            return;
        }

        SpeedComparison();
    }

    public void SpeedComparison()
    {
        Debug.Log("속도계산");
        for (int i = speedComparisonArray.Count - 1; i > 0; i--) // 버블 오름차순 정렬
            for (int j = 0; j < i; j++)
                if (speedComparisonArray[j].GetComponent<StatScript>().myStat.Speed < speedComparisonArray[j + 1].GetComponent<StatScript>().myStat.Speed)
                    Swap(speedComparisonArray, j, j + 1);

        NextMove();

    }
    // 여기까지 해서 적을 불러오고 가장 먼저 진행할 캐릭터가 정해지기까지 했다. 이제 배열의 순서대로 진행하기만 하면 된다. 

    public void NextMove() //배열의 가장 앞에있는놈의 행동 시작
    {
        if (speedComparisonArray.Count == 0)
        {
            TurnStart();
            return;
        }



        if (speedComparisonArray[0].tag == "Player")//플레이어라면
        {


            for (int i = 0; i < myParty.Count; i++)
            {
                if (myParty[i] == speedComparisonArray[0])
                {
                    currentActiveUnitIndex = i;

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
                if (target.GetComponent<SkillScript>().mySkills[i].MyPosition[j] == currentActiveUnitIndex)
                {
                    currentActiveSkillList.Add(target.GetComponent<SkillScript>().mySkills[i]);
                }
            }
        }


        for (int i = 0; i < currentActiveSkillList.Count; i++) //일단 사용할 스킬 리스트만큼 반복
        {

            for (int j = 0; j < myParty.Count; j++) //해당 스킬의 EnemyPosition의 인덱스를 확인을 하는데 내 파티의 생존자 수만큼만 확인 (생존자가 1명이면 1번칸만 확인)
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

        // 이 위의 for문까지가 내가 사용할 수 있는 위치, 내가 사용할수 있는 스킬들중 범위내에 대상이 있는 스킬들을 찾아내 리스트 안에 담아놓은것.
        // 이제 스킬을 골라야됨.
        if (currentActiveSkillList.Count == 0) //사용할 스킬이 없다면
        {
            //아무튼 취소하는내용
        }

        SaveSkill = currentActiveSkillList[Random.Range(0, currentActiveSkillList.Count)];


        combat_Event_UI_Manager.EnemySkillNameText.enabled = true;
        combat_Event_UI_Manager.EnemySkillNameText.text = SaveSkill.Name;
        combat_Event_UI_Manager.EnemySkillNameText.GetComponent<DOTweenAnimation>().DORestart();
        Debug.Log("사용할 스킬 결정! 스킬의 이름은 " + SaveSkill.Name);

    }

    public void EnemySkillUse()
    {
        int UseIndex;
        while (true)
        {
            UseIndex = SaveSkill.EnemyPosition[Random.Range(0, (myParty.Count))];
            if (UseIndex == -1)
            {
                continue;
            }
            break;
        }


        Debug.Log("대상에게 스킬 사용 완료! 대상은 " + myParty[UseIndex]);
        //여기서 사용할 대상 이미지 출력
        combat_Event_UI_Manager.Player_Targeting.SetActive(true);
        combat_Event_UI_Manager.Player_Targeting.transform.position = myParty[UseIndex].transform.position + new Vector3(0, 1.7f, 0);
        combat_Event_UI_Manager.Player_Targeting.GetComponent<DOTweenAnimation>().DORestart();
        StartCoroutine(EnemyAttack(UseIndex));


    }




    public void SkillResultInit(GameObject target)
    {
        if (speedComparisonArray[0].tag == "Player")
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
                 + target.GetComponent<EquipScript>().myEquip[0].Def + target.GetComponent<EquipScript>().myEquip[1].Def;

        }


        if (Random.Range(0, 100) < speedComparisonArray[0].GetComponent<StatScript>().myStat.Cri)
        {
            Damage += (int)(Damage / 2);
            Debug.Log("Crit!");
        }

        if (Random.Range(0, speedComparisonArray[0].GetComponent<StatScript>().myStat.Acc) < target.GetComponent<StatScript>().myStat.Agi)
        {
            Debug.Log("회피!");
            Damage = 0;
        }

        target.GetComponent<StatScript>().myStat.HP -= Damage;

        if (target.GetComponent<StatScript>().myStat.HP <= 0)
        {
            int destroyIdx = 0;

            if (target.tag == "Enemy")
            {
                //currentActiveHeroIndex가 아니라 타겟이 된 Enemy의 인덱스 번호가 필요하다.
                for (int i = 0; i < enemys.Count; i++)
                {
                    if (enemys[i] == target)
                    {
                        destroyIdx = i;
                    }
                }

                for (int i = destroyIdx + 1; i < enemys.Count; i++)
                {
                    enemys[i].transform.DOMove(FirstEnemyCreatePos + new Vector3((-1.5f * (i-1)), 0, 0), 1);
                    Debug.Log(enemys[i] + "이동함");
                }
                for (int i = 0; i < speedComparisonArray.Count; i++)
                    if (speedComparisonArray[i] == target) speedComparisonArray.Remove(target);


                enemys.Remove(target);
                Destroy(target);
                if (enemys.Count == 0)
                {
                    speedComparisonArray.Clear();
                    isCombat = false;
                    InGame_Player_Script IP = GameObject.Find("InGamePlayer").GetComponent<InGame_Player_Script>();
                    IP.isMove = true;


                    return;
                }
            }
            if (target.tag == "Player")
            {
                for (int i = 0; i < myParty.Count; i++)
                {
                    if (myParty[i] == target)
                    {
                        destroyIdx = i;
                    }
                }

                for (int i = destroyIdx + 1; i < myParty.Count; i++)
                {
                    myParty[i].transform.DOMove(FirstHeroCreatePos + new Vector3((-1.5f * (i-1)), 0, 0), 1);
                }
                for (int i = 0; i < speedComparisonArray.Count; i++)
                    if (speedComparisonArray[i] == target) speedComparisonArray.Remove(target);



                myParty.Remove(target);
                heroManager.CurrentHeroList.Remove(target);
                Destroy(target);
            }
        }


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

        GameObject textobj = GameObject.Find("Combat_Event_UI_Manger");
        textobj.GetComponent<Combat_Event_UI_Manager>().TextClear();

        Debug.Log(speedComparisonArray[0] + " 의 스킬UI출력");
        //skillActiveManager.GetComponent<RectTransform>().anchoredPosition = CombatCamera.WorldToScreenPoint(speedComparisonArray[0].transform.position);
        //skillActiveManager.transform.position = new Vector3(0, 1.75f, 0);
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        combat_Event_UI_Manager.CurrentAttack_Move();


        skillActiveManager.SkillActiveOn(speedComparisonArray[0].GetComponent<SkillScript>().mySkills); //스킬의 정보를 띄워줌
                                                                                                        //UI쪽에서 스킬창 띄워주고 드래그&드롭으로 saveSkill에 스킬 파라미터값 넣어줌

    }

    IEnumerator EnemyActive()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("행동할 유딧 대상 지정 완료");
        for (int i = 0; i < enemys.Count; i++)
        {
            if (enemys[i] == speedComparisonArray[0])
            {
                currentActiveUnitIndex = i; //스킬을 사용할 유닛의 위치번호
                Debug.Log("행동할 대상은" + speedComparisonArray[0] + "인덱스는" + currentActiveUnitIndex);

                combat_Event_UI_Manager.CurrentAttack_Move();
                break;
            }
        }

        yield return new WaitForSeconds(3);
        EnemySkillSelect(speedComparisonArray[0]); //이 함수가 호출되고 난 뒤에는 SaveSkill에 Enemy가 사용할 스킬이 저장되어있다. 
        yield return new WaitForSeconds(3);

        EnemySkillUse();


    }

    IEnumerator EnemyAttack(int target_Idx)
    {
        yield return new WaitForSeconds(2);
        combat_Event_UI_Manager.EnemySkillNameText.enabled = false;
        combat_Event_UI_Manager.Player_Targeting.SetActive(false);
        combat_Event_UI_Manager.Current_Attack_Unit.gameObject.SetActive(false);


        Vector3 EnemyPos = speedComparisonArray[0].transform.position;
        Vector3 HeroPos = myParty[target_Idx].transform.position;

        //for(int i = 0; i < speedComparisonArray.Count; i++)
        //{
        //    speedComparisonArray[i].SetActive(false);
        //}
        //    speedComparisonArray[0].SetActive(true);
        //    myParty[target_Idx].SetActive(true);

        speedComparisonArray[0].transform.position = new Vector3(-2997.85f, 0, -3.12f);

        myParty[target_Idx].transform.position = new Vector3(-2999.58f, 0, -3.12f);


        speedComparisonArray[0].transform.DOMove(speedComparisonArray[0].transform.position - new Vector3(0.8f, 0, 0), 3f);
        myParty[target_Idx].transform.DOMove(myParty[target_Idx].transform.position - new Vector3(0.8f, 0, 0), 3f);
        myParty[target_Idx].transform.GetChild(0).GetComponent<Animator>().SetInteger("herostate", 1000);
        ppCon.DepthOfFieldOnOff(ppCon); // 전투 시 블러 처리 yoon
        combat_Effect_Manager.HitLight.enabled = true;
        yield return new WaitForSeconds(4);
        myParty[target_Idx].transform.GetChild(0).GetComponent<Animator>().SetInteger("herostate", 998);
        ppCon.DepthOfFieldOnOff(ppCon); // 블러 끄기
        speedComparisonArray[0].transform.position = EnemyPos;
        myParty[target_Idx].transform.position = HeroPos;

        combat_Effect_Manager.HitLight.enabled = false;

        SkillResultInit(myParty[target_Idx]);




        // speedComparisonArray[0].transform.DOMove()

        //speedComparisonArray[0]위치 저장
        //myParty[target_Idx] 위치저장
        //speedComparisonArray전부 오브젝트 비활성화 

        //speedComparisonArray[0]위치 변경 
        //myParty[target_Idx] 위치변경 
        //Tween으로 무빙

        //오브젝트 전부 활성화
        //위치 바꿨던 놈들 제자리 


        //여기에 적이 공격하는 애니메이션 입력해주면 됨. 
    }
    public IEnumerator HeroAttackDlay(GameObject target)
    {
        //여기부터 공격을 시작한 히어로의 움직임
        yield return new WaitForSeconds(0.5f);
        combat_Event_UI_Manager.Current_Attack_Unit.gameObject.SetActive(false);

        target_Panal_Script.TargetAllOff();

        Vector3 HeroPos = speedComparisonArray[0].transform.position;
        Vector3 EnemyPos = target.transform.position;


        speedComparisonArray[0].transform.position = new Vector3(-2999.58f, 0, -3.12f);

        target.transform.position = new Vector3(-2997.85f, 0, -3.12f);


        speedComparisonArray[0].transform.DOMove(speedComparisonArray[0].transform.position - new Vector3(-0.8f, 0, 0), 3f);
        target.transform.DOMove(target.transform.position - new Vector3(-0.8f, 0, 0), 3f);
        combat_Effect_Manager.HitLight.enabled = true;
        ppCon.DepthOfFieldOnOff(ppCon); // 전투 시 블러 처리 yoon
        speedComparisonArray[0].transform.GetChild(0).GetComponent<Animator>().SetInteger("herostate", SaveSkill.Index); // 스킬 인덱스에 맞게 애니메이션 출력 yoon
        yield return new WaitForSeconds(4);
        Debug.Log(target + "를 대상으로" + SaveSkill.Name + "스킬 사용");
        speedComparisonArray[0].transform.GetChild(0).GetComponent<Animator>().SetInteger("herostate", 998); // 애니메이션 IDLE로 바꿈
        ppCon.DepthOfFieldOnOff(ppCon); // 블러 끄기
        speedComparisonArray[0].transform.position = HeroPos;
        target.transform.position = EnemyPos;
        combat_Effect_Manager.HitLight.enabled = false;

        SkillResultInit(target);
        Debug.Log("Test");

    }
}
