using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetAssigner : MonoBehaviour
{
    #region Singleton

    public static PlanetAssigner instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    private bool AfterStart = false;

    public Rigidbody2D RB;

    public List<Attractor> Planets = new List<Attractor>();
    public List<Booster> Boosters = new List<Booster>();

    // Start is called before the first frame update
    void Start()
    {
        RB = BikeController.instance.RB;
    }

    // Update is called once per frame
    void Update()
    {
        if(AfterStart == false)
        {
            foreach (Attractor planet in Planets)
            {
                planet.Other = RB;
            }
            foreach (Booster booster in Boosters)
            {
                booster.RB = RB;
            }
            AfterStart = true;
        }
        
    }
}
