using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

//========================================================================================//
// �ش� ��ũ��Ʈ�� ����� ��ġ�� UI�� �ѹ��� �����ϸ� CurrentHeroList�� �ɹ��� ���⼭ �������ϴ�//
//========================================================================================//
namespace Song
{
    public class GuildManager : MonoBehaviour
    {
        public int guildLv = 1;
        public int oneDayCreateHeroCount = 3; // ������ �Ѿ�� �� ������ Hero�� ��. ��尡 �������ϰ� �ȴٸ� �ش� ���� ������ �Ϸ翡 ����� �� �ִ� ������ ���� �����Ѵ�. 


        public GameObject unemployedHero_UI_Prefabs_Create_Point;
        public GameObject currentHero_UI_Prefabs_Create_Point;
        public GameObject unemployedHero_UI_Prefab;
        public GameObject currentHero_UI_Prefab;

        public Song.HeroManager heroManager; // inspectorâ�� HeroManager�־���
        public List<Button> Init_CurrentHeroList_Buttons;
        public List<string> unemployeHeroNames;

        public GameObject[] unemployedHero = new GameObject[9]; //�Լ��� �Ű������� �������� ����.

        public List<GameObject> Current_UI_Prefabs;  //�ش� ������ �����ϴ� ��� �� ���� UI Prefab�̴� 

        public List<GameObject> Current_Hero_UI_List; //��� �����Ǹ� �������
        public List<PartyMember_UI_Script> Party_Hero_UI_List; // ��� �̹� �����Ǿ������Ƿ� inspector���� ����
        public GameObject[] Party_Hero_Member = new GameObject[3]; // ������ ������ 3����

        public void UnemployedHero_UI_Prefabs_UpLoad(List<GameObject> UnemployedHero)
        {

            if (Current_UI_Prefabs.Count > 0)
            {
                //Debug.Log("Test");
                for (int j = 0; j < Current_UI_Prefabs.Count; j++)
                {
                    Destroy(Current_UI_Prefabs[j].gameObject);
                    Destroy(unemployedHero[j]);
                }
            }

            Current_UI_Prefabs.Clear();
            Array.Clear(unemployedHero, 0, unemployedHero.Length); //���߿� ������ �Ѿ�� �̰ɷ� unemploydHero�迭 ������

            for (int i = 0; i < UnemployedHero.Count; i++)
            {
                unemployedHero[i] = UnemployedHero[i];

                Current_UI_Prefabs.Add(Instantiate(unemployedHero_UI_Prefab));
                Current_UI_Prefabs[i].name = "" + i;
                Current_UI_Prefabs[i].transform.SetParent(unemployedHero_UI_Prefabs_Create_Point.transform);
                Current_UI_Prefabs[i].transform.GetChild(0).GetComponent<Text>().text = "Name : " + UnemployedHero[i].GetComponent<StatScript>().myStat.Name;
                Current_UI_Prefabs[i].transform.GetChild(1).GetComponent<Text>().text = "Job : " + UnemployedHero[i].GetComponent<StatScript>().myStat.Job;
                Current_UI_Prefabs[i].GetComponent<Song.Unemployed_Hero_UI_Script>().This_Prefab_Object = UnemployedHero[i];
            }
            UnemployedHero.Clear();
        }

        public void Load_Guild_UI_Prefabs()
        {
            GameObject currentPrefab;

            for (int i = 0; i < heroManager.CurrentHeroList.Count; i++)
            {
                currentPrefab = Instantiate(currentHero_UI_Prefab);
                currentPrefab.transform.SetParent(currentHero_UI_Prefabs_Create_Point.transform);
                currentPrefab.transform.GetChild(0).GetComponent<Text>().text = "Name : " + heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat.Name;
                currentPrefab.transform.GetChild(1).GetComponent<Text>().text = "Job : " + heroManager.CurrentHeroList[i].GetComponent<StatScript>().myStat.Job;
                currentPrefab.GetComponent<Current_Hero_UI_Script>().This_Prefab_Object = heroManager.CurrentHeroList[i];
                currentPrefab.name = "" + i;
                Current_Hero_UI_List.Add(currentPrefab);

            }
        }
        #region //�����Ǵ� ��� ��ư�� ����� �޸��ϱ� ���� �׳� �Լ� 10�� ���� ����
        public void ListBtn0()
        {
            heroManager.CurrentHeroList.Add(unemployedHero[0]); // CurrentHeroList�� �ɹ� ������
            unemployedHero[0] = null;
            //heroManager.unemployedHeroList.Remove(unemployedHero[0]);
        }
        public void ListBtn1()
        {
            heroManager.CurrentHeroList.Add(unemployedHero[1]);
            unemployedHero[1] = null;
        }
        public void ListBtn2()
        {
            heroManager.CurrentHeroList.Add(unemployedHero[2]);
            unemployedHero[2] = null;
        }
        public void ListBtn3()
        {
            heroManager.CurrentHeroList.Add(unemployedHero[3]);
            unemployedHero[3] = null;
        }
        public void ListBtn4()
        {
            heroManager.CurrentHeroList.Add(unemployedHero[4]);
            unemployedHero[4] = null;
        }
        public void ListBtn5()
        {
            heroManager.CurrentHeroList.Add(unemployedHero[5]);
            unemployedHero[5] = null;
        }
        public void ListBtn6()
        {
            heroManager.CurrentHeroList.Add(unemployedHero[6]);
            unemployedHero[6] = null;
        }
        public void ListBtn7()
        {
            heroManager.CurrentHeroList.Add(unemployedHero[7]);
            unemployedHero[7] = null;
        }
        public void ListBtn8()
        {
            heroManager.CurrentHeroList.Add(unemployedHero[8]);
            unemployedHero[8] = null;
        }
        public void ListBtn9()
        {
            heroManager.CurrentHeroList.Add(unemployedHero[9]);
            unemployedHero[9] = null;
        }

        #endregion
        public void UpdateMember(GameObject member)//firefunc�� ��� �ذ��ϸ� ����.
        {
            for(int i = 0; i< Current_Hero_UI_List.Count; i++)
            {
                if (Current_Hero_UI_List[i].GetComponent<Current_Hero_UI_Script>().This_Prefab_Object == member)
                {
                    Destroy(Current_Hero_UI_List[i]);
                    Current_Hero_UI_List.RemoveAt(i);
                }
            }
            for(int j = 0; j < Party_Hero_UI_List.Count; j++)
            {
                if(Party_Hero_UI_List[j].This_Prefab_Object == member)
                {
                    Party_Hero_UI_List[j].This_Prefab_Object = null;

                    Party_Hero_UI_List[j].isParty_Hero_In = true;
                    Party_Hero_UI_List[j].gameObject.transform.GetChild(0).GetComponent<Text>().text = "";
                    Party_Hero_UI_List[j].gameObject.transform.GetChild(1).GetComponent<Text>().text = "";
                    Party_Hero_UI_List[j].gameObject.transform.GetChild(2).GetComponent<Text>().text = "";
                }
            }
            for(int k = 0; k < heroManager.CurrentHeroList.Count; k++)
            {
                if(heroManager.CurrentHeroList[k] == member)
                {
                    Destroy(heroManager.CurrentHeroList[k]);
                    heroManager.CurrentHeroList.RemoveAt(k);
                    
                }

            }


        }

    }



}
