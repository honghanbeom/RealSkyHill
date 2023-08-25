using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCourtine : MonoBehaviour
{
    public GameObject[] endingObj;
    private float timeDelay = 2f;

    private void Update()
    {
        StartCoroutine(Ending());
    }

    IEnumerator Ending()
    {
        for (int index = 0; index < 5; index++)
        { 
            endingObj[index].SetActive(true);         
            yield return new WaitForSeconds(timeDelay);
        }

        yield return new WaitForSeconds(0.1f);
        Application.Quit();
      
    }
}
