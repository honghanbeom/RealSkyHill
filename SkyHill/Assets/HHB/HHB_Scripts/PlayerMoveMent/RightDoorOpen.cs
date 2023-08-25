using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDoorOpen : MonoBehaviour
{
    public Sprite changeImage;
    private Sprite originalImage;
    private SpriteRenderer spriteRenderer;

    private Vector3 originalPosition;
    private Vector3 originalScale;
    private Quaternion originalRotation;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalImage = spriteRenderer.sprite;
        originalScale = transform.localScale;
        originalRotation = transform.rotation;
        originalPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        spriteRenderer.sprite = changeImage;
        transform.localPosition = new Vector3(-0.42f, -1.1f, 0f);
        transform.localScale = new Vector3(0.8f, 1f, 1f);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));

        yield return new WaitForSeconds(0.6f);

        transform.localScale = originalScale;
        transform.rotation = originalRotation;
        spriteRenderer.sprite = originalImage;
        transform.position = originalPosition;
    }
}
