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

    //{ fill amount�� ������ ȿ�� ����� StartCourtine���� ���� �ð� �� ������� �ǵ�����
    private void OnMouseDown()
    {
        Debug.Log("��");
        //string str = eventData.selectedObject.tag;
        if (gb.CompareTag("EleDoor"))
        {
            gb.SetActive(false);
        }
    }
}
