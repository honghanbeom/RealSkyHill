using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HungerUI : MonoBehaviour
{
    public Text hungerText; 

    public float maxHunger = 100.0f;
    public float decreaseRate = 1.0f;
    public float increaseRate = 1.0f;

    void Start()
    {
        UpdateUI(UserInformation.player.hunger);
    }

    private void Update()
    {
        UpdateUI(UserInformation.player.hunger);
    }

    void UpdateUI(float hungerValue)
    {
        float fillAmount = hungerValue / maxHunger;
        //hpFillImage.fillAmount = fillAmount;

        hungerText.text =  hungerValue.ToString("0") + " / " + maxHunger.ToString("0");
    }

    public void DecreaseHunger()
    {
        UserInformation.player.hunger -= decreaseRate;
        UserInformation.player.hunger = Mathf.Clamp(UserInformation.player.hunger, 0f, maxHunger);
        UpdateUI(UserInformation.player.hunger);
    }

    public void IncreaseHunger()
    {
        UserInformation.player.hunger += increaseRate;
        UserInformation.player.hunger = Mathf.Clamp(UserInformation.player.hunger, 0f, maxHunger);
        UpdateUI(UserInformation.player.hunger);
    }
}
