using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelCollision : MonoBehaviour
{
    public BikeController Bike;
    public Transform last;
    //public bool front;

    void OnCollisionEnter2D(Collision2D col)
    {
        Bike.Grounded = true;
        if (col.transform.GetComponent<Attractor>() && col.transform != last)
        {
            last = col.transform;
            Bike.Current = last.GetComponent<Attractor>();
            
            Bike.pt.Land();
            Debug.Log("land");
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        Bike.Grounded = false;
        if (col.transform.transform.GetComponent<Attractor>() && col.transform != last)
        {
            //Bike.Current = null;
        }
    }
}
