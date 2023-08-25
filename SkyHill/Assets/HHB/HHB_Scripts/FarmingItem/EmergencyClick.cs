using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EmergencyClick : MonoBehaviour
{
    private GameObject gb;

    private Transform user;
    // Start is called before the first frame update
    void Awake()
    {
        user = GameObject.Find("User").transform;
        gb = this.gameObject;

        //DropItem.dropItem.Initialize();
    }

    private void OnMouseDown()
    {
        float dis = Vector3.Distance(gb.transform.position, user.transform.position);
        if (dis <= 5f)
        {
            if (gb.CompareTag("Clickable"))
            {
                // emergency (100 ~ 105)
                int makingEmergencyIndex = Random.Range(100, 105);
                ItemManager.myInvenList.Add(makingEmergencyIndex);
                ItemManager.itemManager.ItemRoutine();
                Destroy(gb);
            }
        }
    }
}
