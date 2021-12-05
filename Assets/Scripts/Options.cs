using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class Options : MonoBehaviour
{
    #region Singleton

    public static Options instance;

    void Awake()
    {
        instance = this;
        ChangeSlider(VolumePercent, 1);
        ChangeSlider(VolumePercent2, 0);
    }

    #endregion

    public Slider SoundSlider;
    public Slider MusicSlider;

    //sound
    private float VolumeFloat;
    public static int VolumePercent;
    public static int VolumeChange;

    //mussic
    private float VolumeFloat2;
    public static int VolumePercent2;
    public static int VolumeChange2;

    public static bool OnStart = true;

    public Text SoundText;
    public Text MusicText;

    public AudioMixer audioMixerSound;
    public AudioMixer audioMixerMusic;

    public TMP_InputField Field;

    TouchScreenKeyboard keyboard;

    public GameObject NotLongEnough;

    public bool FirstLog;
    
    public void SetToMax(bool True)
    {
        FirstLog = True;
        if (True == true)
        {
            SoundSlider.value = 1;
            MusicSlider.value = 1;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        //sound
        //on scale of .00 to 1.00
        VolumeFloat = SoundSlider.value;
        //turn into int
        VolumeFloat = VolumeFloat * 100;
        VolumePercent = (int)VolumeFloat / 100;

        //display text
        string VolumeText = VolumePercent + "%";
        SoundText.text = VolumeText;

        //on scale of -80 to 80
        //-(int * 8 / 10
        int VolumeChangePT = -(VolumePercent * 8 / 10) + 160;
        VolumeChange = 80 - VolumeChangePT;
        audioMixerSound.SetFloat("Volume", VolumeChange);

        //muisc
        VolumeFloat2 = MusicSlider.value;
        VolumeFloat2 = VolumeFloat2 * 100;
        VolumePercent2 = (int)VolumeFloat2 / 100;
        string VolumeText2 = VolumePercent2 + "%";
        MusicText.text = VolumeText2;

        int VolumeChangePT2 = -(VolumePercent2 * 8 / 10) + 160;
        VolumeChange2 = 80 - VolumeChangePT2;
        audioMixerMusic.SetFloat("Volume", VolumeChange2);
    }

    public void ChangeSlider(int Percent, int Slider)
    {
        if (Slider == 0)
        {
            MusicSlider.value = Percent;
        }
        else if (Slider == 1)
        {
            SoundSlider.value = Percent;
        }
    }
    void Start()
    {
        //SoundSlider.value = 100;
        //MusicSlider.value = 100;
        Field.text = UpgradeScript.Name;
        if (OnStart == true)
        {
            VolumePercent = 100;
            OnStart = false;
        }
        if (FirstLog == true)
        {

        }
        audioMixerSound.SetFloat("Volume", VolumeChange);
        audioMixerMusic.SetFloat("Volume", VolumeChange2);

        if (UpgradeScript.Name.Length < 8)
        {
            NotLongEnough.SetActive(false);
        }
        else
        {
            NotLongEnough.SetActive(true);
        }
    }

    public void OpenNameChange()
    {
        if(keyboard != null)
        {
            keyboard.active = true;
        }
        //TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, true);
    }
    public void Finish()
    {
        if (keyboard != null)
        {
            keyboard.active = false;
        }
        if (Field.text.Length < 8)
        {
            UpgradeScript.Name = Field.text;
            NotLongEnough.SetActive(false);
        }
        else
        {
            NotLongEnough.SetActive(true);
        }
        
    }
    public void ChangeBoth(string Text)
    {
        Field.text = Text;
        UpgradeScript.Name = Field.text;
    }
}