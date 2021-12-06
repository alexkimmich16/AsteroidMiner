using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public float gravity;

    public Rigidbody2D Other;

    /// <summary>
    /// minimum distance to pull player
    /// </summary>
    public float MinDistance;

    public float revSpeed;

    /// <summary>
    /// for checking when gravity should be enabled downwards on player
    /// </summary>
    public float DistenceSubtract;
    //14

    public float Distence;

    public float DistenceAjusted;

    public bool CanPull = true;

    public float Timer;
    public float MaxTime;

    private bool TimerActive;

    public void SetTime(float Time)
    {
        MaxTime = Time;
        TimerActive = true;
        CanPull = false;
        Timer = 0;
    }

    //public Transform LookAtPlanet;

    void Start()
    {
        PlanetAssigner.instance.Planets.Add(this);
    }


    void FixedUpdate()
    {
        if (Other)
        {
            Vector2 difference = this.gameObject.transform.position - Other.gameObject.transform.position;
            //float dist1 = Vector3.Distance(other.position, transform.position);
            float dist = difference.magnitude;
            Distence = dist;
            if (MinDistance > dist && CanPull == true)
            {
                Vector2 gravityDirection = difference.normalized;
                Vector2 gravityVector = (gravityDirection * gravity) / (dist * dist);

                Other.AddForce(gravityVector, ForceMode2D.Force);

                float distBalenced = dist - DistenceSubtract;
                DistenceAjusted = distBalenced;

                if (distBalenced > 0)
                {
                    //Other.MoveRotation(Other.rotation + revSpeed * Time.fixedDeltaTime * distBalenced);
                    BikeController.instance.GravityAdd(true);
                    
                    //Physics2D.gravity = new Vector2(0, -10.81f);
                }
                else
                {
                    //Physics2D.gravity = Vector2.zero;
                    //Debug.Log("false1");
                    BikeController.instance.GravityAdd(false);
                }
            }
        }
        
    }


    void Update()
    {
        if (Timer > MaxTime && TimerActive == true)
        {
            Timer = 0;
            TimerActive = false;
            CanPull = true;
        }
        else if (TimerActive == true)
        {
            Timer += Time.deltaTime;
        }
    }
}

