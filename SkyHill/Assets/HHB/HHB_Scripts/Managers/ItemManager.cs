using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemManager : MonoBehaviour
{
    public static ItemManager itemManager;
    //InventoryContent inventoryContent;
    // �κ� ����Ʈ
    public static List<int> myInvenList = new List<int>();

    // �������� ����Ʈ (����, ����, ��Ÿ)
    public static List<int> myWeaponList = new List<int>();
    public static List<int> myMediList = new List<int>();
    public static List<int> myETCList = new List<int>() ;

    public event Action OnItemsUpdated;

    private void Awake()
    {
        itemManager = this;
        //inventoryContent = GetComponent<InventoryContent>();
        //myInvenList.Add(100);
        //myInvenList.Add(700);
        //myInvenList.Add(900);
        //myInvenList.Add(806);
        //myInvenList.Add(605);
        //myInvenList.Add(600);


        //myInvenList.Add(406);
        //myInvenList.Add(306);

        //myInvenList.Add(502);
        //myInvenList.Add(505);
        //myInvenList.Add(506);
        //for (int i = 501; i < 513; i++)
        //{
        //    myInvenList.Add(i);
        //}

        //!���߿� ��ġ ���� �ʼ�

    }

    public void ItemRoutine()
    {
        //Debug.Log("ItemManager��");
        ClassifyAddList();
        myInvenList.Clear();
        OnItemsUpdated?.Invoke();
    }


    // Start is called before the first frame update
    void Start()
    {
        //myInvenList.Add(406);
        //myInvenList.Add(306);
        // 15�� 12�� ��������
        //myInvenList.Add(406);
        myInvenList.Add(306);
        //myInvenList.Add(404);
        //myInvenList.Add(305);
        //myInvenList.Add(302);
        //myInvenList.Add(600);
        //myInvenList.Add(601);
        //myInvenList.Add(602);
        //myInvenList.Add(100);
        //myInvenList.Add(101);
        //myInvenList.Add(504);
        //myInvenList.Add(504);
        //myInvenList.Add(801);
        //myInvenList.Add(1000);
        //myInvenList.Add(1001);
        //myInvenList.Add(1002);
        //myInvenList.Add(915);
        //myInvenList.Add(705);
        //myInvenList.Add(901);
        //myInvenList.Add(905);

        //for (int i = 301; i < 325; i++)
        //{
        //    myInvenList.Add(i);
        //}
        for (int i = 400; i < 407; i++)
        {
            myInvenList.Add(i);
        }
        ItemRoutine();

    }

    // Update is called once per frame
    void Update()
    {
        //ClassifyAddList();
        //myInvenList.Clear();

    }

    // �������� ����� ���ؼ� ��� ����Ʈ�� Add���� �Ǵ��ϴ� �Լ�
    //{ ClassifyAddList()
    void ClassifyAddList()
    {
        // ������ ���Ƿ� ������ �־ �̻��
        //string[] filePaths = {
        //    "EMERGENCY",
        //    "FRESHFOOD",
        //    "ROOTFOOD",
        //    "ROOTMATERIAL",
        //    "ROOTWEAPON",
        //    "SPOILEDFOOD"
        //};
        //for (int i = 0; i < 6; i++)
        //{ 
        //    List<Dictionary<string, object>> test = CSVReader.Read(filePaths[i]);
        //}


        // �κ����� �������� ������ ���� �۵�
        if (myInvenList.Count != 0)
        {
            for (int i = 0; i < myInvenList.Count; i++)
            {
                Categorize(myInvenList[i]);
            }
        }



    }
    //} ClassifyAddList()


    //{ Categorize()
    public void Categorize(int id)
    {
        // (0 ~ 3) ROOTEMERGENCY => ���� ����Ʈ�� �߰�
        if (id >= 0 && id <= 3)
        {
            myMediList.Add(id);
        }
        // (100 ~ 104) EMERGENCY => ���� ����Ʈ�� �߰�
        if (id >= 100 && id <= 104)
        {
            myMediList.Add(id);
        }
        // (301 ~ 324) MAKINGWEAPON => ���� ����Ʈ�� �߰�
        if (id >= 301 && id <= 324)
        {
            myWeaponList.Add(id);
        }
        // (400 ~ 406) ROOTWEAPON => ���� ����Ʈ�� �߰�
        if (id >= 400 && id <= 406)
        {
            myWeaponList.Add(id);
        }
        // (501 ~ 512) MAKINGMATERIAL => ��Ÿ ����Ʈ�� �߰�
        if (id >= 501 && id <= 512)
        {
            myETCList.Add(id);
        }
        // (600 ~ 605) ROOTMATERIAL => ��Ÿ ����Ʈ�� �߰�
        if (id >= 600 && id <= 605)
        {
            myETCList.Add(id);
        }
        // (700 ~ 713) FRESHFOOD => ���� ����Ʈ�� �߰�
        if (id >= 700 && id <= 713)
        {
            myMediList.Add(id);
        }
        // (800 ~ 813) SPOILEDFOOD => ���� ����Ʈ�� �߰�
        if (id >= 800 && id <= 813)
        {
            myMediList.Add(id);
        }
        // (900 ~ 917) ROOTFOOD => ���� ����Ʈ�� �߰�
        if (id >= 900 && id <= 917)
        {
            myMediList.Add(id);
        }
        // (900 ~ 917) MAKINGFOOD => ���� ����Ʈ�� �߰�
        if (id >= 1000 && id <= 1016)
        {
            myMediList.Add(id);
        }
    }

    //// �ƾ��� �߰��� Action�� ���ؼ� �߰� & ���
    //public void AddItem(int itemId)
    //{
    //    myInvenList.Add(itemId);
    //    OnItemAdded?.Invoke();
    //    ClassifyAddList();
    //    myInvenList.Clear();
    //    inventoryContent.WeaponItemCreate();


    //}

    //// ������ ���Ž� Action�� ���ؼ� ���� & ��� 
    //public void RemoveItem(int itemId)
    //{
    //    myETCList.Remove(itemId);
    //    myMediList.Remove(itemId);
    //    myWeaponList.Remove(itemId);
    //    OnItemRemoved?.Invoke();
    //    inventoryContent.WeaponItemCreate();
    //}


    //} Categorize()

    //{ DebugLog()
    // ����׿� 
//    public void DebugLog()
//    {
//        Debug.Log("--------------�κ�-----------------");
//        Debug.Log("------------����-----------");
//        for (int i = 0; i < myWeaponList.Count; i++)
//        {
//            Debug.LogFormat("myWeaponList ID: {0}", myWeaponList[i]);
//        }
//;
//        Debug.Log("------------����-----------");
//        for (int i = 0; i < myMediList.Count; i++)
//        {
//            Debug.LogFormat("myMediList ID: {0}", myMediList[i]);
//        }

//        Debug.Log("------------��Ÿ-----------");
//        for (int i = 0; i < myETCList.Count; i++)
//        {
//            Debug.LogFormat("myETCList ID: {0}", myETCList[i]);
//        }
//        Debug.Log("--------------�κ���----------------");
//    }
//    //{ DebugLog()


}
