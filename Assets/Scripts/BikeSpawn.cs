using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeSpawn : MonoBehaviour
{
    public Transform Spawn;

    public GameObject MyBike;

    public void SpawnBike()
    {
        if (GameScene.Bools[UpgradeScript.Level] == true)
        {
            Spawn = GameObject.Find("Spawn").transform;

            MyBike = Instantiate(UpgradeScript.Vehicles[UpgradeScript.MyBikeNumber].VehicleObject, Spawn.position, Quaternion.identity);
            MyBike.transform.position = new Vector3(MyBike.transform.position.x, MyBike.transform.position.y, -1f);
            MyBike.GetComponent<BikeController>().enabled = true;
            MyBike.GetComponent<BikeController>().Restart();
        }
    }

    void OnEnable()
    {
        SpawnBike();
    }
}
