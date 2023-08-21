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
        DropItem.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("±Â");
        if (changeImage != null && spriteRenderer != null)
        {
            if (gb.CompareTag("Clickable"))
            {
                //gb.SetActive(false);
                spriteRenderer.sprite = changeImage;
            }
        }
        
        int randomIndex = Random.Range(0, DropItem.dropItemData.Count);

        Debug.Log(randomIndex);

        ItemManager.myInvenList.Add(randomIndex);
        ItemManager.itemManager.ItemRoutine();
    }
}
