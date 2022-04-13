using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class starttest : MonoBehaviour
{
    public Text aaaa;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(aaaa, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
