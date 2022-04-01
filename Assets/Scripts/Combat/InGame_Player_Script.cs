using UnityEngine;
using UnityEngine.UI;

public class InGame_Player_Script : MonoBehaviour
{
    public int currentPlayers = 0;
    public int PreviousPlayers;
    public int NextPlayers;
    public Text currentPlayerText;
    //public MapCreate mapCreate;
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
                break;
        }
        RC.RoomCheck(currentPlayers);
    }

    public void KeepGoing()
    {
        PreviousPlayers = currentPlayers;
        currentPlayers = NextPlayers;
        RC.RoomCheck(currentPlayers);
    }
    public void TurningBack() //룸체크는 인자로 들어온놈을 노란색으로 바꿔주고 Previous를 흰색으로 바꿔줌. 
    {
        NextPlayers = PreviousPlayers;
        PreviousPlayers = currentPlayers;
        currentPlayers = NextPlayers;
        RC.RoomCheck(currentPlayers);
    }
    public void StartWarp(int roomnumber)
    {
        currentPlayers = roomnumber;
        RC.RoomCheck(currentPlayers);
    }

}
