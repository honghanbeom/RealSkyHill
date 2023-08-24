using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class WeaponImage : MonoBehaviour
{
    public Image leftWeaponImages;
    //public Image noneImages;
    public Image rightWeaponImages;
    public Image leftSatisfyImage;
    public Image rightSatisfyImage;
    public void ControlLeftImage(List<int> myWeaponList)
    {
        int leftWeapon = myWeaponList[0];
        ItemList.itemList.ImageMatch(leftWeapon, leftWeaponImages);

        ClassifyColor(myWeaponList[0], leftSatisfyImage);

        // 이거 색 고민 해봐야할듯ㅎㅎ;
        Color leftImageColor = leftWeaponImages.color;
        leftImageColor = new Color(1f, 1f, 1f, 1f);
        leftWeaponImages.color = leftImageColor;

    }
    public void ControlRightImage(List<int> myWeaponList)
    {
        int rightWeapon = myWeaponList[1];
        ItemList.itemList.ImageMatch(rightWeapon, rightWeaponImages);

        ClassifyColor(myWeaponList[1], rightSatisfyImage);

        // 이거 색 고민 해봐야할듯ㅎㅎ;
        Color rightImageColor = rightWeaponImages.color;
        rightImageColor = new Color(1f, 1f, 1f, 1f);
        rightWeaponImages.color = rightImageColor;
    }

    public void ClassifyColor(int id, Image image)
    {
        int reqDEX = default;
        int reqSTR = default;
        int reqSPD = default; 
        List<Dictionary<string, object>> rootWeapon = CSVReader.Read("ROOTWEAPON");
        List<Dictionary<string, object>> makingWeapon = CSVReader.Read("MAKINGWEAPON");
        // (400 ~ 406) ROOTWEAPON
        if (id >= 400 && id <= 406)
        {
            reqDEX = (int)(rootWeapon[id - 400]["REQ_DEX"]);
            reqSTR = (int)(rootWeapon[id - 400]["REQ_STR"]);
            reqSPD = (int)(rootWeapon[id - 400]["REQ_SPD"]);

            // 모든 조건을 충족할 경우
            if (UserInformation.player.dex >= reqDEX &&
                UserInformation.player.str >= reqSTR &&
                UserInformation.player.spd >= reqSPD)
            {
                image.color = Color.green;
            }
            else
            { 
                image.color = Color.red;
            }
        }
        // (301 ~ 324) MAKINGWEAPON
        if (id >= 301 && id <= 324)
        {
            reqDEX = (int)(makingWeapon[id - 301]["REQ_DEX"]);
            reqSTR = (int)(makingWeapon[id - 301]["REQ_STR"]);
            reqSPD = (int)(makingWeapon[id - 301]["REQ_SPD"]);

            // 모든 조건을 충족할 경우
            if (UserInformation.player.dex >= reqDEX &&
                UserInformation.player.str >= reqSTR &&
                UserInformation.player.spd >= reqSPD)
            {
                image.color = Color.green;
            }
            else
            {
                image.color = Color.red;
            }
        }
    }
}
