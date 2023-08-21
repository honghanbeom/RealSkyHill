using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreaftContent : MonoBehaviour
{
    public GameObject prefab;
    public Image[] combinationImage;
    public Sprite[] changeSprites;

    [SerializeField]
    protected Color[] originalColors;
    [SerializeField]
    protected RectTransform rectTransform;
    [SerializeField]
    protected RectTransform[] rectTransformChild;

    float xPos = -20f;
    float yPos = 275f;

    // Start is called before the first frame update
    void Awake()
    {
        CreaftAwake();
    }

    public virtual void CreaftAwake()
    {
        rectTransform = GetComponent<RectTransform>();


        originalColors = new Color[combinationImage.Length];
        for (int i = 0; i < combinationImage.Length; i++)
        {
            originalColors[i] = combinationImage[i].color;
        }

        for (int i = 0; i < 24; i++)
        {
            GameObject buttonObj = Instantiate(prefab, rectTransform);
            Button button = buttonObj.GetComponent<Button>();
            button.image.sprite = changeSprites[i];

            int buttonIndex = i;
            button.onClick.AddListener(() => CombinationImageMatch(buttonIndex));
        }

        rectTransformChild = new RectTransform[rectTransform.childCount];


        for (int i = 0; i < rectTransform.childCount; i++)
        {
            //Debug.Log(i);
            rectTransformChild[i] = rectTransform.GetChild(i) as RectTransform;
        }

        Position();
    }


    public void Position()
    {
        for (int i = 0; i < rectTransformChild.Length; i++)
        {
            //Debug.Log (i);
            // 짝수 or 0 
            if (i % 2 == 0)
            {
                //Debug.LogFormat("왼쪽 : {0}",i);
                rectTransformChild[i].anchoredPosition = new Vector2(xPos, yPos);
                xPos += 50f;
            }
            // 홀수
            if (i % 2 == 1)
            {
                //Debug.LogFormat("오른쪽 : {0}", i);
                rectTransformChild[i].anchoredPosition = new Vector2(xPos, yPos);
                yPos -= 50f;
                xPos -= 50f;
            }
        }
    }

    public virtual void CombinationImageMatch(int buttonIndex)
    {
        List<Dictionary<string, object>> makingWeapon = CSVReader.Read("MAKINGWEAPON");
        Dictionary<string, object> itemInfo = makingWeapon[buttonIndex];
        //List<Dictionary<string, object>> rootWeapon = CSVReader.Read("ROOTWEAPON");
        //List<Dictionary<string, object>> rootMaterial = CSVReader.Read("ROOTMATERIAL");
        //List<Dictionary<string, object>> makingMaterial = CSVReader.Read("MAKINGMATERIAL");
        //List<Dictionary<string, object>> rootFood = CSVReader.Read("ROOTFOOD");
        //List<Dictionary<string, object>> freshFood = CSVReader.Read("FRESHFOOD");

        int com1 = NameToIDChanger.n2D.NameToID(makingWeapon[buttonIndex]["COM1"].ToString());
        int com2 = NameToIDChanger.n2D.NameToID(makingWeapon[buttonIndex]["COM2"].ToString());
        int com3 = NameToIDChanger.n2D.NameToID(makingWeapon[buttonIndex]["COM3"].ToString());
        int com4 = NameToIDChanger.n2D.NameToID(makingWeapon[buttonIndex]["COM4"].ToString());

        //Debug.Log(com1);
        //Debug.Log(com2);
        //Debug.Log(com3);
        //Debug.Log(com4);


        int[] com = {com1, com2, com3, com4};

        CombinationCreateButton.combinationList.Clear();
        CombinationCreateButton.combinationNeedList.Clear();

        for (int i = 1; i <= 4; i++)
        {
            string comKey = "COM" + i;
            if (itemInfo.ContainsKey(comKey))
            {
                int comId = NameToIDChanger.n2D.NameToID(itemInfo[comKey].ToString());
                CombinationCreateButton.combinationNeedList.Add(comId);
            }
        }
        int makeId = NameToIDChanger.n2D.NameToID(itemInfo["WEAPON_NAME"].ToString());
        CombinationCreateButton.combinationList.Add(makeId);



        for (int i = 0; i < combinationImage.Length; i++)
        {
            foreach (Image image in combinationImage)
            {
                image.gameObject.SetActive(true);
            }
            // 만약 내가 아이템을 가지고 있지 않다면
            if (!(ItemManager.myWeaponList.Contains(com[i]) ||
                ItemManager.myETCList.Contains(com[i])) ||
                ItemManager.myMediList.Contains(com[i]))
            {
                Color disableColor = new Color(1f, 0f, 0f, 0.3f);
                combinationImage[i].color = disableColor;
                ItemList.itemList.ImageMatch(com[i], combinationImage[i]);
            }
            // 가지고 있다면
            else
            {
                combinationImage[i].color = originalColors[i];
                ItemList.itemList.ImageMatch(com[i], combinationImage[i]);
            }
        }
        //ItemList.itemList.ImageMatch(com1, combinationImage[0]);
        //ItemList.itemList.ImageMatch(com2, combinationImage[1]);
        //ItemList.itemList.ImageMatch(com3, combinationImage[2]);
        //ItemList.itemList.ImageMatch(com4, combinationImage[3]);
    }

    #region LEGACY
    //public void CreateItem(int[] com, int buttonIndex)
    //{
    //    bool canCraft = true;
    //    foreach (int itemId in com)
    //    {
    //        if (!(ItemManager.myWeaponList.Contains(itemId) ||
    //            ItemManager.myETCList.Contains(itemId) ||
    //            ItemManager.myMediList.Contains(itemId)))
    //        {
    //            canCraft = false;
    //            break;
    //        }
    //    }

    //    if (canCraft)
    //    {
    //        foreach (int itemId in com)
    //        {
    //            if (ItemManager.myWeaponList.Contains(itemId))
    //            {
    //                ItemManager.myWeaponList.Remove(itemId);
    //            }
    //            else if (ItemManager.myETCList.Contains(itemId))
    //            {
    //                ItemManager.myETCList.Remove(itemId);
    //            }
    //            else if (ItemManager.myMediList.Contains(itemId))
    //            {
    //                ItemManager.myMediList.Remove(itemId);
    //            }
    //        }

    //        List<Dictionary<string, object>> makingWeapon = CSVReader.Read("MAKINGWEAPON");
    //        int myItem = NameToIDChanger.n2D.NameToID(makingWeapon[buttonIndex]["WEAPON_NAME"].ToString());
    //        ItemManager.myInvenList.Add(myItem);
    //    }
    //}
    #endregion
}
