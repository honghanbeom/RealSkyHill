using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraMoving : MonoBehaviour
{

    public Transform userTarget;

    public float cameraSpeed = 0.125f;

    public float yOffSet; // ī�޶���� �Ÿ� ����

    public Vector3 UserPosition;


    //public void Start()
    //{
    //    UserPosition.x += 1.843f;
    //    UserPosition.y += 3.1725f;
    //}

    private void Update()
    {

        UserCamera();

    }


    private void UserCamera()
    {
        // ��� ������Ʈ�� y ��ġ�� yOffset�� ���� ���� �����ͼ� ī�޶� ��ġ ���
        Vector3 desiredPosition = new Vector3(transform.position.x, userTarget.position.y + yOffSet, transform.position.z);
        // ������ �� ��ġ ���
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, cameraSpeed);
        // ī�޶� ��ġ�� ������Ʈ
        transform.position = smoothedPosition;

    }
}
