using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeRoom : MonoBehaviour
{

    public GameObject blackOut;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Debug.Log("��Ҵ�!");
            blackOut.SetActive(false);
        }

    }
}