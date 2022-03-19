using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroesStats : MonoBehaviour
{
    private void Awake()
    {
        if (gameObject.tag == "Knight")
        {
            Status knight = new Status();
            knight.hp = PlayerPrefs.GetInt("hp");
            knight.mp = PlayerPrefs.GetInt("mp");

            Debug.Log("HP : " + knight.hp + "::" + "MP : " + knight.mp);
        }
        else
        {
            Status others = new Status();
            others.hp = PlayerPrefs.GetInt("hp") - 1;
            others.mp = PlayerPrefs.GetInt("mp") - 1;

            Debug.Log("HP : " + others.hp + "::" + "MP : " + others.mp);
        }

    }

}
