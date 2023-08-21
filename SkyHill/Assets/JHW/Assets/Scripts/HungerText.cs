using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerText : MonoBehaviour
{
    public Text hungerText; // ü�� ���� ǥ���� UI Text ������Ʈ
    public Image hungerFillImage; // ü���� ��Ÿ���� UI Image ������Ʈ


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
        hungerFillImage.fillAmount = fillAmount;

        hungerText.text = "HUNGER: " + hungerValue.ToString("0") + " / " + maxHunger.ToString("0");
    }



    public void DecreaseHp()
    {
        UserInformation.player.hunger -= decreaseRate;
        UserInformation.player.hunger = Mathf.Clamp(UserInformation.player.hunger, 0f, maxHunger);
        UpdateUI(UserInformation.player.hunger);
    }

    public void IncreaseHp()
    {
        UserInformation.player.hunger += increaseRate;
        UserInformation.player.hunger = Mathf.Clamp(UserInformation.player.hunger, 0f, maxHunger);
        UpdateUI(UserInformation.player.hunger);
    }
}
