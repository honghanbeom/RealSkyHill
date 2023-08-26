using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatUI : MonoBehaviour
{
    public static StatUI statUI;
    public Text skillPointText;
    public Text skillPointInfoText;
    public Text levelText;
    public Text expText;
    public Image expImage;

    private void Awake()
    {
        statUI = this;
    }

    public void LevelUpUI()
    { 
        skillPointText.text = "��ų ����Ʈ :" + UserInformation.player.skillPoint.ToString();
    }

    public void SkillPointUI()
    {
        int str = UserInformation.player.str;
        int dex = UserInformation.player.dex;
        int spd = UserInformation.player.spd;
        int acc = UserInformation.player.hit;
        skillPointInfoText.text = "���� : " + str.ToString() + "\n\n" +
                                  "�ӵ� : " + dex.ToString() + "\n\n" +
                                  "��ø : " + spd.ToString() + "\n\n" +
                                  "���� : " + acc.ToString() + "\n\n";
    }

    public void LevelUI()
    { 
        int currentExp = UserInformation.player.exp;
        int maxExp = UserInformation.player.maxEXP;
        int userLevel = UserInformation.player.userLevel;

        levelText.text = currentExp.ToString() + "/" + maxExp.ToString();
        expText.text = "���� : " + userLevel.ToString();
    }

    public void EXPFillAmount()
    {
        expImage.fillAmount = UserInformation.player.exp/UserInformation.player.maxEXP;
    }

    public void LevelUp()
    {
        if (UserInformation.player.exp >= UserInformation.player.maxEXP)
        {
            UserInformation.player.exp = 0;
            UserInformation.player.maxEXP += 50;
        }
        else { /* Do Nothing*/ }
    }
}
