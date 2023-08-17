using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject scroll;
    public GameObject[] otherScrolls;

    private void Start()
    {
        scroll.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        scroll.SetActive(true);
        foreach (var otherScroll in otherScrolls)
        {
            if (otherScroll != scroll)
            {
                otherScroll.SetActive(false);
            }
        }
    }
}
