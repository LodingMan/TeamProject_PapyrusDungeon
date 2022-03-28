using UnityEngine;
using UnityEngine.UI;

//=================================================================//
//해당 스크립트는 고용되지않은 UI Prefab에서 사용되는 컴포넌트 입니다. //
//================================================================//
public class Guild_UI : MonoBehaviour
{
    GuildManager guildManager;
    GameObject UI_Prefab;
    private void Start()
    {
        guildManager = GameObject.Find("GuildManager").GetComponent<GuildManager>();
        gameObject.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(BtnFunc);
        gameObject.transform.GetChild(2).GetComponent<Button>().gameObject.SetActive(true);

    }


    public void BtnFunc()
    {
        switch (gameObject.name)
        {
            case "0":
                guildManager.ListBtn0();
                break;
            case "1":
                guildManager.ListBtn1();
                break;
            case "2":
                guildManager.ListBtn2();
                break;
            case "3":
                guildManager.ListBtn3();
                break;
            case "4":
                guildManager.ListBtn4();
                break;
            case "5":
                guildManager.ListBtn5();
                break;
            case "6":
                guildManager.ListBtn6();
                break;
            case "7":
                guildManager.ListBtn7();
                break;
            case "8":
                guildManager.ListBtn8();
                break;
            case "9":
                guildManager.ListBtn9();
                break;
            default:
                break;
        }
        //  transform.parent = guildManager.CurrentHero_UI_Prefabs_Create_Point.transform;
        UI_Prefab = Instantiate(guildManager.currentHero_UI_Prefab);
        UI_Prefab.transform.parent = guildManager.currentHero_UI_Prefabs_Create_Point.transform;
        UI_Prefab.transform.GetChild(0).GetComponent<Text>().text = gameObject.transform.GetChild(0).GetComponent<Text>().text;
        UI_Prefab.transform.GetChild(1).GetComponent<Text>().text = gameObject.transform.GetChild(1).GetComponent<Text>().text;
        Destroy(gameObject);

        gameObject.transform.GetChild(2).GetComponent<Button>().gameObject.SetActive(false);




    }
}
