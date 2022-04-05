using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public MapCreate mapCreate;
    public List<GameObject> RoomList;
    public RoomScript roomScript;

    public InGame_Player_Script inGamePlayerScript;
    public Combat_Event_UI_Manager combat_Event_UI_Manager;
    public Room_Passage_Event room_Passage_Event;
    public e_CombatManager combatManager;

    
    public List<Material> RoomColors;
    public int PreviousRoomNumber;

    public bool isFirst = true;

    public List<GameObject> RoomPrefabs = new List<GameObject>();



    public void RoomCheck(int Roomnumber)
    {
        Debug.Log(Roomnumber);

        for (int i = 0; i<RoomList.Count; i++)
        {
            if (RoomList[i].GetComponent<RoomScript>().roomNumber == Roomnumber)
            {
                RoomList[i].GetComponent<MeshRenderer>().material = RoomColors[1];
                Debug.Log(Roomnumber);
                if(!isFirst)
                {
                    for(int j = 0; j < RoomList.Count; j++)
                    {
                        if(RoomList[j].GetComponent<RoomScript>().roomNumber == inGamePlayerScript.PreviousPlayers)
                        {
                            RoomList[j].GetComponent<MeshRenderer>().material = RoomColors[0];
                            //Debug.Log(inGamePlayerScript.PreviousPlayers);

                            break;

                        }
                    }

                    if(RoomList[i].GetComponent<RoomScript>().roomNumber < 99)
                    {
                        switch (RoomList[i].GetComponent<RoomScript>().DungeonEventPram) //룸이벤트
                        {
                            case 0:
                                
                            case 1:
                               
                            case 2:
                                Debug.Log("전투시작");
                                StartCoroutine(BattleDlay());
                                inGamePlayerScript.isMove = false;
                                
                                //여기서 컴뱃 스타트임.
                                break;
                            case 3:
                                Debug.Log("골드");
                                break;
                            case 4:
                                Debug.Log("아이템");
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        StartCoroutine(PassageEventDlay(RoomList[i]));
                        
                    }
                }

                isFirst = false;
            }
        }



    }

    IEnumerator BattleDlay()
    {
        yield return new WaitForSeconds(11);
        combatManager.EnemyInit();

        combat_Event_UI_Manager.BattleStart();

    }

    public IEnumerator RoomPrefabLoad()
    {
        
        yield return new WaitForSeconds(3);
        RoomPrefabs[1].SetActive(false);
        RoomPrefabs[2].SetActive(false);
        RoomPrefabs[0].SetActive(true);

    }
    public IEnumerator PassagePrefabLoad()
    {
        yield return new WaitForSeconds(3);
        RoomPrefabs[0].SetActive(false);
        RoomPrefabs[1].SetActive(true);
        RoomPrefabs[2].SetActive(true);
    }

    public IEnumerator PassageEventDlay(GameObject Room)
    {

        yield return new WaitForSeconds(5);
        //그냥 여기서 코루틴 부르고 코루틴 안에서 이벤트 처리하는게 나을듯
        switch (Room.GetComponent<RoomScript>().DungeonEventPram) //복도이벤트
        {
            case 0:

            case 1:

            case 2:
            case 3:
            case 4:
                room_Passage_Event.Passage_HpDown_Event();
                break;
            default:
                break;
        }

        combat_Event_UI_Manager.Go_Back_On(); //이벤트가 끝나고 나타나야됨.  가급적이면 

    }


}
