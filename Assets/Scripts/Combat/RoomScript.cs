using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public MeshRenderer Renderer;
    public int roomNumber;
    void Start()
    {
        Renderer = gameObject.GetComponent<MeshRenderer>();
    }



/// <summary>
/// 방 생성시 번호부여
/// </summary>
/// <param name="num">해당 숫자가 방 번호를 결정함</param>
    public void InitRoomNumber(int num)
    {
        roomNumber = num;
    }



}
