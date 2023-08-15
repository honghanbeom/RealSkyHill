using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryContent : MonoBehaviour
{
    public GameObject magicItemBox;

    RectTransform rectTransform;
    RectTransform[] rectTransformChild;


    public Sprite[] changeSprites;


    private float xPos = -170f;
    private float yPos = 110f;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        WeaponItemCreate();


    }

    // Update is called once per frame
    void Update()
    {

    }

    #region LEGACY
    //void WeaponItemCreate()
    //{
    //    rectTransform = GetComponent<RectTransform>();
    //    for (int i = 0; i < ItemManager.myWeaponList.Count; i++)
    //    {
    //        //Debug.LogFormat("{0}", ItemManager.myWeaponList.Count);
    //        GameObject myWeaponItems = Instantiate(magicItemBox, rectTransform);
    //    }

    //    rectTransformChild = new RectTransform[rectTransform.childCount];

    //    for (int i = 0; i < rectTransform.childCount; i++)
    //    {
    //        //Debug.Log(i);
    //        rectTransformChild[i] = rectTransform.GetChild(i) as RectTransform;
    //    }

    //    WeaponPosition();
    //}
    #endregion
    void WeaponItemCreate()
    {
        rectTransform = GetComponent<RectTransform>();

        foreach (int itemId in ItemManager.myWeaponList)
        {
            GameObject myWeaponItems = Instantiate(magicItemBox, rectTransform);

            Image itemImage = myWeaponItems.GetComponent<Image>();

            ItemList.itemList.ImageMatch(itemId, itemImage);

            myWeaponItems.GetComponent<MagicBox>().itemId = itemId;
        }

        rectTransformChild = new RectTransform[rectTransform.childCount];

        for (int i = 0; i < rectTransform.childCount; i++)
        {
            rectTransformChild[i] = rectTransform.GetChild(i) as RectTransform;
        }

        WeaponPosition();
    }

    void WeaponPosition()
    {
        int colSize = 6;
        for (int i = 0; i < rectTransformChild.Length; i++)
        {
            int row = i / colSize;
            int column = i % colSize;

            float xPosition = xPos + column * 70f;
            float yPosition = yPos - row * 60f;

            rectTransformChild[i].anchoredPosition = new Vector2(xPosition, yPosition);
        }
    }
}
