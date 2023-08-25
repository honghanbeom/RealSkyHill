using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class IconButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject buttonObj;
    private Color originalColor;
    private Image buttonImg;

    void Awake()
    {
        originalColor = Color.white;
        buttonImg = buttonObj.GetComponent<Image>();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImg.color = new Color(0.91f, 0.84f, 0.24f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {  
        buttonImg.color = originalColor;
    }

    public void QuitGame()
    { 
        Application.Quit();
    }
}
