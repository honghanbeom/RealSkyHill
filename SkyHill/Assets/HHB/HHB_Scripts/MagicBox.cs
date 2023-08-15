using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MagicBox : MonoBehaviour, IPointerClickHandler
{
    public int itemId { get; set; }


    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.LogFormat("{0}", itemId);
    }
}
