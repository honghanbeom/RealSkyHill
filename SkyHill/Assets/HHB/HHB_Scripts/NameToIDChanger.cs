using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameToIDChanger : MonoBehaviour
{
    public static NameToIDChanger n2D;

    private void Awake()
    {
        n2D = this;
    }
    public int NameToID(string Name)
    {
        List<Dictionary<string, object>> makingWeapon = CSVReader.Read("MAKINGWEAPON");
        List<Dictionary<string, object>> rootMaterial = CSVReader.Read("ROOTMATERIAL");
        List<Dictionary<string, object>> rootWeapon = CSVReader.Read("ROOTWEAPON");
        List<Dictionary<string, object>> makingMaterial = CSVReader.Read("MAKINGMATERIAL");
        List<Dictionary<string, object>> emergency = CSVReader.Read("EMERGENCY");
        List<Dictionary<string, object>> freshFood = CSVReader.Read("FRESHFOOD");
        List<Dictionary<string, object>> makingFood = CSVReader.Read("MAKINGFOOD");
        List<Dictionary<string, object>> vipRoom = CSVReader.Read("VIPROOM");
        List<Dictionary<string, object>> rootFood = CSVReader.Read("ROOTFOOD");




        int id = FindIDByName(makingWeapon, "WEAPON_NAME", Name);
        if (id == -1)
        {
            id = FindIDByName(makingFood, "FOOD_NAME", Name);
        }
        if (id == -1)
        {
            id = FindIDByName(rootMaterial, "MATERIAL_NAME", Name);
        }
        if (id == -1)
        {
            id = FindIDByName(rootWeapon, "WEAPON_NAME", Name);
        }
        if (id == -1)
        {
            id = FindIDByName(makingMaterial, "MATERIAL_NAME", Name);
        }
        if (id == -1)
        {
            id = FindIDByName(freshFood, "FOOD_NAME", Name);
        }
        if (id == -1)
        {
            id = FindIDByName(emergency, "EMERGENCY_NAME", Name);
        }

        if (id == -1)
        {
            id = FindIDByName(vipRoom, "VIPROOM", Name);
        }
        if (id == -1)
        {
            id = FindIDByName(rootFood, "FOOD_NAME", Name);
        }

        return id;
    }

    private int FindIDByName(List<Dictionary<string, object>> data, string headerName, string name)
    {
        for (int i = 0; i < data.Count; i++)
        {
            if (data[i].TryGetValue(headerName, out object value) && value.ToString() == name)
            {
                if (data[i].TryGetValue("ID", out object idValue) && int.TryParse(idValue.ToString(), out int id))
                {
                    return id;
                }
            }
        }
        return -1;
    }
}
