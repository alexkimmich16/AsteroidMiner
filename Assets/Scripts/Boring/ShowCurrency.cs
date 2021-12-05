using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowCurrency : MonoBehaviour
{
    public TextMeshProUGUI CoinText;
    public TextMeshProUGUI GemText;

    // Update is called once per frame
    void Update()
    {
        
        if(CoinText != null)
        {
            string MoneyDisplay = "" + UpgradeScript.Money;
            CoinText.text = MoneyDisplay;
        }

        if (GemText != null)
        {
            string MoneyDisplay2 = "" + UpgradeScript.Gems;
            GemText.text = MoneyDisplay2;
        }
        
        
    }
}
