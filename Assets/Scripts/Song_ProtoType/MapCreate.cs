using System.Collections.Generic;
using UnityEngine;

public class MapCreate : MonoBehaviour
{

    public GameObject[,] map = new GameObject[8, 8]; //?? prefab

    public GameObject nomalRoomPrefab; // ??? ???? ?? ???????
    public GameObject bossRoomPrefab; // ??? ???? ?????? ???????
    public GameObject passagePrefab;
    public Vector3[,] mapCreatePos = new Vector3[8, 8];// 

    public List<GameObject> passageList;

    public int searchX; //?? ?????? ???? ????????? X???
    public int searchY; // ????

    public List<int> selectRoom;
    public int createRoomCnt = 0; // ?????? ???? ????
    public int currentSelectRoom = 0; // ???? ?????? ?????? ???? ?????? ???

    public int noneCnt;  // ?? ?????? ????? ??????? ???? ????? ??????. noneCnt?? ???? ??? ????? ???? ???????? ??????.

    void Start()
    {
        for (int i = 0; i < 8; i++)  //?? ???? ??? ????
        {
            for (int j = 0; j < 8; j++)
            {
                mapCreatePos[i, j] = new Vector3(0 + (j * 10), 0 + (i * 10), 0);
            }
        }
        firstSelect();

        for (int i = 0; i < 1000; i++)
        {
            MapIns();

            if (createRoomCnt > 30)
            {
                break;
            }
        }
        BossRoomCreate();

        PassageCreate();
    }

    public void firstSelect()
    {
        int rnd = Random.Range(0, 7);
        map[6, rnd] = Instantiate(nomalRoomPrefab, mapCreatePos[6, rnd], transform.rotation) as GameObject;
        map[6, rnd].name = "[" + 6 + "," + rnd + "]" + "START";
        selectRoom.Add((6 * 10) + rnd); // ???? ??? ?????? ?? ????? SelectRoom??????? ???//
                                        //  gameManager.PlayerSector = (int)SelectRoom[0]; //????????? ??????? ????
    }

