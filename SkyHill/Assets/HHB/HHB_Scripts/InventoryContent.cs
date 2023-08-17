using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class InventoryContent : MonoBehaviour
{
    // id�� �޾Ƽ� ��������Ʈ�� ��ü���ִ� �ڽ� magic box
    public GameObject magicItemBox;

    // InventoryUI/InventoryView/Content�� Content ������ �����Ǵ� �͵�
    RectTransform rectTransform;
    RectTransform[] rectTransformChild;

    // magic box�� ������ �����ϴ� ����Ʈ
    private List<GameObject> weaponMagicBox = new List<GameObject>();
    private List<GameObject> mediMagicBox = new List<GameObject>();
    private List<GameObject> ETCMagicBox = new List<GameObject>();

    // �ʱ� ��� ��ġ
    private float xPos = -170f;
    private float yPos = 110f;



    void Awake()
    {
        // ������ ���� �׼�
        ItemManager.itemManager.OnItemsUpdated += UpdateItem;
    }


    // �ٲ� ����
    public void UpdateItem()
    {
        ItemCreate();
        //Debug.Log("InventoryContent��");
    }

    // MagicBox Destroy
    void DestroyItems<T>(List<T> myMagicBoxes)
    {
        // weaponMagicBox�� Destroy
        foreach (var item in myMagicBoxes)
        {
            if (item is GameObject gameObjectItem)
            { 
                Destroy(gameObjectItem);
            }
        }
        // ����Ʈ null ������ �ʱ�ȭ
        myMagicBoxes.Clear();
    }

    // Item ������ ����, �̹��� ��Ī, ID ����
    void CreateItems()
    {

        // �� ������ ����Ʈ��ŭ ~
        foreach (int itemId in ItemManager.myWeaponList)
        {
            // magicBox ����
            GameObject myWeaponItems = Instantiate(magicItemBox, rectTransform);
            // ���� ����Ʈ�� �߰�
            weaponMagicBox.Add(myWeaponItems);
            // �̹��� ��Ī ������Ʈ ��������
            Image itemImage = myWeaponItems.GetComponent<Image>();
            // �̹��� ����
            ItemList.itemList.ImageMatch(itemId, itemImage);
            // ������ �����տ� id ��ũ��Ʈ ����
            myWeaponItems.GetComponent<MagicBox>().itemId = itemId;
        }

        // �� ������ ����Ʈ��ŭ ~
        foreach (int itemId in ItemManager.myMediList)
        {
            // magicBox ����
            GameObject myMediItems = Instantiate(magicItemBox, rectTransform);
            // ���� ����Ʈ�� �߰�
            mediMagicBox.Add(myMediItems);
            // �̹��� ��Ī ������Ʈ ��������
            Image itemImage = myMediItems.GetComponent<Image>();
            // �̹��� ����
            ItemList.itemList.ImageMatch(itemId, itemImage);
            // ������ �����տ� id ��ũ��Ʈ ����
            myMediItems.GetComponent<MagicBox>().itemId = itemId;
        }

        // �� ������ ����Ʈ��ŭ ~
        foreach (int itemId in ItemManager.myETCList)
        {
            // magicBox ����
            GameObject myETCItems = Instantiate(magicItemBox, rectTransform);
            // ���� ����Ʈ�� �߰�
            ETCMagicBox.Add(myETCItems);
            // �̹��� ��Ī ������Ʈ ��������
            Image itemImage = myETCItems.GetComponent<Image>();
            // �̹��� ����
            ItemList.itemList.ImageMatch(itemId, itemImage);
            // ������ �����տ� id ��ũ��Ʈ ����
            myETCItems.GetComponent<MagicBox>().itemId = itemId;
        }
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

    // ������ ���
    public void ItemCreate()
    {

        DestroyItems<GameObject>(weaponMagicBox);
        DestroyItems<GameObject>(mediMagicBox);
        DestroyItems<GameObject>(ETCMagicBox);
        //// magic box�� �μ�
        //foreach (var item in weaponMagicBox)
        //{
        //    Destroy(item);
        //}
        //// ����Ʈ null ������ �ʱ�ȭ
        //weaponMagicBox.Clear();

        // ����׿�
        //for (int i = 0; i < ItemManager.myWeaponList.Count; i++)
        //{
        //    Debug.LogFormat("ID : {0} Count : {1}",
        //        ItemManager.myWeaponList[i], ItemManager.myWeaponList.Count);
        //}

        // rectTransform ����
        rectTransform = GetComponent<RectTransform>();

        CreateItems();
        //// �� ������ ����Ʈ��ŭ ~
        //foreach (int itemId in ItemManager.myWeaponList)
        //{
        //    // magicBox ����
        //    GameObject myWeaponItems = Instantiate(magicItemBox, rectTransform);
        //    // ���� ����Ʈ�� �߰�
        //    weaponMagicBox.Add(myWeaponItems);
        //    // �̹��� ��Ī ������Ʈ ��������
        //    Image itemImage = myWeaponItems.GetComponent<Image>();
        //    // �̹��� ����
        //    ItemList.itemList.ImageMatch(itemId, itemImage);
        //    // ������ �����տ� id ��ũ��Ʈ ����
        //    myWeaponItems.GetComponent<MagicBox>().itemId = itemId;
        //}

        ////Debug.LogFormat("instantiatedItems�� ���� : {0}", instantiatedItems.Count);


        // ���� ��ġ�� �����ϱ� �� �̸� ��ġ�Ǿ� �ִ� ��ġ�� ���� ����
        if (rectTransformChild != null)
        {
            for (int i = 0; i < rectTransformChild.Length; i++)
            {
                //Debug.LogFormat("Length : {0}",rectTransformChild.Length);
                //Debug.LogFormat("Name : {0}", rectTransformChild[i].name);
                Destroy(rectTransformChild[i].gameObject);
            }
        }


        //! 2���� List�� rectTransform�� Destory�ϴµ� �ð��� �ҿ�ʿ� ���� StartCourtine 
        StartCoroutine(WaitForPositionSetting());
        //WeaponPosition();
    }

    // ��ġ�� �����ϴ� Function
    void Position()
    {
        int colSize = 6;
        //Debug.LogFormat("Weapon Position : {0}", rectTransformChild.Length);
        for (int i = 0; i < rectTransformChild.Length; i++)
        {
            int row = i / colSize;
            int column = i % colSize;

            float xPosition = xPos + column * 70f;
            float yPosition = yPos - row * 60f;

            //Debug.LogFormat("������ġ x : {0} y : {1}", xPosition, yPosition);
            rectTransformChild[i].anchoredPosition = new Vector2(xPosition, yPosition);
        }

    }

    private IEnumerator WaitForPositionSetting()
    {
        // ������ ���߱�
        yield return new WaitForNextFrameUnit();
        // �ı��� rectTransform�� ���� ����
        rectTransformChild = new RectTransform[rectTransform.childCount];
        for (int i = 0; i < rectTransform.childCount; i++)
        {
            rectTransformChild[i] = rectTransform.GetChild(i) as RectTransform;
        }
        Position();
        // ������ ���߱�
        yield return new WaitForNextFrameUnit();
    }
}
