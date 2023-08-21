using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUIManager : MonoBehaviour
{
    public static WeaponUIManager weaponUI;
    public Text leftWeaponInfoText;
    public Text rightWeaponInfoText;
    public Text leftPlusStatText;
    public Text rightPlusStatText;



    private void Awake()
    {
        weaponUI = this;
    }


    public void WeaponNamePrint()
    {
        string leftWeaponName = default;
        string rightWeaponName = default;
        List<Dictionary<string, object>> rootWeapon = CSVReader.Read("ROOTWEAPON");
        List<Dictionary<string, object>> makingWeapon = CSVReader.Read("MAKINGWEAPON");



        // WeaponItem.myEquipWeapon[0]
        if (UserInformation.player.myEquipWeapon[0] >= 400 && 
            UserInformation.player.myEquipWeapon[0] <= 406)
        {
            leftWeaponName = rootWeapon
                [UserInformation.player.myEquipWeapon[0] - 400]["WEAPON_NAME"].ToString();

        }
        else if (UserInformation.player.myEquipWeapon[0] >= 301 &&
            UserInformation.player.myEquipWeapon[0] <= 324)
        {
            leftWeaponName = makingWeapon
                [UserInformation.player.myEquipWeapon[0] - 301]["WEAPON_NAME"].ToString();
        }
        else
        {
            leftWeaponName = "PUNCH";
        }

        leftWeaponInfoText.text = leftWeaponName;

        // WeaponItem.myEquipWeapon[1]
        if (UserInformation.player.myEquipWeapon[1] >= 400 
            && UserInformation.player.myEquipWeapon[1] <= 406)
        {
            rightWeaponName = rootWeapon
                [UserInformation.player.myEquipWeapon[1] - 400]["WEAPON_NAME"].ToString();
        }
        else if (UserInformation.player.myEquipWeapon[1] >= 301 
            && UserInformation.player.myEquipWeapon[1] <= 324)
        {
            rightWeaponName = makingWeapon
                [UserInformation.player.myEquipWeapon[1] - 301]["WEAPON_NAME"].ToString();
        }
        else
        {
            rightWeaponName = "PUNCH";
        }

        rightWeaponInfoText.text = rightWeaponName;
    }

    public void WeaponStatPrint()
    {

        // WeaponItem.myEquipWeapon[0]
        if (UserInformation.player.myEquipWeapon[0] >= 400 
            && UserInformation.player.myEquipWeapon[0] <= 406)
        {
            float max = UserInformation.player.maxAttackDamage;
            float min = UserInformation.player.minAttackDamage;


            leftPlusStatText.text = "데미지 : " + min.ToString() + " - " + max.ToString();
        }
        else if (UserInformation.player.myEquipWeapon[0] >= 301 
            && UserInformation.player.myEquipWeapon[0] <= 324)
        {
            float max = UserInformation.player.maxAttackDamage;
            float min = UserInformation.player.minAttackDamage;


            leftPlusStatText.text = "데미지 : " + min.ToString() + " - " + max.ToString();
        }
        else
        {
            rightPlusStatText.text = "데미지 : " + UserInformation.player.lastStats[1]
                + " - " + UserInformation.player.lastStats[2];

        }

                
        // WeaponItem.myEquipWeapon[1]
        if (UserInformation.player.myEquipWeapon[1] >= 400 
            && UserInformation.player.myEquipWeapon[1] <= 406)
        {

            float max = UserInformation.player.maxAttackDamage;
            float min = UserInformation.player.minAttackDamage;

            rightPlusStatText.text = "데미지 : " + min.ToString() + " - " + max.ToString();
        }
        else if (UserInformation.player.myEquipWeapon[1] >= 301 
            && UserInformation.player.myEquipWeapon[1] <= 324)
        {
;
            float max = UserInformation.player.maxAttackDamage;
            float min = UserInformation.player.minAttackDamage;

            rightPlusStatText.text = "데미지 : " + min.ToString() + " - " + max.ToString();
        }
        else
        {
            rightPlusStatText.text = "데미지 : " + UserInformation.player.lastStats[1]
                + " - " + UserInformation.player.lastStats[2];
        }
    }

    public void GreenOrRed()
    {
        //if (UserInformation.player.myEquipWeapon[0])
        //{ 
        
        //}
        //if (UserInformation.player.myEquipWeapon[1])
        //{ 
        
        //}


    }

}
