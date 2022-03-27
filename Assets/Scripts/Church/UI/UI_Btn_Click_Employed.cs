using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// 고용중인 영웅 버튼 클릭에 달려 있음.
public class UI_Btn_Click_Employed : MonoBehaviour
{
    Shin.UI_EmployedHeroLoad uI_EmployedHeroLoad;
    public Button btn; // 자기 자신의 버튼.
    public int Cnt;
    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Create_HealingHero_UI_Prefab); // 버튼이 눌리면
        
    }
    private void Start()
    {
        uI_EmployedHeroLoad = GameObject.Find("UI_ChurchManager").GetComponent<Shin.UI_EmployedHeroLoad>();
    }

    public void Create_HealingHero_UI_Prefab()
    {
        gameObject.SetActive(false);
        uI_EmployedHeroLoad.healingHero_UI[Cnt] = Instantiate(uI_EmployedHeroLoad.healingHero_UI_Prefab, uI_EmployedHeroLoad.healing_List_UI_Content.transform); // UI 생성.
        uI_EmployedHeroLoad.healingHero_UI[Cnt].name = gameObject.name; // UI 네이밍.
        Cnt++;
        
    }
}
