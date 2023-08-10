using UnityEngine;

public class DataLogger : MonoBehaviour
{
    void Start()
    {
        // TestReader 클래스의 데이터 초기화
        TestReader.Initialize();

        // TestReader 클래스의 데이터 가져와서 로그 출력
        foreach (int data in TestReader.dropItemData)
        {
            Debug.Log(data);
        }
    }
}
