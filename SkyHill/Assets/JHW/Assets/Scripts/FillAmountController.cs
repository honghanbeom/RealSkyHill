using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpController : MonoBehaviour
{
    public Image image; // UI Image ������Ʈ

    // �ִ� ü�� ���� ����
    public float maxHp = 100.0f;
    public float decreaseRate = 1.0f; // ���� �ӵ�
    public float increaseRate = 1.0f; // ���� �ӵ�

    void Start()
    {
        // �ʱ� Fill Amount ����
        UpdateFillAmount(UserInformation.player.hp);
    }

    // Fill Amount�� ������Ʈ�ϴ� �Լ�
    public void UpdateFillAmount(float hpValue)
    {
        // hpValue�� 0���� 1 ������ Fill Amount ������ ��ȯ
        float fillAmount = hpValue / maxHp;

        // Fill Amount ������Ʈ
        image.fillAmount = fillAmount;
    }


    // Ư�� ���ǿ��� hunger ���� ���ҽ�Ű�� �Լ�
    public void DecreaseHunger()
    {
        UserInformation.player.hp -= decreaseRate;
        UserInformation.player.hp = Mathf.Clamp(UserInformation.player.hp, 0f, maxHp); // �� ����

        UpdateFillAmount(UserInformation.player.hp);
    }

    // Ư�� ���ǿ��� hunger ���� ������Ű�� �Լ�
    public void IncreaseHunger()
    {
        UserInformation.player.hp += increaseRate;
        UserInformation.player.hp = Mathf.Clamp(UserInformation.player.hp, 0f, maxHp); // �� ����

        UpdateFillAmount(UserInformation.player.hp);
    }



}
