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
        // ������ �ߴ��� üũ�ϰ�
        StatUI.statUI.LevelUp();
        // ����ġ �� ä���
        StatUI.statUI.EXPFillAmount();
        // ���� �����ϰ�
        UserInformation.player.SaveLastItemData(UserInformation.player.myEquipWeapon[0]);
        // �ҷ��ͼ�
        UserInformation.player.LoadLastItemData(UserInformation.player.myEquipWeapon[0]);
        // ��ų ����Ʈ UI ����
        StatUI.statUI.SkillPointUI();
        // ������ UI ����
        StatUI.statUI.LevelUpUI();
        // �ٲ� ������ ������ ������ �ٽ� ����
        WeaponItem.weaponItem.ApplyWeapon(UserInformation.player.myEquipWeapon[0]);
        //WeaponItem.weaponItem.ApplyWeapon(UserInformation.player.myEquipWeapon[1]);
        WeaponImage weaponImage = FindObjectOfType<WeaponImage>();
        // ���� �̹��� �����ϰ�
        weaponImage.ControlLeftImage(UserInformation.player.myEquipWeapon);
        //weaponImage.ControlRightImage(UserInformation.player.myEquipWeapon);
        // ���� UI �����ϰ�
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
