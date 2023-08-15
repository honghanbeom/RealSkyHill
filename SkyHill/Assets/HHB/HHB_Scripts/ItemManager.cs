using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager itemManager;
    // 인벤 리스트
    public List<int> myInvenList = new List<int>();

    // 나눠야할 리스트 (무기, 의학, 기타)
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

        // !나중에 위치 변경 필수
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

    // 아이템을 헤더와 비교해서 어디 리스트에 Add할지 판단하는 함수
    //{ ClassifyAddList()
    void ClassifyAddList()
    {
        // 지금은 임의로 파일을 넣어서 미사용
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


        // 인벤에서 아이템이 존재할 때만 작동
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
        // (100 ~ 108) EMERGENCY => 의학 리스트에 추가
        if (id >= 100 && id <= 108)
        {
            myMediList.Add(id);
        }
        // (301 ~ 324) MAKINGWEAPON => 무기 리스트에 추가
        if (id >= 301 && id <= 324)
        {
            myWeaponList.Add(id);
        }
        // (400 ~ 406) ROOTWEAPON => 무기 리스트에 추가
        if (id >= 400 && id <= 406)
        {
            myWeaponList.Add(id);
        }
        // (501 ~ 512) MAKINGMATERIAL => 기타 리스트에 추가
        if (id >= 501 && id <= 512)
        {
            myETCList.Add(id);
        }
        // (600 ~ 605) ROOTMATERIAL => 기타 리스트에 추가
        if (id >= 600 && id <= 605)
        {
            myETCList.Add(id);
        }
        // (700 ~ 713) FRESHFOOD => 의학 리스트에 추가
        if (id >= 700 && id <= 713)
        {
            myMediList.Add(id);
        }
        // (800 ~ 813) SPOILEDFOOD => 의학 리스트에 추가
        if (id >= 800 && id <= 813)
        {
            myMediList.Add(id);
        }
        // (900 ~ 917) ROOTFOOD => 의학 리스트에 추가
        if (id >= 900 && id <= 917)
        {
            myMediList.Add(id);
        }

    }
    //} Categorize()

    //{ DebugLog()
    // 디버그용 
    public void DebugLog()
    {
        Debug.Log("--------------인벤-----------------");
        Debug.Log("------------무기-----------");
        for (int i = 0; i < myWeaponList.Count; i++)
        {
            Debug.LogFormat("myWeaponList ID: {0}", myWeaponList[i]);
        }
;
        Debug.Log("------------의학-----------");   
        for (int i = 0; i < myMediList.Count; i++)
        {
            Debug.LogFormat("myMediList ID: {0}", myMediList[i]);
        }

        Debug.Log("------------기타-----------");
        for (int i = 0; i < myETCList.Count; i++)
        {
            Debug.LogFormat("myETCList ID: {0}", myETCList[i]);
        }
        Debug.Log("--------------인벤끝----------------");
    }
    //{ DebugLog()


}
