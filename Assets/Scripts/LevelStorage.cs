using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStorage : MonoBehaviour
{
    public static List<Levels> TotalLevels = new List<Levels>();
    public int Levels;
    void Awake()
    {
        if(UpgradeScript.First == true)
        {
            for (var i = 0; i < Levels; i++)
            {
                TotalLevels.Add(new Levels());

                TotalLevels[i].Stars.Add(false);
                TotalLevels[i].Stars.Add(false);
                TotalLevels[i].Stars.Add(false);
            }
            //UpgradeScript.Keys = SetKeys;
        }
        
    }

    public static void RecieveLevels(int[] levels)
    {
        for (var i = 0; i < 14; i++)
        {
            //Debug.Log(i + "savedataRecive:  " + levels[i]);
            if (levels[i] == 3)
            {
                TotalLevels[i].Stars[2] = true;
                TotalLevels[i].Stars[1] = true;
                TotalLevels[i].Stars[0] = true;
            }
            else if (levels[i] == 2)
            {
                TotalLevels[i].Stars[2] = true;
                TotalLevels[i].Stars[1] = false;
                TotalLevels[i].Stars[0] = false;
            }
            else if (levels[i] == 1)
            {
                TotalLevels[i].Stars[2] = true;
                TotalLevels[i].Stars[1] = true;
                TotalLevels[i].Stars[0] = false;
            }
            else
            {
                TotalLevels[i].Stars[2] = false;
                TotalLevels[i].Stars[1] = false;
                TotalLevels[i].Stars[0] = false;
            }
        }
    }

    
}
