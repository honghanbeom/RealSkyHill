using UnityEngine;

public class DataLogger : MonoBehaviour
{
    void Start()
    {
        // TestReader Ŭ������ ������ �ʱ�ȭ
        TestReader.Initialize();

        // TestReader Ŭ������ ������ �����ͼ� �α� ���
        foreach (int data in TestReader.dropItemData)
        {
            Debug.Log(data);
        }
    }
}
