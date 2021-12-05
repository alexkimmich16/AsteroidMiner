using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscores : MonoBehaviour 
{
    public TMPro.TextMeshProUGUI[] rNames;
    public TMPro.TextMeshProUGUI[] rScores;
    HighScores myScores;

    public bool MainMenu;

    void Start() //Fetches the Data at the beginning
    {
        for (int i = 0; i < rNames.Length;i ++)
        {
            rNames[i].text = i + 1 + ". Fetching...";
        }
        myScores = GetComponent<HighScores>();
        StartCoroutine("RefreshHighscores");
    }
    public void SetScoresToMenu(PlayerScore[] highscoreList) //Assigns proper name and score for each text value
    {
        for (int i = 0; i < rNames.Length;i ++)
        {
            rNames[i].text = i + 1 + ". ";
            if (highscoreList.Length > i)
            {
                //Debug.Log(highscoreList[i].score + " SCORE");
                
                float AjustedScore = highscoreList[i].score / 100f;
                //Debug.Log(AjustedScore + " AjustedSCORE");
                rScores[i].text = AjustedScore.ToString();
                rNames[i].text = highscoreList[i].username;
                if(MainMenu == false)
                {
                    //check time
                    if(ThisLevelSystem.instance.Timer > highscoreList[4].score)
                    {
                        BikeController.instance.WinBanner.GetComponent<WinBanner>().TellHighScore(ThisLevelSystem.instance.Timer / 100);
                    }
                    
                }
                else
                {

                }
            }
        }
    }
    IEnumerator RefreshHighscores() //Refreshes the scores every 30 seconds
    {
        while(true)
        {
            myScores.DownloadScores();
            yield return new WaitForSeconds(30);
        }
    }
}
