using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnText : MonoBehaviour
{
    public Button Btn;
    public Sprite ChangeImage;
    void Start()
    {
        Btn.image.sprite= ChangeImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
