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
/// �� ������ ��ȣ�ο�
/// </summary>
/// <param name="num">�ش� ���ڰ� �� ��ȣ�� ������</param>
    public void InitRoomNumber(int num)
    {
        roomNumber = num;
    }



}
