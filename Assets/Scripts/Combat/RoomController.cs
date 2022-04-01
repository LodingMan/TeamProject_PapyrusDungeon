using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public MapCreate mapCreate;
    public List<GameObject> RoomList;
    public RoomScript roomScript;
    public PlayerScript_Proto inGamePlayerScript;
    public List<Material> RoomColors;




    public void RoomCheck(int roomnumber)
    {

        for(int i = 0; i<RoomList.Count; i++)
        {
            if (RoomList[i].GetComponent<RoomScript>().roomNumber == inGamePlayerScript.currentPlayers)
            {
             //   RoomList[i].GetComponent<MeshRenderer>().material = 
            }
        }






        #region º¸Çè
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
