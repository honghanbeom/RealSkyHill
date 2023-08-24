using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIController : MonoBehaviour, IPointerClickHandler
{
    private bool isOn = false;
    public GameObject[] buttonControllObjs;
    float minScaleFactor = 0.001f;
    float maxScaleFactor = 1.0f;
    public void OnPointerClick(PointerEventData eventData)
    {

        if (isOn == false)
        {
            foreach (GameObject objs in buttonControllObjs)
            {
                objs.transform.localScale = transform.localScale * maxScaleFactor;
                isOn = true;
            }
        }
        else if (isOn == true)
        {
            foreach (GameObject objs in buttonControllObjs)
            {
                objs.transform.localScale = transform.localScale * minScaleFactor;
                isOn = false;
            }
        }
    }
}