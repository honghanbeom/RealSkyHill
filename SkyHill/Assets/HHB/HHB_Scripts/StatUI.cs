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
        skillPointText.text = "스킬 포인트 :" + UserInformation.player.skillPoint.ToString();
    }

    public void SkillPointUI()
    {
        int str = UserInformation.player.str;
        int dex = UserInformation.player.dex;
        int spd = UserInformation.player.spd;
        int acc = UserInformation.player.hit;
        skillPointInfoText.text = "강도 : " + str.ToString() + "\n\n" +
                                  "속도 : " + dex.ToString() + "\n\n" +
                                  "민첩 : " + spd.ToString() + "\n\n" +
                                  "명중 : " + acc.ToString() + "\n\n";
    }

    public void LevelUI()
    { 
        int currentExp = UserInformation.player.exp;
        int maxExp = UserInformation.player.maxEXP;
        int userLevel = UserInformation.player.userLevel;

        levelText.text = currentExp.ToString() + "/" + maxExp.ToString();
        expText.text = "수준 : " + userLevel.ToString();
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
