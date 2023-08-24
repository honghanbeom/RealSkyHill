using System.Collections;
using System.Collections.Generic;
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
    public Image completeImage;
    private WeaponImage weaponImage;

    //List<int> duplicateId = new List<int>();
    //int sameID = default;


    void Awake()
    {
       //itemManager = GetComponent<ItemManager>();
       //completeImage = GetComponent<Image>();
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

        if (VerifyItemsNeeded() /*&& !SameItemNamesVerify()*/)
        {

            foreach (var com in combinationNeedList)
            {
                // 가진 아이템들을 제거
                //itemManager.RemoveItem(com);
                ItemManager.myWeaponList.Remove(com);
                ItemManager.myMediList.Remove(com);
                ItemManager.myETCList.Remove(com);

                // 무기아이템의 경우 내가 아이템에서 빼면 들고 있는 무기 리스트에서 같이 제거 해줌
                for (int i = 0; i < UserInformation.player.myEquipWeapon.Count; i++)
                {
                    if (UserInformation.player.myEquipWeapon[i] == com)
                    {
                        UserInformation.player.myEquipWeapon[i] = -1;
                    }
                }
                weaponImage = FindObjectOfType<WeaponImage>();
                weaponImage.ControlLeftImage(UserInformation.player.myEquipWeapon);
                weaponImage.ControlRightImage(UserInformation.player.myEquipWeapon);
                WeaponUIManager.weaponUI.WeaponNamePrint();
                WeaponUIManager.weaponUI.WeaponStatPrint();
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
            StartCoroutine(ImageChange());
            ItemManager.myInvenList.Add(combinationList[0]);
            ItemManager.itemManager.ItemRoutine();
        }
        //else if (VerifyItemsNeeded() && SameItemNamesVerify())
        //{
        //    ItemManager.myWeaponList.Remove(sameID);
        //    ItemManager.myMediList.Remove(sameID);
        //    ItemManager.myETCList.Remove(sameID);
        //    StartCoroutine(ImageChange());
        //    ItemManager.myInvenList.Add(combinationList[0]);
        //    ItemManager.itemManager.ItemRoutine();
        //}
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

    //public bool SameItemNamesVerify()
    //{
    //    duplicateId.Clear();

    //    int mySameCount = 0;
    //    sameID = 0;

    //    // 같은거 체크해서 HashSet에 넣음
    //    foreach (int id in combinationNeedList)
    //    {
    //        duplicateId.Add(id);
    //        if (duplicateId.Contains(id))
    //        {
    //            mySameCount++;
    //            sameID = duplicateId[id];
    //        }
    //    }

    //    if (mySameCount > 0)
    //    { 
    //        return true;
    //    }
    //    else { return false;}
    //}



    private IEnumerator ImageChange()
    {
        yield return new WaitForNextFrameUnit();
        completeImage.gameObject.SetActive(true);
        float imageShowTime = 0.6f;
        ItemList.itemList.ImageMatch(combinationList[0], completeImage);
        yield return new WaitForSeconds(imageShowTime);
        completeImage.gameObject.SetActive(false);
    }


  


}
