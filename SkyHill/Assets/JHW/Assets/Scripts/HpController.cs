using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillAmountController : MonoBehaviour
{
    public Image image; // UI Image 컴포넌트

    // 최대 체력 값을 설정
    public float maxHp = 100.0f;

    void Start()
    {
        // 초기 Fill Amount 설정
        UpdateFillAmount(UserInformation.player.hp);
    }

    // Fill Amount를 업데이트하는 함수
    public void UpdateFillAmount(float hpValue)
    {
        // hpValue를 0부터 1 사이의 Fill Amount 값으로 변환
        float fillAmount = hpValue / maxHp;

        // Fill Amount 업데이트
        image.fillAmount = fillAmount;
    }
}
