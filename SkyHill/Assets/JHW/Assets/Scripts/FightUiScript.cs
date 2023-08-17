using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class FightUiScript : MonoBehaviour , IPointerClickHandler

{
    public GameObject uiImage; // 활성화할 UI 이미지
    public GameObject uiImage1; // 활성화할 UI 이미지
    public GameObject uiImage2; // 활성화할 UI 이미지

    public Sprite newImageSprite; // 클릭 시 변경할 이미지 스프라이트
    public Image image; // UI 이미지의 Image 컴포넌트
    public void Start()
    {
        image = GetComponent<Image>(); // UI 이미지의 Image 컴포넌트 가져오기


        uiImage = GameObject.Find("LeftHand");
        uiImage1 = GameObject.Find("RightHand");
        uiImage2 = GameObject.Find("AttackType");
        //uiImage.SetActive(false);
        //uiImage1.SetActive(false);
        //uiImage2.SetActive(false);
    }
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Debug.Log("만났다!!");

            ActivateUIImages();

        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Debug.Log("나갔다 !!! ");

            ActivateUIImages2();

        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (newImageSprite != null)
        {
            image.sprite = newImageSprite; // 이미지 스프라이트 변경
        }
    }

    private void ActivateUIImages()
    {
        uiImage.SetActive(true);
        uiImage1.SetActive(true);
        uiImage2.SetActive(true);
        ImageSc3();
        ImageSc4();
        ImageSc5();

    }

    private void ActivateUIImages2()
    {
        uiImage.SetActive(false);
        uiImage1.SetActive(false);
        uiImage2.SetActive(false);
    }


    public void ImageSc3()
    {
        Vector3 uiImageScale = uiImage.transform.localScale;

        Vector3 newScale = new Vector3(1, 1, 0);

        uiImage.transform.localScale = newScale;
    }

    public void ImageSc4()
    {
        Vector3 uiImageScale = uiImage1.transform.localScale;

        Vector3 newScale = new Vector3(1, 1, 0);

        uiImage1.transform.localScale = newScale;
    }

    public void ImageSc5()
    {
        Vector3 uiImageScale = uiImage2.transform.localScale;

        Vector3 newScale = new Vector3(1, 1, 0);

        uiImage2.transform.localScale = newScale;
    }

}
