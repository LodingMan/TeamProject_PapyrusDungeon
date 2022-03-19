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
/// 방 생성시 번호부여
/// </summary>
/// <param name="num">해당 숫자가 방 번호를 결정함</param>
    public void InitRoomNumber(int num)
    {
        roomNumber = num;
    }

    /// <summary>
    /// Passage의 생성은 MapCreate에서 함
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
