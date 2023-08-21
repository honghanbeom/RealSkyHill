using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickChange : MonoBehaviour
{
    private GameObject gb;

    public Sprite changeImage;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        gb = this.gameObject;
        spriteRenderer = GetComponent<SpriteRenderer>();
        //DropItem.dropItem.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("��");
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
    }
}
