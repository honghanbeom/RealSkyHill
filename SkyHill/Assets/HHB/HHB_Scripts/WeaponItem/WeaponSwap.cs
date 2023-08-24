using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponSwap : MonoBehaviour, IPointerClickHandler
{
    private GameObject weaponName;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("Å¬¸¯µÊ");

            if (UserInformation.player.myEquipWeapon[0] != -1)
            {

                SwapWeapons();

                //WeaponItem.weaponItem.ApplyWeapon(UserInformation.player.myEquipWeapon[0]);
                //WeaponItem.weaponItem.ApplyWeapon(UserInformation.player.myEquipWeapon[0]);
                WeaponImage weaponImage = FindObjectOfType<WeaponImage>();
                weaponImage.ControlLeftImage(UserInformation.player.myEquipWeapon);
                weaponImage.ControlRightImage(UserInformation.player.myEquipWeapon);
                WeaponUIManager.weaponUI.WeaponStatPrint();
                WeaponUIManager.weaponUI.WeaponNamePrint();

                WeaponSpriteMatch weaponSpriteMatch = FindObjectOfType<WeaponSpriteMatch>();

                weaponName = GameObject.Find("Weapon");
                weaponName.GetComponent<SpriteRenderer>().sprite 
                    = weaponSpriteMatch.WeaponMatch(UserInformation.player.myEquipWeapon[0]);



                UserInformation.player.minAttackDamage = 
                    WeaponUIManager.weaponUI.leftWeaponStat[0];
                UserInformation.player.maxAttackDamage =
                    WeaponUIManager.weaponUI.leftWeaponStat[1];
            }
        }
    }

    public void SwapWeapons()
    {
        int temp = UserInformation.player.myEquipWeapon[0];
        UserInformation.player.myEquipWeapon[0] = UserInformation.player.myEquipWeapon[1];
        UserInformation.player.myEquipWeapon[1] = temp;
    }
}
