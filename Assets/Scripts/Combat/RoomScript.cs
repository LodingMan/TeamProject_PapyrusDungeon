using UnityEngine;
using UnityEngine.EventSystems;

public class RoomScript : MonoBehaviour
{
    public MeshRenderer Renderer;
    public InGame_Player_Script inGame_Player_Script;
    public int roomNumber;

    public bool isBossRoom = false;


    public int DungeonEventPram = 0; //0 æ∆π´∞Õµµæ¯¿Ω , 1 ¿¸≈ı , 2 ∞ÒµÂ»πµÊ , 3 æ∆¿Ã≈€ »πµÊ , 6 ∫∏Ω∫∑Î

    public int moveDir;
    void Start()
    {
        if(!isBossRoom)
        {
            DungeonEventPram = Random.Range(0, 5);
        }
        else
        {
            DungeonEventPram = 6;
        }
        inGame_Player_Script = GameObject.Find("InGamePlayer").GetComponent<InGame_Player_Script>();
        Renderer = gameObject.GetComponent<MeshRenderer>();
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
