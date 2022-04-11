using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class InGame_Player_Script : MonoBehaviour
{
    public int currentPlayers = 0;
    public int PreviousPlayers;
    public int NextPlayers;
    public Text currentPlayerText;
    //public MapCreate mapCreate;
    public RoomController RC;



    public Combat_Event_UI_Manager combat_Event_UI_Manager;
    public e_CombatManager combatManager;
    public CombatCameraControll combatCameraControll;


    public bool isRoom = true;
    public bool isMove = true;


    void Start()
    {

    }

    public void PlayerWarp(int roomnumber)
    {
        PreviousPlayers = currentPlayers;

        switch (roomnumber)
        {
            case 1:
                PreviousPlayers = currentPlayers;
                NextPlayers = currentPlayers + 1;
                currentPlayers += 100;

                break;
            case -1:
                PreviousPlayers = currentPlayers;
                NextPlayers = currentPlayers - 1;
                currentPlayers += 99;


                break;
            case 10:
                PreviousPlayers = currentPlayers;
                NextPlayers = currentPlayers + 10;
                currentPlayers += 200;

                break;
            case -10:
                PreviousPlayers = currentPlayers;
                NextPlayers = currentPlayers - 10;
                currentPlayers += 190;

                break;
            default:
                return;
        }
        isRoom = false;
        RC.RoomCheck(currentPlayers);
        StartCoroutine(combatCameraControll.MinimapDlay());

        combatCameraControll.CameraCurrentPosSet();
        //복도로 이동
        StartCoroutine(RC.PassagePrefabLoad());


    }

    public void KeepGoing()
    {
        PreviousPlayers = currentPlayers;
        currentPlayers = NextPlayers;
        isRoom = true;

        RC.RoomCheck(currentPlayers);
        combatCameraControll.CameraCurrentPosSet();

        //던전으로 바꾸기
        StartCoroutine(RC.RoomPrefabLoad());


    }
    public void TurningBack() //룸체크는 인자로 들어온놈을 노란색으로 바꿔주고 Previous를 흰색으로 바꿔줌. 
    {
        NextPlayers = PreviousPlayers;
        PreviousPlayers = currentPlayers;
        currentPlayers = NextPlayers;
        isRoom = true;
        RC.RoomCheck(currentPlayers);
        combatCameraControll.CameraCurrentPosSet();

        //던전으로 바꾸기
        StartCoroutine(RC.RoomPrefabLoad());


    }
    public void StartWarp(int roomnumber)
    {
        currentPlayers = roomnumber;
        RC.RoomCheck(currentPlayers);
        combat_Event_UI_Manager.MinimapGuide();
        isMove = true;
    }

    
}
