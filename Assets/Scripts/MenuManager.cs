using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    #region Singleton

    public static MenuManager instance;

    void Awake()
    {
        instance = this;
        //GameObject.Find("GameManager").GetComponent<UpgradeScript>().SpawnBike();
    }

    #endregion

    public GameObject StartMenu;

    public GameObject LevelMenu;

    public GameObject OptionsMenu;

    public GameObject CarMenu;

    public GameObject Title;

    public swipeMenu SwipeScript;

    public int ChosenCar;

    public AudioSource ButtonClick;
    public GameObject Reminder;
    //public AudioSource Win;

    public void ActivateNameReminder(bool SetActive)
    {
        Reminder.SetActive(SetActive);
    }

    public void PlayButton()
    {
        OptionsMenu.SetActive(false);
        StartMenu.SetActive(false);
        CarMenu.SetActive(true);
        Title.SetActive(false);
        Reminder.SetActive(false);
        ButtonClick.Play();
    }
    public static void banner()
    {
        ADManager.Instance.ShowBanner();
    }
    public static void Inter()
    {
        ADManager.Instance.ShowInterstitial();
    }
    public static void Rewarded()
    {
        ADManager.Instance.ShowRewardedVideo();
    }
    public void OptionsMenuTouch()
    {
        OptionsMenu.SetActive(true);
        StartMenu.SetActive(false);
        Title.SetActive(false);
        Reminder.SetActive(false);
        ButtonClick.Play();
    }

    public void LevelMenuTouch()
    {
        LevelMenu.SetActive(true);
        StartMenu.SetActive(false);
        CarMenu.SetActive(false);
        ChosenCar = SwipeScript.Selected;
        Reminder.SetActive(false);
        UpgradeScript.MyBikeNumber = SwipeScript.Selected;
        ButtonClick.Play();
    }

    public void BackButtonClick()
    {
        Reminder.SetActive(false);
        if (LevelMenu.activeSelf == true)
        {
            StartMenu.SetActive(false);
            LevelMenu.SetActive(false);
            CarMenu.SetActive(true);
        }
        else if (CarMenu.activeSelf == true)
        {
            StartMenu.SetActive(true);
            LevelMenu.SetActive(false);
            CarMenu.SetActive(false);
            Title.SetActive(true);
        }
        else if (OptionsMenu.activeSelf == true)
        {
            OptionsMenu.SetActive(false);
            StartMenu.SetActive(true);
            Title.SetActive(true);
            if (UpgradeScript.ShouldSave == true)
            {
                SaveSystem.SaveStats();
            }
        }
        ButtonClick.Play();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
