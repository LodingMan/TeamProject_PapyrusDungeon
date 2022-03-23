using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    public HeroSavingData heroSavingData = new HeroSavingData();

    void Start()
    {
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
