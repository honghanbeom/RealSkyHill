using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpText : MonoBehaviour
{
    public Image hpFillImage; // 체력을 나타내는 UI Image 컴포넌트
    public Text hpText; // 체력 값을 표시할 UI Text 컴포넌트

    public float maxHp = 100.0f;
    public float decreaseRate = 1.0f;
    public float increaseRate = 1.0f;

    void Start()
    {
        UpdateUI(UserInformation.player.hp);
    }


    private void Update()
    {
        UpdateUI(UserInformation.player.hp);
    }
    void UpdateUI(float hpValue)
    {
        float fillAmount = hpValue / maxHp;
        hpFillImage.fillAmount = fillAmount;

        hpText.text = "HP: " + hpValue.ToString("0") + " / " + maxHp.ToString("0");
    }

    

    public void DecreaseHp()
    {
        UserInformation.player.hp -= decreaseRate;
        UserInformation.player.hp = Mathf.Clamp(UserInformation.player.hp, 0f, maxHp);
        UpdateUI(UserInformation.player.hp);
    }

    public void IncreaseHp()
    {
        UserInformation.player.hp += increaseRate;
        UserInformation.player.hp = Mathf.Clamp(UserInformation.player.hp, 0f, maxHp);
        UpdateUI(UserInformation.player.hp);
    }
}
