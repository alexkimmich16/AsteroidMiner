using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToUpgrade : MonoBehaviour
{
    public List<GameObject> Bikes = new List<GameObject>();
    public static List<float> AjustedMultiplier = new List<float>();



    // Start is called before the first frame update
    void Awake()
    {
        if (UpgradeScript.First == true)
        {
            Debug.Log("StRT");
            for (var i = 0; i < Bikes.Count; i++)
            {
                UpgradeScript.Vehicles.Add(new vehicleClass());

                //UpgradeScript.Vehicles[i].JumpStats.Clear();
                UpgradeScript.Vehicles[i].JumpStats.Add(1.3f);
                UpgradeScript.Vehicles[i].JumpStats.Add(1.45f);
                UpgradeScript.Vehicles[i].JumpStats.Add(1.55f);
                UpgradeScript.Vehicles[i].JumpStats.Add(1.65f);
                UpgradeScript.Vehicles[i].JumpStats.Add(1.75f);

                //UpgradeScript.Vehicles[i].JumpCosts.Clear();
                UpgradeScript.Vehicles[i].JumpCosts.Add(25);
                UpgradeScript.Vehicles[i].JumpCosts.Add(50);
                UpgradeScript.Vehicles[i].JumpCosts.Add(75);
                UpgradeScript.Vehicles[i].JumpCosts.Add(100);

                //UpgradeScript.Vehicles[i].ControlStats.Clear();
                UpgradeScript.Vehicles[i].ControlStats.Add(1.1f);
                UpgradeScript.Vehicles[i].ControlStats.Add(1.25f);
                UpgradeScript.Vehicles[i].ControlStats.Add(1.4f);
                UpgradeScript.Vehicles[i].ControlStats.Add(1.5f);
                UpgradeScript.Vehicles[i].ControlStats.Add(1.6f);

                //UpgradeScript.Vehicles[i].ControlCosts.Clear();
                UpgradeScript.Vehicles[i].ControlCosts.Add(20);
                UpgradeScript.Vehicles[i].ControlCosts.Add(30);
                UpgradeScript.Vehicles[i].ControlCosts.Add(50);
                UpgradeScript.Vehicles[i].ControlCosts.Add(75);
                //UpgradeScript.ControlCosts.Add(5);

                //UpgradeScript.Vehicles[i].SpeedStats.Clear();
                UpgradeScript.Vehicles[i].SpeedStats.Add(1.3f);
                UpgradeScript.Vehicles[i].SpeedStats.Add(1.4f);
                UpgradeScript.Vehicles[i].SpeedStats.Add(1.5f);
                UpgradeScript.Vehicles[i].SpeedStats.Add(1.6f);
                UpgradeScript.Vehicles[i].SpeedStats.Add(1.7f);

                //UpgradeScript.Vehicles[i].SpeedCosts.Clear();
                UpgradeScript.Vehicles[i].SpeedCosts.Add(25);
                UpgradeScript.Vehicles[i].SpeedCosts.Add(50);
                UpgradeScript.Vehicles[i].SpeedCosts.Add(75);
                UpgradeScript.Vehicles[i].SpeedCosts.Add(100);
                //UpgradeScript.SpeedCosts.Add(25);

                UpgradeScript.Vehicles[i].VehicleObject = Bikes[i];

                //ChangeUI
            }
            UpgradeScript.Vehicles[0].RedLevel = .3f;
            UpgradeScript.Vehicles[1].RedLevel = .2f;
            UpgradeScript.Vehicles[2].RedLevel = .1f;
            //UpgradeScript.Vehicles[0].JumpCosts[0] = 1000;
        }


    }
}
