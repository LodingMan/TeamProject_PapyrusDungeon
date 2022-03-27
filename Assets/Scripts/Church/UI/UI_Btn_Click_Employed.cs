using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// ������� ���� ��ư Ŭ���� �޷� ����.
public class UI_Btn_Click_Employed : MonoBehaviour
{
    Shin.UI_EmployedHeroLoad uI_EmployedHeroLoad;
    public Button btn; // �ڱ� �ڽ��� ��ư.
    public int Cnt;
    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Create_HealingHero_UI_Prefab); // ��ư�� ������
        
    }
    private void Start()
    {
        uI_EmployedHeroLoad = GameObject.Find("UI_ChurchManager").GetComponent<Shin.UI_EmployedHeroLoad>();
    }

    public void Create_HealingHero_UI_Prefab()
    {
        gameObject.SetActive(false);
        uI_EmployedHeroLoad.healingHero_UI[Cnt] = Instantiate(uI_EmployedHeroLoad.healingHero_UI_Prefab, uI_EmployedHeroLoad.healing_List_UI_Content.transform); // UI ����.
        uI_EmployedHeroLoad.healingHero_UI[Cnt].name = gameObject.name; // UI ���̹�.
        Cnt++;
        
    }
}
