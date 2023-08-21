using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class FightUiScript : MonoBehaviour, IPointerClickHandler

{
    public GameObject uiImage; // Ȱ��ȭ�� UI �̹���
    public GameObject uiImage1; // Ȱ��ȭ�� UI �̹���
    public GameObject uiImage2; // Ȱ��ȭ�� UI �̹���

    public Image newImageSprite; // Ŭ�� �� ������ �̹��� ��������Ʈ
    public Image image; // UI �̹����� Image ������Ʈ
    public void Start()
    {
        image = GetComponent<Image>(); // UI �̹����� Image ������Ʈ ��������


        uiImage = GameObject.Find("LeftHand_F");
        uiImage1 = GameObject.Find("RightHand_F");
        uiImage2 = GameObject.Find("AttackType");
        //uiImage.SetActive(false);
        //uiImage1.SetActive(false);
        //uiImage2.SetActive(false);


        ImageSc();
        ImageSc1();
        ImageSc2();
    }
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            Debug.Log("������!!");

            ActivateUIImages();

        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            Debug.Log("������ !!! ");

            ActivateUIImages2();

        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (newImageSprite != null)
        {
            Debug.Log("Ŭ���̴�!");
            image = newImageSprite; // �̹��� ��������Ʈ ����
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

        Vector3 newScale = new Vector3(0.7f, 0.7f, 0);

        uiImage2.transform.localScale = newScale;
    }


    public void ImageSc()
    {
        Vector3 uiImageScale = uiImage.transform.localScale;

        Vector3 newScale = new Vector3(0.001f, 0.001f, 0);

        uiImage.transform.localScale = newScale;
    }

    public void ImageSc1()
    {
        Vector3 uiImageScale = uiImage1.transform.localScale;

        Vector3 newScale = new Vector3(0.001f, 0.001f, 0);

        uiImage1.transform.localScale = newScale;
    }

    public void ImageSc2()
    {
        Vector3 uiImageScale = uiImage2.transform.localScale;

        Vector3 newScale = new Vector3(0.001f, 0.001f, 0);

        uiImage2.transform.localScale = newScale;
    }

}
