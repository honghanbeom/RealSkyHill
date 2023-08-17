using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpItem : MonoBehaviour, IhPItem
{
    // HEALTH
    public void UseHealthItem(int itemId)
    {
        //EMERGENCY
        List<Dictionary<string, object>> emergency = CSVReader.Read("EMERGENCY");
        float healHP = (float)((int)emergency[itemId - 100]["HP"]);

        if (UserInformation.player.hp + healHP>= 100f)
        {
            UserInformation.player.hp = 100f;
        }
        else if(UserInformation.player.hp + healHP < 100f)
        {
            UserInformation.player.hp += healHP;
        }
        ItemManager.myMediList.Remove(itemId);
        ItemManager.itemManager.ItemRoutine();
    }

    // FOOD
    public void UseFoodItem(int itemId)
    {
        float hungry = default;

        // FRESHFOOD
        if (itemId >= 700 && itemId <= 713)
        {
            List<Dictionary<string, object>> freshFood = CSVReader.Read("FRESHFOOD");
            hungry = (float)((int)freshFood[itemId - 700]["HP"]);
        }
        // FOOTFOOD
        if (itemId >= 900 && itemId <= 917)
        {
            List<Dictionary<string, object>> rootFood = CSVReader.Read("ROOTFOOD");
            hungry = (float)((int)rootFood[itemId - 900]["HP"]);
        }
        // MAKINGFOOD
        if (itemId >= 1000 && itemId <= 1016)
        {
            List<Dictionary<string, object>> makingFood = CSVReader.Read("MAKINGFOOD");
            hungry = (float)((int)makingFood[itemId - 1000]["HP"]);
        }



        // ¹è°íÇÄ Ãß°¡ ·ÎÁ÷
        if (UserInformation.player.hunger + hungry >= 100f)
        {
            UserInformation.player.hunger = 100f;
        }
        else if (UserInformation.player.hunger + hungry < 100f)
        {
            UserInformation.player.hunger += hungry;
        }
        ItemManager.myMediList.Remove(itemId);
        ItemManager.itemManager.ItemRoutine();


    }

    // SPOILED
    public void UseSpoiledFood(int itemId)
    { 
        // Æú¸®½Ì
    
    }
}
