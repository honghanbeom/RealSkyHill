using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserControl : MonoBehaviour
{


    private bool isMoving = false;
    private Vector3 targetPosition;

    public Transform userTarget;

    public float cameraMoving = 0.125f;
    public float decreaseRate = 1.0f;
    public float increaseRate = 1.0f;
    public float maxHunger = 100.0f;



    public Animator animator; // Animator ������Ʈ





    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // Animator ������Ʈ ��������
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
            Debug.LogFormat("����ü �� ��������?? name: {0}, tag: {1}", collider.gameObject.name, collider.gameObject.tag);

            if (collider != null && collider.CompareTag("PlayerMoving"))
            {
                targetPosition = collider.transform.position;
                targetPosition.y -= 4.43f;
                targetPosition.x -= 1.25f;
                isMoving = true;
                Debug.LogFormat("���ȴ�!");

                DecreaseHp();
                Debug.LogFormat("����� {0}", UserInformation.player.hunger);
            }

        }

        
        if (isMoving)
        {
            // �÷��̾ Ŭ���� ��ġ�� �ε巴�� �̵�
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5f);
            animator.SetBool("userWalking", true); // "IsRunning" �Ķ���͸� true�� �����Ͽ� "Run" �ִϸ��̼� �۵�

            // �������� �� �̵� ���߱�
            if (transform.position == targetPosition)
            {
                isMoving = false;
                animator.SetBool("userWalking", false); // "IsRunning" �Ķ���͸� false�� �����Ͽ� "Run" �ִϸ��̼� ����
            }
        }


    }

    public void DecreaseHp()
    {
        UserInformation.player.hunger -= 1;
        UserInformation.player.hunger = Mathf.Clamp(UserInformation.player.hunger, 0f, maxHunger);
        //UpdateUI(UserInformation.player.hunger);
    }

    public void IncreaseHp()
    {
        UserInformation.player.hunger += 1;
        UserInformation.player.hunger = Mathf.Clamp(UserInformation.player.hunger, 0f, maxHunger);
        //UpdateUI(UserInformation.player.hunger);
    }




}