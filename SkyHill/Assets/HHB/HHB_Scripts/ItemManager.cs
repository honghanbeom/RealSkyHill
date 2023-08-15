using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager itemManager;
    // �κ� ����Ʈ
    public List<int> myInvenList = new List<int>();

    // �������� ����Ʈ (����, ����, ��Ÿ)
    public static List<int> myWeaponList = new List<int>();
    public static List<int> myMediList = new List<int>();
    public static List<int> myETCList = new List<int>() ;

    
    private void Awake()
    {
        itemManager = this;
        //myInvenList.Add(100);
        //myInvenList.Add(700);
        //myInvenList.Add(900);
        //myInvenList.Add(806);
        //myInvenList.Add(605);
        myInvenList.Add(401);
        myInvenList.Add(401);
        myInvenList.Add(402);
        myInvenList.Add(403);
        myInvenList.Add(403);
        myInvenList.Add(402);
        myInvenList.Add(402);
        myInvenList.Add(402);
        //myInvenList.Add(600);

        //myInvenList.Add(502);
        //myInvenList.Add(505);
        //myInvenList.Add(506);
        //for (int i = 501; i < 513; i++)
        //{
        //    myInvenList.Add(i);
        //}

        // !���߿� ��ġ ���� �ʼ�
        ClassifyAddList();
        DebugLog();

        myInvenList.Clear();


    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        // (100 ~ 108) EMERGENCY => ���� ����Ʈ�� �߰�
        if (id >= 100 && id <= 108)
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

    }
    //} Categorize()

    //{ DebugLog()
    // ����׿� 
    public void DebugLog()
    {
        Debug.Log("--------------�κ�-----------------");
        Debug.Log("------------����-----------");
        for (int i = 0; i < myWeaponList.Count; i++)
        {
            Debug.LogFormat("myWeaponList ID: {0}", myWeaponList[i]);
        }
;
        Debug.Log("------------����-----------");   
        for (int i = 0; i < myMediList.Count; i++)
        {
            Debug.LogFormat("myMediList ID: {0}", myMediList[i]);
        }

        Debug.Log("------------��Ÿ-----------");
        for (int i = 0; i < myETCList.Count; i++)
        {
            Debug.LogFormat("myETCList ID: {0}", myETCList[i]);
        }
        Debug.Log("--------------�κ���----------------");
    }
    //{ DebugLog()


}