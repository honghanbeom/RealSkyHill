using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour
{


    private bool isMoving = false;
    private Vector3 targetPosition;

    public Transform userTarget;

    public float cameraMoving = 0.125f;



    //Animation animation = null;
    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            // 마우스 클릭 위치를 월드 좌표로 변환
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            // 마우스 클릭한 위치에 해당하는 오브젝트 찾기
            Collider2D collider = Physics2D.OverlapPoint(mousePosition);
            Debug.LogFormat("도대체 뭘 누른거지?? name: {0}, tag: {1}", collider.gameObject.name, collider.gameObject.tag);

            if (collider != null && collider.CompareTag("PlayerMoving"))
            {
                targetPosition = collider.transform.position;
                targetPosition.y -= 4.43f;
                targetPosition.x -= 1.25f;
                isMoving = true;
                Debug.LogFormat("눌렸다!");
            }

        }

        
        if (isMoving)
        {
            // 플레이어를 클릭한 위치로 부드럽게 이동
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5f);

            // 도착했을 때 이동 멈추기
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }


    }




}