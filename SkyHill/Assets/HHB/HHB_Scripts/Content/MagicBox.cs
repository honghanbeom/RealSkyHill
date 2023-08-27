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

        // ���콺 ��Ŭ��
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            //Debug.LogFormat("{0}", itemId);

            
            if (ItemManager.myMediList.Contains(itemId))
            {
                // ȸ��������
                // (100 ~ 104) EMERGENCY , (0 ~ 3) ROOTEMERGENCY
                if (((itemId >= 100 && itemId <= 104) || (itemId >= 0 && itemId <= 3) )&& itemId != 103)
                {
                    //Debug.LogFormat("���� ü�� : {0}",UserInformation.player.hp);
                    hpItem.UseHealthItem(itemId);
                    //Debug.LogFormat("���� ü�� : {0}", UserInformation.player.hp);
                }
                if (itemId == 103)
                {
                    hpItem.UseAntidote(itemId);  
                }
                // (800 ~ 808) SPOILEDFOOD
                else if (itemId >= 800 && itemId <= 808)
                {
                    hpItem.UseSpoiledFood(itemId);
                    //Debug.LogFormat("�ߵ� ���� : {0}", UserInformation.player.poision);
                }
                // ���ľ�����
                // (700 ~ 713) FRESHFOOD, (900~917) ROOTFOOD, (1000~1016) MAKINGFOOD
                else
                {
                    //Debug.LogFormat("���� ����� ���� : {0}", UserInformation.player.hunger);
                    hpItem.UseFoodItem(itemId);
                    //Debug.LogFormat("���� ����� ���� : {0}", UserInformation.player.hunger);
                }
                
            }
            // ���������
            if (ItemManager.myWeaponList.Contains(itemId))
            {
                //Debug.Log("---------------------[���� ������]-----------------------------------");
                //Debug.LogFormat("���� �ִ� ���ݷ� : {0}", UserInformation.player.maxAttackDamage);
                //Debug.LogFormat("���� �ּ� ���ݷ� : {0}", UserInformation.player.minAttackDamage);
                //Debug.LogFormat("���� DEX : {0}", UserInformation.player.dex);
                //Debug.LogFormat("���� STR : {0}", UserInformation.player.str);
                //Debug.LogFormat("���� SPD : {0}", UserInformation.player.spd);
                //Debug.Log("---------------------------------------------------------------------");
                weaponItem.ApplyWeapon(itemId);
                //Debug.Log("---------------------[���� ������]-----------------------------------");
                //Debug.LogFormat("���� �ִ� ���ݷ� : {0}", UserInformation.player.maxAttackDamage);
                //Debug.LogFormat("���� �ּ� ���ݷ� : {0}", UserInformation.player.minAttackDamage);
                //Debug.LogFormat("���� DEX : {0}", UserInformation.player.dex);
                //Debug.LogFormat("���� STR : {0}", UserInformation.player.str);
                //Debug.LogFormat("���� SPD : {0}", UserInformation.player.spd);
                //Debug.LogFormat("[���� ������ ����]   [0�� : {0}]  [1�� : {1}]",
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
        //Debug.LogFormat("���콺�� ���� ���� {0}", itemId);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.LogFormat("���콺 ���� {0}", itemId);
    }



}
