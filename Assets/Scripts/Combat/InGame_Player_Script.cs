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
        combatCameraControll.CameraCurrentPosSet();

    }

    public void KeepGoing()
    {
        PreviousPlayers = currentPlayers;
        currentPlayers = NextPlayers;
        isRoom = true;

        RC.RoomCheck(currentPlayers);
        combatCameraControll.CameraCurrentPosSet();

    }
    public void TurningBack() //·ëÃ¼Å©´Â ÀÎÀÚ·Î µé¾î¿Â³ðÀ» ³ë¶õ»öÀ¸·Î ¹Ù²ãÁÖ°í Previous¸¦ Èò»öÀ¸·Î ¹Ù²ãÁÜ. 
    {
        NextPlayers = PreviousPlayers;
        PreviousPlayers = currentPlayers;
        currentPlayers = NextPlayers;
        isRoom = true;
        RC.RoomCheck(currentPlayers);
        combatCameraControll.CameraCurrentPosSet();

    }
    public void StartWarp(int roomnumber)
    {
        currentPlayers = roomnumber;
        RC.RoomCheck(currentPlayers);
    }

}
