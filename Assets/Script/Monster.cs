using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject levelControl;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<CharacterControlller>().enabled = false;
        thePlayer.GetComponent<Animator>().Play("Death");
        levelControl.GetComponent<LevelDistance>().enabled = false;
        levelControl.GetComponent<EndRunSequence>().enabled = true;
        }
        else if(other.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
