using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerController : MonoBehaviour
{
    public Image image; // UI Image 컴포넌트

    // 최대 배고픔 값을 설정
    public float maxHunger = 100.0f;

    public float decreaseRate = 1.0f; // 감소 속도
    public float increaseRate = 1.0f; // 증가 속도

    void Start()
    {
        // 초기 Fill Amount 설정
        UpdateFillAmount(UserInformation.player.hunger);
    }

    // Fill Amount를 업데이트하는 함수
    public void UpdateFillAmount(float hungerValue)
    {
        // hungerValue를 0부터 1 사이의 Fill Amount 값으로 변환
        float fillAmount = hungerValue / maxHunger;

        // Fill Amount 업데이트
        image.fillAmount = fillAmount;
    }


    // 특정 조건에서 hunger 값을 감소시키는 함수
    public void DecreaseHunger()
    {
        UserInformation.player.hunger -= decreaseRate;
        UserInformation.player.hunger = Mathf.Clamp(UserInformation.player.hunger, 0f, maxHunger); // 값 제한

        UpdateFillAmount(UserInformation.player.hunger);
    }

    // 특정 조건에서 hunger 값을 증가시키는 함수
    public void IncreaseHunger()
    {
        UserInformation.player.hunger += increaseRate;
        UserInformation.player.hunger = Mathf.Clamp(UserInformation.player.hunger, 0f, maxHunger); // 값 제한

        UpdateFillAmount(UserInformation.player.hunger);
    }


}
