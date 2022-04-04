using System.Collections.Generic;
using UnityEngine;

public class MapCreate : MonoBehaviour
{

    public GameObject[,] map = new GameObject[8, 8];
    public List<GameObject> passages;

    public GameObject nomalRoomPrefab;
    public GameObject bossRoomPrefab;
    public GameObject passagePrefab;
    public Vector3[,] mapCreatePos = new Vector3[8, 8];
    public CombatCameraControll combatCameraControll;

    public RoomController RC;


    public int startRoomNumber;

    public int searchX;
    public int searchY;
    public List<int> selectRoom;
    public List<int> passageRoom;
    public int createRoomCnt = 0;
    public int currentSelectRoom = 0;

    public int noneCnt;
    public int startingPointRoomNumber;

    //여기 아래부터 참조하는 스크립트

    public InGame_Player_Script players;
    public RoomScript roomScript;
    public GameObject MinimapBundle;


    public void MapCreateFunc()
    {
        Debug.Log("시작");
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                mapCreatePos[i, j] = new Vector3(3000 + (j * 10), 0 + (i * 10), -1);
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

        players.StartWarp(startRoomNumber);
        combatCameraControll.CameraCurrentPosSet();


    }

    public void firstSelect()
    {
        int rnd = Random.Range(0, 7);
        map[6, rnd] = Instantiate(nomalRoomPrefab, mapCreatePos[6, rnd], transform.rotation) as GameObject;
        map[6, rnd].name = "[" + 6 + "," + rnd + "]" + "START";


        map[6, rnd].GetComponent<RoomScript>().InitRoomNumber(60 + rnd);// 방에게 현재 방번호 부여
        map[6, rnd].transform.SetParent(MinimapBundle.transform);

        selectRoom.Add((6 * 10) + rnd);
        RC.RoomList.Add(map[6, rnd]);

        startRoomNumber = selectRoom[0];

        // players.StartWarp(selectRoom[0]);


    }

    public void MapIns()
    {

        int SearchNum;

        SearchNum = selectRoom[currentSelectRoom];

        if (SearchNum < 70)
        {
            SearchNum += 10;
            searchX = SearchNum % 10;
            searchY = SearchNum / 10;


            if (map[searchY, searchX] == null)
            {
                if (searchY != 7)
                {
                    if (map[searchY + 1, searchX] != null)
                    {
                        noneCnt++;
                    }
                }
                if (searchX != 0)
                {
                    if (map[searchY, searchX - 1] != null)
                    {
                        noneCnt++;
                    }
                }
                if (searchX != 7)
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
                        map[searchY, searchX].transform.SetParent(MinimapBundle.transform);

                        RC.RoomList.Add(map[searchY, searchX]);

                        map[searchY, searchX].name = "[" + searchY + "," + searchX + "]";

                        map[searchY, searchX].GetComponent<RoomScript>().InitRoomNumber((searchY * 10) + searchX);// 방에게 현재 방번호 부여

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



            if (map[searchY, searchX] == null)
            {
                if (searchY != 0)
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
                        map[searchY, searchX].transform.SetParent(MinimapBundle.transform);

                        RC.RoomList.Add(map[searchY, searchX]);

                        map[searchY, searchX].name = "[" + searchY + "," + searchX + "]";

                        map[searchY, searchX].GetComponent<RoomScript>().InitRoomNumber((searchY * 10) + searchX);// 방에게 현재 방번호 부여

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


            if (map[searchY, searchX] == null)
            {
                if (searchY != 7)
                {
                    if (map[searchY + 1, searchX] != null)
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
                        map[searchY, searchX].transform.SetParent(MinimapBundle.transform);

                        RC.RoomList.Add(map[searchY, searchX]);

                        map[searchY, searchX].name = "[" + searchY + "," + searchX + "]";

                        map[searchY, searchX].GetComponent<RoomScript>().InitRoomNumber((searchY * 10) + searchX);// 방에게 현재 방번호 부여

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


            if (map[searchY, searchX] == null)
            {
                if (searchY != 7)
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
                if (searchX != 7)
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
                        map[searchY, searchX].transform.SetParent(MinimapBundle.transform);

                        RC.RoomList.Add(map[searchY, searchX]);

                        map[searchY, searchX].name = "[" + searchY + "," + searchX + "]";

                        map[searchY, searchX].GetComponent<RoomScript>().InitRoomNumber((searchY * 10) + searchX);// 방에게 현재 방번호 부여

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
        RC.RoomList.RemoveAt(RC.RoomList.Count - 1);
        map[bossY, bossX] = Instantiate(bossRoomPrefab, mapCreatePos[bossY, bossX], transform.rotation) as GameObject;
        map[bossY, bossX].transform.SetParent(MinimapBundle.transform);

        RC.RoomList.Add(map[bossY, bossX]);


        map[bossY, bossX].GetComponent<RoomScript>().InitRoomNumber((bossY * 10) + bossX);// 방에게 현재 방번호 부여

        map[bossY, bossX].name = "[" + bossY + "," + bossX + "]" + "BOSSROOM";

    }


    public void PassageCreate()
    {
        GameObject Passage;

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
                    Passage = Instantiate(passagePrefab, mapCreatePos[selectRoom[i] / 10, selectRoom[i] % 10] + new Vector3(Random.Range(-1, 2), 5, 0), Quaternion.Euler(0, 0, 90)) as GameObject;
                    Passage.transform.SetParent(MinimapBundle.transform);

                    Passage.name = "" + selectRoom[i] + "Up";
                    Passage.tag = "Up";
                    RC.RoomList.Add(Passage);

                    Passage.GetComponent<RoomScript>().roomNumber = selectRoom[i] + 200;

                }
                if (selectRoom[i] + 1 == selectRoom[j])
                {
                    Passage = Instantiate(passagePrefab, mapCreatePos[selectRoom[i] / 10, selectRoom[i] % 10] + new Vector3(5, Random.Range(-1, 2), 0), Quaternion.Euler(0, 0, 0)) as GameObject;
                    Passage.transform.SetParent(MinimapBundle.transform);

                    Passage.name = "" + selectRoom[i] + "Right";
                    Passage.tag = "Right";
                    RC.RoomList.Add(Passage);

                    Passage.GetComponent<RoomScript>().roomNumber = selectRoom[i] + 100;

                }
            }
        }
    }

    //public void RoomCheck()
    //{
    //    for (int i = 0; i < selectRoom.Count; i++)
    //    {
    //        if (map[selectRoom[i] / 10, selectRoom[i] % 10].GetComponent<RoomScript>().roomNumber == players.currentPlayers)
    //        {
    //            roomScript = map[selectRoom[i] / 10, selectRoom[i] % 10].GetComponent<RoomScript>();
    //            roomScript.renderer.material = roomScript.PlayerCheckList[1];
    //        }
    //        else
    //        {
    //            roomScript = map[selectRoom[i] / 10, selectRoom[i] % 10].GetComponent<RoomScript>();
    //            roomScript.renderer.material = roomScript.PlayerCheckList[0];
    //        }
    //    }
    //}






    void Swap(List<int> arr, int num1, int num2)
    {
        int tmp = arr[num1];
        arr[num1] = arr[num2];
        arr[num2] = tmp;
    }

}
