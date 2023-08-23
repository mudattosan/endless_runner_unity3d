using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public string parentName;
    void Update()
    {
        parentName = transform.name;
        StartCoroutine(DestroyClone());
    }

    IEnumerator DestroyClone()
    {
        yield return new WaitForSeconds(50);
        if(parentName == "Section1(Clone)" || parentName == "Section2(Clone)" || parentName == "StartSection(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
