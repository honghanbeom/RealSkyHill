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
        // ���콺 ��Ŭ��
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.LogFormat("{0}", itemId);
            if (ItemManager.myMediList.Contains(itemId))
            {
                // EMERGENCY
                if (itemId >= 100 && itemId <= 108)
                {
                    Debug.LogFormat("���� ü�� : {0}",UserInformation.player.hp);
                    hpItem.UseHealthItem(itemId);
                    Debug.LogFormat("���� ü�� : {0}", UserInformation.player.hp);
                }
                // (700 ~ 713) FRESHFOOD, (900~917) ROOTFOOD, (1000~1016) MAKINGFOOD
                else
                {
                    Debug.LogFormat("���� ����� ���� : {0}", UserInformation.player.hunger);
                    hpItem.UseFoodItem(itemId);
                    Debug.LogFormat("���� ����� ���� : {0}", UserInformation.player.hunger);
                }
            }
            if (ItemManager.myWeaponList.Contains(itemId))
            { 
                // csv �о ������ �����ϰ� ���� �̹��� �ٲٴ� ȿ�� ����~
            }           
        }
    }

    public void OnPointerEnter(PointerEventData eventData) 
    {  
        // ���⼭ ������ ������ ����ִ°�
        // magicbox ���� �����ؼ� ���°� ������ҵ�..��
    
    }
}
