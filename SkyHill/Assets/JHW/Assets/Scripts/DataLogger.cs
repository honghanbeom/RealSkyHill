using UnityEngine;

public class DataLogger : MonoBehaviour
{
    void Start()
    {
        // TestReader Ŭ������ ������ �ʱ�ȭ
        DropItem.Initialize();

        // TestReader Ŭ������ ������ �����ͼ� �α� ���
        foreach (int data in DropItem.dropItemData)
        {
            Debug.Log(data);
        }
    }
}