    public void MapIns()
    {

        int SearchNum;

        SearchNum = selectRoom[currentSelectRoom]; //???  selectroomnumber?? 0???? ???? ????????? ? ???? ??????? ??.
                                                   //??? ?????? 60+? ?? ???? SearchNum?? ???.


        if (SearchNum < 70) //???????? 60???? ???? ???????? ?????? ?????? ?????. ???? ????? 70??????? ??????? ???????? ??? ????? if???? ???????. 
        {
            SearchNum += 10;
            searchX = SearchNum % 10; //1?????
            searchY = SearchNum / 10; //10?????


            /////////////??????
            if (map[searchY, searchX] == null)  //?????? ???????
            {
                if (searchY != 7) //?? ????? ??? ?????
                {
                    if (map[searchY + 1, searchX] != null) //??????? ??? ?? ???
                    {
                        noneCnt++;
                    }
                }
                if (searchX != 0) // ?? ?????? ?????
                {
                    if (map[searchY, searchX - 1] != null)
                    {
                        noneCnt++;
                    }
                }
                if (searchX != 7) // ?? ?????? ?????
                {
                    if (map[searchY, searchX + 1] != null)
                    {
                        noneCnt++;
                    }
                }

                int RandomCreate = Random.Range(0, 10);

                if (noneCnt < 1)
                {
                    if (RandomCreate >= 3)
                    {
                        map[searchY, searchX] = Instantiate(nomalRoomPrefab, mapCreatePos[searchY, searchX], transform.rotation) as GameObject;
                        map[searchY, searchX].name = "[" + searchY + "," + searchX + "]";
                        selectRoom.Add((searchY * 10) + searchX);
                        createRoomCnt++;
                    }
                }
                noneCnt = 0;
            }
        }

        SearchNum = selectRoom[currentSelectRoom];

        if (SearchNum > 7)
        {
            SearchNum -= 10;
            searchX = SearchNum % 10;
            searchY = SearchNum / 10;

            //////////////////?????

            if (map[searchY, searchX] == null)  //?????? ???????
            {
                if (searchY != 0) // ?? ?????? ?????
                {
                    if (map[searchY - 1, searchX] != null)
                    {
                        //  Debug.Log("?????? ???????");
                        noneCnt++;
                    }
                }
                if (searchX != 0) // ?? ?????? ?????
                {
                    if (map[searchY, searchX - 1] != null)
                    {
                        //   Debug.Log("?????? ???????");
                        noneCnt++;
                    }
                }
                if (searchX != 7) // ?? ?????? ?????
                {
                    if (map[searchY, searchX + 1] != null)
                    {
                        //   Debug.Log("?????? ???????");
                        noneCnt++;
                    }
                }
                int RandomCreate = Random.Range(0, 10);
                if (noneCnt < 1)
                {
                    if (RandomCreate >= 3)
                    {
                        map[searchY, searchX] = Instantiate(nomalRoomPrefab, mapCreatePos[searchY, searchX], transform.rotation) as GameObject;
                        map[searchY, searchX].name = "[" + searchY + "," + searchX + "]";

                        selectRoom.Add((searchY * 10) + searchX);
                        createRoomCnt++;
                    }
                }
                noneCnt = 0;


            }
        }

        SearchNum = selectRoom[currentSelectRoom];
        if ((SearchNum % 10) != 0)
        {

            SearchNum -= 1;
            searchX = SearchNum % 10;
            searchY = SearchNum / 10;

            //////////////////???????

            if (map[searchY, searchX] == null)  //?????? ???????
            {
                if (searchY != 7) //?? ????? ??? ?????
                {
                    if (map[searchY + 1, searchX] != null) //??????? ??? ?? ???
                    {
                        noneCnt++;
                    }
                }
                if (searchY != 0) // ?? ?????? ?????
                {
                    if (map[searchY - 1, searchX] != null)
                    {
                        noneCnt++;
                    }
                }
                if (searchX != 0) // ?? ?????? ?????
                {
                    if (map[searchY, searchX - 1] != null)
                    {
                        noneCnt++;
                    }
                }
                int RandomCreate = Random.Range(0, 10);

                if (noneCnt < 1)
                {
                    if (RandomCreate >= 3)
                    {
                        map[searchY, searchX] = Instantiate(nomalRoomPrefab, mapCreatePos[searchY, searchX], transform.rotation) as GameObject;
                        map[searchY, searchX].name = "[" + searchY + "," + searchX + "]";


                        selectRoom.Add((searchY * 10) + searchX);
                        createRoomCnt++;


                    }
                }
                noneCnt = 0;
            }
        }



        SearchNum = selectRoom[currentSelectRoom];
        if ((SearchNum % 10) != 7)
        {

            SearchNum += 1;
            searchX = SearchNum % 10;
            searchY = SearchNum / 10;

            //////////////////???????

            if (map[searchY, searchX] == null)  //?????? ???????
            {
                if (searchY != 7) //?? ????? ??? ?????
                {
                    if (map[searchY + 1, searchX] != null) //??????? ??? ?? ???
                    {
                        noneCnt++;
                    }
                }
                if (searchY != 0) // ?? ?????? ?????
                {
                    if (map[searchY - 1, searchX] != null)
                    {
                        noneCnt++;
                    }
                }
                if (searchX != 7) // ?? ?????? ????? ????
                {
                    if (map[searchY, searchX + 1] != null)
                    {
                        noneCnt++;
                    }
                }
                int RandomCreate = Random.Range(0, 10);

                if (noneCnt < 1)
                {
                    if (RandomCreate >= 3)
                    {
                        map[searchY, searchX] = Instantiate(nomalRoomPrefab, mapCreatePos[searchY, searchX], transform.rotation) as GameObject;
                        map[searchY, searchX].name = "[" + searchY + "," + searchX + "]";


                        selectRoom.Add((searchY * 10) + searchX);
                        createRoomCnt++;

                    }
                }
                noneCnt = 0;


            }
        }

        if (createRoomCnt <= currentSelectRoom)
        {
            --currentSelectRoom;
        }
        ++currentSelectRoom;
    }

    void BossRoomCreate()
    {
        int bossX;
        int bossY;

        bossX = selectRoom[selectRoom.Count - 1] % 10;
        bossY = selectRoom[selectRoom.Count - 1] / 10;
        Destroy(map[bossY, bossX]);
        map[bossY, bossX] = Instantiate(bossRoomPrefab, mapCreatePos[bossY, bossX], transform.rotation) as GameObject;
        map[bossY, bossX].name = "[" + searchY + "," + searchX + "]" + "BOSSROOM";

    }


    public void PassageCreate()
    {
        for (int i = selectRoom.Count - 1; i > 0; i--) // 버블 오름차순 정렬
            for (int j = 0; j < i; j++)
                if (selectRoom[j] > selectRoom[j + 1])
                    Swap(selectRoom, j, j + 1);

        for (int i = 0; i < selectRoom.Count; i++) // 통로 생성
        {
            for (int j = 0; j < selectRoom.Count; j++)
            {
                if (selectRoom[i] + 10 == selectRoom[j])
                {
                    Instantiate(passagePrefab, mapCreatePos[selectRoom[i] / 10 , selectRoom[i] % 10] + new Vector3(0,5,0), Quaternion.Euler(0,0,90));
                }
                if (selectRoom[i] - 1 == selectRoom[j])
                {
                    Instantiate(passagePrefab, mapCreatePos[selectRoom[i] / 10, selectRoom[i] % 10] + new Vector3(-5, 0, 0), Quaternion.Euler(0, 0, 0));

                }
                if (selectRoom[i] + 1 == selectRoom[j])
                {
                    Instantiate(passagePrefab, mapCreatePos[selectRoom[i] / 10, selectRoom[i] % 10] + new Vector3(5, 0, 0), Quaternion.Euler(0, 0, 0));

                }
            }
        }

    }
        void Swap(List<int> arr, int num1, int num2)
        {
            int tmp = arr[num1];
            arr[num1] = arr[num2];
            arr[num2] = tmp;
        }

}
