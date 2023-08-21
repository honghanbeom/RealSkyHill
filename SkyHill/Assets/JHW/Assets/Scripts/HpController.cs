using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillAmountController : MonoBehaviour
{
    public Image image; // UI Image ������Ʈ

    // �ִ� ü�� ���� ����
    public float maxHp = 100.0f;

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
}
