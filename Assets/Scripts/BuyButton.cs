using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public enum ItemType
    {
        Silver100,
        Silver200,
        NoAds
    }

    public ItemType itemType;
    public Text priceText;

    private string defaultText;
    // Start is called before the first frame update
    void Start()
    {
        defaultText = priceText.text;
        StartCoroutine(LoadPriceRoutine());
    }

    public void ClickBuy()
    {
        switch (itemType)
        {
            case ItemType.Silver100:
                IAPManager.instance.Buy100Silver();
                break;
            case ItemType.Silver200:
                IAPManager.instance.Buy200Silver();
                break;
            case ItemType.NoAds:
                IAPManager.instance.BuyNoAds();
                break;
        }
    }

    private IEnumerator LoadPriceRoutine()
    {
        while (!IAPManager.instance.IsInitialized())
        {
            yield return null;
        }
        string loadedPrice = "";

        switch (itemType)
        {
            case ItemType.Silver100:
                loadedPrice = IAPManager.instance.GetProducePriceFromStore(IAPManager.instance.Silver_100);
                break;
            case ItemType.Silver200:
                loadedPrice = IAPManager.instance.GetProducePriceFromStore(IAPManager.instance.Silver_200);
                break;
            case ItemType.NoAds:
                loadedPrice = IAPManager.instance.GetProducePriceFromStore(IAPManager.instance.No_Ads);
                break;
        }

        priceText.text = defaultText + " " + loadedPrice;
    }

}
