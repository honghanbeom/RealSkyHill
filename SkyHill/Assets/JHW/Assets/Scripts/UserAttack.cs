using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UserAttack : MonoBehaviour , IPointerClickHandler

{
    public GameObject uiImage3;

    public Animator animator; // Animator 컴포넌트



    // Start is called before the first frame update
    void Start()
    {
        /*animator = GetComponent<Animator>();*/ // Animator 컴포넌트 가져오기
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
            Debug.Log("눌려진다 어택땅");
            ImageSc6();
            animator.SetBool("SpearAttack", true); // "IsRunning" 파라미터를 true로 설정하여 "Run" 애니메이션 작동
        }




    }

    public void ImageSc6()
    {
        Vector3 uiImageScale = uiImage3.transform.localScale;

        Vector3 newScale = new Vector3(0.001f, 0.001f, 0);

        uiImage3.transform.localScale = newScale;
    }

}
