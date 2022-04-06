using UnityEngine;
using UnityEngine.UI;

//=================================================================//
//�ش� ��ũ��Ʈ�� ���������� UI Prefab���� ���Ǵ� ������Ʈ �Դϴ�. //
//================================================================//
namespace Song
{


    public class Unemployed_Hero_UI_Script : MonoBehaviour
    {
        GuildManager guildManager;
        Shin.HeroImageTable heroImageTable;
        GameObject UI_Prefab;
        public GameObject This_Prefab_Object; //���� ���� ������Ʈ�� ����Ű�� �ֳ�
        static int Current_Hero_Prefab_Count = 0;
        public Image heroImage; // shin
        private void Start()
        {
            guildManager = GameObject.Find("GuildManager").GetComponent<GuildManager>();
            heroImageTable = GameObject.Find("HeroImageManager").GetComponent<Shin.HeroImageTable>();
            gameObject.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(BtnFunc);
            //gameObject.transform.GetChild(2).GetComponent<Button>().gameObject.SetActive(true);
            
            switch (gameObject.transform.GetChild(1).GetComponent<Text>().text) // shin
            {
                case "Babarian":
                    heroImage.sprite = heroImageTable.sprite[0];
                    break;
                case "Archer":
                    heroImage.sprite = heroImageTable.sprite[1];
                    break;
                case "Knight":
                    heroImage.sprite = heroImageTable.sprite[2];
                    break;
                case "Barristan":
                    heroImage.sprite = heroImageTable.sprite[3];
                    break;
                case "Mage":
                    heroImage.sprite = heroImageTable.sprite[4];
                    break;
                case "Porter":
                    heroImage.sprite = heroImageTable.sprite[5];
                    break;
                default:
                    break;
            }

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
            UI_Prefab.name = "" + Current_Hero_Prefab_Count;
            Current_Hero_Prefab_Count++;
            UI_Prefab.transform.SetParent(guildManager.currentHero_UI_Prefabs_Create_Point.transform);
            UI_Prefab.transform.localScale = new Vector3(1, 1, 1);
            UI_Prefab.transform.GetChild(0).GetComponent<Text>().text = gameObject.transform.GetChild(0).GetComponent<Text>().text;
            //UI_Prefab.transform.GetChild(1).GetComponent<Text>().text = gameObject.transform.GetChild(1).GetComponent<Text>().text;
            

        
            UI_Prefab.transform.localScale = new Vector3(1, 1, 1); // Yoon
            UI_Prefab.GetComponent<Song.Current_Hero_UI_Script>().This_Prefab_Object = This_Prefab_Object; //����� �������� ���� ���� ���������� �Ѿ�鼭 ������Ʈ �μ��ΰ�
            guildManager.Current_Hero_UI_List.Add(UI_Prefab);
            Destroy(gameObject);

            gameObject.transform.GetChild(2).GetComponent<Button>().gameObject.SetActive(false);




        }
    }
}
