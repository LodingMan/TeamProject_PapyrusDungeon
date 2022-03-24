using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiredPrefabInfo : MonoBehaviour
{
    public int index;
    public CreateHiredPrefabs createHiredPrefabs;
    public Button hireBtn;
    public Text textHeroName;
    public Text textHeroLv;
    public Text textHeroIndex;
    public HeroClass heroData; // ��ü������ HeroClass�� ������ �־�� ��.

    void Awake()
    {
        createHiredPrefabs = transform.parent.GetComponent<CreateHiredPrefabs>();
        hireBtn = transform.GetChild(0).GetComponent<Button>();
        textHeroName = transform.GetChild(2).GetComponent<Text>();
        textHeroLv = transform.GetChild(3).GetComponent<Text>();
        textHeroIndex = transform.GetChild(4).GetComponent<Text>();

        heroData = createHiredPrefabs.heroData;

        gameObject.name = heroData.name;
        textHeroIndex.text = "Index : " + heroData.index;
        textHeroLv.text = "Lv : " + heroData.lv;
        textHeroName.text = heroData.name;

        // heroClass�޾ƿ°ɷ� ���⼭ ������Ʈ������ ����.
    }


}
