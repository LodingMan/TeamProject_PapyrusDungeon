using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLoadCurrentHeroData : MonoBehaviour
{
    public Song.HeroManager heroManager;
    // Start is called before the first frame update
    void Start()
    {
        heroManager = GameObject.Find("HeroManager").GetComponent<Song.HeroManager>();
        heroManager._Load();

    }
}
