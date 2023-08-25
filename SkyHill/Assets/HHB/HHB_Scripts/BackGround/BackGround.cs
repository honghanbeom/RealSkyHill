using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Transform userTarget;

    public float cameraSpeed = 0.1f;

    public float yOffSet; // ī�޶���� �Ÿ� ����

    public Vector3 UserPosition;


    private void Update()
    {

        BackGroundMove();

    }


    private void BackGroundMove()
    {
        // ��� ������Ʈ�� y ��ġ�� yOffset�� ���� ���� �����ͼ� ī�޶� ��ġ ���
        Vector3 desiredPosition = new Vector3(transform.position.x, userTarget.position.y + yOffSet, transform.position.z);
        // ������ �� ��ġ ���
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, cameraSpeed);
        // ī�޶� ��ġ�� ������Ʈ
        transform.position = desiredPosition;

    }
}
