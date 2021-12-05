using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalManager : MonoBehaviour
{
    public ParticleSystem Landing;
    private float CurrentLandEmit;
    public float LandEmit;
    private bool LandEmiting;

    public void Land()
    {
        LandEmiting = true;
        Landing.Play();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LandEmiting == true)
        {
            CurrentLandEmit += Time.deltaTime;
            if (CurrentLandEmit > LandEmit)
            {
                CurrentLandEmit = 0;
                Landing.Stop();
                LandEmiting = false;
            }
        }
    }
}
