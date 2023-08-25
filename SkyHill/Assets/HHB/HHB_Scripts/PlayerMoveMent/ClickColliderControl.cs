using UnityEngine;
using System.Collections;

public class ClickColliderControl : MonoBehaviour
{
    private Collider2D myCollider; 

    private void Start()
    {
        myCollider = GetComponent<Collider2D>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            myCollider.enabled = false;
            StartCoroutine(ColliderControl(3.0f)); 
        }
    }

    private IEnumerator ColliderControl(float delay)
    {
        yield return new WaitForSeconds(delay);

        myCollider.enabled = true;
    }
}
