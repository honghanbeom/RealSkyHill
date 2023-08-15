using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CombinationCreateButton : MonoBehaviour, IPointerClickHandler
{
    public Image[] combinationImages;


    void Awake()
    { 
        InventoryContent inventory = GetComponent<InventoryContent>();  
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; i < combinationImages.Length; i++)
        {
            ItemList.itemList.ImageMatch(-1, combinationImages[i]);
        }

    }


}
