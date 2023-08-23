using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public AudioSource CoinSFX;
    
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        CoinSFX.Play();
        Pref.Coins += 1;
        this.gameObject.SetActive(false);
    }
}
