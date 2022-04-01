using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public MapCreate mapCreate;
    public List<GameObject> RoomList;
    public RoomScript roomScript;
    public InGame_Player_Script inGamePlayerScript;
    public List<Material> RoomColors;
    public int PreviousRoomNumber;

    public bool isFirst = true;




    public void RoomCheck(int Roomnumber)
    {

        for(int i = 0; i<RoomList.Count; i++)
        {
            if (RoomList[i].GetComponent<RoomScript>().roomNumber == Roomnumber)
            {
                RoomList[i].GetComponent<MeshRenderer>().material = RoomColors[1];
                if(!isFirst)
                {
                    for(int j = 0; j < RoomList.Count; j++)
                    {
                        if(RoomList[j].GetComponent<RoomScript>().roomNumber == Roomnumber)
                        {
                            RoomList[j].GetComponent<MeshRenderer>().material = RoomColors[0];
                            Debug.Log("함수 써짐");

                            break;

                        }
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
