using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BikeController : MonoBehaviour
{
    #region Singleton

    public static BikeController instance;

    void Awake()
    {
        instance = this;
        RB = gameObject.GetComponent<Rigidbody2D>();
    }

    #endregion

    public float Speed;

    private Text text;

    public Rigidbody2D RB;

    private BikeControl CT;

    public bool Grounded;

    private Transform SpawnPoint;

    private Camera CamScript;

    private Transform CameraObjective;

    public float LerpSpeed;
    [HideInInspector]
    public Transform WinBanner;

    [HideInInspector]
    public bool HasWon;

    private GameObject Canvas;

    public AudioSource Win;

    private float LoadTimer;

    public float JumpForce;

    public static List<bool> Gravity = new List<bool>(0);

    private bool IsGravity;

    private int frameBuffer = 30;

    private int Bufferleft;

    private bool OneWheel;
    public Attractor Current;

    public bool SpeedDestory = false;

    public ParticalManager pt;

    public int Clockwise = 0;

    void FixedUpdate()
    {
        //jump would add force from direction of planet
        //OR just have a tic on top that denotes direction of jump

        //forward is always just right

        int BikeNum = UpgradeScript.MyBikeNumber;
        if (Grounded == true)
        {
            //RB.AddForce(transform.right * Speed * UpgradeScript.Vehicles[BikeNum].CurrentSpeed * Time.fixedDeltaTime);

            RB.AddForce(Vector2.right * Speed * UpgradeScript.Vehicles[BikeNum].CurrentSpeed * Time.fixedDeltaTime);
        }
        
        if (Bufferleft > 0 && Grounded == true && Current != null)
        {
            Bufferleft = 0;
            Vector2 dir = (transform.position - Current.transform.position).normalized;
            RB.AddForce(dir * JumpForce * UpgradeScript.Vehicles[BikeNum].CurrentJump, ForceMode2D.Impulse);
            
        }
        if (CT.Jumping == true)
        {
            CT.Jumping = false;
            Bufferleft = frameBuffer;
            if (Grounded == true && Current != null)
            {
                //Debug.Log("Jump" + UpgradeScript.CurrentJump);
                Vector2 dir = (transform.position - Current.transform.position).normalized;
                RB.AddForce(dir * UpgradeScript.Vehicles[BikeNum].CurrentJump, ForceMode2D.Impulse);

                Current.SetTime(1f);
                Current = null;
                Bufferleft = 0;
            }
        }
        Bufferleft -= 1;
        GravityCheck();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Win")
        {
            OnWin();
        }
        else if (col.gameObject.transform.childCount > 1)
        {
            if (col.gameObject.transform.GetChild(0).tag == "Win")
            {
                OnWin();
            }
            else if (col.gameObject.transform.GetChild(1).tag == "Win")
            {
                OnWin();
            }
        }
    }

    public void Restart()
    {
        if(LoadTimer > .05f && HasWon == false)
        {
            Physics2D.gravity = new Vector2(0, -10.81f);
            GameScene.instance.LoadScene(UpgradeScript.Level);
            ThisLevelSystem.CurrectMoney = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag != "Booster" && HasWon == false && col.gameObject.tag != "coin" && col.gameObject.tag != "Win")
        {
            Restart();
        }
    }
    
    public void GravityAdd(bool GravityEnabled)
    {
        Gravity.Add(GravityEnabled);
    }

    

    void Start()
    {
        SpawnPoint = GameObject.Find("Spawn").transform;
        CameraObjective = GameObject.Find("CameraObjective").transform;

        Canvas = GameObject.Find("Canvas");
        WinBanner = Canvas.transform.Find("WinBanner");
        WinBanner.gameObject.SetActive(false);

        CT = GameObject.Find("Buttons").GetComponent<BikeControl>();

        CamScript = GameObject.Find("Main Camera").GetComponent<Camera>();
        CamScript.player = transform;

        PlanetAssigner.instance.RB = RB;

        GameObject.Find("ThisLevel").GetComponent<ThisLevelSystem>().enabled = true;

        Physics2D.gravity = new Vector2(0, -10.81f);

        CT.Control = this;
    }

    public void OnWin()
    {
        if (HasWon == false)
        {
            float done = ThisLevelSystem.instance.Timer * 100;
            int Ajusted  = (int)done;
            HighScores.instance.UploadScore(UpgradeScript.Name, Ajusted);

            WinBanner.gameObject.SetActive(true);
            ThisLevelSystem.instance.SetLevel();
            if (UpgradeScript.ShouldSave == true)
            {
                SaveSystem.SaveStats();
            }
            int TOtal = UpgradeScript.Level - 1;
            Debug.Log("playable assign" + TOtal);
            StarAssigner.Playable[UpgradeScript.Level -1] = true;

            Win.Play();
        }
        HasWon = true;
    }

    

    public void AddTorqueImpulse(float angularChangeInDegrees)
    {
        var impulse = (angularChangeInDegrees * Mathf.Deg2Rad) * RB.inertia;

        RB.AddTorque(impulse, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        LoadTimer += Time.deltaTime * UpgradeScript.Vehicles[UpgradeScript.MyBikeNumber].CurrentJump;

        float magnitude = RB.velocity.magnitude;
        float AjustedMagnitude = Mathf.Round(magnitude * 100f) * 0.01f;
        if (AjustedMagnitude > 80 && HasWon == false && SpeedDestory == true)
        {
            Restart();
        }
    }

    public void GravityCheck()
    {
        for (var i = 0; i < Gravity.Count; i++)
        {
            if (Gravity[i] == false)
            {
                IsGravity = false;
                //Debug.Log("false2");
            }
        }

        if (Gravity.Count == 0)
        {
            Physics2D.gravity = new Vector2(0, -10.81f);
        }
        else
        {
            if (IsGravity == false)
            {
                Physics2D.gravity = Vector2.zero;
                //Debug.Log("false3");
            }
            else
            {
                Physics2D.gravity = new Vector2(0, -10.81f);
                //Debug.Log("true3");
            }
        }
        Gravity.Clear();
    }
}
