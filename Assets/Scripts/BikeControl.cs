using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BikeControl : MonoBehaviour
{
    public bool Moving = false;

    public bool ReverseMoving = false;

    public bool clockwise;
    public bool Counterclockwise;

    public float JumpCountdown;
    public float JumpSpacing;
    public bool Jumping;

    public GameObject Ready;
    public GameObject NotReady;

    public BikeController Control;

    void Update()
    {
        JumpCountdown += Time.deltaTime * UpgradeScript.Vehicles[UpgradeScript.MyBikeNumber].CurrentJump;
        if (JumpCountdown > JumpSpacing)
        {
            Ready.SetActive(true);
            NotReady.SetActive(false);
        }
        else
        {
            Ready.SetActive(false);
            NotReady.SetActive(true);
        }
        if(UpgradeScript.Keys == true)
        {
            if (Input.GetKey("d"))
            {
                Moving = true;
            }
            else
            {
                Moving = false;
            }

            if (Input.GetKey("a"))
            {
                ReverseMoving = true;
            }
            else
            {
                ReverseMoving = false;
            }

            if (Input.GetKey("w"))
            {
                clockwise = true;
            }
            else
            {
                clockwise = false;
            }

            //while button pressed
            if (Input.GetKey("s"))
            {
                Counterclockwise = true;
            }
            else
            {
                Counterclockwise = false;
            }

            //on button press
            if (Input.GetKeyDown("z"))
            {
                Jump();
            }
        }
        
        
    }

    public void Jump()
    {
        if (JumpCountdown > JumpSpacing)
        {
            Jumping = true;
            JumpCountdown = 0;
        }
    }

    public void AddForce(bool Enable)
    {
        //Debug.Log("force");
        Moving = Enable;
    }

    public void RemoveForce(bool Enable)
    {
        ReverseMoving = Enable;
    }

    public void Clockwise(bool Enable)
    {
        clockwise = Enable;
    }

    public void CounterClockwise(bool Enable)
    {
        Counterclockwise = Enable;
    }
    
}
