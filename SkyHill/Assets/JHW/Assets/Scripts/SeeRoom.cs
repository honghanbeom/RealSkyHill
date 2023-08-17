using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.UI;


public class SeeRoom : MonoBehaviour
{

    public GameObject blackOut;
    public Image uiImage; // 활성화할 UI 이미지
    public Image uiImage1; // 활성화할 UI 이미지
    public Image uiImage2; // 활성화할 UI 이미지


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
            Debug.Log("닿았다!");
            blackOut.SetActive(false);

            // 플레이어와 충돌한 콜라이더 내에 Enemy 태그를 가진 객체가 있는지 확인
            if (collision.transform.childCount > 0)
            {
                for (int i = 0; i < collision.transform.childCount; i++)
                {
                    if (collision.transform.GetChild(i).CompareTag("Enemy"))
                    {
                        Debug.Log("플레이어와 충돌한 콜라이더 내에 적이 있음!");
                        ActivateUIImages();
                        break;
                    }
                }
            }

        }
    }

    private void ActivateUIImages()
    {
        uiImage.gameObject.SetActive(true);
        uiImage1.gameObject.SetActive(true);
        uiImage2.gameObject.SetActive(true);
    }
    //public void ActivateImage()
    //{
    //    uiImage.gameObject.SetActive(true);
    //}






}
