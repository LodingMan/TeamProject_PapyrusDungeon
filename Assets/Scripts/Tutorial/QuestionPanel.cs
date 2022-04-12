using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionPanel : MonoBehaviour
{
    public ManagerTable MgrTable;
    public GameObject Church;
    public GameObject Train;
    public GameObject Inven;
    public GameObject Shop;
    public GameObject Smith;
    // Start is called before the first frame update
    void Start()
    {
        MgrTable = GameObject.Find("ManagerTable").GetComponent<ManagerTable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (MgrTable.TutorialMgr.isChurch)
            {
                MgrTable.TutorialMgr.isChurch = false;
                Church.SetActive(false);
                MgrTable.TutorialMgr.isTrain = true;
                Train.SetActive(true);
            }
            else if (MgrTable.TutorialMgr.isTrain)
            {
                MgrTable.TutorialMgr.isTrain = false;
                Train.SetActive(false);
                MgrTable.TutorialMgr.isInven = true;
                Inven.SetActive(true);
            }
            else if (MgrTable.TutorialMgr.isInven)
            {
                MgrTable.TutorialMgr.isInven = false;
                Inven.SetActive(false);
                MgrTable.TutorialMgr.isShop = true;
                Shop.SetActive(true);
            }
            else if (MgrTable.TutorialMgr.isShop)
            {
                MgrTable.TutorialMgr.isShop = false;
                Shop.SetActive(false);
                MgrTable.TutorialMgr.isSmith = true;
                Smith.SetActive(true);

            }
            else if (MgrTable.TutorialMgr.isSmith)
            {
                MgrTable.TutorialMgr.isSmith = false;
                Smith.SetActive(false);
                MgrTable.TutorialMgr.QuestionOff();
            }
        }
    }
}
