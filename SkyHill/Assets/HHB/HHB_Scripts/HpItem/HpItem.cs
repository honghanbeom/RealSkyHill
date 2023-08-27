using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpItem : MonoBehaviour, IHPItem
{
    // HEALTH
    public void UseHealthItem(int itemId)
    {
        //EMERGENCY
        if (itemId >= 100 && itemId <= 104)
        {
            List<Dictionary<string, object>> emergency = CSVReader.Read("EMERGENCY");
            float healHP = (float)((int)emergency[itemId - 100]["HP"]);

            if (UserInformation.player.hp + healHP >= 100f)
            {
                UserInformation.player.hp = 100f;
            }
            else if (UserInformation.player.hp + healHP < 100f)
            {
                UserInformation.player.hp += healHP;
            }
            ItemManager.myMediList.Remove(itemId);
            ItemManager.itemManager.ItemRoutine();
        }
        //ROOTEMERGENCY
        if (itemId >= 0 && itemId <= 3)
        {
            List<Dictionary<string, object>> rootEmergency = CSVReader.Read("ROOTEMERGENCY");
            float healHP = (float)((int)rootEmergency[itemId - 100]["HP"]);

            if (UserInformation.player.hp + healHP >= 100f)
            {
                UserInformation.player.hp = 100f;
            }
            else if (UserInformation.player.hp + healHP < 100f)
            {
                UserInformation.player.hp += healHP;
            }
            ItemManager.myMediList.Remove(itemId);
            ItemManager.itemManager.ItemRoutine();
        }
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
        // 배고픔 추가 로직
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
        float hungry = default;
        float damamge = default;
        int poisionProb = 50;
        int randomProb = Random.Range(0, 100);
        // SPOILEDFOOD
        if (itemId >= 800 && itemId <= 808)
        {
            List<Dictionary<string, object>> spoiledFood = CSVReader.Read("SPOILEDFOOD");
            hungry = (float)((int)spoiledFood[itemId - 800]["HP"]);
            damamge = (float)((int)spoiledFood[itemId - 800]["DAMAGE"]);
        }

        // 배고픔 추가 로직 && 중독로직 && 데미지로직

        UserInformation.player.hp -= damamge;
        UserInformation.player.hunger += hungry;

        if (poisionProb > randomProb)
        {
            UserInformation.player.poision = true;
            Poision poision = FindObjectOfType<Poision>();
            poision.PoisionImageControl();
        }

        ItemManager.myMediList.Remove(itemId);
        ItemManager.itemManager.ItemRoutine();
    }

    public void UseAntidote(int itemId)
    {
        if (UserInformation.player.poision == true)
        {
            UserInformation.player.poision = false;
            Poision poision = FindObjectOfType<Poision>();
            poision.PoisionImageControl();
        }

    }
}
