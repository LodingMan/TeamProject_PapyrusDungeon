using UnityEngine;
using UnityEngine.EventSystems;

public class RoomScript : MonoBehaviour
{
    public MeshRenderer Renderer;
    public InGame_Player_Script inGame_Player_Script;
    public int roomNumber;

    public int DungeonEventPram = 0; //0 �ƹ��͵����� , 1 ���� , 2 ���ȹ�� , 3 ������ ȹ��

    public int moveDir;
    void Start()
    {
        inGame_Player_Script = GameObject.Find("InGamePlayer").GetComponent<InGame_Player_Script>();
        Renderer = gameObject.GetComponent<MeshRenderer>();
        DungeonEventPram = Random.Range(0, 5);
    }



    public void InitRoomNumber(int num)
    {
        roomNumber = num;
    }

        //if(inGame_Player_Script.isRoom)
        //{
        //    if(inGame_Player_Script.isMove)
        //    {
        //        moveDir = inGame_Player_Script.currentPlayers - roomNumber;
        //        Debug.Log(moveDir);
        //    }
        //}

}
