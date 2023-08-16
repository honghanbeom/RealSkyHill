using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CombinationCreateButton : MonoBehaviour, IPointerClickHandler
{
    //private ItemManager itemManager;
    public static List<int> combinationList = new List<int>();
    public static List<int> combinationNeedList = new List<int>();
    public Image[] combinationImages;
    public Image completeImages;

    void Awake()
    {
       //itemManager = GetComponent<ItemManager>();
       completeImages = GetComponent<Image>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; i < combinationImages.Length; i++)
        {
            ItemList.itemList.ImageMatch(-1, combinationImages[i]);
        }
        CreatItem();
    }

    public void CreatItem()
    {

        combinationNeedList.RemoveAll(com => com == -1);

        //foreach (var com in combinationNeedList)
        //{
        //    Debug.Log(com);
        //}
        //Debug.Log(combinationList[0]);

        if (VerifyItemsNeeded())
        {

            foreach (var com in combinationNeedList)
            {
                // 가진 아이템들을 제거
                //itemManager.RemoveItem(com);
                ItemManager.myWeaponList.Remove(com);
                ItemManager.myMediList.Remove(com);
                ItemManager.myETCList.Remove(com);

                //for (int i = 0; i < ItemManager.myWeaponList.Count; i++)
                //{
                //    Debug.Log(ItemManager.myWeaponList[i]);
                //}
                //for (int i = 0; i < ItemManager.myMediList.Count; i++)
                //{
                //    Debug.Log(ItemManager.myMediList[i]);
                //}
                //for (int i = 0; i < ItemManager.myETCList.Count; i++)
                //{
                //    Debug.Log(ItemManager.myETCList[i]);
                //}

            }
            //itemManager.AddItem(combinationList[0]);
            //StartCoroutine(ImageChange());
            ItemManager.myInvenList.Add(combinationList[0]);
            ItemManager.itemManager.ItemRoutine();
        }
        else if (!VerifyItemsNeeded())
        {
            /*Do Nothing*/
            Debug.Log("조합실패");
        }
    }

    public bool VerifyItemsNeeded()
    {
        foreach (var com in combinationNeedList)
        {
            // 나의 리스트에서 가지고 있는지 검증
            if (!(ItemManager.myMediList.Contains(com) ||
                ItemManager.myETCList.Contains(com) ||
                ItemManager.myWeaponList.Contains(com)))
            {
                return false;
            }
    
        }
        return true;
    }

    private IEnumerator ImageChange()
    {
        //completeImages.gameObject.SetActive(true);
        float imageShowTime = 3f;
        ItemList.itemList.ImageMatch(combinationList[0], completeImages);
        //completeImages.gameObject.SetActive(false);
        yield return new WaitForSeconds(imageShowTime);
    }


  


}
