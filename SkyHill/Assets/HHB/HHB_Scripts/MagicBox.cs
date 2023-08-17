using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MagicBox : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    public int itemId { get; set; }
    private HpItem hpItem;

    private void Awake()
    {

    }


    public void OnPointerClick(PointerEventData eventData)
    {
        hpItem = FindObjectOfType<HpItem>();
        // 마우스 우클릭
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.LogFormat("{0}", itemId);
            if (ItemManager.myMediList.Contains(itemId))
            {
                // EMERGENCY
                if (itemId >= 100 && itemId <= 108)
                {
                    Debug.LogFormat("유저 체력 : {0}",UserInformation.player.hp);
                    hpItem.UseHealthItem(itemId);
                    Debug.LogFormat("유저 체력 : {0}", UserInformation.player.hp);
                }
                // (700 ~ 713) FRESHFOOD, (900~917) ROOTFOOD, (1000~1016) MAKINGFOOD
                else
                {
                    Debug.LogFormat("유저 배고픔 지수 : {0}", UserInformation.player.hunger);
                    hpItem.UseFoodItem(itemId);
                    Debug.LogFormat("유저 배고픔 지수 : {0}", UserInformation.player.hunger);
                }
            }
            if (ItemManager.myWeaponList.Contains(itemId))
            { 
                // csv 읽어서 아이템 장착하고 밑의 이미지 바꾸는 효과 적용~
            }           
        }
    }

    public void OnPointerEnter(PointerEventData eventData) 
    {  
        // 여기서 아이템 정보를 띄어주는것
        // magicbox 에서 수정해서 쓰는거 해줘야할듯..ㄴ
    
    }
}
