using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDistance : MonoBehaviour
{
    public GameObject disDisplay;
    public GameObject disEndDisplay;
    public float distanceRun;
    public bool addingDis = false;
    public float disDelay = 0.35f;
    void Update()
    {
        if(addingDis == false)
        {
            addingDis = true;
            StartCoroutine(AddingDis());
        }
    }
    IEnumerator AddingDis()
    {
        distanceRun += 1;
        disDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "" + distanceRun;
        disEndDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "" + distanceRun;
        yield return new WaitForSeconds(disDelay);
        addingDis = false;
    }
}
