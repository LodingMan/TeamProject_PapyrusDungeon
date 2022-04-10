using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class TownManager : MonoBehaviour
{
    //�÷��̾��� ������ �����ϴ� ��ũ��Ʈ. 
    //�ش� ��ũ��Ʈ���� ���� ����, ���, �� �ǹ��� ������Ȳ
    public int Week = 0;
    public int Gold = 0;
    public int Jewel = 0;

    public Song.HeroManager heroManager; // inspectorâ�� HeroManager�־���
    public Shin.UI_ChurchManager churchManager;
    public e_CombatManager combatManager;
    public ShopManager shopMgr;

    public List<GameObject> OnControll = new List<GameObject>(); 

    public List<GameObject> OffControll = new List<GameObject>();

    public Text text_Week;
    public Text text_Gold;
    public Text text_Jewel;

    public bool isTown;
    public bool isTent;
    public bool isCombat;
    private void Awake()
    {
        isTown = true;
        isTent = false;
        isCombat = false;
    }
    public void Update()
    {
        text_Week.text = Week.ToString();
        text_Gold.text = Gold.ToString();
        text_Jewel.text = Jewel.ToString();
    }
    public void NextWeek() // ���� ���� , ó�� ���� ���� ���� ������ �÷��̾��� ���൵�� �����ַ� �Ѿ.
                           // �ش� �Լ��� ���� �Ǿ����� HeroManager���� ������ ����ŭ Hero�� �������� �����ϴµ� 
                           // �����Ǵ� ���� HeroManager�� ����Ǿ��ִ� guildManager�� oneDayCreateHeroCount ������ �����Ѵ�.
    {
        Week++;
        heroManager.RandomHeroCreate();
        shopMgr.ItemSpawn();
    } //�������ڸ� TownManager�� HeroManager���� ������ �����϶� ����ϰ�, HeroManager�� Guild���� ��� �����ؾ� �ϴ��� ���� �޾� �����Ѵ�. 

    public void UpdateManager_All_Off()
    {
        // OffControll = GameObject.Find("TentManager");
        // OffControll.GetComponent<ItemUseManager>().enabled = false;
        Debug.Log(OffControll.Count);
        for (int i = 0; i < OffControll.Count; i++)
        {
            OffControll[i].SetActive(false); //�� ����Ʈ�� ����� �� �������µ� ���߿� �� ����Ʈ�� �ѹ��� �ٽ� �ѹ������.

        }

        for(int i = 0; i < heroManager.CurrentHeroList.Count; i++)
        {
            heroManager.CurrentHeroList[i].SetActive(false);
        }
        for(int i = 0; i < heroManager.unemployedHeroList.Count; i++)
        {
            heroManager.unemployedHeroList[i].SetActive(false);
        }

        for(int i = 0; i < combatManager.myParty.Count; i++)
        {
            combatManager.myParty[i].SetActive(true);
        }

        for(int i = 0; i < OnControll.Count; i++)
        {
            OnControll[i].SetActive(true);
        }

    }

    public void UpdateManager_All_ON()
    {
        // OffControll = GameObject.Find("TentManager");
        // OffControll.GetComponent<ItemUseManager>().enabled = false;
        Debug.Log(OffControll.Count);
        for (int i = 0; i < OffControll.Count; i++)
        {
            OffControll[i].SetActive(false); //�� ����Ʈ�� ����� �� �������µ� ���߿� �� ����Ʈ�� �ѹ��� �ٽ� �ѹ������.

        }

        for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
        {
            heroManager.CurrentHeroList[i].SetActive(false);
        }
        for (int i = 0; i < heroManager.unemployedHeroList.Count; i++)
        {
            heroManager.unemployedHeroList[i].SetActive(false);
        }

        for (int i = 0; i < combatManager.myParty.Count; i++)
        {
            combatManager.myParty[i].SetActive(true);
        }

        for (int i = 0; i < OnControll.Count; i++)
        {
            OnControll[i].SetActive(true);
        }

    }
}
