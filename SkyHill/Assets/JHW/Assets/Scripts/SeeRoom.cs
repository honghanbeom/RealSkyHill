using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.UI;


public class SeeRoom : MonoBehaviour
{

    public GameObject blackOut;
    public Image uiImage; // Ȱ��ȭ�� UI �̹���
    public Image uiImage1; // Ȱ��ȭ�� UI �̹���
    public Image uiImage2; // Ȱ��ȭ�� UI �̹���


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Debug.Log("��Ҵ�!");

            blackOut.SetActive(false);

        }
    }


    //public void ActivateImage()
    //{
    //    uiImage.gameObject.SetActive(true);
    //}






}
