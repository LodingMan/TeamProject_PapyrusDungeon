using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class e_CombatManager : MonoBehaviour
{
    public TownManager townManager;
    public ShopManager shopManager;
    public Combat_Guide_Script combat_Guide_Script;



    public List<GameObject> enemyPrefabs = new List<GameObject>();  //랜덤으로 생성될 에너미 종류
    public Enemy_Stat_Table enemy_Stat_Table = new Enemy_Stat_Table();  // 에너미 프리펩에 맞는 에너미 스텟 부여
    public Enemy_Sequence_Table enemy_Sequence_Table = new Enemy_Sequence_Table(); //에너미 배치를 정해주는 테이블
    public SKillTable sKillTable = new SKillTable(); //스킬테이블

    public int DungeonType;
    public int DungeonDifficulty;


    public List<GameObject> myParty = new List<GameObject>(); //GuildManager에서 가져온 PartyHero를 담은 배열
    //public List<GameObject> CreateEnemyPool = new List<GameObject>(); //
    public List<GameObject> enemys = new List<GameObject>(); //생성한 에너미 3마리가 들어감. 

    public List<GameObject> speedComparisonArray = new List<GameObject>(); //속도계산 배열 해당 리스트의 0번째가 현재 행동중인 유닛

    public Song.HeroManager heroManager;
    public Song.GuildManager guildManager;
    public Combat_Event_UI_Manager combat_Event_UI_Manager;
    public CombatCameraControll combatCameraControll;
    public Target_Panal_Script target_Panal_Script;
    public Combat_Effect_Manager combat_Effect_Manager;
    public SkillActiveManager skillActiveManager;
    public Target_Panal_Script enemyTargetScript;

    public skill SaveSkill; //스킬 사용자의 스킬 저장
    public int currentActiveUnitIndex; //현재 스킬을 사용할 히어로가 몇번째에 위치하는지 

    public Camera CombatCamera;
    public GameObject CombatCamera_ShakeObj;
    public Canvas CombatCanvas;
    public Canvas Skill_Targeting_Canvas;
    public Transform CanvasTransform;


    public quick_outline.quick_outline outline;


    int Damage; //총 합산 데미지
    int StatPram;
    int Turn;
    public GameObject CurrentCreateEnemy;

    public Vector3 FirstHeroCreatePos = new Vector3(-3000, 0, 0);
    public Vector3 FirstEnemyCreatePos = new Vector3(-2997, 0, 0);

    public bool isCombat;
    public bool isLastCombat;
    public bool isAISkillNone = false;
    public bool isGameOver = false;

    public List<skill> currentActiveSkillList = new List<skill>(); // 확인하려고 꺼내놓은것. 다쓰고 EnemySkillSelect에 다시 넣어놓을것.

    public PostProcessingController ppCon; // ����Ʈ ���μ��� ��Ʈ�ѷ�

    Ray ray;
    RaycastHit hit;

    private void Update()
    {
        if (CombatCamera.gameObject.activeSelf)
        {
            if (isCombat)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    Ray ray = CombatCamera.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray.origin, ray.direction, out hit))
                    {
                        switch (hit.transform.gameObject.name)
                        {
                            case "Skill1":
                                skillActiveManager.Skill1();
                                break;
                            case "Skill2":
                                skillActiveManager.Skill2();
                                break;
                            case "Skill3":
                                skillActiveManager.Skill3();
                                break;
                            case "None":
                                skillActiveManager.SkillNone();
                                break;
                            case "Target1":
                                hit.transform.gameObject.GetComponent<DOTweenAnimation>().DORestart();
                                StartCoroutine(HeroAttackDlay(hit.transform.gameObject.GetComponent<Unit_Target_Script>().This_TargetObject));
                                break;
                            case "Target2":
                                hit.transform.gameObject.GetComponent<DOTweenAnimation>().DORestart();
                                StartCoroutine(HeroAttackDlay(hit.transform.gameObject.GetComponent<Unit_Target_Script>().This_TargetObject));
                                break;
                            case "Target3":
                                hit.transform.gameObject.GetComponent<DOTweenAnimation>().DORestart();
                                StartCoroutine(HeroAttackDlay(hit.transform.gameObject.GetComponent<Unit_Target_Script>().This_TargetObject));
                                break;
                            case "_Target1":
                                hit.transform.gameObject.GetComponent<DOTweenAnimation>().DORestart();
                                StartCoroutine(HeroAttackDlay(hit.transform.gameObject.GetComponent<Unit_Target_Script>().This_TargetObject));
                                break;
                            case "_Target2":
                                hit.transform.gameObject.GetComponent<DOTweenAnimation>().DORestart();
                                StartCoroutine(HeroAttackDlay(hit.transform.gameObject.GetComponent<Unit_Target_Script>().This_TargetObject));
                                break;
                            case "_Target3":
                                hit.transform.gameObject.GetComponent<DOTweenAnimation>().DORestart();
                                StartCoroutine(HeroAttackDlay(hit.transform.gameObject.GetComponent<Unit_Target_Script>().This_TargetObject));
                                break;
                            default:
                                break;
                        }

                        if(hit.transform.gameObject.tag == "Player" || hit.transform.gameObject.tag == "Enemy")
                        {
                            combat_Event_UI_Manager.HeroStatInfo_Text[0].text = "" +
                                hit.transform.gameObject.GetComponent<StatScript>().myStat.Name;
                            combat_Event_UI_Manager.HeroStatInfo_Text[1].text = "" +
                                hit.transform.gameObject.GetComponent<StatScript>().myStat.Job;
                            combat_Event_UI_Manager.HeroStatInfo_Text[2].text = "ATK : " +
                                hit.transform.gameObject.GetComponent<StatScript>().myStat.Atk;
                            combat_Event_UI_Manager.HeroStatInfo_Text[3].text = "DEF : " +
                                hit.transform.gameObject.GetComponent<StatScript>().myStat.Def;
                            combat_Event_UI_Manager.HeroStatInfo_Text[4].text = "CRI : " +
                                hit.transform.gameObject.GetComponent<StatScript>().myStat.Cri;
                            combat_Event_UI_Manager.HeroStatInfo_Text[5].text = "ACC : " +
                                hit.transform.gameObject.GetComponent<StatScript>().myStat.Acc;
                            combat_Event_UI_Manager.HeroStatInfo_Text[6].text = "AGI : " +
                                hit.transform.gameObject.GetComponent<StatScript>().myStat.Agi;
                            combat_Event_UI_Manager.HeroStatInfo_Text[7].text = "SPEED : " +
                                hit.transform.gameObject.GetComponent<StatScript>().myStat.Speed;
                            combat_Event_UI_Manager.HeroStatInfo_Text[8].text = "HP : " +
                                hit.transform.gameObject.GetComponent<StatScript>().myStat.HP
                                + "/" + hit.transform.gameObject.GetComponent<StatScript>().myStat.MAXHP;
                            combat_Event_UI_Manager.HeroStatInfo_Text[9].text = "MP : " +
                                hit.transform.gameObject.GetComponent<StatScript>().myStat.MP
                                + "/" + hit.transform.gameObject.GetComponent<StatScript>().myStat.MAXMP;
                        }
                       
                        Debug.Log(hit.transform.gameObject.name);
                    }

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
            myParty[i + 1].transform.position = FirstHeroCreatePos - new Vector3(2.0f * (i + 1), 0, 0);
            myParty[i + 1].transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        combat_Event_UI_Manager.Bars.SetActive(true);
         combat_Event_UI_Manager.Hero_HP_Bar.Clear();
        for (int i = 0; i < myParty.Count; i++)
        {
            outline = myParty[i].GetComponent<quick_outline.quick_outline>();
            outline.OutlineColor = Color.white;
            outline.enabled = true;

            combat_Event_UI_Manager.Hero_HP_Bar.Add(combat_Event_UI_Manager.Defalt_Hero_Hp_Bar[i]);

            combat_Event_UI_Manager.Hero_HP_Bar[i].GetComponent<RectTransform>().anchoredPosition =
                combat_Event_UI_Manager.Hero_Hp_Bar_Pos[i];

            combat_Event_UI_Manager.Hero_HP_Bar[i].SetActive(true);
            combat_Event_UI_Manager.Hero_HP_Bar[i].GetComponent<Slider>().maxValue =
                myParty[i].GetComponent<StatScript>().myStat.MAXHP;
            combat_Event_UI_Manager.Hero_HP_Bar[i].GetComponent<Slider>().value =
                myParty[i].GetComponent<StatScript>().myStat.HP;
            combat_Event_UI_Manager.Hero_Hp_Bar_Pos.Add
                (combat_Event_UI_Manager.Hero_HP_Bar[i].GetComponent<RectTransform>().anchoredPosition);
        }
    }




    public void Out_Dungeon_Party()
    {
        combat_Event_UI_Manager.Bars.SetActive(false);
        for (int i = 0; i < myParty.Count; i++)
        {
            myParty[i].transform.position = new Vector3(0, 0, 0);
            myParty[i].GetComponent<NavMeshAgent>().enabled = true;
            myParty[i].GetComponent<Shin.NaviMeshHero>().enabled = true;

            outline = myParty[i].GetComponent<quick_outline.quick_outline>();
            outline.OutlineColor = Color.white;
            outline.enabled = false;

            combat_Event_UI_Manager.Hero_HP_Bar[i].SetActive(false);
        }
        myParty.Clear();



    }
    public void BarUpdate()
    {
        for (int i = 0; i < myParty.Count; i++)
        {
            combat_Event_UI_Manager.Hero_HP_Bar[i].GetComponent<Slider>().value =
                myParty[i].GetComponent<StatScript>().myStat.HP;
        }
        for (int i = 0; i < enemys.Count; i++)
        {
            combat_Event_UI_Manager.Enemy_HP_Bar[i].GetComponent<Slider>().value =
                enemys[i].GetComponent<StatScript>().myStat.HP;
        }
    }


    //=====================================================================================================// 여기서부터 시작
    public void EnemyInit()
    {
        Turn = 0;
        combat_Event_UI_Manager.TurnText.text = "" + Turn;
        combat_Event_UI_Manager.TurnTextImg.SetActive(true);


        
        ppCon.ChromaticAberration_On_Off(ppCon);
        ppCon.CombatSeeting();
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

            CurrentCreateEnemy.transform.position = FirstEnemyCreatePos + new Vector3(2.0f * i, 0, 0);
            CurrentCreateEnemy.transform.rotation = Quaternion.Euler(0, -90, 0);

            enemys.Add(CurrentCreateEnemy);

        }

        combat_Event_UI_Manager.Enemy_HP_Bar.Clear();
        for (int i = 0; i < enemys.Count; i++)
        {
            combat_Event_UI_Manager.Enemy_HP_Bar.Add(combat_Event_UI_Manager.Defalt_Enemy_Hp_Bar[i]);

            combat_Event_UI_Manager.Enemy_HP_Bar[i].GetComponent<RectTransform>().anchoredPosition =
                combat_Event_UI_Manager.Enemy_Hp_Bar_Pos[i];


            combat_Event_UI_Manager.Enemy_HP_Bar[i].SetActive(true);

            combat_Event_UI_Manager.Enemy_HP_Bar[i].GetComponent<Slider>().maxValue =
                enemys[i].GetComponent<StatScript>().myStat.MAXHP;
            combat_Event_UI_Manager.Enemy_HP_Bar[i].GetComponent<Slider>().value =
                enemys[i].GetComponent<StatScript>().myStat.HP;
        }

        TurnStart();

    }
    public void TurnStart() //전투가 시작되면 모든 유닛의 속도를 비교해 주어야 하므로 6칸 짜리 배열에 모든 오브젝트를 때려넣는다. 
    {
        Turn++;
        combat_Event_UI_Manager.TurnText.text = "" + Turn;
        combat_Event_UI_Manager.TurnText.GetComponent<DOTweenAnimation>().DORestart();
        speedComparisonArray.Clear();


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
        if (townManager.Week == 1)
        {
            if (!combat_Guide_Script.isCombat_Skill_Guide)
            {
                for (int i = 0; i < enemys.Count; i++) enemys[i].GetComponent<StatScript>().myStat.Speed = 0;
                combat_Guide_Script.Combat_Skill_Guide_On();
            }
        }


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
            HeroInfo_Init();
            combat_Event_UI_Manager.HeroStatusInfo_Panel.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero, 1);
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
                    break;
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
            Debug.Log("사용할 스킬 없음 다음턴으로 넘어감");
            isAISkillNone = true;

        }
        else
        {
            SaveSkill = currentActiveSkillList[Random.Range(0, currentActiveSkillList.Count)];

            combat_Event_UI_Manager.EnemySkillNameText.enabled = true;
            combat_Event_UI_Manager.EnemySkillNameText.text = SaveSkill.Name;
            combat_Event_UI_Manager.EnemySkillNameText.GetComponent<DOTweenAnimation>().DORestart();
            Debug.Log("사용할 스킬 결정! 스킬의 이름은 " + SaveSkill.Name + "::인덱스는" + SaveSkill.Index);
        }


        currentActiveSkillList.Clear();


    }

    public void EnemySkillUse()
    {



        if (isAISkillNone)
        {
            combat_Event_UI_Manager.Current_Attack_Unit.gameObject.SetActive(false);
            speedComparisonArray.RemoveAt(0);
            NextMove();
            isAISkillNone = false;
            return;
        }



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
        StatScript targetStat = target.GetComponent<StatScript>();
        StatScript CurrentMyStat = speedComparisonArray[0].GetComponent<StatScript>();
        if (speedComparisonArray[0].tag == "Player")
        {
            switch (SaveSkill.Type)
            {
                case 0:
                    Damage += (SaveSkill.ATK + speedComparisonArray[0].GetComponent<StatScript>().myStat.Atk +
               speedComparisonArray[0].GetComponent<EquipScript>().myEquip[0].Atk + speedComparisonArray[0].GetComponent<EquipScript>().myEquip[1].Atk);
                    break;
                case 1:
                    StatPram += (SaveSkill.ATK);

                    break;
                default:
                    break;
            }

        }
        else
        {
            Damage += (SaveSkill.ATK + speedComparisonArray[0].GetComponent<StatScript>().myStat.Atk);
        }




        if (SaveSkill.Type == 0)
        {

            if (speedComparisonArray[0].tag == "Player")
            {
                Damage -= targetStat.myStat.Def;
            }
            else
            {
                Damage -= targetStat.myStat.Def
                     + target.GetComponent<EquipScript>().myEquip[0].Def + target.GetComponent<EquipScript>().myEquip[1].Def;

            }

            if (Damage <= 0)
            {
                Damage = 1;
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
            combat_Event_UI_Manager.DamageText.SetActive(true);


            if (speedComparisonArray[0].tag == "Player")
            {
                combat_Event_UI_Manager.TextAnim.SetInteger("TextState", 2);

            }
            else
            {
                combat_Event_UI_Manager.TextAnim.SetInteger("TextState", 1);

            }

            combat_Event_UI_Manager.DamageText.GetComponent<Text>().text = "-" + Damage;

            //RectTransform DamageTextPos = combat_Event_UI_Manager.DamageText.GetComponent<RectTransform>();
            //Vector2 EmptyPos = DamageTextPos.anchoredPosition;
            //Vector3 TextScale = DamageTextPos.localScale;

            //combat_Event_UI_Manager.DamageText.SetActive(true);

            //DamageTextPos.DOAnchorPos(DamageTextPos.anchoredPosition - new Vector2(0, -100), 2f);
            //DamageTextPos.DOScale(new Vector3(0, 0, 0), 2f);




        }
        else if (SaveSkill.Type == 1)
        {
            switch (SaveSkill.Pram)
            {
                case 1:
                    targetStat.myStat.Atk += SaveSkill.ATK;
                    break;
                case 2:
                    targetStat.myStat.Def += SaveSkill.ATK;
                    break;
                case 3:
                    targetStat.myStat.Cri += SaveSkill.ATK;
                    break;
                case 4:
                    targetStat.myStat.Acc += SaveSkill.ATK;
                    break;
                case 5:
                    targetStat.myStat.Agi += SaveSkill.ATK;
                    break;
                case 6:
                    targetStat.myStat.Speed += SaveSkill.ATK;
                    break;
                default:
                    break;
            }

            targetStat.BuffPram.Add(SaveSkill.Pram);
            targetStat.BuffValue.Add(SaveSkill.ATK);
            targetStat.myBuffTime.Add(SaveSkill.BuffTime);
            targetStat.BuffCount++;

            //여기서 히어로한테 mybufftime숫자를 대입한다. 대입값은 스킬의 buffTime이다 
            //Turn이 증가할때마다 myBuffTime이 감소하고 0이되면 감소를 멈추고 버프를 지운다. 

            GameObject buffeffect = Instantiate(combat_Effect_Manager.buffEffect);
            buffeffect.transform.SetParent(target.transform);
            buffeffect.transform.localPosition = new Vector3(0, -0.5f, 0);

            Debug.Log("여기서 스탯, HP버프");
            Debug.Log(speedComparisonArray[0] + "이" + target + "에게 버프함.");
        }


        for (int i = 0; i < CurrentMyStat.BuffCount; i++)
        {
            if (CurrentMyStat.myBuffTime[i] != 0)
            {
                CurrentMyStat.myBuffTime[i]--; //버프타임 감소
                if (CurrentMyStat.myBuffTime[i] <= 0)//버프가 다 떨어졌다면 
                {
                    switch (CurrentMyStat.BuffPram[i]) //상황에 맞는 값 감소
                    {
                        case 1:
                            Debug.Log(i);
                            CurrentMyStat.myStat.Atk -= CurrentMyStat.BuffValue[i];
                            break;
                        case 2:
                            CurrentMyStat.myStat.Def -= CurrentMyStat.BuffValue[i];
                            break;
                        case 3:
                            CurrentMyStat.myStat.Cri -= CurrentMyStat.BuffValue[i];
                            break;
                        case 4:
                            CurrentMyStat.myStat.Acc -= CurrentMyStat.BuffValue[i];
                            break;
                        case 5:
                            CurrentMyStat.myStat.Agi -= CurrentMyStat.BuffValue[i];
                            break;
                        case 6:
                            CurrentMyStat.myStat.Speed -= CurrentMyStat.BuffValue[i];
                            break;
                        default:
                            break;
                    }
                    CurrentMyStat.BuffPram.RemoveAt(i);
                    CurrentMyStat.BuffValue.RemoveAt(i);
                    CurrentMyStat.myBuffTime.RemoveAt(i);
                    CurrentMyStat.BuffCount--;
                    if (CurrentMyStat.BuffCount == 0)
                    {
                        for (int f = 0; f < CurrentMyStat.transform.childCount; f++)
                        {
                            if (CurrentMyStat.transform.GetChild(f).tag == "Effect")
                            {
                                Destroy(CurrentMyStat.transform.GetChild(f).gameObject);
                            }
                        }
                    }
                }
            }
        }

        Damage = 0;
        StatPram = 0;

    }

    public void LastResult(GameObject target)
    {

        if (target.GetComponent<StatScript>().myStat.HP <= 0)
        {
            Debug.Log("누구 죽음");
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
                    enemys[i].transform.DOMove(FirstEnemyCreatePos + new Vector3((2.0f * (i - 1)), 0, 0), 1);

                    combat_Event_UI_Manager.Enemy_HP_Bar[i].GetComponent<RectTransform>().DOAnchorPos(
                        combat_Event_UI_Manager.Enemy_HP_Bar[i - 1].GetComponent<RectTransform>().anchoredPosition, 1);
                    // new Vector2(-165 * (i-1),0),1); //hp바 앞으로 당기기

                    Debug.Log(enemys[i] + "이동함");
                }
                for (int i = 0; i < speedComparisonArray.Count; i++)
                    if (speedComparisonArray[i] == target) speedComparisonArray.Remove(target);


                //  Destroy(combat_Event_UI_Manager.Enemy_HP_Bar[destroyIdx]);
                combat_Event_UI_Manager.Enemy_HP_Bar[destroyIdx].SetActive(false);
                combat_Event_UI_Manager.Enemy_HP_Bar.RemoveAt(destroyIdx); //Hp바 삭제

                enemys.Remove(target);
                Destroy(target);
                if (enemys.Count == 0)
                {

                    combat_Event_UI_Manager.TurnTextImg.SetActive(false);

                    outline.OutlineColor = Color.white;
                    speedComparisonArray.Clear();
                    isCombat = false;
                    InGame_Player_Script IP = GameObject.Find("InGamePlayer").GetComponent<InGame_Player_Script>();
                    IP.isMove = true;
                    RoomController RC = GameObject.Find("RoomController").GetComponent<RoomController>();
                    RC.RoomCombatClear(IP.currentPlayers);
                    ppCon.ChromaticAberration_On_Off(ppCon);
                    ppCon.CombatEndSeeting();
                    if (isLastCombat)
                    {
                        RC.GameClearFunc();
                        isLastCombat = false;
                    }
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
                    myParty[i].transform.DOMove(FirstHeroCreatePos + new Vector3((-2.0f * (i - 1)), 0, 0), 1);


                    combat_Event_UI_Manager.Hero_HP_Bar[i].GetComponent<RectTransform>().DOAnchorPos(
                        combat_Event_UI_Manager.Hero_HP_Bar[i - 1].GetComponent<RectTransform>().anchoredPosition, 1);
                    //new Vector2(165 * (i - 1), 0), 1); //hp바 앞으로 당기기
                }
                for (int i = 0; i < speedComparisonArray.Count; i++)
                    if (speedComparisonArray[i] == target) speedComparisonArray.Remove(target);

                ////////////////////UI지우기///////////////
                for (int i = 0; i < guildManager.Party_Hero_UI_List.Count; i++)
                {
                    if (guildManager.Party_Hero_UI_List[i].This_Prefab_Object == target)
                    {
                        guildManager.Party_Hero_UI_List[i].SlotClear();
                    }
                }


                for (int i = 0; i < guildManager.Current_Hero_UI_List.Count; i++)
                {
                    if (guildManager.Current_Hero_UI_List[i].GetComponent<Song.Current_Hero_UI_Script>().This_Prefab_Object == target)
                    {
                        Destroy(guildManager.Current_Hero_UI_List[i]);
                        guildManager.Current_Hero_UI_List.RemoveAt(i);
                    }
                }



                //    Destroy(combat_Event_UI_Manager.Hero_HP_Bar[destroyIdx]);
                combat_Event_UI_Manager.Hero_HP_Bar[destroyIdx].SetActive(false);
                combat_Event_UI_Manager.Hero_HP_Bar.RemoveAt(destroyIdx); //Hp바 삭제

                myParty.Remove(target);
                heroManager.CurrentHeroList.Remove(target);
                Destroy(target);

                if (myParty.Count == 0)
                {
                    combat_Event_UI_Manager.TurnTextImg.SetActive(false);

                    isGameOver = true;
                    isLastCombat = false;
                    isCombat = false;

                    for(int i = enemys.Count-1; i >= 0; i--)
                    {
                        Debug.Log(i);
                        Destroy(enemys[i]);
                        enemys.Remove(enemys[i]);
                        combat_Event_UI_Manager.Enemy_HP_Bar[i].SetActive(false);
                    }

                    speedComparisonArray.Clear();

                    RoomController RC = GameObject.Find("RoomController").GetComponent<RoomController>();
                    RC.GameFailFunc();

                    ppCon.ChromaticAberration_On_Off(ppCon);
                    ppCon.CombatEndSeeting();
                    return;
                }


            }
        }

        speedComparisonArray.RemoveAt(0);

        BarUpdate();//갱신
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
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < myParty.Count; i++)
        {
            outline = myParty[i].GetComponent<quick_outline.quick_outline>();
            outline.OutlineColor = Color.white;
            outline.OutlineWidth = 4;
        }



        outline = speedComparisonArray[0].GetComponent<quick_outline.quick_outline>();
        outline.OutlineWidth = 7;
        outline.OutlineColor = (Color.green);

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
        yield return new WaitForSeconds(1.5f);
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

        yield return new WaitForSeconds(1);
        EnemySkillSelect(speedComparisonArray[0]); //이 함수가 호출되고 난 뒤에는 SaveSkill에 Enemy가 사용할 스킬이 저장되어있다. 
        yield return new WaitForSeconds(1);

        EnemySkillUse();


    }

    IEnumerator EnemyAttack(int target_Idx)
    {
        combat_Event_UI_Manager.HeroStatusInfo_Panel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-1280, 0), 1);
        yield return new WaitForSeconds(1);
        combat_Event_UI_Manager.Bars.SetActive(false);
        combat_Event_UI_Manager.EnemySkillNameText.enabled = false;
        combat_Event_UI_Manager.Player_Targeting.SetActive(false);
        combat_Event_UI_Manager.Current_Attack_Unit.gameObject.SetActive(false);


        Vector3 EnemyPos = speedComparisonArray[0].transform.position;
        Vector3 HeroPos = myParty[target_Idx].transform.position;

        speedComparisonArray[0].transform.position = new Vector3(-2997.85f, 0, -3.12f);

        myParty[target_Idx].transform.position = new Vector3(-3000, 0, -3.12f);


        speedComparisonArray[0].transform.DOMove(speedComparisonArray[0].transform.position - new Vector3(1.3f, 0, 0), 3f);
        myParty[target_Idx].transform.DOMove(myParty[target_Idx].transform.position - new Vector3(1.3f, 0, 0), 3f);

        combat_Effect_Manager.HitLight.enabled = true;



        myParty[target_Idx].transform.GetChild(0).GetComponent<Animator>().SetInteger("herostate", 1000); // 영웅이 맞는 애니메이션 yoon
        speedComparisonArray[0].transform.GetChild(0).GetComponent<Animator>().SetInteger("enemystate", SaveSkill.Index); // 적이 때리는 애니메이션 yoon
        combat_Effect_Manager.EnemyEffect_On(myParty[target_Idx]); //적이 때릴시 영웅이 맞는 이펙트

        SkillResultInit(myParty[target_Idx]);

        combatCameraControll.CombatCamera.transform.DOMove(new Vector3(-2998.72f, 0.2f, -5.8f), 0.5f);
        combatCameraControll.CombatCamera.transform.DORotate(new Vector3(-5.7f, 0, 0), 0.5f);

        ppCon.DepthOfFieldOnOff(ppCon); // 전투 시 블러 처리 yoon

        yield return new WaitForSeconds(0.5f);

        //카메라 흔들림
        combatCameraControll.CombatCamera.transform.DOMove(new Vector3(-2998.72f - 0.6f, 0.2f, -5.8f), 2f);
        combatCameraControll.CombatCamera.transform.DORotate(new Vector3(-5.7f, 0, 3f), 2f);
        CombatCamera_ShakeObj.transform.DOShakePosition(1f, 0.1f);



        yield return new WaitForSeconds(3);
        myParty[target_Idx].transform.GetChild(0).GetComponent<Animator>().SetInteger("herostate", 998); //영웅 애니메이션 IDLE로 변경
        speedComparisonArray[0].transform.GetChild(0).GetComponent<Animator>().SetInteger("enemystate", 998);//적 애니메이션 IDLE로 변경
        ppCon.DepthOfFieldOnOff(ppCon); // 블러 끄기

        combatCameraControll.CombatCamera.transform.DOMove(new Vector3(-2998.72f, 4.84f, -6.05f), 0.5f);
        combatCameraControll.CombatCamera.transform.DORotate(new Vector3(32.3f, 0, 0), 0.5f);

        speedComparisonArray[0].transform.position = EnemyPos;
        myParty[target_Idx].transform.position = HeroPos;

        combat_Effect_Manager.HitLight.enabled = false;

        combat_Event_UI_Manager.TextAnim.SetInteger("TextState", 0);
        combat_Event_UI_Manager.DamageText.SetActive(false);


        combat_Event_UI_Manager.Bars.SetActive(true);

        BarUpdate();
        LastResult(myParty[target_Idx]);

    }
    public IEnumerator HeroAttackDlay(GameObject target)
    {
        combat_Event_UI_Manager.HeroStatusInfo_Panel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-1280,0), 1);
        //여기부터 공격을 시작한 히어로의 움직임
        yield return new WaitForSeconds(0.5f);
        combat_Event_UI_Manager.Current_Attack_Unit.gameObject.SetActive(false);

        target_Panal_Script.TargetAllOff();


        Vector3 HeroPos = speedComparisonArray[0].transform.position;
        Vector3 EnemyPos = target.transform.position;
        combat_Event_UI_Manager.Bars.SetActive(false);

        switch (SaveSkill.Type)
        {
            case 0: //어택

                speedComparisonArray[0].transform.position = new Vector3(-3000f, 0, -3.12f);
                target.transform.position = new Vector3(-2997.85f, 0, -3.12f);

                target.transform.DOMove(target.transform.position - new Vector3(-1.3f, 0, 0), 3f);
                speedComparisonArray[0].transform.DOMove(speedComparisonArray[0].transform.position - new Vector3(-1.3f, 0, 0), 3f);
                combat_Effect_Manager.HitLight.enabled = true;
                speedComparisonArray[0].transform.GetChild(0).GetComponent<Animator>().SetInteger("herostate", SaveSkill.Index); // 스킬 인덱스에 맞게 애니메이션 출력 yoon
                target.transform.GetChild(0).GetComponent<Animator>().SetInteger("enemystate", 1000); //적이 맞는 애니메이션 yoon
                combat_Effect_Manager.HeroEffect_On(speedComparisonArray[0], target); // 공격시 이펙트 0409Yoon
                SkillResultInit(target);

                combatCameraControll.CombatCamera.transform.DOMove(new Vector3(-2998.72f, 0.2f, -5.8f), 0.5f);
                combatCameraControll.CombatCamera.transform.DORotate(new Vector3(-5.7f, 0, 0), 0.5f);
                ppCon.DepthOfFieldOnOff(ppCon); // 전투 시 블러 처리 yoon
                yield return new WaitForSeconds(0.5f);
                combatCameraControll.CombatCamera.transform.DOMove(new Vector3(-2998.72f + 0.6f, 0.2f, -5.8f), 2f);
                combatCameraControll.CombatCamera.transform.DORotate(new Vector3(-5.7f, 0, -3f), 2f);
                CombatCamera_ShakeObj.transform.DOShakePosition(1f, 0.1f);
                // combatCameraControll.CombatCamera.transform.DOShakeRotation(1f, 0.08f);


                yield return new WaitForSeconds(3);

                Debug.Log(target + "를 대상으로" + SaveSkill.Name + "스킬 사용" + "::스킬인덱스 =" + SaveSkill.Index);
                speedComparisonArray[0].transform.GetChild(0).GetComponent<Animator>().SetInteger("herostate", 998); // 애니메이션 IDLE로 바꿈
                target.transform.GetChild(0).GetComponent<Animator>().SetInteger("enemystate", 998);

                ppCon.DepthOfFieldOnOff(ppCon); // 블러 끄기

                combatCameraControll.CombatCamera.transform.DOMove(new Vector3(-2998.72f, 4.84f, -6.05f), 0.5f);
                combatCameraControll.CombatCamera.transform.DORotate(new Vector3(32.3f, 0, 0), 0.5f);

                speedComparisonArray[0].transform.position = HeroPos;
                target.transform.position = EnemyPos;
                combat_Effect_Manager.HitLight.enabled = false;

                Debug.Log("Test");

                break;
            case 1: //버프
                speedComparisonArray[0].transform.position = new Vector3(-3000f, 0, -3.12f);
                speedComparisonArray[0].transform.DOMove(speedComparisonArray[0].transform.position - new Vector3(-1.3f, 0, 0), 3f);
                combat_Effect_Manager.HitLight.enabled = true;
                speedComparisonArray[0].transform.GetChild(0).GetComponent<Animator>().SetInteger("herostate", SaveSkill.Index); // 스킬 인덱스에 맞게 애니메이션 출력 yoon
                //적이 맞는 애니메이션 일단 없음.
                combat_Effect_Manager.HeroEffect_On(speedComparisonArray[0], target); // 공격시 이펙트 0409Yoon
                combatCameraControll.CombatCamera.transform.DOMove(new Vector3(-2998.72f, 0.2f, -5.8f), 0.5f);
                combatCameraControll.CombatCamera.transform.DORotate(new Vector3(-5.7f, 0, 0), 0.5f);
                ppCon.DepthOfFieldOnOff(ppCon); // 전투 시 블러 처리 yoon
                SkillResultInit(target);
                yield return new WaitForSeconds(0.5f);
                combatCameraControll.CombatCamera.transform.DOMove(new Vector3(-2998.72f + 0.6f, 0.2f, -5.8f), 2f);
                combatCameraControll.CombatCamera.transform.DORotate(new Vector3(-5.7f, 0, -1f), 0.1f);

                yield return new WaitForSeconds(3);

                Debug.Log(target + "를 대상으로" + SaveSkill.Name + "스킬 사용" + "::스킬인덱스 =" + SaveSkill.Index);
                speedComparisonArray[0].transform.GetChild(0).GetComponent<Animator>().SetInteger("herostate", 998); // 애니메이션 IDLE로 바꿈
                                                                                                                     //   target.transform.GetChild(0).GetComponent<Animator>().SetInteger("enemystate", 998);

                ppCon.DepthOfFieldOnOff(ppCon); // 블러 끄기

                combatCameraControll.CombatCamera.transform.DOMove(new Vector3(-2998.72f, 4.84f, -6.05f), 0.5f);
                combatCameraControll.CombatCamera.transform.DORotate(new Vector3(32.3f, 0, 0), 0.5f);

                speedComparisonArray[0].transform.position = HeroPos;

                combat_Effect_Manager.HitLight.enabled = false;


                Debug.Log("Test");

                break;
            default:
                Debug.Log("오류");
                break;

        }
        combat_Event_UI_Manager.Bars.SetActive(true);


        combat_Event_UI_Manager.TextAnim.SetInteger("TextState", 0);
        combat_Event_UI_Manager.DamageText.SetActive(false);

        BarUpdate();

        LastResult(target);

    }


    public void PartyExpUp()
    {
        for (int i = 0; i < myParty.Count; i++)
        {
            myParty[i].GetComponent<StatScript>().MyExp += 40; //이거 던전 난이도에 따라 다르게 넣어야 될 수도 있음
            if (myParty[i].GetComponent<StatScript>().MyExp >= 100)
            {
                myParty[i].GetComponent<StatScript>().LevelUp();
            }
        }
    }

    public void DungeonClearBuffOff() //버프 이펙트 삭제 및 효과 삭제 0412 윤성근
    {
        for (int i = 0; i < myParty.Count; i++)
        {
            for (int j = 0; j < myParty[i].transform.childCount; j++)
            {
                if (myParty[i].transform.GetChild(j).tag == "Effect")
                {
                    StatScript CurrentMyStat = myParty[i].gameObject.transform.GetComponent<StatScript>();

                    CurrentMyStat.BuffPram.Clear();
                    CurrentMyStat.BuffValue.Clear();
                    CurrentMyStat.myBuffTime.Clear();
                    CurrentMyStat.BuffCount = 0;
                    Destroy(myParty[i].transform.GetChild(j).gameObject);
                }
            }
        }
    }

    public void HeroInfo_Init()
    {
        combat_Event_UI_Manager.HeroStatInfo_Text[0].text = "" +
            speedComparisonArray[0].GetComponent<StatScript>().myStat.Name;
        combat_Event_UI_Manager.HeroStatInfo_Text[1].text = "" +
           speedComparisonArray[0].GetComponent<StatScript>().myStat.Job;
        combat_Event_UI_Manager.HeroStatInfo_Text[2].text = "ATK : " +
            speedComparisonArray[0].GetComponent<StatScript>().myStat.Atk;
        combat_Event_UI_Manager.HeroStatInfo_Text[3].text = "DEF : " +
            speedComparisonArray[0].GetComponent<StatScript>().myStat.Def;
        combat_Event_UI_Manager.HeroStatInfo_Text[4].text = "CRI : " +
            speedComparisonArray[0].GetComponent<StatScript>().myStat.Cri;
        combat_Event_UI_Manager.HeroStatInfo_Text[5].text = "ACC : " +
            speedComparisonArray[0].GetComponent<StatScript>().myStat.Acc;
        combat_Event_UI_Manager.HeroStatInfo_Text[6].text = "AGI : " +
            speedComparisonArray[0].GetComponent<StatScript>().myStat.Agi;
        combat_Event_UI_Manager.HeroStatInfo_Text[7].text = "SPEED : " +
            speedComparisonArray[0].GetComponent<StatScript>().myStat.Speed;
        combat_Event_UI_Manager.HeroStatInfo_Text[8].text = "HP : " +
            speedComparisonArray[0].GetComponent<StatScript>().myStat.HP
            + "/" + speedComparisonArray[0].GetComponent<StatScript>().myStat.MAXHP;
        combat_Event_UI_Manager.HeroStatInfo_Text[9].text = "MP : " +
            speedComparisonArray[0].GetComponent<StatScript>().myStat.MP
            + "/" + speedComparisonArray[0].GetComponent<StatScript>().myStat.MAXMP;
    }

}
