using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Transform userTarget;

    public float cameraSpeed = 0.1f;

    public float yOffSet; // 카메라와의 거리 조절

    public Vector3 UserPosition;


    private void Update()
    {

        BackGroundMove();

    }


    private void BackGroundMove()
    {
        // 대상 오브젝트의 y 위치에 yOffset을 더한 값을 가져와서 카메라 위치 계산
        Vector3 desiredPosition = new Vector3(transform.position.x, userTarget.position.y + yOffSet, transform.position.z);
        // 스무딩 된 위치 계산
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, cameraSpeed);
        // 카메라 위치를 업데이트
        transform.position = desiredPosition;

    }
}
