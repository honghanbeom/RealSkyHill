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
            // Ŭ���� ��ü�� off �ϰ� ��
            // isCheck�� ���� ���� ����
            buttonController.isCheck = true;
            buttonController.AllButtonOFF();

            // ���� ���� �ٽ� Ŵ
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
