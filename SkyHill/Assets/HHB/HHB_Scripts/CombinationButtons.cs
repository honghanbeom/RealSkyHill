using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CombinationDelButtons : MonoBehaviour, IPointerClickHandler
{
    public Image[] combinationImages;

    //List<GameObject> activeButtons = new List<GameObject>();

    //public GameObject weaponButtons;
    ////public GameObject foodButtons;
    ////public GameObject medicalButtons;
    ////public GameObject etcButtons;
    ////public GameObject vipButtons;


    //void GetButtons()
    //{
    //    FindButtons(weaponButtons);
    //    //FindButtons(foodButtons);
    //    //FindButtons(medicalButtons);
    //    //FindButtons(etcButtons);
    //    //FindButtons(vipButtons);
    //}

    //void FindButtons(GameObject content)
    //{
    //    Button[] buttons = content.GetComponentsInChildren<Button>();

    //    foreach (Button button in buttons)
    //    {
    //        activeButtons.Add(button.gameObject);
    //    }
    //}


    //public void DelClick()
    //{
    //    GetButtons();
    //    //// µð¹ö±×¿ë
    //    //foreach (var a in activeButtons)
    //    //{
    //    //    Debug.LogFormat("{0}", a);
    //    //}

    //    foreach (GameObject button in activeButtons)
    //    {
    //        Button buttonComponent = button.GetComponent<Button>();
    //        if (buttonComponent != null)
    //        {
    //            Debug.Log("±Â");

    //        }
    //    }
    //}

    void Awake()
    { 
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; i < combinationImages.Length; i++)
        {
            ItemList.itemList.ImageMatch(-1, combinationImages[i]);
        }
    }
}
