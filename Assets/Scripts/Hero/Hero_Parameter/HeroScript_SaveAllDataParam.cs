using UnityEngine;

public class HeroScript_SaveAllDataParam : MonoBehaviour
{
    public HeroSavingData heroSavingData = new HeroSavingData(); //이 오브젝트가 json으로 파일이 저장될때 사용할 데이터

    void Start()
    {
        SaveMydata(); //오브젝트가 생성됨과 동시에 자신의 스텟 초기화,
                      //이후 세이브 , 레벨업 등 오브젝트의 스텟을 초기화 할 필요가 있다면 사용
    }
    public void SaveMydata() 
    {
        #region // 파라미터 변경. 상세내용은 ClassBundle.cs 66참조
        //heroSavingData.Name = gameObject.GetComponent<StatScript>().Name;
        //heroSavingData.Index = gameObject.GetComponent<StatScript>().Index;
        //heroSavingData.Job = gameObject.GetComponent<StatScript>().Job;
        //heroSavingData.HP = gameObject.GetComponent<StatScript>().HP;
        //heroSavingData.MP = gameObject.GetComponent<StatScript>().MP;
        //heroSavingData.Atk = gameObject.GetComponent<StatScript>().Atk;
        //heroSavingData.Def = gameObject.GetComponent<StatScript>().Def;
        //heroSavingData.Cri = gameObject.GetComponent<StatScript>().Cri;
        //heroSavingData.Acc = gameObject.GetComponent<StatScript>().Acc;
        //heroSavingData.Agi = gameObject.GetComponent<StatScript>().Agi;
        //heroSavingData.Speed = gameObject.GetComponent<StatScript>().Speed;
        //endregion 바로 아래 한문장으로 대체됨.
        #endregion
        heroSavingData.stat = gameObject.GetComponent<StatScript>().myStat; // 영웅 자신의 능력치 저장
        heroSavingData.skills = gameObject.GetComponent<SkillScript>().skills; //스킬 저장
        heroSavingData.equips = gameObject.GetComponent<EquipScript>().myEquip; //장비저장
    }

}
