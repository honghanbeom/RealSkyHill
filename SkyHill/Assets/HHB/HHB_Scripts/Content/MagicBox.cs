using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MagicBox : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int itemId { get; set; }
    private HpItem hpItem;
    private WeaponItem weaponItem;
    private WeaponImage weaponImage;
    private WeaponUIManager weaponUI;
    private GameObject weaponName;

    public void OnPointerClick(PointerEventData eventData)
    {
        hpItem = FindObjectOfType<HpItem>();
        weaponItem = FindObjectOfType<WeaponItem>();
        weaponUI = FindObjectOfType<WeaponUIManager>();

        // 마우스 우클릭
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            //Debug.LogFormat("{0}", itemId);

            
            if (ItemManager.myMediList.Contains(itemId))
            {
                // 회복아이템
                // (100 ~ 104) EMERGENCY , (0 ~ 3) ROOTEMERGENCY
                if (((itemId >= 100 && itemId <= 104) || (itemId >= 0 && itemId <= 3) )&& itemId != 103)
                {
                    //Debug.LogFormat("유저 체력 : {0}",UserInformation.player.hp);
                    hpItem.UseHealthItem(itemId);
                    //Debug.LogFormat("유저 체력 : {0}", UserInformation.player.hp);
                }
                if (itemId == 103)
                {
                    hpItem.UseAntidote(itemId);  
                }
                // (800 ~ 808) SPOILEDFOOD
                else if (itemId >= 800 && itemId <= 808)
                {
                    hpItem.UseSpoiledFood(itemId);
                    //Debug.LogFormat("중독 여부 : {0}", UserInformation.player.poision);
                }
                // 음식아이템
                // (700 ~ 713) FRESHFOOD, (900~917) ROOTFOOD, (1000~1016) MAKINGFOOD
                else
                {
                    //Debug.LogFormat("유저 배고픔 지수 : {0}", UserInformation.player.hunger);
                    hpItem.UseFoodItem(itemId);
                    //Debug.LogFormat("유저 배고픔 지수 : {0}", UserInformation.player.hunger);
                }
                
            }
            // 무기아이템
            if (ItemManager.myWeaponList.Contains(itemId))
            {
                //Debug.Log("---------------------[무기 장착전]-----------------------------------");
                //Debug.LogFormat("유저 최대 공격력 : {0}", UserInformation.player.maxAttackDamage);
                //Debug.LogFormat("유저 최소 공격력 : {0}", UserInformation.player.minAttackDamage);
                //Debug.LogFormat("유저 DEX : {0}", UserInformation.player.dex);
                //Debug.LogFormat("유저 STR : {0}", UserInformation.player.str);
                //Debug.LogFormat("유저 SPD : {0}", UserInformation.player.spd);
                //Debug.Log("---------------------------------------------------------------------");
                weaponItem.ApplyWeapon(itemId);
                //Debug.Log("---------------------[무기 장착후]-----------------------------------");
                //Debug.LogFormat("유저 최대 공격력 : {0}", UserInformation.player.maxAttackDamage);
                //Debug.LogFormat("유저 최소 공격력 : {0}", UserInformation.player.minAttackDamage);
                //Debug.LogFormat("유저 DEX : {0}", UserInformation.player.dex);
                //Debug.LogFormat("유저 STR : {0}", UserInformation.player.str);
                //Debug.LogFormat("유저 SPD : {0}", UserInformation.player.spd);
                //Debug.LogFormat("[유저 아이템 정보]   [0번 : {0}]  [1번 : {1}]",
                //    UserInformation.player.myEquipWeapon[0], UserInformation.player.myEquipWeapon[1]);
                //Debug.Log("---------------------------------------------------------------------");


                WeaponSpriteMatch weaponSpriteMatch = FindObjectOfType<WeaponSpriteMatch>();

                weaponName = GameObject.Find("Weapon");
                weaponName.GetComponent<SpriteRenderer>().sprite = weaponSpriteMatch.WeaponMatch(itemId);
                //GetComponent<SpriteRenderer>().sprite = weaponSpriteMatch.WeaponMatch(itemId);
                //weaponSprite = weaponSpriteMatch.WeaponMatch(itemId);
                //Debug.Log(weaponSprite.name);


                weaponImage = FindObjectOfType<WeaponImage>();
                weaponImage.ControlLeftImage(UserInformation.player.myEquipWeapon);
                weaponImage.ControlRightImage(UserInformation.player.myEquipWeapon);
                weaponUI.WeaponStatPrint();
                weaponUI.WeaponNamePrint();
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData) 
    {
        //Debug.LogFormat("마우스가 위에 있음 {0}", itemId);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.LogFormat("마우스 나감 {0}", itemId);
    }



}
