using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FightUiScript : MonoBehaviour
{
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

    public void ActivateImage()
    {
        uiImage.gameObject.SetActive(true);
    }

}
