using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UserAttack : MonoBehaviour , IPointerClickHandler

{
    public GameObject uiImage3;

    public Animator animator; // Animator ������Ʈ



    // Start is called before the first frame update
    void Start()
    {
        /*animator = GetComponent<Animator>();*/ // Animator ������Ʈ ��������
        uiImage3 = GameObject.Find("AttackArea");
        ImageSc6();


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
            ImageSc6();
            animator.SetBool("SpearAttack", true); // "IsRunning" �Ķ���͸� true�� �����Ͽ� "Run" �ִϸ��̼� �۵�
        }




    }

    public void ImageSc6()
    {
        Vector3 uiImageScale = uiImage3.transform.localScale;

        Vector3 newScale = new Vector3(0.001f, 0.001f, 0);

        uiImage3.transform.localScale = newScale;
    }

}
