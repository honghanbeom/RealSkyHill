using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    public List<object> myList = new List<object>();

    // Start is called before the first frame update
    void Start()
    {
        // 파일의 경로 설정
        string filePath = "EMERGENCY"; // 파일 이름만 지정
        List<Dictionary<string, object>> test = CSVReader.Read(filePath);

        // Resources 폴더 아래의 파일 로드

        for (int i = 0; i < test.Count; i++)
        {
            //Debug.Log("i = " + i + "[" + test[i]["EMERGENCY_NAME"].ToString() + "]"
            //    + "[" + test[i]["ID"].ToString() + "]"
            //    + "[" + test[i]["HP"].ToString() + "]"
            //    + "[" + test[i]["COM1"].ToString() + "]"
            //    + "[" + test[i]["COM2"].ToString() + "]"
            //    + "[" + test[i]["COM3"].ToString() + "]");

            myList.Add(test[i]["EMERGENCY_NAME"].ToString());

            Debug.Log(myList[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
