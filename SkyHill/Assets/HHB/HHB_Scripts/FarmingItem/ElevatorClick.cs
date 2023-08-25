using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ElevatorClick : MonoBehaviour
{
    private GameObject gb;
    private Transform user;

    // Start is called before the first frame update
    void Awake()
    {
        user = GameObject.Find("User").transform;
        gb = this.gameObject;
    }

    private void OnMouseDown()
    {
        float dis = Vector3.Distance(gb.transform.position, user.transform.position);
        if (dis <= 5f)
        {
            if (gb.CompareTag("EleDoor"))
            {
                StartCoroutine(ElevatorClose(1.0f));
            }
        }
    }

    private IEnumerator ElevatorClose(float delay)
    {
        gb.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        yield return new WaitForSeconds(delay);
        gb.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
