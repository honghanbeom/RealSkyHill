using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentScript : MonoBehaviour
{
    public GameObject prefab;


    RectTransform rectTransform;
    RectTransform[] rectTransformChild;

    float xPos = -25f;
    float yPos = 125f;

    // Start is called before the first frame update
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        
        for (int i = 0; i < 30; i++)
        {
            Instantiate(prefab, rectTransform);
        }

        rectTransformChild = new RectTransform[rectTransform.childCount];


        for (int i = 0; i < rectTransform.childCount; i++)
        {
            //Debug.Log(i);
            rectTransformChild[i] = rectTransform.GetChild(i) as RectTransform;


        }

        Position();
    }

    public void Position()
    {

        for (int i = 0; i < rectTransformChild.Length; i++)
        {
            //Debug.Log (i);
            // Â¦¼ö or 0 
            if (i % 2 == 0)
            {
                //Debug.LogFormat("¿ÞÂÊ : {0}",i);
                rectTransformChild[i].anchoredPosition = new Vector2(xPos, yPos);
                xPos += 50f;
            }
            // È¦¼ö
            if (i % 2 == 1)
            {
                //Debug.LogFormat("¿À¸¥ÂÊ : {0}", i);
                rectTransformChild[i].anchoredPosition = new Vector2(xPos, yPos);
                yPos -= 50f;
                xPos -= 50f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
