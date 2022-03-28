using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaviMeshMgr : MonoBehaviour
{
    public GameObject[] CurrentHero;
    public static int num = 0;
    public NaviMeshMgr[] agent;
    void Start()
    {
        
    }

    
    void Update()
    {
        agent = new NaviMeshMgr[num];
        
    }
}
