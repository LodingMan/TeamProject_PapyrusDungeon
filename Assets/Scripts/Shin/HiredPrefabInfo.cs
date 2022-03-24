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
    public HeroClass heroData; // 자체적으로 HeroClass를 가지고 있어야 됨.

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

        // heroClass받아온걸로 여기서 오브젝트프리팹 생성.
    }


}
