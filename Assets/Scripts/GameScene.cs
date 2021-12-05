using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    public static GameScene instance;

    public static List<string> Strings = new List<string>();
    public static List<bool> Bools = new List<bool>();

    public Animator transitionMenu;

    public GameObject Music;
    public AudioSource ButtonClick;
    public static GameObject MusicStatic;

    private GameObject VideoButton;

    void Start()
    {
        if (UpgradeScript.Level != 0 && UpgradeScript.Level != 1)
        {
            ADManager.Instance.ShowInterstitial();
        }
        
        if (UpgradeScript.First == true)
        {
            MusicStatic = Music;

            if (UpgradeScript.ShouldSave == true)
            {
                SaveSystem.LoadGameLarge();
            }

        }
        VideoButton = GameObject.Find("WatchVideo");
        ADManager.Instance.Video = VideoButton;
        if (ADManager.Instance.IntersitialAdTime < ADManager.Instance.InterstitialTime)
        {
            ADManager.Instance.InterstitialTime = 0;
        }
        ADManager.Instance.ShowBanner();
    }
    void Awake()
    {
        Strings.Add("UpgradeMenu");
        Strings.Add("StartMenu");
        Strings.Add("GameScene1");
        Strings.Add("GameScene2");
        Strings.Add("GameScene3");
        Strings.Add("GameScene4");
        Strings.Add("GameScene5");
        Strings.Add("GameScene6");
        Strings.Add("GameScene7");
        Strings.Add("GameScene8");
        Strings.Add("GameScene9");
        Strings.Add("GameScene10");
        Strings.Add("GameScene11");
        Strings.Add("GameScene12");
        Strings.Add("GameScene13");
        Strings.Add("GameScene14");
        Strings.Add("GameScene15");
        Strings.Add("GameScene16");
        Strings.Add("GameScene17");
        Strings.Add("GameScene18");
        Strings.Add("GameScene19");
        Strings.Add("GameScene20");
        Strings.Add("GameScene21");
        Strings.Add("GameScene22");
        Strings.Add("GameScene23");
        Strings.Add("GameScene24");
        Strings.Add("GameScene25");
        Strings.Add("GameScene26");
        Strings.Add("GameScene27");
        Strings.Add("GameScene28");
        Strings.Add("GameScene29");

        //Bools.Clear;
        Bools.Add(false);
        Bools.Add(false);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);
        Bools.Add(true);

        

        instance = this;

        
    }
    public void LoadScene(int Number)
    {
        if (UpgradeScript.Lock == true)
        {
            if (Number > 1)
            {
                int MinusTotal = Number - 2;
                //Debug.Log("ckecing " + MinusTotal);
                //Debug.Log(StarAssigner.Playable[Number - 2]);

                int TOtal = UpgradeScript.Level - 2;
                //Debug.Log("playable Check" + MinusTotal);
                if (StarAssigner.Playable[Number - 2] == false)
                {
                    return;
                }
            }
        }
        StartCoroutine(LoadTime(Number));
    }
    
    IEnumerator LoadTime(int Level)
    {
        
        Debug.Log(Level);
        
        if(Level == 0 || Level == 1)
        {
            Time.timeScale = 1f;
            
        }
        
        if(Bools[Level] == true)
        {
            //transitionMenu.SetTrigger("Start");
        }


        if (transitionMenu != null)
        {
            transitionMenu.SetTrigger("Start");
            yield return new WaitForSeconds(.8f);
        }

        DontDestroyOnLoad(MusicStatic);

        UpgradeScript.IsGame = Bools[Level];
        SceneManager.LoadScene(Strings[Level]);
        UpgradeScript.Level = Level;
        Time.timeScale = 1f;
    }
    
}
