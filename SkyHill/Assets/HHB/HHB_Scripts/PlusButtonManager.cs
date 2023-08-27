using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusButtonManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (UserInformation.player.skillPoint == 0)
        {
            gameObject.transform.localScale = Vector3.one * 0.001f;
        }
        else 
        {
            gameObject.transform.localScale = Vector3.one * 1f;
        }
    }

    public void UpdateLevelUP()
    {
        // 레벨업 했는지 체크하고
        StatUI.statUI.LevelUp();
        // 경험치 바 채우고
        StatUI.statUI.EXPFillAmount();
        // 정보 저장하고
        UserInformation.player.SaveLastItemData(UserInformation.player.myEquipWeapon[0]);
        // 불러와서
        UserInformation.player.LoadLastItemData(UserInformation.player.myEquipWeapon[0]);
        // 스킬 포인트 UI 조절
        StatUI.statUI.SkillPointUI();
        // 레벨업 UI 조절
        StatUI.statUI.LevelUpUI();
        // 바뀐 스텟이 있으면 아이템 다시 끼고
        WeaponItem.weaponItem.ApplyWeapon(UserInformation.player.myEquipWeapon[0]);
        //WeaponItem.weaponItem.ApplyWeapon(UserInformation.player.myEquipWeapon[1]);
        WeaponImage weaponImage = FindObjectOfType<WeaponImage>();
        // 무기 이미지 관리하고
        weaponImage.ControlLeftImage(UserInformation.player.myEquipWeapon);
        //weaponImage.ControlRightImage(UserInformation.player.myEquipWeapon);
        // 무기 UI 관리하고
        WeaponUIManager.weaponUI.WeaponStatPrint();
        WeaponUIManager.weaponUI.WeaponNamePrint();
    }


    public void OnclickSTR()
    {
        if (UserInformation.player.skillPoint != 0)
        {
            UserInformation.player.skillPoint -= 1;
            UserInformation.player.str += 1;
            UpdateLevelUP();
        }
    }

    public void OnclickSPD()
    {
        if (UserInformation.player.skillPoint != 0)
        {
            UserInformation.player.skillPoint -= 1;
            UserInformation.player.spd += 1;
            UpdateLevelUP();
        }
    }

    public void OnclickDEX()
    {
        if (UserInformation.player.skillPoint != 0)
        {
            UserInformation.player.skillPoint -= 1;
            UserInformation.player.dex += 1;
            UpdateLevelUP();
        }
    }

    public void OnclickACC()
    {
        if (UserInformation.player.skillPoint != 0)
        {
            UserInformation.player.skillPoint -= 1;
            UserInformation.player.hit += 1;
            UpdateLevelUP();
        }
    }
}
