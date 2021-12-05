using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public AudioSource MenuMusic;
    public AudioSource GameMusic;
    //public AudioSource GameMusic;
    //public bool Playing = false;
    public bool MenuActive = false;

    // Update is called once per frame
    void Update()
    {
        if (UpgradeScript.Level == 0 || UpgradeScript.Level == 1)
        {
            if(MenuActive == false)
            {
                MenuMusic.Play();
                GameMusic.Stop();
                MenuActive = true;
            }
        }
        else
        {
            if (MenuActive == true)
            {
                MenuMusic.Stop();
                GameMusic.Play();
                MenuActive = false;
            }
        }
        //add game music(men of stone)
        //in app perchesice
        //make sure ads work
        //find use for diamonds
    }
}
