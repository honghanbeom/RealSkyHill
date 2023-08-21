using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerController : MonoBehaviour
{
    public Image image; // UI Image ������Ʈ

    // �ִ� ����� ���� ����
    public float maxHunger = 100.0f;

    public float decreaseRate = 1.0f; // ���� �ӵ�
    public float increaseRate = 1.0f; // ���� �ӵ�

    void Start()
    {
        // �ʱ� Fill Amount ����
        UpdateFillAmount(UserInformation.player.hunger);
    }

    // Fill Amount�� ������Ʈ�ϴ� �Լ�
    public void UpdateFillAmount(float hungerValue)
    {
        // hungerValue�� 0���� 1 ������ Fill Amount ������ ��ȯ
        float fillAmount = hungerValue / maxHunger;

        // Fill Amount ������Ʈ
        image.fillAmount = fillAmount;
    }


    // Ư�� ���ǿ��� hunger ���� ���ҽ�Ű�� �Լ�
    public void DecreaseHunger()
    {
        UserInformation.player.hunger -= decreaseRate;
        UserInformation.player.hunger = Mathf.Clamp(UserInformation.player.hunger, 0f, maxHunger); // �� ����

        UpdateFillAmount(UserInformation.player.hunger);
    }

    // Ư�� ���ǿ��� hunger ���� ������Ű�� �Լ�
    public void IncreaseHunger()
    {
        UserInformation.player.hunger += increaseRate;
        UserInformation.player.hunger = Mathf.Clamp(UserInformation.player.hunger, 0f, maxHunger); // �� ����

        UpdateFillAmount(UserInformation.player.hunger);
    }


}
