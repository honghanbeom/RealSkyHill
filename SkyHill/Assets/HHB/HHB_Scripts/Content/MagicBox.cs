using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class MagicBox : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    public int itemId { get; set; }
    private HpItem hpItem;
    private WeaponItem weaponItem;
    private WeaponImage weaponImage;
    private WeaponUIManager weaponUI;

    public void OnPointerClick(PointerEventData eventData)
    {
        hpItem = FindObjectOfType<HpItem>();
        weaponItem = FindObjectOfType<WeaponItem>();
        weaponUI = FindObjectOfType<WeaponUIManager>();

        // ���콺 ��Ŭ��
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.LogFormat("{0}", itemId);

            
            if (ItemManager.myMediList.Contains(itemId))
            {
                // ȸ��������
                // (100 ~ 104) EMERGENCY , (0 ~ 3) ROOTEMERGENCY
                if ((itemId >= 100 && itemId <= 104) || (itemId >= 0 && itemId <= 3))
                {
                    Debug.LogFormat("���� ü�� : {0}",UserInformation.player.hp);
                    hpItem.UseHealthItem(itemId);
                    Debug.LogFormat("���� ü�� : {0}", UserInformation.player.hp);
                }
                // ���ľ�����
                // (700 ~ 713) FRESHFOOD, (900~917) ROOTFOOD, (1000~1016) MAKINGFOOD
                else
                {
                    Debug.LogFormat("���� ����� ���� : {0}", UserInformation.player.hunger);
                    hpItem.UseFoodItem(itemId);
                    Debug.LogFormat("���� ����� ���� : {0}", UserInformation.player.hunger);
                }
            }
            // ���������
            if (ItemManager.myWeaponList.Contains(itemId))
            {
                Debug.Log("---------------------[���� ������]-----------------------------------");
                Debug.LogFormat("���� �ִ� ���ݷ� : {0}", UserInformation.player.maxAttackDamage);
                Debug.LogFormat("���� �ּ� ���ݷ� : {0}", UserInformation.player.minAttackDamage);
                Debug.LogFormat("���� DEX : {0}", UserInformation.player.dex);
                Debug.LogFormat("���� STR : {0}", UserInformation.player.str);
                Debug.LogFormat("���� SPD : {0}", UserInformation.player.spd);
                Debug.Log("---------------------------------------------------------------------");
                weaponItem.ApplyWeapon(itemId);
                Debug.Log("---------------------[���� ������]-----------------------------------");
                Debug.LogFormat("���� �ִ� ���ݷ� : {0}", UserInformation.player.maxAttackDamage);
                Debug.LogFormat("���� �ּ� ���ݷ� : {0}", UserInformation.player.minAttackDamage);
                Debug.LogFormat("���� DEX : {0}", UserInformation.player.dex);
                Debug.LogFormat("���� STR : {0}", UserInformation.player.str);
                Debug.LogFormat("���� SPD : {0}", UserInformation.player.spd);
                Debug.LogFormat("[���� ������ ����]   [0�� : {0}]  [1�� : {1}]",
                    WeaponItem.myEquipWeapon[0], WeaponItem.myEquipWeapon[1]);
                Debug.Log("---------------------------------------------------------------------");


                weaponImage = FindObjectOfType<WeaponImage>();
                weaponImage.ControlLeftImage(WeaponItem.myEquipWeapon);
                weaponImage.ControlRightImage(WeaponItem.myEquipWeapon);
                weaponUI.WeaponStatPrint();
                weaponUI.WeaponNamePrint();
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData) 
    {  
        // ���⼭ ������ ������ ����ִ°�
        // magicbox ���� �����ؼ� ���°� ������ҵ�..��
        // if ��������
    
    }
}
