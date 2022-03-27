using UnityEngine;
using UnityEngine.UI;

public class Guild_UI : MonoBehaviour
{
    GuildManager guildManager;
    private void Start()
    {
        guildManager = GameObject.Find("GuildManager").GetComponent<GuildManager>();
        switch (gameObject.name)
        {
            case "0":
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
                gameObject.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(guildManager.ListBtn0);

                break;
            case "1":
                gameObject.transform.GetChild(3).gameObject.SetActive(true);
                gameObject.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(guildManager.ListBtn1);
                break;
            case "2":
                gameObject.transform.GetChild(4).gameObject.SetActive(true);
                gameObject.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(guildManager.ListBtn2);
                break;
            case "3":
                gameObject.transform.GetChild(5).gameObject.SetActive(true);
                gameObject.transform.GetChild(5).GetComponent<Button>().onClick.AddListener(guildManager.ListBtn3);
                break;

            case "4":
                gameObject.transform.GetChild(6).gameObject.SetActive(true);
                gameObject.transform.GetChild(6).GetComponent<Button>().onClick.AddListener(guildManager.ListBtn4);
                break;

            case "5":
                gameObject.transform.GetChild(7).gameObject.SetActive(true);
                gameObject.transform.GetChild(7).GetComponent<Button>().onClick.AddListener(guildManager.ListBtn5);
                break;

            case "6":
                gameObject.transform.GetChild(8).gameObject.SetActive(true);
                gameObject.transform.GetChild(8).GetComponent<Button>().onClick.AddListener(guildManager.ListBtn6);
                break;

            case "7":
                gameObject.transform.GetChild(9).gameObject.SetActive(true);
                gameObject.transform.GetChild(9).GetComponent<Button>().onClick.AddListener(guildManager.ListBtn7);
                break;

            case "8":
                gameObject.transform.GetChild(10).gameObject.SetActive(true);
                gameObject.transform.GetChild(10).GetComponent<Button>().onClick.AddListener(guildManager.ListBtn8);
                break;

            case "9":
                gameObject.transform.GetChild(11).gameObject.SetActive(true);
                gameObject.transform.GetChild(11).GetComponent<Button>().onClick.AddListener(guildManager.ListBtn9);
                break;
            default:
                break;
        }
    }

    public void DestroyMine()
    {
        Destroy(gameObject);
    }


}
