using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUseManager : MonoBehaviour
{
    public Stat stats;
    public string heroName;


    private void Start()
    {
        stats.Name = "0";
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
               stats = hit.transform.gameObject.GetComponent<StatScript>().myStat;
               heroName = hit.transform.gameObject.name;

            }
        }

    }


}
