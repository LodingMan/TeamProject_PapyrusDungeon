using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Song;
using Shin;

public class ManagerTable : MonoBehaviour
{
    public UI_Tweening_Manager tweenManager;
    public TownManager townManager;
    public ItemUseManager itemUseMgr;
    public UI_DungeonInitButton uI_DungeonInitButton;
    public HeroManager heroManager;
    public HeroImageTable heroImageTable;
    public GuildManager guildManager;
    public UI_ChurchManager churchManager;
    public UI_TrainingManager trainingManager;
    public SmithManager smithManager;
    public ShopManager shopManager;
    public CameraMoving cameraMoving;
    public UI_DungeonSelect_Manager dungeonSelect_Manager;
    public SkillDetailTable skillDetailTable;
    public EquipDetailTable equipDetailTable;
    public UI_SoundMgr soundMgr;
    public TutorialManager TutorialMgr;
    public BMPanelManager bmMgr;
    private void Awake()
    {
        tweenManager = GameObject.Find("TweeningManager").GetComponent<UI_Tweening_Manager>();
        townManager = GameObject.Find("TownManager").GetComponent<TownManager>();
        itemUseMgr = GameObject.Find("TentManager").GetComponent<ItemUseManager>();
        uI_DungeonInitButton = GameObject.Find("TentManager").GetComponent<UI_DungeonInitButton>();
        heroManager = GameObject.Find("HeroManager").GetComponent<HeroManager>();
        heroImageTable = GameObject.Find("HeroImageManager").GetComponent<HeroImageTable>();
        guildManager = GameObject.Find("GuildManager").GetComponent<GuildManager>();
        trainingManager = GameObject.Find("TrainingManager").GetComponent<UI_TrainingManager>();
        churchManager = GameObject.Find("ChurchManager").GetComponent<UI_ChurchManager>();
        smithManager = GameObject.Find("SmithManager").GetComponent<SmithManager>();
        shopManager = GameObject.Find("ShopManager").GetComponent<ShopManager>();
        cameraMoving = GameObject.Find("CameraManager").GetComponent<CameraMoving>();
        dungeonSelect_Manager = GameObject.Find("DungeonSelectManager").GetComponent<UI_DungeonSelect_Manager>();
        skillDetailTable = GameObject.Find("Skill_EquipDetailManager").GetComponent<SkillDetailTable>();
        equipDetailTable = GameObject.Find("Skill_EquipDetailManager").GetComponent<EquipDetailTable>();
        soundMgr = GameObject.Find("UI_SoundMgr").GetComponent<UI_SoundMgr>();
        TutorialMgr = GameObject.Find("TutorialManager").GetComponent<TutorialManager>();
        bmMgr = GameObject.Find("BMPanelManager").GetComponent<BMPanelManager>();
    }

}
