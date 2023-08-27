using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonArea : MonoBehaviour
{
    //public FightCoroutine fightCoroutine;

    FightCoroutine fightCoroutine;

    private void Awake()
    {
        fightCoroutine = FindObjectOfType<FightCoroutine>();   
    }


    public void AttackAreaButton()
    {
        fightCoroutine.attackButton_L = true;
    }
    public void AttackAreaButton2()
    {
        fightCoroutine.attackButton_M = true;
    }
    public void AttackAreaButton3()
    {
        fightCoroutine.attackButton_R = true;
    }
}
