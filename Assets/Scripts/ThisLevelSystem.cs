using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThisLevelSystem : MonoBehaviour
{
    #region Singleton

    public static ThisLevelSystem instance;

    void Awake()
    {
        instance = this;
        //GameObject.Find("GameManager").GetComponent<UpgradeScript>().SpawnBike();
    }

    #endregion
    //under timefor1
    public float TimeFor1;
    public float TimeFor2;

    public float Timer;
    public float SaveTime;

    public Sprite True;
    public Sprite False;

    public Image Star1;
    public Image Star2;
    public Image Star3;

    public TextMeshProUGUI text;

    public bool AlreadySet = false;

    public static int CurrectMoney;

    //private UpgradeScript Upgrades;

    void Update()
    {
        double AjustedTime = Mathf.Round(Timer * 100) * 0.01;
        string TimeDisplay = "";
        if(BikeController.instance != null)
        {
            if (BikeController.instance.HasWon == false)
            {
                
                if (Timer < TimeFor2)
                {
                    TimeDisplay = "Time: " + AjustedTime + "/" + TimeFor2;
                }
                else if (Timer < TimeFor1)
                {
                    TimeDisplay = "Time: " + AjustedTime + "/" + TimeFor1;
                }
                else
                {
                    TimeDisplay = "Time: " + AjustedTime;
                }
                Timer += Time.deltaTime;
                text.text = TimeDisplay;
            }
        }
    }

    public void SetLevel()
    {
        if (AlreadySet == false)
        {
            UpgradeScript.Money += CurrectMoney;
            CurrectMoney = 0;
            SaveTime = Timer;
            if (Timer < TimeFor1)
            {
                LevelStorage.TotalLevels[UpgradeScript.Level - 2].Stars[1] = true;
            }
            if (Timer < TimeFor2)
            {
                LevelStorage.TotalLevels[UpgradeScript.Level - 2].Stars[2] = true;
            }
            LevelStorage.TotalLevels[UpgradeScript.Level - 2].Stars[0] = true;

            if (Timer < TimeFor2)
            {
                Star1.sprite = True;
                Star2.sprite = True;
                Star3.sprite = True;
            }
            else if (Timer < TimeFor1)
            {
                Star1.sprite = True;
                Star2.sprite = True;
                Star3.sprite = False;
            }
            else
            {
                Star1.sprite = True;
                Star2.sprite = False;
                Star3.sprite = False;
            }

            //Timer = Timer;
            AlreadySet = true;
        }
        
    }
}
