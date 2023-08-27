using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class FightUiScript : MonoBehaviour, IPointerClickHandler

{



    public GameObject AttackArea_R;
    public GameObject AttackArea_N;




    public void Start()
    {

        AttackArea_R = GameObject.Find("AttackArea");
        AttackArea_N = GameObject.Find("AttackArea2");

        ImageSc6();
        ImageSc8();

    }


    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {

            }
            else
            {
                // ���콺 Ŭ�� ��ġ�� ���� ��ǥ�� ��ȯ
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;

                // ���콺 Ŭ���� ��ġ�� �ش��ϴ� ������Ʈ ã��
                Collider2D collider = Physics2D.OverlapPoint(mousePosition);

                if (collider != null && collider.CompareTag("Rookie"))
                {
                    ImageSc7();
                }
                if (collider != null && collider.CompareTag("Neighbour"))
                {
                    ImageSc9();
                }
            }
        }

    }



    public void OnPointerClick(PointerEventData eventData)
    {

        if (gameObject.CompareTag("Finish"))
        {
            ImageSc6();
            ImageSc8();
        }

    }






    public void ImageSc6()
    {
        Vector3 uiImageScale = AttackArea_R.transform.localScale;

        Vector3 newScale = new Vector3(0.001f, 0.001f, 0);

        AttackArea_R.transform.localScale = newScale;
    }


    public void ImageSc7()
    {
        Vector3 uiImageScale = AttackArea_R.transform.localScale;

        Vector3 newScale = new Vector3(1f, 1f, 1f);

        AttackArea_R.transform.localScale = newScale;
    }

    public void ImageSc8()
    {
        Vector3 uiImageScale = AttackArea_N.transform.localScale;

        Vector3 newScale = new Vector3(0.001f, 0.001f, 0);

        AttackArea_N.transform.localScale = newScale;
    }


    public void ImageSc9()
    {
        Vector3 uiImageScale = AttackArea_N.transform.localScale;

        Vector3 newScale = new Vector3(1f, 1f, 1f);

        AttackArea_N.transform.localScale = newScale;
    }

}
