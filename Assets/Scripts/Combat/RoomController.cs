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

    
    public List<Material> RoomColors;
    public int PreviousRoomNumber;

    public bool isFirst = true;



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
                        switch (RoomList[i].GetComponent<RoomScript>().DungeonEventPram) //전투이벤트
                        {
                            case 0:
                                
                            case 1:
                               
                            case 2:
                                Debug.Log("전투시작");
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
                        switch (RoomList[i].GetComponent<RoomScript>().DungeonEventPram)
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


                        combat_Event_UI_Manager.Go_Back_On(); //이벤트가 끝나고 나타나야됨. 


                    }





                }

                isFirst = false;
            }
        }

        #region 보험
        //Debug.Log(roomnumber);
        //if (players.isRoom)
        //{ 
        //    for (int i = 0; i < RoomList.Count; i++)
        //    {
        //        if (roomnumber == RoomList[i].GetComponent<RoomScript>().roomNumber)
        //        {
        //            roomScript = RoomList[i].GetComponent<RoomScript>();
        //            roomScript.Renderer.material = roomScript.PlayerCheckList[1];
        //            for (int j = 0; j < PassageList.Count; j++)
        //            {
        //                if (PassageList[j].GetComponent<PassageScript>().passageNumber == players.PreviousPlayers)
        //                {
        //                    passageScript = PassageList[j].GetComponent<PassageScript>();

        //                }
        //            }
        //        }
        //    }
        //}
        //else if (!players.isRoom)
        //{
        //    for (int i = 0; i < PassageList.Count; i++)
        //    {
        //        if (roomnumber == PassageList[i].GetComponent<PassageScript>().passageNumber)
        //        {
        //            passageScript = PassageList[i].GetComponent<PassageScript>();
        //            for(int j = 0; j < RoomList.Count; j++)
        //            {
        //                if (RoomList[j].GetComponent<RoomScript>().roomNumber == players.PreviousPlayers)
        //                {
        //                    roomScript = RoomList[j].GetComponent<RoomScript>();

        //                    roomScript.Renderer.material = roomScript.PlayerCheckList[0];

        //                }
        //            }

        //        }
        //    }
        //}
        #endregion


    }



}
