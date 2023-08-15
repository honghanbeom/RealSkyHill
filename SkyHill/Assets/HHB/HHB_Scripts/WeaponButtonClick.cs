using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponButtonClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject weaponScroll;

    private void Start()
    {
        weaponScroll.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        weaponScroll.SetActive(true);
    }
}
