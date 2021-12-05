using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour
{
    public TextMeshProUGUI ControlCostTextRed;
    public TextMeshProUGUI ControlCostTextGreen;
    public TextMeshProUGUI SpeedCostTextRed;
    public TextMeshProUGUI SpeedCostTextGreen;
    public TextMeshProUGUI JumpCostTextRed;
    public TextMeshProUGUI JumpCostTextGreen;

    public CircleSlider ControlRed;
    public CircleSlider ControlGreen;

    public CircleSlider SpeedRed;
    public CircleSlider SpeedGreen;

    public CircleSlider JumpRed;
    public CircleSlider JumpGreen;

    public int ControlLevel;
    public int Count;

    public swipeMenu Swipe;

    public int CurrentBike;

    public List<float> ControlChange = new List<float>();
    public List<float> SpeedChange = new List<float>();
    public List<float> JumpChange = new List<float>();

    public List<float> ControlProgress = new List<float>();
    public List<float> SpeedProgress = new List<float>();
    public List<float> JumpProgress = new List<float>();

    public bool InfiniteMoney;

    public GameObject InAppMenu;

    void Start()
    {
        for (var i = 0; i < 5; i++)
        {
            ControlChange[i] = UpgradeScript.Vehicles[i].ControlStats[4] - UpgradeScript.Vehicles[i].ControlStats[0];
            SpeedChange[i] = UpgradeScript.Vehicles[i].SpeedStats[4] - UpgradeScript.Vehicles[i].SpeedStats[0];
            JumpChange[i] = UpgradeScript.Vehicles[i].JumpStats[4] - UpgradeScript.Vehicles[i].JumpStats[0];

            float Multiplier = 100 / ControlChange[i];
            ControlProgress[i] = ((Multiplier * UpgradeScript.Vehicles[i].CurrentControl) - Multiplier) / 100;

            float Multiplier2 = 100 / SpeedChange[i];
            SpeedProgress[i] = ((Multiplier2 * UpgradeScript.Vehicles[i].CurrentSpeed) - Multiplier2) / 100;

            float Multiplier3 = 100 / JumpChange[i];
            JumpProgress[i] = ((Multiplier3 * UpgradeScript.Vehicles[i].CurrentJump) - Multiplier3) / 100;
        }
    }

    void Update()
    {
        for (var i = 0; i < 5; i++)
        {
            float Multiplier = (100 - (UpgradeScript.Vehicles[i].RedLevel * 100)) / ControlChange[i];
            ControlProgress[i] = (((Multiplier * UpgradeScript.Vehicles[i].CurrentControl) - Multiplier) / 100);

            float Multiplier2 = (100 - (UpgradeScript.Vehicles[i].RedLevel * 100)) / SpeedChange[i];
            SpeedProgress[i] = (((Multiplier2 * UpgradeScript.Vehicles[i].CurrentSpeed) - Multiplier2) / 100);

            float Multiplier3 = (100 - (UpgradeScript.Vehicles[i].RedLevel * 100)) / JumpChange[i];
            JumpProgress[i] = (((Multiplier3 * UpgradeScript.Vehicles[i].CurrentJump) - Multiplier3) / 100);
        }

        CurrentBike = UpgradeScript.CurrentBikeEdit;

        ControlRed.Progress = UpgradeScript.Vehicles[UpgradeScript.CurrentBikeEdit].RedLevel;
        ControlGreen.Progress = ControlProgress[UpgradeScript.CurrentBikeEdit];
        SpeedRed.Progress = UpgradeScript.Vehicles[UpgradeScript.CurrentBikeEdit].RedLevel;
        SpeedGreen.Progress = SpeedProgress[UpgradeScript.CurrentBikeEdit];
        JumpRed.Progress = UpgradeScript.Vehicles[UpgradeScript.CurrentBikeEdit].RedLevel;
        JumpGreen.Progress = JumpProgress[UpgradeScript.CurrentBikeEdit];

        UpgradeScript.CurrentBikeEdit = Swipe.Selected;

        ControlLevel = UpgradeScript.Vehicles[UpgradeScript.CurrentBikeEdit].ControlLevel;
        Count = UpgradeScript.Vehicles[UpgradeScript.CurrentBikeEdit].ControlCosts.Count;

        int BikeNum = UpgradeScript.CurrentBikeEdit;
        if (UpgradeScript.Vehicles[BikeNum].JumpCosts.Count < UpgradeScript.Vehicles[BikeNum].JumpLevel + 1)
        {
            JumpCostTextRed.text = "Max";
            JumpCostTextGreen.text = "";
        }
        else if (UpgradeScript.Vehicles[BikeNum].JumpCosts[UpgradeScript.Vehicles[BikeNum].JumpLevel] > UpgradeScript.Money && InfiniteMoney == false)
        {
            string ControlDisplay = "" + UpgradeScript.Vehicles[BikeNum].JumpCosts[UpgradeScript.Vehicles[BikeNum].JumpLevel];
            JumpCostTextRed.text = ControlDisplay;
            JumpCostTextGreen.text = "";
        }
        else
        {
            string ControlDisplay = "" + UpgradeScript.Vehicles[BikeNum].JumpCosts[UpgradeScript.Vehicles[BikeNum].JumpLevel];
            JumpCostTextRed.text = "";
            JumpCostTextGreen.text = ControlDisplay;
        }


        if (UpgradeScript.Vehicles[BikeNum].ControlCosts.Count < UpgradeScript.Vehicles[BikeNum].ControlLevel + 1)
        {
            ControlCostTextRed.text = "Max";
            ControlCostTextGreen.text = "";
        }
        else if (UpgradeScript.Vehicles[BikeNum].ControlCosts[BikeNum] > UpgradeScript.Money && InfiniteMoney == false)
        {
            string ControlDisplay = "" + UpgradeScript.Vehicles[BikeNum].ControlCosts[UpgradeScript.Vehicles[BikeNum].ControlLevel];
            ControlCostTextRed.text = ControlDisplay;
            ControlCostTextGreen.text = "";
        }
        else
        {
            string ControlDisplay = "" + UpgradeScript.Vehicles[BikeNum].ControlCosts[UpgradeScript.Vehicles[BikeNum].ControlLevel];
            ControlCostTextRed.text = "";
            ControlCostTextGreen.text = ControlDisplay;
        }

        
        if (UpgradeScript.Vehicles[BikeNum].SpeedCosts.Count < UpgradeScript.Vehicles[BikeNum].SpeedLevel + 1)
        {
            SpeedCostTextRed.text = "Max";
            SpeedCostTextGreen.text = "";
        }
        else if (UpgradeScript.Vehicles[BikeNum].SpeedCosts[BikeNum] > UpgradeScript.Money && InfiniteMoney == false)
        {
            string SpeedDisplay = "" + UpgradeScript.Vehicles[BikeNum].SpeedCosts[UpgradeScript.Vehicles[BikeNum].SpeedLevel];
            SpeedCostTextRed.text = SpeedDisplay;
            SpeedCostTextGreen.text = "";
        }
        else
        {
            string SpeedDisplay = "" + UpgradeScript.Vehicles[BikeNum].SpeedCosts[UpgradeScript.Vehicles[BikeNum].SpeedLevel];
            SpeedCostTextRed.text = "";
            SpeedCostTextGreen.text = SpeedDisplay;
        }
    }

    public void EnableMenu(bool Active)
    {
        InAppMenu.SetActive(Active);
    }
}
