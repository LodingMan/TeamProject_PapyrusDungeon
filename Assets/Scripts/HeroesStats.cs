using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroesStats : MonoBehaviour
{
    public int hp = 100;
    public int mp = 50;
    public int atk = 10;
    public int def = 5;

    private void Awake()
    {
        if (gameObject.tag == "Knight")
        {
            this.hp += 100;
            this.atk += 50;
            this.def += 50;

        }
        else if (gameObject.tag == "Mage")
        {

            this.mp += 100;

        }
        else
        {

            this.hp += 10;
        }

    }

}
