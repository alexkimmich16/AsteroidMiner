using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class vehicleClass
{
    public GameObject VehicleObject;

    public int JumpLevel = 0;
    public float CurrentJump;
    public List<float> JumpStats = new List<float>();
    public List<int> JumpCosts = new List<int>();


    public int ControlLevel = 0;
    public float CurrentControl;
    public List<float> ControlStats = new List<float>();
    public List<int> ControlCosts = new List<int>();

    public int SpeedLevel = 0;
    public float CurrentSpeed;
    public List<float> SpeedStats = new List<float>();
    public List<int> SpeedCosts = new List<int>();

    public float RedLevel;
}
