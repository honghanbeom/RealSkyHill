using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classify : MonoBehaviour
{
    // �κ� ����Ʈ
    private List<int> myInvenList = new List<int>();

    // �������� ����Ʈ (����, ����, ��Ÿ)
    public List<int> myWeaponList = new List<int>();
    public List<int> myMediList = new List<int>();
    public List<int> myETCList = new List<int>() ;
    private void Awake()
    {
        //myInvenList.Add(100);
        //myInvenList.Add(700);
        //myInvenList.Add(900);
        //myInvenList.Add(806);
        //myInvenList.Add(605);
        //myInvenList.Add(401);

        // !���߿� ��ġ ���� �ʼ�
        ClassifyAddList();
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
            for(int i = 0;  i < myInvenList.Count; i++) 
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
        // (400 ~ 406) ROOTWEAPON => ���� ����Ʈ�� �߰�
        else if (id >= 400 && id <= 406)
        {
            myWeaponList.Add(id);
        }
        // (600 ~ 605) ROOTMATERIAL => ��Ÿ ����Ʈ�� �߰�
        else if (id >= 600 && id <= 605)
        {
            myETCList.Add(id);
        }
        // (700 ~ 713) FRESHFOOD => ���� ����Ʈ�� �߰�
        else if (id >= 700 && id <= 713)
        {
            myMediList.Add(id);
        }
        // (800 ~ 813) SPOILEDFOOD => ���� ����Ʈ�� �߰�
        else if (id >= 800 && id <= 813)
        {
            myMediList.Add(id);
        }
        // (900 ~ 917) ROOTFOOD => ���� ����Ʈ�� �߰�
        else if (id >= 900 && id <= 917)
        {
            myMediList.Add(id);
        }

        // �з��ϰ� ����Ʈ �ʱ�ȭ
        myInvenList.Remove(id);
    }
    //} Categorize()

    //{ DebugLog()
    // ����׿� 
    public void DebugLog()
    {
        Debug.Log("�κ�");
        for (int i = 0; i < myWeaponList.Count; i++)
        {
            Debug.Log("����");
            Debug.LogFormat("myWeaponList ID: {0}", myWeaponList[i]);
        }
;
        for (int i = 0; i < myMediList.Count; i++)
        {
            Debug.Log("����");   
            Debug.LogFormat("myMediList ID: {0}", myMediList[i]);
        }

        for (int i = 0; i < myETCList.Count; i++)
        {
            Debug.Log("��Ÿ");
            Debug.LogFormat("myETCList ID: {0}", myETCList[i]);
        }
    }
    //{ DebugLog()

}
