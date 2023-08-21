using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediCreaft : CreaftContent
{

    public override void CreaftAwake()
    {
        rectTransform = GetComponent<RectTransform>();


        originalColors = new Color[combinationImage.Length];
        for (int i = 0; i < combinationImage.Length; i++)
        {
            originalColors[i] = combinationImage[i].color;
        }

        for (int i = 0; i < 5; i++)
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




    public override void CombinationImageMatch(int buttonIndex)
    {
        List<Dictionary<string, object>> emergency = CSVReader.Read("EMERGENCY");
        Dictionary<string, object> itemInfo = emergency[buttonIndex];


        //Debug.Log(emergency[buttonIndex]["COM1"].ToString());
        //Debug.Log(emergency[buttonIndex]["COM2"].ToString());
        //Debug.Log(emergency[buttonIndex]["COM3"].ToString());
        //Debug.Log(emergency[buttonIndex]["COM4"].ToString());



        int com1 = NameToIDChanger.n2D.NameToID(emergency[buttonIndex]["COM1"].ToString());
        int com2 = NameToIDChanger.n2D.NameToID(emergency[buttonIndex]["COM2"].ToString());
        int com3 = NameToIDChanger.n2D.NameToID(emergency[buttonIndex]["COM3"].ToString());
        int com4 = NameToIDChanger.n2D.NameToID(emergency[buttonIndex]["COM4"].ToString());

        //Debug.Log(com1);
        //Debug.Log(com2);
        //Debug.Log(com3);
        //Debug.Log(com4);


        int[] com = { com1, com2, com3, com4 };

        CombinationCreateButton.combinationList.Clear();
        CombinationCreateButton.combinationNeedList.Clear();

        for (int i = 1; i <= 4; i++)
        {
            foreach (Image image in combinationImage)
            {
                image.gameObject.SetActive(true);
            }
            string comKey = "COM" + i;
            if (itemInfo.ContainsKey(comKey))
            {
                int comId = NameToIDChanger.n2D.NameToID(itemInfo[comKey].ToString());
                CombinationCreateButton.combinationNeedList.Add(comId);
            }
        }
        int makeId = NameToIDChanger.n2D.NameToID(itemInfo["EMERGENCY_NAME"].ToString());
        CombinationCreateButton.combinationList.Add(makeId);

        for (int i = 0; i < combinationImage.Length; i++)
        {
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
    }
}
