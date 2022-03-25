using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript_SaveAllDataParam : MonoBehaviour
{
    public HeroSavingData heroSavingData = new HeroSavingData(); //이 오브젝트가 json으로 파일이 저장될때 사용할 데이터

    void Start()
    {
        SaveMydata();
    }
    public void SaveMydata()
    {
        // 변경 사유 : 데이터를 저장할때마다 현재 생성된 오브젝트 리스트의 변경사항을 한번에 저장하기위해서 내용을 함수로 변경
        #region // 영웅 자신의 능력치 저장
        heroSavingData.Name = gameObject.GetComponent<StatScript>().Name;
        heroSavingData.Index = gameObject.GetComponent<StatScript>().Index;
        heroSavingData.Job = gameObject.GetComponent<StatScript>().Job;
        heroSavingData.HP = gameObject.GetComponent<StatScript>().HP;
        heroSavingData.MP = gameObject.GetComponent<StatScript>().MP;
        heroSavingData.Atk = gameObject.GetComponent<StatScript>().Atk;
        heroSavingData.Def = gameObject.GetComponent<StatScript>().Def;
        heroSavingData.Cri = gameObject.GetComponent<StatScript>().Cri;
        heroSavingData.Acc = gameObject.GetComponent<StatScript>().Acc;
        heroSavingData.Agi = gameObject.GetComponent<StatScript>().Agi;
        heroSavingData.skills = gameObject.GetComponent<SkillScript>().skills;
        #endregion
    }

}
