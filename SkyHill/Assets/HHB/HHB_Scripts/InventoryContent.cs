using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class InventoryContent : MonoBehaviour
{
    // static
    public static InventoryContent inventoryContent;

    // id를 받아서 스프라이트를 교체해주는 박스 magic box
    public GameObject magicItemBox;

    // Content와 Content 하위에 생성되는 것들
    RectTransform rectTransform;
    RectTransform[] rectTransformChild;

    // magic box를 갯수를 관리하는 리스트
    private List<GameObject> instantiatedItems = new List<GameObject>();

    // 바꿔줄 스프라이트 매칭
    public Sprite[] changeSprites;


    // 초기 출력 위치
    private float xPos = -170f;
    private float yPos = 110f;



    void Awake()
    {
        // 아이템 변경 액션
        ItemManager.itemManager.OnItemsUpdated += UpdateItem;
    }


    // 바뀔 내용
    public void UpdateItem()
    {
        WeaponItemCreate();
        //Debug.Log("InventoryContent굿");
    }

    #region LEGACY
    //void WeaponItemCreate()
    //{
    //    rectTransform = GetComponent<RectTransform>();
    //    for (int i = 0; i < ItemManager.myWeaponList.Count; i++)
    //    {
    //        //Debug.LogFormat("{0}", ItemManager.myWeaponList.Count);
    //        GameObject myWeaponItems = Instantiate(magicItemBox, rectTransform);
    //    }

    //    rectTransformChild = new RectTransform[rectTransform.childCount];

    //    for (int i = 0; i < rectTransform.childCount; i++)
    //    {
    //        //Debug.Log(i);
    //        rectTransformChild[i] = rectTransform.GetChild(i) as RectTransform;
    //    }

    //    WeaponPosition();
    //}
    #endregion

    // 아이템 출력
    public void WeaponItemCreate()
    {
        // magic box를 부숨
        foreach (var item in instantiatedItems)
        {
            Destroy(item);
        }
        // 리스트 null 값으로 초기화
        instantiatedItems.Clear();

        // 디버그용
        //for (int i = 0; i < ItemManager.myWeaponList.Count; i++)
        //{
        //    Debug.LogFormat("ID : {0} Count : {1}",
        //        ItemManager.myWeaponList[i], ItemManager.myWeaponList.Count);
        //}

        // rectTransform 접근
        rectTransform = GetComponent<RectTransform>();


        // 내 아이템 리스트만큼 ~
        foreach (int itemId in ItemManager.myWeaponList)
        {
            // magicBox 생성
            GameObject myWeaponItems = Instantiate(magicItemBox, rectTransform);
            // 관리 리스트에 추가
            instantiatedItems.Add(myWeaponItems);
            // 이미지 매칭 컴포넌트 가져오기
            Image itemImage = myWeaponItems.GetComponent<Image>();
            // 이미지 변경
            ItemList.itemList.ImageMatch(itemId, itemImage);
            // 생성된 프리팹에 id 스크립트 지정
            myWeaponItems.GetComponent<MagicBox>().itemId = itemId;


        }

        //Debug.LogFormat("instantiatedItems의 갯수 : {0}", instantiatedItems.Count);


        // 생성 위치를 결정하기 전 미리 배치되어 있는 위치를 전부 삭제
        if (rectTransformChild != null)
        {
            for (int i = 0; i < rectTransformChild.Length; i++)
            {
                //Debug.LogFormat("Length : {0}",rectTransformChild.Length);
                //Debug.LogFormat("Name : {0}", rectTransformChild[i].name);
                Destroy(rectTransformChild[i].gameObject);
            }
        }


        //! 2가지 List랑 rectTransform을 Destory하는데 시간이 소요됨에 따라 StartCourtine 
        StartCoroutine(WaitForPositionSetting());
        //WeaponPosition();
    }

    // 위치를 조정하는 Function
    void WeaponPosition()
    {
        int colSize = 6;
        //Debug.LogFormat("Weapon Position : {0}", rectTransformChild.Length);
        for (int i = 0; i < rectTransformChild.Length; i++)
        {
            int row = i / colSize;
            int column = i % colSize;

            float xPosition = xPos + column * 70f;
            float yPosition = yPos - row * 60f;

            //Debug.LogFormat("생성위치 x : {0} y : {1}", xPosition, yPosition);
            rectTransformChild[i].anchoredPosition = new Vector2(xPosition, yPosition);
        }

    }

    private IEnumerator WaitForPositionSetting()
    {
        // 프레임 늦추기
        yield return new WaitForNextFrameUnit();
        // 파괴된 rectTransform을 새로 생성
        rectTransformChild = new RectTransform[rectTransform.childCount];
        for (int i = 0; i < rectTransform.childCount; i++)
        {
            rectTransformChild[i] = rectTransform.GetChild(i) as RectTransform;
        }
        WeaponPosition();
        // 프레임 늦추기
        yield return new WaitForNextFrameUnit();
    }
}
