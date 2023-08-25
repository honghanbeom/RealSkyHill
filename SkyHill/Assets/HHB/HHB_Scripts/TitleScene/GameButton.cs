using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text playGameText;
    private Color originalColor;

    void Awake()
    { 
        originalColor = Color.white;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        playGameText.text = "ªı ∞‘¿”";
        playGameText.color = new Color(0.91f, 0.84f, 0.24f);
    }

    public void OnPointerExit(PointerEventData eventData)
    { 
        playGameText.color = originalColor;  
    }


    public void NextScene()
    {
        SceneManager.LoadScene("HHB_GameScene");  
    }
}
