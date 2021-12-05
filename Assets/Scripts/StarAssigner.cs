using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarAssigner : MonoBehaviour
{
    public List<Image> Images = new List<Image>();
    public static List<bool> Playable = new List<bool>();
    public List<bool> PlayableSave = new List<bool>();

    public List<Image> ActiveBackrounds = new List<Image>();
    public List<Image> DeActiveBackrounds = new List<Image>();
    public List<Image> LockIcons = new List<Image>();

    public Sprite True;
    public Sprite False;

    

    // Start is called before the first frame update
    public void Start()
    {
        for (var i = 0; i < LevelStorage.TotalLevels.Count; i++)
        {
            Playable.Add(false);
            PlayableSave.Add(false);
        }
        //Storeage = GameObject.Find("GameManager").GetComponent<LevelStorage>();
        int Max = 0;
        for (var i = 0; i < LevelStorage.TotalLevels.Count * 3; i++)
        {
            //Debug.Log(i + "Numnber");
            int Count = 0;
            for (var j = 0; j < i; j++)
            {
                if ((j + 1) % 3 == 0)
                {
                    Count += 1;
                }
            }
            int Remaining = (i - (Count * 3));
            //Debug.Log("Count: " + Count + "  Remaining: " + Remaining);
            if (LevelStorage.TotalLevels[Count].Stars[Remaining] != null)
            {
                if (LevelStorage.TotalLevels[Count].Stars[Remaining] == true)
                {
                    Max = Count + 1;
                    //Debug.Log(i);
                    Images[i].sprite = True;
                }
                else if (LevelStorage.TotalLevels[Count].Stars[Remaining] == false)
                {
                    //Debug.Log(i);
                    Images[i].sprite = False;

                }
            }
            
        }
        for (var i = 0; i < Max + 1; i++)
        {
            Playable[i] = true;
            PlayableSave[i] = true;
        }
        if(UpgradeScript.Lock == true)
        {
            for (var i = 0; i < Playable.Count; i++)
            {
                if (Playable[i] == true)
                {
                    ActiveBackrounds[i].enabled = true;
                    DeActiveBackrounds[i].enabled = false;
                    LockIcons[i].enabled = false;
                }
                else
                {
                    ActiveBackrounds[i].enabled = false;
                    DeActiveBackrounds[i].enabled = true;
                    LockIcons[i].enabled = true;
                }
            }
        }
        else
        {
            for (var i = 0; i < Playable.Count; i++)
            {
                ActiveBackrounds[i].enabled = true;
                DeActiveBackrounds[i].enabled = false;
                LockIcons[i].enabled = false;
            }
        }
        
        //Playable[TopLevelActive + 1] = true;
        //Debug.Log(TopLevelActive + "toplevel");
    }

    public void CheckLevel()
    {

    }
}
