using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class FightUiScript : MonoBehaviour, IPointerClickHandler

{
    public GameObject leftHandImg; // 활성화할 UI 이미지
    public GameObject rightHandImg; // 활성화할 UI 이미지
    public GameObject attackTypeImg; // 활성화할 UI 이미지


    public GameObject AttackArea_R;
    public GameObject AttackArea_N;




    public void Start()
    {



        leftHandImg = GameObject.Find("LeftHand");
        rightHandImg = GameObject.Find("RightHand");
        attackTypeImg = GameObject.Find("AttackType");


        AttackArea_R = GameObject.Find("AttackArea");
        AttackArea_N = GameObject.Find("AttackArea2");



        //ImageSc();
        //ImageSc1();
        ImageSc2();
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
                // 마우스 클릭 위치를 월드 좌표로 변환
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;

                // 마우스 클릭한 위치에 해당하는 오브젝트 찾기
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

    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Rookie") || collision.tag.Equals("Neighbour"))
        {
            Debug.Log("몬스터랑 만났다!");
            ActivateUIImages();

        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Rookie") || collision.tag.Equals("Neighbour"))
        {
            Debug.Log("몬스터랑 만났다!");

            ActivateUIImages2();

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

    private void ActivateUIImages()
    {

        ImageSc3();
        ImageSc4();
        ImageSc5();

    }

    private void ActivateUIImages2()
    {
        ImageSc();
        ImageSc1();
        ImageSc2();
    }



    public void ImageSc()
    {
        Vector3 uiImageScale = leftHandImg.transform.localScale;

        Vector3 newScale = new Vector3(0.001f, 0.001f, 0);

        leftHandImg.transform.localScale = newScale;
    }

    public void ImageSc1()
    {
        Vector3 uiImageScale = rightHandImg.transform.localScale;

        Vector3 newScale = new Vector3(0.001f, 0.001f, 0);

        rightHandImg.transform.localScale = newScale;
    }

    public void ImageSc2()
    {
        Vector3 uiImageScale = attackTypeImg.transform.localScale;

        Vector3 newScale = new Vector3(0.001f, 0.001f, 0);

        attackTypeImg.transform.localScale = newScale;
    }

    public void ImageSc3()
    {
        Vector3 uiImageScale = leftHandImg.transform.localScale;

        Vector3 newScale = new Vector3(1, 1, 0);

        leftHandImg.transform.localScale = newScale;
    }

    public void ImageSc4()
    {
        Vector3 uiImageScale = rightHandImg.transform.localScale;

        Vector3 newScale = new Vector3(1, 1, 0);

        rightHandImg.transform.localScale = newScale;
    }

    public void ImageSc5()
    {
        Vector3 uiImageScale = attackTypeImg.transform.localScale;

        Vector3 newScale = new Vector3(0.7f, 0.7f, 0);

        attackTypeImg.transform.localScale = newScale;
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
