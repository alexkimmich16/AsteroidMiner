using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDetector : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        BikeController.instance.OnWin();
    }
}
