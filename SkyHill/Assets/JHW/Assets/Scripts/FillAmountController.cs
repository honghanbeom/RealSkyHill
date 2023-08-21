using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpController : MonoBehaviour
{
    public Image image; // UI Image 컴포넌트

    // 최대 체력 값을 설정
    public float maxHp = 100.0f;
    public float decreaseRate = 1.0f; // 감소 속도
    public float increaseRate = 1.0f; // 증가 속도

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


    // 특정 조건에서 hunger 값을 감소시키는 함수
    public void DecreaseHunger()
    {
        UserInformation.player.hp -= decreaseRate;
        UserInformation.player.hp = Mathf.Clamp(UserInformation.player.hp, 0f, maxHp); // 값 제한

        UpdateFillAmount(UserInformation.player.hp);
    }

    // 특정 조건에서 hunger 값을 증가시키는 함수
    public void IncreaseHunger()
    {
        UserInformation.player.hp += increaseRate;
        UserInformation.player.hp = Mathf.Clamp(UserInformation.player.hp, 0f, maxHp); // 값 제한

        UpdateFillAmount(UserInformation.player.hp);
    }



}
