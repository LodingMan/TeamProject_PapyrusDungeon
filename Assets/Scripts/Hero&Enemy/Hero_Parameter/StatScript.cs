using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatScript : MonoBehaviour
{
    public Stat myStat;
    public int MyExp;
    public int PreviousLv = 1;
    public int BuffCount = 0;
    public List<int> BuffValue = new List<int>();
    public List<int> BuffPram = new List<int>();
    public List<int> myBuffTime = new List<int>();


   public float SaveNum; //float값을 int로 바꾸기 위해 있음

    private void Start()
    {
        PreviousLv = 1;
    }
    public void LevelUp()
    {


        if(myStat.Lv != 5)
        {
           PreviousLv = myStat.Lv;
            myStat.Lv++;

            MyExp -= 100;
            SaveNum = myStat.HP * (1f + 10f / 100f);
            myStat.HP = (int)SaveNum;

            SaveNum = myStat.MAXHP * (1f + 10f / 100f);
            myStat.MAXHP = (int)SaveNum;

            SaveNum = myStat.MP * (1f + 10f / 100f);
            myStat.MP = (int)SaveNum;

            SaveNum = myStat.MAXMP * (1f + 10f / 100f);
            myStat.MAXMP = (int)SaveNum;

            SaveNum = myStat.Atk * (1f + 8f / 100f);
            myStat.Atk = (int)SaveNum+1;

            SaveNum = myStat.Def * (1f + 8f / 100f);
            myStat.Def = (int)SaveNum+1;

            SaveNum = myStat.Acc * (1f + 5f / 100f);
            myStat.Acc = (int)SaveNum+1;

            SaveNum = myStat.Agi * (1f + 5f / 100f);
            myStat.Agi = (int)SaveNum+1;

            SaveNum = myStat.Cri * (1f + 5f / 100f);
            myStat.Cri = (int)SaveNum+1;
        }
        else
        {
            Debug.Log("최대레벨입니다.");
        }


    }


}
