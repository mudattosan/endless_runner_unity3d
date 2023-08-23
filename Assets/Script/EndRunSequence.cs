using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRunSequence : MonoBehaviour
{
    public GameObject liveCoin;
    public GameObject liveDistance;
    public GameObject endScreen;
    public GameObject FadeOut;
    void Start()
    {
         StartCoroutine(EndSequence());
    }
   

    IEnumerator EndSequence()
    {
        yield return new WaitForSeconds(3);
        liveCoin.SetActive(false);
        liveDistance.SetActive(false);
        endScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        FadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}
