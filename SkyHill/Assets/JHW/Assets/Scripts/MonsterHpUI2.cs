using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHpUI2 : MonoBehaviour
{
    //public Image hpFillImage; // 체력을 나타내는 UI Image 컴포넌트
    public Text monsterHpText; // 체력 값을 표시할 UI Text 컴포넌트

    public float maxHp = 30.0f;
    public float decreaseRate = 1.0f;
    public float increaseRate = 1.0f;

    private void Awake()
    {
        monsterHpText.text = "  30 " + "/" + " 30";
    }

    public void Update()
    {

    }
    public void MonsterUIUpdate2(float hpValue2)
    {
        float fillAmount = hpValue2 / maxHp;
        //hpFillImage.fillAmount = fillAmount;

        monsterHpText.text = hpValue2.ToString("0") + " / " + "30";
    }
}


