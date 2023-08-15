using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickImage : MonoBehaviour, IPointerClickHandler
{
    public ButtonController buttonController;
    public GameObject clickedEffect;
    public bool clickedImage = false;


    public void Awake()
    {
        buttonController =
            GameObject.Find("Content").GetComponent<ButtonController>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ButtonActiveOne();
    }

    public void ButtonActiveOne()
    {
        if (clickedImage == false)
        {
            // 클릭시 전체를 off 하고 들어감
            // isCheck는 들어가기 위한 조건
            buttonController.isCheck = true;
            buttonController.AllButtonOFF();

            // 모든걸 끄고 다시 킴
            clickedEffect.SetActive(true);
            clickedImage = true;
        }
        else if (clickedImage == true)
        {
            clickedEffect.SetActive(false);
            clickedImage = false;

        }
    }


}
