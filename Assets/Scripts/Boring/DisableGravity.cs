using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGravity : MonoBehaviour
{

    public Attractor Planet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Planet.CanPull = false;
        Debug.Log("enter");
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        Planet.CanPull = true;
    }
}
