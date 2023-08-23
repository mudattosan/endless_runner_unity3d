using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableControl : MonoBehaviour
{
    public int PlayingCoins;
    public GameObject coinCountDisplay;
    public GameObject coinEndDisplay;
    void Update()
    {
        PlayingCoins = Pref.Coins;
        coinCountDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "" + PlayingCoins;
        coinEndDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "" + PlayingCoins;
    }
}
