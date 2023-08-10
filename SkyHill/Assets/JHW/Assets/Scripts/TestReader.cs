using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public static class TestReader 
{

    public static List<int> allData = new List<int>();

    // Start is called before the first frame update
    public static void Initialize()
    {
        List<Dictionary<string, object>> RootFood = CSVReader.Read("ROOTFOOD");
        List<Dictionary<string, object>> Emergency = CSVReader.Read("EMERGENCY");
        List<Dictionary<string, object>> FreshFood = CSVReader.Read("FRESHFOOD");
        List<Dictionary<string, object>> SpoiledFood = CSVReader.Read("SPOILEDFOOD");
        List<Dictionary<string, object>> RootMaterial = CSVReader.Read("ROOTMATERIAL");
        List<Dictionary<string, object>> RootWeapon = CSVReader.Read("MAKINGWEAPON");




        for(int  i = 0; i < RootFood.Count; i++)
        {
            allData.Add((int)RootFood[i]["ID"]);
        }


        for (int i = 0; i < Emergency.Count; i++)
        {
            allData.Add((int)Emergency[i]["ID"]);
        }


        for (int i = 0; i < FreshFood.Count; i++)
        {
            allData.Add((int)FreshFood[i]["ID"]);
        }


        for (int i = 0; i < SpoiledFood.Count; i++)
        {
            allData.Add((int)SpoiledFood[i]["ID"]);
        }


        for (int i = 0; i < RootMaterial.Count; i++)
        {
            allData.Add((int)RootMaterial[i]["ID"]);
        }


        for (int i = 0; i < RootWeapon.Count; i++)
        {
            allData.Add((int)RootWeapon[i]["ID"]);
        }

        allData.Sort();

        //for (int i = 0; i < allData.Count; i++)
        //{
        //    Debug.Log(allData[i]);
        //}




    }
}
