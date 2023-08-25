using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClickChange : MonoBehaviour
{
    private GameObject gb;

    public Sprite changeImage;

    private SpriteRenderer spriteRenderer;
    private bool isClicked = false;

    private Transform user;
    // Start is called before the first frame update
    void Awake()
    {
        user = GameObject.Find("User").transform;
        gb = this.gameObject;
        spriteRenderer = GetComponent<SpriteRenderer>();
        //DropItem.dropItem.Initialize();
    }

    private void OnMouseDown()
    {
        float dis = Vector3.Distance(gb.transform.position, user.transform.position);
        if (!isClicked)
        {
            if (dis <= 5f)
            {
                //Debug.Log("±Â");
                if (changeImage != null && spriteRenderer != null)
                {
                    if (gb.CompareTag("Clickable"))
                    {
                        //gb.SetActive(false);
                        spriteRenderer.sprite = changeImage;
                    }
                }

                int randomIndex = Random.Range(0, DropItem.dropItem.dropItemData.Count);
                ItemManager.myInvenList.Add(DropItem.dropItem.dropItemData[randomIndex]);
                ItemManager.itemManager.ItemRoutine();
                isClicked = true;
            }

        }
    }
}
