using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHpUI : MonoBehaviour
{
    //public Image hpFillImage; // 체력을 나타내는 UI Image 컴포넌트
    public Text monsterHpText; // 체력 값을 표시할 UI Text 컴포넌트

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


