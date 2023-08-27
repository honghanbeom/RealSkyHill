using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UserControl : MonoBehaviour
{


    private bool isMoving = false;
    private Vector3 targetPosition;

    public Transform userTarget;

    public float cameraMoving = 0.125f;
    public float decreaseRate = 1.0f;
    public float increaseRate = 1.0f;
    public float maxHunger = 100.0f;


    public Animator animator; // Animator 컴포넌트

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // Animator 컴포넌트 가져오기
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (EventSystem.current.IsPointerOverGameObject())
            {
                // UI 오브젝트 위에 있는 경우에 실행할 코드 작성

                Debug.Log("마우스 클릭! UI 위에 있음");


            }
            else
            {
                // UI 오브젝트 위에 없는 경우에 실행할 코드 작성
                Debug.Log("마우스 클릭! UI 위에 없음");


                // 마우스 클릭 위치를 월드 좌표로 변환
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;

                // 마우스 클릭한 위치에 해당하는 오브젝트 찾기
                Collider2D collider = Physics2D.OverlapPoint(mousePosition);
                //Debug.LogFormat("도대체 뭘 누른거지?? name: {0}, tag: {1}", collider.gameObject.name, collider.gameObject.tag);

                if (collider != null && collider.CompareTag("PlayerMoving"))
                {

                    targetPosition = collider.transform.position;
                    targetPosition.y -= 4.43f;
                    targetPosition.x -= 1.35f;
                    isMoving = true;

                    //DecreaseHunger();
                    //Debug.LogFormat("배고픔 {0}", UserInformation.player.hunger);
                }
                

            }
        }

        if (isMoving)
        {
            // 플레이어를 클릭한 위치로 부드럽게 이동
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5f);
            animator.SetBool("userWalking", true); // "IsRunning" 파라미터를 true로 설정하여 "Run" 애니메이션 작동

            // 도착했을 때 이동 멈추기
            if (transform.position == targetPosition)
            {
                isMoving = false;
                animator.SetBool("userWalking", false); // "IsRunning" 파라미터를 false로 설정하여 "Run" 애니메이션 중지
            }
        }


    }
}
