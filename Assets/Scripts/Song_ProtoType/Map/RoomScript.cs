using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public Material[] PlayerCheckList = new Material[2];
    public GameObject[] childernPassage = new GameObject[2];
    public MeshRenderer Renderer;
    public int roomNumber;
    void Start()
    {
        Renderer = gameObject.GetComponent<MeshRenderer>();
        Renderer.material = PlayerCheckList[0];

    }



/// <summary>
/// �� ������ ��ȣ�ο�
/// </summary>
/// <param name="num">�ش� ���ڰ� �� ��ȣ�� ������</param>
    public void InitRoomNumber(int num)
    {
        roomNumber = num;
    }

    /// <summary>
    /// Passage�� ������ MapCreate���� ��
    /// </summary>
    /// <param name="Passage"></param>
    public void initPassage(GameObject Passage)
    {
        if(Passage.tag == "Up")
        {
            childernPassage[0] = Passage;
        }
        else if (Passage.tag == "Right")
        {
            childernPassage[1] = Passage;
        }
    }


}
