using System.Collections.Generic;
using UnityEngine;

public class MapCreate : MonoBehaviour
{
    public GameObject[,] mapPos = new GameObject[8, 8]; //?? ???? ???
    public GameObject[,] map = new GameObject[8, 8]; //?? prefab

    public GameObject nomalRoomPrefab; // ??? ???? ?? ???????
    public GameObject bossRoomPrefab; // ??? ???? ?????? ???????
    public Vector3[,] mapCreatePos = new Vector3[8, 8];// 


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



}
