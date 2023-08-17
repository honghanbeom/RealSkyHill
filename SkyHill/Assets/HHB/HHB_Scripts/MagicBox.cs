using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MagicBox : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    public int itemId { get; set; }


    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.LogFormat("{0}", itemId);
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (ItemManager.myMediList.Contains(itemId))
            {
                //! ���� ����Ʈ���� �����ϴ� ��� �ʼ�


                // EMERGENCY
                if (itemId >= 100 && itemId <= 108)
                { 


                    ItemManager.myMediList.Remove(itemId);
                    ItemManager.itemManager.ItemRoutine();
                }
                // FRESHFOOD
                if (itemId >= 700 && itemId <= 713)
                {
                    

                    ItemManager.myMediList.Remove(itemId);
                    ItemManager.itemManager.ItemRoutine();
                }
                // SPOILEDFOOD
                if (itemId >= 800 && itemId <= 813)
                {


                    ItemManager.myMediList.Remove(itemId);
                    ItemManager.itemManager.ItemRoutine();
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
