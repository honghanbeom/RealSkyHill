using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUIManager : MonoBehaviour
{
    public static WeaponUIManager weaponUI;
    public Text leftWeaponInfoText;
    public Text rightWeaponInfoText;
    public Text leftPlusStatText;
    public Text rightPlusStatText;

    public List<float> leftWeaponStat = new List<float>();

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


        //Debug.Log(UserInformation.player.myEquipWeapon[0]);
        //Debug.Log(UserInformation.player.myEquipWeapon[1]);

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
        else if (UserInformation.player.myEquipWeapon[0] == -1)
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
        else if (UserInformation.player.myEquipWeapon[1] == -1)
        {
            rightWeaponName = "PUNCH";
        }

        rightWeaponInfoText.text = rightWeaponName;
    }

    public void WeaponStatPrint()
    {
        #region LEGACY
        //float rightHighDamage = default;
        //float rightLowDamage = default;

        //float leftHighDamage = default;
        //float leftLowDamage = default;

        //List<Dictionary<string, object>> rootWeapon = CSVReader.Read("ROOTWEAPON");
        //List<Dictionary<string, object>> makingWeapon = CSVReader.Read("MAKINGWEAPON");
        //// WeaponItem.myEquipWeapon[0]
        //// 위의 경우 저장된 데이터를 불러오면 됨

        //if (UserInformation.player.myEquipWeapon[0] >= 400
        //        && UserInformation.player.myEquipWeapon[0] <= 406)
        //{
        //    leftLowDamage = (int)rootWeapon
        //        [UserInformation.player.myEquipWeapon[0] - 400]["LOW_DAMAGE"];
        //    leftLowDamage += DamageApply();
        //    leftLowDamage += UserInformation.player.minAttackDamage;

        //    leftHighDamage = (int)rootWeapon
        //        [UserInformation.player.myEquipWeapon[0] - 400]["MAX_DAMAGE"];
        //    leftHighDamage += DamageApply();
        //    leftHighDamage += UserInformation.player.maxAttackDamage;
        //}
        //else if (UserInformation.player.myEquipWeapon[0] >= 301
        //    && UserInformation.player.myEquipWeapon[0] <= 324)
        //{
        //    leftLowDamage = (int)makingWeapon
        //        [UserInformation.player.myEquipWeapon[0] - 301]["LOW_DAMAGE"];
        //    leftLowDamage += DamageApply();
        //    leftLowDamage += UserInformation.player.minAttackDamage;


        //    leftHighDamage = (int)makingWeapon
        //        [UserInformation.player.myEquipWeapon[0] - 301]["MAX_DAMAGE"];
        //    leftHighDamage += DamageApply();
        //    leftHighDamage += UserInformation.player.maxAttackDamage;

        //}
        //else
        //{
        //    leftHighDamage = 2f;
        //    leftLowDamage = 1f;
        //}
        #endregion
        #region LEGACY
        //// WeaponItem.myEquipWeapon[1]
        //// [1] 번에 들어 있는 아이템의 경우
        //if (UserInformation.player.myEquipWeapon[1] >= 400
        //    && UserInformation.player.myEquipWeapon[1] <= 406)
        //{
        //    rightLowDamage = (int)rootWeapon
        //        [UserInformation.player.myEquipWeapon[1] - 400]["LOW_DAMAGE"];
        //    rightLowDamage += DamageApply();
        //    rightLowDamage += UserInformation.player.minAttackDamage;

        //    rightHighDamage = (int)rootWeapon
        //        [UserInformation.player.myEquipWeapon[1] - 400]["MAX_DAMAGE"];
        //    rightHighDamage += DamageApply();
        //    rightHighDamage += UserInformation.player.maxAttackDamage;

        //}
        //else if (UserInformation.player.myEquipWeapon[1] >= 301
        //    && UserInformation.player.myEquipWeapon[1] <= 324)
        //{
        //    rightLowDamage = (int)makingWeapon
        //        [UserInformation.player.myEquipWeapon[1] - 301]["LOW_DAMAGE"];
        //    rightLowDamage += DamageApply();
        //    rightLowDamage += UserInformation.player.minAttackDamage;


        //    rightHighDamage = (int)makingWeapon
        //        [UserInformation.player.myEquipWeapon[1] - 301]["MAX_DAMAGE"];
        //    rightHighDamage += DamageApply();
        //    rightHighDamage += UserInformation.player.maxAttackDamage;

        //}
        //else
        //{
        //    rightHighDamage = 2f;
        //    rightLowDamage = 1f;
        //}

        //rightPlusStatText.text = "데미지 : " + 
        //    rightLowDamage.ToString() + " - " + rightHighDamage.ToString();
        #endregion

        if (UserInformation.player.myEquipWeapon[0] != -1)
        {
            float leftLowDamage = default;
            float leftHighDamage = default;

            List<Dictionary<string, object>> rootWeapon = CSVReader.Read("ROOTWEAPON");
            List<Dictionary<string, object>> makingWeapon = CSVReader.Read("MAKINGWEAPON");

            if (UserInformation.player.myEquipWeapon[0] >= 400
                && UserInformation.player.myEquipWeapon[0] <= 406)
            {
                float weaponLowDamage =
                     (int)rootWeapon[UserInformation.player.myEquipWeapon[0] - 400]["LOW_DAMAGE"];
                float weaponHighDamage =
                     (int)rootWeapon[UserInformation.player.myEquipWeapon[0] - 400]["MAX_DAMAGE"];


                Classify2(UserInformation.player.myEquipWeapon[0],
                    ref weaponHighDamage, ref weaponLowDamage);

                weaponLowDamage += (DamageApply() + 1f);
                weaponHighDamage += (DamageApply() + 2f);

                leftLowDamage = weaponLowDamage;
                leftHighDamage = weaponHighDamage;

                leftPlusStatText.text = "데미지 : " +
                leftLowDamage.ToString() + " - " + leftHighDamage.ToString();

                leftWeaponStat.Clear();
                leftWeaponStat.Add(leftLowDamage);
                leftWeaponStat.Add(leftHighDamage);
            }
            else if (UserInformation.player.myEquipWeapon[0] >= 301
                && UserInformation.player.myEquipWeapon[0] <= 324)
            {
                float weaponLowDamage =
                     (int)makingWeapon[UserInformation.player.myEquipWeapon[0] - 301]["LOW_DAMAGE"];
                float weaponHighDamage =
                     (int)makingWeapon[UserInformation.player.myEquipWeapon[0] - 301]["MAX_DAMAGE"];


                Classify2(UserInformation.player.myEquipWeapon[0],
                    ref weaponHighDamage, ref weaponLowDamage);

                weaponLowDamage += (DamageApply() + 1f);
                weaponHighDamage += (DamageApply() + 2f);

                leftLowDamage = weaponLowDamage;
                leftHighDamage = weaponHighDamage;

                leftPlusStatText.text = "데미지 : " +
                leftLowDamage.ToString() + " - " + leftHighDamage.ToString();

                leftWeaponStat.Clear();
                leftWeaponStat.Add(leftLowDamage);
                leftWeaponStat.Add(leftHighDamage);
            }
        }

        if (UserInformation.player.myEquipWeapon[1] != -1)
        {
            float rightLowDamage = default;
            float rightHighDamage = default;

            List<Dictionary<string, object>> rootWeapon = CSVReader.Read("ROOTWEAPON");
            List<Dictionary<string, object>> makingWeapon = CSVReader.Read("MAKINGWEAPON");

            if (UserInformation.player.myEquipWeapon[1] >= 400
                && UserInformation.player.myEquipWeapon[1] <= 406)
            {
                float weaponLowDamage =
                     (int)rootWeapon[UserInformation.player.myEquipWeapon[1] - 400]["LOW_DAMAGE"];
                float weaponHighDamage =
                     (int)rootWeapon[UserInformation.player.myEquipWeapon[1] - 400]["MAX_DAMAGE"];


                Classify(UserInformation.player.myEquipWeapon[1],
                    ref weaponHighDamage, ref weaponLowDamage);

                weaponLowDamage += (DamageApply() + 1f);
                weaponHighDamage += (DamageApply() + 2f);

                rightLowDamage = weaponLowDamage;
                rightHighDamage = weaponHighDamage;

                rightPlusStatText.text = "데미지 : " +
                rightLowDamage.ToString() + " - " + rightHighDamage.ToString();


            }
            else if (UserInformation.player.myEquipWeapon[1] >= 301
                && UserInformation.player.myEquipWeapon[1] <= 324)
            {
                float weaponLowDamage =
                     (int)makingWeapon[UserInformation.player.myEquipWeapon[1] - 301]["LOW_DAMAGE"];
                float weaponHighDamage =
                     (int)makingWeapon[UserInformation.player.myEquipWeapon[1] - 301]["MAX_DAMAGE"];


                Classify(UserInformation.player.myEquipWeapon[1],
                    ref weaponHighDamage, ref weaponLowDamage);

                weaponLowDamage += (DamageApply() + 1f);
                weaponHighDamage += (DamageApply() + 2f);

                rightLowDamage = weaponLowDamage;
                rightHighDamage = weaponHighDamage;

                rightPlusStatText.text = "데미지 : " +
                rightLowDamage.ToString() + " - " + rightHighDamage.ToString();


            }
        }
    }

    public int DamageApply()
    {
        int applyDEX = UserInformation.player.dex - 5;
        int applySTR = UserInformation.player.str - 5;
        int applySPD = UserInformation.player.spd - 5;

        int applyDamage = applyDEX + applySTR + applySPD;
        return applyDamage;
    }

    public void Classify(int id, ref float rightHigh, ref float rightLow)
    {
        int reqDEX;
        int reqSTR;
        int reqSPD;
        if (UserInformation.player.myEquipWeapon[1] >= 400
           && UserInformation.player.myEquipWeapon[1] <= 406)
        {

            List<Dictionary<string, object>> rootWeapon = CSVReader.Read("ROOTWEAPON");
            reqDEX = (int)(rootWeapon[id - 400]["REQ_DEX"]);
            reqSTR = (int)(rootWeapon[id - 400]["REQ_STR"]);
            reqSPD = (int)(rootWeapon[id - 400]["REQ_SPD"]);
            // 모든 조건을 충족할 경우
            if (UserInformation.player.dex >= reqDEX &&
                UserInformation.player.str >= reqSTR &&
                UserInformation.player.spd >= reqSPD)
            {
                return;
            }
            else
            {
                rightHigh = rightHigh * 0.66f;
                rightLow = rightLow * 0.66f;
            }
        }
        else if (UserInformation.player.myEquipWeapon[1] >= 301
            && UserInformation.player.myEquipWeapon[1] <= 324)
        {
            List<Dictionary<string, object>> makingWeapon = CSVReader.Read("MAKINGWEAPON");
            reqDEX = (int)(makingWeapon[id - 301]["REQ_DEX"]);
            reqSTR = (int)(makingWeapon[id - 301]["REQ_STR"]);
            reqSPD = (int)(makingWeapon[id - 301]["REQ_SPD"]);
            // 모든 조건을 충족할 경우
            if (UserInformation.player.dex >= reqDEX &&
                UserInformation.player.str >= reqSTR &&
                UserInformation.player.spd >= reqSPD)
            {
                return;
            }
            else
            {
                rightHigh = rightHigh * 0.66f;
                rightLow = rightLow * 0.66f;
            }
        }
    }

    public void Classify2(int id, ref float leftHigh,ref float leftLow)
    {
        int reqDEX;
        int reqSTR;
        int reqSPD;
        if (UserInformation.player.myEquipWeapon[0] >= 400
           && UserInformation.player.myEquipWeapon[0] <= 406)
        {

            List<Dictionary<string, object>> rootWeapon = CSVReader.Read("ROOTWEAPON");
            reqDEX = (int)(rootWeapon[id - 400]["REQ_DEX"]);
            reqSTR = (int)(rootWeapon[id - 400]["REQ_STR"]);
            reqSPD = (int)(rootWeapon[id - 400]["REQ_SPD"]);
            // 모든 조건을 충족할 경우
            if (UserInformation.player.dex >= reqDEX &&
                UserInformation.player.str >= reqSTR &&
                UserInformation.player.spd >= reqSPD)
            {
                return;
            }
            else
            {
                leftHigh = leftHigh * 0.66f;
                leftLow = leftLow * 0.66f;
            }
        }
        else if (UserInformation.player.myEquipWeapon[0] >= 301
            && UserInformation.player.myEquipWeapon[0] <= 324)
        {
            List<Dictionary<string, object>> makingWeapon = CSVReader.Read("MAKINGWEAPON");
            reqDEX = (int)(makingWeapon[id - 301]["REQ_DEX"]);
            reqSTR = (int)(makingWeapon[id - 301]["REQ_STR"]);
            reqSPD = (int)(makingWeapon[id - 301]["REQ_SPD"]);
            // 모든 조건을 충족할 경우
            if (UserInformation.player.dex >= reqDEX &&
                UserInformation.player.str >= reqSTR &&
                UserInformation.player.spd >= reqSPD)
            {
                return;
            }
            else
            {
                leftHigh = leftHigh * 0.66f;
                leftLow = leftLow * 0.66f;
            }
        }
    }
}
