using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHpUI : MonoBehaviour
{
    //public Image hpFillImage; // ü���� ��Ÿ���� UI Image ������Ʈ
    public Text monsterHpText; // ü�� ���� ǥ���� UI Text ������Ʈ

    public float maxHp = 20.0f;
    public float decreaseRate = 1.0f;
    public float increaseRate = 1.0f;

    private void Awake()
    {
        monsterHpText.text = "  20 " + "/" + " 20";
    }

    public void Update()
    {
       
    }
    public void MonsterUIUpdate(float hpValue)
    {
        float fillAmount = hpValue / maxHp;
        //hpFillImage.fillAmount = fillAmount;s

        monsterHpText.text = hpValue.ToString("0") + " / " + "20";
    }
}


