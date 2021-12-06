using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelCollision : MonoBehaviour
{
    public BikeController Bike;
    public Transform last;
    public Vector2 Dir;
    public Vector2 Velocity;
    public float Angle;

    
    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.transform.GetComponent<Attractor>() && col.transform != last)
        {
            last = col.transform;
            Bike.Current = last.GetComponent<Attractor>();
            Velocity = Bike.RB.velocity;
            
            Vector2 PlanetDirection = col.transform.position - transform.position;
            Angle = Vector2.Angle(Velocity, PlanetDirection);
            // closer to clockwise than counter
            
            if (Angle > 90f)
            {
                Bike.Clockwise = true;
            }
            else
            {
                Bike.Clockwise = false;
            }
            
            Bike.pt.Land();
            Debug.Log("land");

            
            Dir = PlanetDirection;
            //rb.velocity = new Vector2(0.0f, 2.0f);
            //transform.position
        }
        if (col.transform.tag == "Reflector")
        {
            Bike.Reflect();
        }
        
        //get position
        //use position to 
    }

    void OnCollisionExit2D(Collision2D col)
    {
        Bike.Grounded = false;
        Bike.FloorTile = null;
        if (col.transform.GetComponent<Attractor>() && col.transform != last)
        {
            Bike.Current = null;
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        Bike.Grounded = true;
        if (col.transform.tag == "Floor")
        {
            Bike.FloorTile = col.transform;
            
        }
        
    }
}
