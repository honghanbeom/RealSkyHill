using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemList : MonoBehaviour
{
    public static ItemList itemList;
    private SpriteRenderer spriteRenderer;
    public Sprite[] emergencySprites;
    public Sprite[] makingWeaponSprites;
    public Sprite[] rootWeaponSprites;
    public Sprite[] makingMaterialSprites;
    public Sprite[] rootMaterialSprites;
    public Sprite[] freshFoodSprites;
    public Sprite[] spoiledFoodSprites;
    public Sprite[] rootFoodSprites;
    public Sprite[] makingFoodSprites;
    public Sprite[] vipSprites;
    public Sprite[] rootEmergencySprites;

    private void Awake()
    {
        itemList = this;
    }
    public void ImageMatch(int id, Image image)
    {
        List<Dictionary<string, object>> rootFood = CSVReader.Read("ROOTFOOD");
        List<Dictionary<string, object>> emergency = CSVReader.Read("EMERGENCY");
        List<Dictionary<string, object>> freshFood = CSVReader.Read("FRESHFOOD");
        List<Dictionary<string, object>> spoiledFood = CSVReader.Read("SPOILEDFOOD");
        List<Dictionary<string, object>> rootMaterial = CSVReader.Read("ROOTMATERIAL");
        List<Dictionary<string, object>> rootWeapon = CSVReader.Read("ROOTWEAPON");
        List<Dictionary<string, object>> makingFood = CSVReader.Read("MAKINGFOOD");
        List<Dictionary<string, object>> makingMaterial = CSVReader.Read("MAKINGMATERIAL");
        List<Dictionary<string, object>> makingWeapon = CSVReader.Read("MAKINGWEAPON");
        List<Dictionary<string, object>> rootEmergency = CSVReader.Read("ROOTEMERGENCY");

        // (0 ~ 3) ROOTEMERGENCY
        if (id >= 0 && id <= 3)
        {
            int index = id;
            image.sprite = rootEmergencySprites[index];
        }
        // (100 ~ 104) EMERGENCY 
        if (id >= 100 && id <= 104)
        {
            int index = id - 100;
            image.sprite = emergencySprites[index];

        }
        // (301 ~ 324) MAKINGWEAPON 
        if (id >= 301 && id <= 324)
        {
            int index = id - 301;
            image.sprite = makingWeaponSprites[index];
        }
        // (400 ~ 406) ROOTWEAPON
        else if (id >= 400 && id <= 406)
        {
            int index = id - 400;
            image.sprite = rootWeaponSprites[index];
        }
        // (501 ~ 512) MAKINGMATERIAL
        else if (id >= 501 && id <= 512)
        {
            int index = id - 501;
            image.sprite = makingMaterialSprites[index];
        }
        // (600 ~ 605) ROOTMATERIAL 
        else if (id >= 600 && id <= 605)
        {
            int index = id - 600;
            image.sprite = rootMaterialSprites[index];

        }
        // (700 ~ 713) FRESHFOOD
        else if (id >= 700 && id <= 713)
        {
            int index = id - 700;
            image.sprite = freshFoodSprites[index];
        }
        // (800 ~ 808) SPOILEDFOOD
        else if (id >= 800 && id <= 808)
        {
            int index = id - 800;
            image.sprite = spoiledFoodSprites[index];
        }
        // (900 ~ 917) ROOTFOOD
        else if (id >= 900 && id <= 917)
        {
            int index = id - 900;
            image.sprite = rootFoodSprites[index];

        }
        // (1000 ~ 1016) MAKINGFOOD
        else if (id >= 1000 && id <= 1016)
        {
            int index = id - 1000;
            image.sprite = makingFoodSprites[index];

        }
        // null
        else if (id == -1)
        {
            Color nullColor = image.color;
            nullColor.a = 0f;
            image.color = nullColor;
            image.sprite = null;
        }

    }

  

    
}
