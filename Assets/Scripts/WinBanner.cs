using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class WinBanner : MonoBehaviour
{
    public GameObject HighScore;
    public TextMeshProUGUI YourTime;
    public GameObject YourTimeOBJ;
    public GameObject BasicWin;
    public HighScores scores;

    public void TellHighScore(float Time)
    {
        BasicWin.SetActive(false);
        YourTimeOBJ.SetActive(true);
        HighScore.SetActive(false);
        YourTime.text = "Your Time: " + Time;
        //UploadScore
        //upload
    }
    public void NotHighScore()
    {
        BasicWin.SetActive(true);
        YourTimeOBJ.SetActive(false);
        HighScore.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
