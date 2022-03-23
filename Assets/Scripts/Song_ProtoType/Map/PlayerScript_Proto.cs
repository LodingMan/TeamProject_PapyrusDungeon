using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript_Proto : MonoBehaviour
{
    public int currentPlayers=0;
    public int PreviousPlayers;
    public bool isRoom =true;
    public Text currentPlayerText;
    public MapCreate mapCreate;
    public RoomController RC;


    void Start()
    {

    }

    public void PlayerWarp(int roomnumber)
    {
        PreviousPlayers = currentPlayers;

        switch (roomnumber)
        {
            case 1:
                if(isRoom)
                {
                    currentPlayers += 100;
                    isRoom = false;
                }
                else
                {
                    currentPlayers -= 99;
                    isRoom = true;
                }
                break;
            case -1:
                if (isRoom)
                {
                    currentPlayers += 99;
                    isRoom = false;

                }
                else
                {
                    currentPlayers -= 100;
                    isRoom = true;
                }
                break;
            case 10:
                if (isRoom)
                {
                    currentPlayers += 200;
                    isRoom = false;
                }
                else
                {
                    currentPlayers -= 190;
                    isRoom = true;
                }
                break;
            case -10:
                if (isRoom)
                {
                    currentPlayers += 190;
                    isRoom = false;
                }
                else
                {
                    currentPlayers -= 200;
                    isRoom = true;
                }
                break;
            default:
                break;
        }
        RC.RoomCheck(currentPlayers);


    }
    public void StartWarp(int roomnumber)
    {
        currentPlayers = roomnumber;
        currentPlayerText.text = "" + currentPlayers;
        //RC.RoomCheck(currentPlayers);

    }
    public void Warp()
    {
        RC.RoomCheck(currentPlayers);

    }

}
