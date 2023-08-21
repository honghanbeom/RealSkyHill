using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject mother;
    private GameObject[] child; 
    public bool isCheck = true;

    private void Start()
    {
        FindButtons();
    }

    public void FindButtons()
    {
        int childCount = mother.transform.childCount;
        child = new GameObject[childCount];

        for (int i = 0; i < childCount; i++)
        {
            GameObject prefabInstance = mother.transform.GetChild(i).gameObject;
            Transform clickedTransform = prefabInstance.transform.Find("Clicked");

            if (clickedTransform != null)
            {
                child[i] = clickedTransform.gameObject;
            }
        }
    }


    public void AllButtonOFF()
    {
        if (isCheck)
        {
            for (int i = 0; i < child.Length; i++)
            {
                if (child[i].activeSelf)
                {
                    child[i].SetActive(false);

                    child[i].transform.parent.GetComponent<ClickImage>().clickedImage = false;
                    
                }
            }

            isCheck = false;
        }
    }
}

