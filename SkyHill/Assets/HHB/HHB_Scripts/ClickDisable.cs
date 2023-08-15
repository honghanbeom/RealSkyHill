using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.EventSystems;

public class ClickDisable : MonoBehaviour
{
    private GameObject gb;
    // Start is called before the first frame update
    void Awake()
    {
        gb = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //{ fill amount로 열리는 효과 만들고 StartCourtine으로 일정 시간 후 원래대로 되돌리기
    private void OnMouseDown()
    {
        Debug.Log("굿");
        //string str = eventData.selectedObject.tag;
        if (gb.CompareTag("EleDoor"))
        {
            gb.SetActive(false);
        }
    }
}
