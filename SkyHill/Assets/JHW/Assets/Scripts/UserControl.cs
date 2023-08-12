using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour
{


    private bool isMoving = false;
    private Vector3 targetPosition;

    //Animation animation = null;
    



    //public void OnMouseEnter()
    //{
    //    if(CompareTag("Clickale"))
    //    {



    //        blackOut.SetActive(false);
    //    }
    //}


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

            if (collider != null && collider.CompareTag("ClickMoving"))
            {
                targetPosition = collider.transform.position;
                targetPosition.y -= 4.21f;
                targetPosition.x -= 2.441f;
                isMoving = true;
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