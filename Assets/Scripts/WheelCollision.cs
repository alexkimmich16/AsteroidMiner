using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelCollision : MonoBehaviour
{
    public BikeController Bike;
    public Transform last;
    public Vector2 Dir;


    void OnCollisionEnter2D(Collision2D col)
    {
        Bike.Grounded = true;
        if (col.transform.GetComponent<Attractor>() && col.transform != last)
        {
            last = col.transform;
            Bike.Current = last.GetComponent<Attractor>();
            
            Bike.pt.Land();
            Debug.Log("land");
            Vector2 PlanetDirection = col.transform.position - transform.position;
            Dir = PlanetDirection;
            //rb.velocity = new Vector2(0.0f, 2.0f);
            //transform.position
        }
        
        //get position
        //use position to 
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
