using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicyMenu : MonoBehaviour
{
    private string PolicyKey = "policy";
    public static bool ShowMenu = true;
    void Start()
    {
        ShowTheMenu();
    }

    public void ShowTheMenu()
    {
        if (ShowMenu == false)
        {
            return;
        }
        // Show a dialog that prompts the user to accept the Terms of Service and Privacy Policy
        SimpleGDPR.ShowDialog(new TermsOfServiceDialog().
            SetTermsOfServiceLink("https://policies.google.com/terms?hl=en-US").
            SetPrivacyPolicyLink("https://policies.google.com/privacy?hl=en-US"),
            OnMenuClosed);
    }
    private void OnMenuClosed()
    {
        //Debug.Log("accepted");
        PlayerPrefs.GetInt(PolicyKey, 1);
        ShowMenu = false;
    }

    public static void RecieveBool(bool Show)
    {
        ShowMenu = Show;
    }
}
