using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponImage : MonoBehaviour
{
    public Image leftWeaponImages;
    public Image rightWeaponImages;

    public void ControlLeftImage(List<int> myWeaponList)
    {
        int leftWeapon = myWeaponList[0];
        ItemList.itemList.ImageMatch(leftWeapon, leftWeaponImages);

        // ÀÌ°Å »ö °í¹Î ÇØºÁ¾ßÇÒµí¤¾¤¾;
        Color leftImageColor = leftWeaponImages.color;
        leftImageColor = new Color(1f, 1f, 1f, 1f);
        leftWeaponImages.color = leftImageColor;

    }
    public void ControlRightImage(List<int> myWeaponList)
    {
        int rightWeapon = myWeaponList[1];
        ItemList.itemList.ImageMatch(rightWeapon, rightWeaponImages);

        // ÀÌ°Å »ö °í¹Î ÇØºÁ¾ßÇÒµí¤¾¤¾;
        Color rightImageColor = rightWeaponImages.color;
        rightImageColor= new Color(1f,1f,1f,1f);
        rightWeaponImages.color = rightImageColor;  
    }
}
