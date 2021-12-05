using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScript : MonoBehaviour
{
    #region Singleton

    public static UpgradeScript instance;

    void Awake()
    {
        instance = this;
        if (First == true)
        {
            //Vehicles.Add(new vehicleClass());
            //Vehicles.Add(new vehicleClass());
            //Vehicles.Add(new vehicleClass());
            //Vehicles.Add(new vehicleClass());
        }
    }

    #endregion

    public static List<vehicleClass> Vehicles = new List<vehicleClass>();

    public static int MyBikeNumber;

    public static int Money;
    public static int Gems;

    public static bool IsGame = false;
    public static bool First = true;
    public static int Level;

    public static int CurrentBikeEdit;

    public AudioSource UpgradeSound;
    public AudioSource UpgradeFail;

    public static bool ShouldSave = true;
    public static bool Keys = true;
    public static bool Lock = true;
    public static bool SetToZero = true;
    public static bool InfiniteMoney = false;

    public static string Name = "MyName";
    
    public static void ReciveLoad(int Silver, int GemsSave, int[] Jump, int[] Control, int[] Speed)
    {
        UpgradeScript.Vehicles[0].JumpLevel = Jump[0];
        UpgradeScript.Vehicles[1].JumpLevel = Jump[1];

        UpgradeScript.Vehicles[0].ControlLevel = Control[0];
        UpgradeScript.Vehicles[1].ControlLevel = Control[1];

        UpgradeScript.Vehicles[0].SpeedLevel = Speed[0];
        UpgradeScript.Vehicles[1].SpeedLevel = Speed[1];

        Money = Silver;
        Gems = GemsSave;
        if (SetToZero == true)
        {
            UpgradeScript.Vehicles[0].JumpLevel = 0;
            UpgradeScript.Vehicles[1].JumpLevel = 0;

            UpgradeScript.Vehicles[0].ControlLevel = 0;
            UpgradeScript.Vehicles[1].ControlLevel = 0;

            UpgradeScript.Vehicles[0].SpeedLevel = 0;
            UpgradeScript.Vehicles[1].SpeedLevel = 0;

            Money = 0;
            Gems = 0;
        }
        
    }

    public void TryUpgradeJump()
    {
        if (Money >= Vehicles[CurrentBikeEdit].JumpCosts[Vehicles[CurrentBikeEdit].JumpLevel] || InfiniteMoney == true)
        {
            Money -= Vehicles[CurrentBikeEdit].JumpCosts[Vehicles[CurrentBikeEdit].JumpLevel];
            Vehicles[CurrentBikeEdit].JumpLevel += 1;
            Vehicles[CurrentBikeEdit].CurrentControl = Vehicles[CurrentBikeEdit].ControlStats[Vehicles[CurrentBikeEdit].JumpLevel];
            UpgradeSound.Play();
            if (UpgradeScript.ShouldSave == true)
            {
                SaveSystem.SaveStats();
            }
        }
        else
        {
            UpgradeFail.Play();
        }
    }

    public void TryUpgradeSpeed()
    {
        if(Money >= Vehicles[CurrentBikeEdit].SpeedCosts[Vehicles[CurrentBikeEdit].SpeedLevel] || InfiniteMoney == true)
        {
            Money -= Vehicles[CurrentBikeEdit].SpeedCosts[Vehicles[CurrentBikeEdit].SpeedLevel];
            Vehicles[CurrentBikeEdit].SpeedLevel += 1;
            Vehicles[CurrentBikeEdit].CurrentSpeed = Vehicles[CurrentBikeEdit].SpeedStats[Vehicles[CurrentBikeEdit].SpeedLevel];
            UpgradeSound.Play();
            if (UpgradeScript.ShouldSave == true)
            {
                SaveSystem.SaveStats();
            }
        }
        else
        {
            UpgradeFail.Play();
        }
    }

    public void TryUpgradeControl()
    {
        if (Money >= Vehicles[CurrentBikeEdit].ControlCosts[Vehicles[CurrentBikeEdit].ControlLevel] || InfiniteMoney == true)
        {
            Money -= Vehicles[CurrentBikeEdit].ControlCosts[Vehicles[CurrentBikeEdit].ControlLevel];
            Vehicles[CurrentBikeEdit].ControlLevel += 1;
            Vehicles[CurrentBikeEdit].CurrentControl = Vehicles[CurrentBikeEdit].ControlStats[Vehicles[CurrentBikeEdit].ControlLevel];
            UpgradeSound.Play();
            if (UpgradeScript.ShouldSave == true)
            {
                SaveSystem.SaveStats();
            }
        }
        else
        {
            UpgradeFail.Play();
        }
    }

    void Start()
    {
        if(First == true)
        {
            for (int i = 0; i < Vehicles.Count; i++)
            {
                Vehicles[i].CurrentSpeed = Vehicles[i].SpeedStats[Vehicles[i].SpeedLevel];
                Vehicles[i].CurrentControl = Vehicles[i].ControlStats[Vehicles[i].ControlLevel];
                Vehicles[i].CurrentJump = Vehicles[i].JumpStats[Vehicles[i].JumpLevel];
            }
            First = false;
        }
          
    }

    
}
