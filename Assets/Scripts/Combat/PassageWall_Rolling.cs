using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageWall_Rolling : MonoBehaviour
{
    public GameObject Wall1;
    public GameObject Wall2;
    public Vector3 SaveVec;
    public Vector3 limitVec;
    
    public float Speed = 10;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-Speed * Time.deltaTime, 0, 0));

        if(transform.position.x <= limitVec.x)
        {
            transform.position = SaveVec;
        }
        
    }
}
