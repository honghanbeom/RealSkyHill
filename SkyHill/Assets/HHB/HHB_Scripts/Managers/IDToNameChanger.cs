using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDToNameChanager : MonoBehaviour
{
    public static IDToNameChanager I2D;

    private void Awake()
    {
        I2D = this;
    }

    public string IDToName(string dataType, int id)
    {
        string name = FindNameByID(dataType, id);
        return name;
    }

    private string FindNameByID(string dataType, int id)
    {
        List<Dictionary<string, object>> data = CSVReader.Read(dataType);
        foreach (var item in data)
        {
            if (item.TryGetValue("ID", out object idValue) && int.TryParse(idValue.ToString(), out int itemId) && itemId == id)
            {
                if (item.TryGetValue("EMERGENCY_NAME", out object nameValue))
                {
                    return nameValue.ToString();
                }
                else if (item.TryGetValue("FOOD_NAME", out nameValue))
                {
                    return nameValue.ToString();
                }
                else if (item.TryGetValue("MATERIAL_NAME", out nameValue))
                {
                    return nameValue.ToString();
                }
                else if (item.TryGetValue("WEAPON_NAME", out nameValue))
                {
                    return nameValue.ToString();
                }
                else if (item.TryGetValue("UPGRADE_NAME", out nameValue))
                {
                    return nameValue.ToString();
                }
            }
        }
        return null;
    }
}
