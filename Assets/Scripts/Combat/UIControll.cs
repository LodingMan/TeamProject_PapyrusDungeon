using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControll : MonoBehaviour
{

    public PlayerScript_Proto players;

    public void LeftMove()
    {
        players.PlayerWarp(-1);
    }

    public void RightMove()
    {
        players.PlayerWarp(1);

    }
    public void UpMove()
    {
        players.PlayerWarp(10);

    }
    public void DownMove()
    {
        players.PlayerWarp(-10);

    }
}
