using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    public Sprite[] emergencySprites;
    public Sprite[] vipSprites;
    public Sprite[] makingWeaponSprites;
    public Sprite[] rootWeaponSprites;
    public Sprite[] makingMaterialSprites;
    public Sprite[] rootMaterialSprites;
    public Sprite[] freshFoodSprites;
    public Sprite[] spoiledFoodSprites;
    public Sprite[] rootFoodSprites;
    public Sprite[] makingFoodSprites;


    // Start is called before the first frame update
    void Start()
    {
        int[] dropItemList = new int[emergencySprites.Length + rootWeaponSprites.Length + rootMaterialSprites.Length + freshFoodSprites.Length + spoiledFoodSprites.Length
                                     + rootFoodSprites.Length];

    }

    // Update is called once per frame
    void Update()
    {

    }


    
}
