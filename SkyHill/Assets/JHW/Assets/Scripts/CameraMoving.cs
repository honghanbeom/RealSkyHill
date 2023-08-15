using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraMoving : MonoBehaviour
{

    public Transform userTarget;

    public float cameraSpeed = 0.125f;

    public float yOffSet; // 카메라와의 거리 조절

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
        // 대상 오브젝트의 y 위치에 yOffset을 더한 값을 가져와서 카메라 위치 계산
        Vector3 desiredPosition = new Vector3(transform.position.x, userTarget.position.y + yOffSet, transform.position.z);
        // 스무딩 된 위치 계산
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, cameraSpeed);
        // 카메라 위치를 업데이트
        transform.position = smoothedPosition;

    }
}
