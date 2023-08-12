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
            // ���콺 Ŭ�� ��ġ�� ���� ��ǥ�� ��ȯ
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            // ���콺 Ŭ���� ��ġ�� �ش��ϴ� ������Ʈ ã��
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
            // �÷��̾ Ŭ���� ��ġ�� �ε巴�� �̵�
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5f);

            // �������� �� �̵� ���߱�
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }


    
    
}