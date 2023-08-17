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
                //! 끝에 리스트에서 제거하는 기능 필수


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
