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

        // 마우스 우클릭
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.LogFormat("{0}", itemId);

            
            if (ItemManager.myMediList.Contains(itemId))
            {
                // 회복아이템
                // (100 ~ 104) EMERGENCY , (0 ~ 3) ROOTEMERGENCY
                if ((itemId >= 100 && itemId <= 104) || (itemId >= 0 && itemId <= 3))
                {
                    Debug.LogFormat("유저 체력 : {0}",UserInformation.player.hp);
                    hpItem.UseHealthItem(itemId);
                    Debug.LogFormat("유저 체력 : {0}", UserInformation.player.hp);
                }
                // 음식아이템
                // (700 ~ 713) FRESHFOOD, (900~917) ROOTFOOD, (1000~1016) MAKINGFOOD
                else
                {
                    Debug.LogFormat("유저 배고픔 지수 : {0}", UserInformation.player.hunger);
                    hpItem.UseFoodItem(itemId);
                    Debug.LogFormat("유저 배고픔 지수 : {0}", UserInformation.player.hunger);
                }
            }
            // 무기아이템
            if (ItemManager.myWeaponList.Contains(itemId))
            {
                Debug.Log("---------------------[무기 장착전]-----------------------------------");
                Debug.LogFormat("유저 최대 공격력 : {0}", UserInformation.player.maxAttackDamage);
                Debug.LogFormat("유저 최소 공격력 : {0}", UserInformation.player.minAttackDamage);
                Debug.LogFormat("유저 DEX : {0}", UserInformation.player.dex);
                Debug.LogFormat("유저 STR : {0}", UserInformation.player.str);
                Debug.LogFormat("유저 SPD : {0}", UserInformation.player.spd);
                Debug.Log("---------------------------------------------------------------------");
                weaponItem.ApplyWeapon(itemId);
                Debug.Log("---------------------[무기 장착후]-----------------------------------");
                Debug.LogFormat("유저 최대 공격력 : {0}", UserInformation.player.maxAttackDamage);
                Debug.LogFormat("유저 최소 공격력 : {0}", UserInformation.player.minAttackDamage);
                Debug.LogFormat("유저 DEX : {0}", UserInformation.player.dex);
                Debug.LogFormat("유저 STR : {0}", UserInformation.player.str);
                Debug.LogFormat("유저 SPD : {0}", UserInformation.player.spd);
                Debug.LogFormat("[유저 아이템 정보]   [0번 : {0}]  [1번 : {1}]",
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
        // 여기서 아이템 정보를 띄어주는것
        // magicbox 에서 수정해서 쓰는거 해줘야할듯..ㄴ
        // if 지옥갈듯
    
    }
}
