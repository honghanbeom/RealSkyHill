using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UserAttack2 : MonoBehaviour
{
    public GameObject uiImage4;

    public Animator animator; // Animator ������Ʈ



    // Start is called before the first frame update
    void Start()
    {
        /*animator = GetComponent<Animator>();*/ // Animator ������Ʈ ��������
        uiImage4 = GameObject.Find("AttackArea2");


    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnPointerClick(PointerEventData eventData)
    {

        if (gameObject.CompareTag("Attack"))
        {
            Debug.Log("�������� ���ö�");
            ImageSc8();
            animator.SetBool("SpearAttack", true); // "IsRunning" �Ķ���͸� true�� �����Ͽ� "Run" �ִϸ��̼� �۵�
        }




    }

    public void ImageSc8()
    {
        Vector3 uiImageScale = uiImage4.transform.localScale;

        Vector3 newScale = new Vector3(1f, 1f, 1f);

        uiImage4.transform.localScale = newScale;
    }

}
