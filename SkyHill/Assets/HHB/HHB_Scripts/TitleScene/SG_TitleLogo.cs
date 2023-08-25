using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG_TitleLogo : MonoBehaviour
{

    public GameObject[] onOffLogo;

    private WaitForSeconds waitForSecondsH;
    private WaitForSeconds waitForSeconds;
    private WaitForSeconds blinkH;
    private float hDelayTime;

    private Coroutine coroutine;



    // Start is called before the first frame update
    void Start()
    {
        hDelayTime = 0.5f;
        waitForSeconds = new WaitForSeconds(0.1f);
        blinkH = new WaitForSeconds(0.2f);
        waitForSecondsH = new WaitForSeconds(hDelayTime);

        coroutine = StartCoroutine(PlayFirstLogo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayFirstLogo()
    {
        yield return waitForSecondsH;
        yield return waitForSecondsH;



        for (int i =0; i < onOffLogo.Length; i++)
        {
            onOffLogo[i].SetActive(true);
            yield return waitForSeconds; 
        }

        yield return waitForSecondsH;
        yield return waitForSecondsH;

        coroutine = StartCoroutine(OffH());
    }

    IEnumerator OnH()
    {

        yield return waitForSecondsH;
        onOffLogo[3].SetActive(true);
        yield return waitForSecondsH;
        coroutine = StartCoroutine(OffH());
    }

    IEnumerator OffH()
    {
        yield return waitForSecondsH;
        onOffLogo[3].SetActive(false);
        yield return blinkH;
        onOffLogo[3].SetActive(true);
        yield return blinkH;
        onOffLogo[3].SetActive(false);
        yield return blinkH;
        coroutine = StartCoroutine(OnH());


    }

}
