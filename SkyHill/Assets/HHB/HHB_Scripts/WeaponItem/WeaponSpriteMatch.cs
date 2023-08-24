using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpriteMatch : MonoBehaviour
{
    public Sprite[] rootWeaponSprite;
    public Sprite[] makingWeaponSprite;

    public Sprite WeaponMatch(int id)
    {
        if (id >= 400 && id<= 406)
        {
            int index = id - 400;
            if (index >= 0 && index < rootWeaponSprite.Length)
            {
                //Debug.Log(rootWeaponSprite[index].name);
                return rootWeaponSprite[index];
            }
        }
        else if (id >= 301 && id <= 324)
        {
            int index = id - 301;
            if (index >= 0 && index < makingWeaponSprite.Length)
            {
                //Debug.Log(rootWeaponSprite[index].name);
                return makingWeaponSprite[index];
            }
        }

        return null;
    }
}
