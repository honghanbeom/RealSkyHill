using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public static class DropItem
{

    public static List<int> dropItemData = new List<int>();

    // Start is called before the first frame update
    public static void Initialize()
    {
        List<Dictionary<string, object>> rootFood = CSVReader.Read("ROOTFOOD");
        List<Dictionary<string, object>> emergency = CSVReader.Read("EMERGENCY");
        List<Dictionary<string, object>> freshFood = CSVReader.Read("FRESHFOOD");
        List<Dictionary<string, object>> spoiledFood = CSVReader.Read("SPOILEDFOOD");
        List<Dictionary<string, object>> rootMaterial = CSVReader.Read("ROOTMATERIAL");
        List<Dictionary<string, object>> rootWeapon = CSVReader.Read("ROOTWEAPON");





        for(int  i = 0; i < rootFood.Count; i++)
        {
            dropItemData.Add((int)rootFood[i]["ID"]);
        }


        for (int i = 0; i < emergency.Count; i++)
        {
            dropItemData.Add((int)emergency[i]["ID"]);
        }


        for (int i = 0; i < freshFood.Count; i++)
        {
            dropItemData.Add((int)freshFood[i]["ID"]);
        }


        for (int i = 0; i < spoiledFood.Count; i++)
        {
            dropItemData.Add((int)spoiledFood[i]["ID"]);
        }


        for (int i = 0; i < rootMaterial.Count; i++)
        {
            dropItemData.Add((int)rootMaterial[i]["ID"]);
        }


        for (int i = 0; i < rootWeapon.Count; i++)
        {
            dropItemData.Add((int)rootWeapon[i]["ID"]);
        }

        dropItemData.Sort();

        //for (int i = 0; i < allData.Count; i++)
        //{
        //    Debug.Log(allData[i]);
        //}
    }
}
