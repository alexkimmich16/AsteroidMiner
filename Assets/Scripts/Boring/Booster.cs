using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public Rigidbody2D RB;
    public float Force;
    public bool Boost;
    // Start is called before the first frame update
    void Start()
    {
        RB = BikeController.instance.RB;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        Boost = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        Boost = false;
    }

    void FixedUpdate()
    {
        if (Boost == true)
        {
            RB.AddForce(RB.velocity.normalized * Time.fixedDeltaTime * Force);
        }
    }
}
