using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int MoneyAdd;
    public int GemsAdd;
    public bool Collected;
    public Vector3 point;
    public float Offset;

    public float Speed;

    private float Z;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            ThisLevelSystem.CurrectMoney += MoneyAdd;
            UpgradeScript.Gems += GemsAdd;
            Z = transform.position.z;
            Collected = true;
        }
        
    }
    void Start()
    {
        point = new Vector3(transform.position.x, transform.position.y + Offset, Z);
    }
    void Update()
    {
        if (Collected == true)
        {
            transform.position = Vector3.Lerp(transform.position, point, Speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, point) < .1f)
            {
                Destroy(gameObject);
            }
        }
    }
}
