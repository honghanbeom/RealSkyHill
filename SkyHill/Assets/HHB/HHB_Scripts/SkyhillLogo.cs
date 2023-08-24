using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyhillLogo : MonoBehaviour
{
    public GameObject withH;
    public GameObject withoutH;


    private void Update()
    {
        StartCoroutine(BlinkLogo());
    }

    IEnumerator BlinkLogo()
    { 
        withH.SetActive(true);
        yield return new WaitForSeconds(1f);
        withH.SetActive(false);
        withoutH.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        withoutH.SetActive(false);
        withoutH.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        withoutH.SetActive(false);
        withoutH.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        withoutH.SetActive(false);
    }
}
