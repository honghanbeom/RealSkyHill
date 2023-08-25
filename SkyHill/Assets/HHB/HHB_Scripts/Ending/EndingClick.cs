using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EndingClick : MonoBehaviour
{
    void OnMouseDown()
    {
        if (gameObject.CompareTag("Clickable"))
        {
            SceneManager.LoadScene("EndingScene");
        }
    }
}
