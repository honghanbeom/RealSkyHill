using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FightUiScript : MonoBehaviour
{
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

    public void ActivateImage()
    {
        uiImage.gameObject.SetActive(true);
    }

}
