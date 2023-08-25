using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonArea : MonoBehaviour
{
    //public FightCoroutine fightCoroutine;


    public void AttackAreaButton()
    {
        FightCoroutine.fight.attackButton_L = true;
    }
    public void AttackAreaButton2()
    {
        FightCoroutine.fight.attackButton_M = true;
    }
    public void AttackAreaButton3()
    {
        FightCoroutine.fight.attackButton_R = true;
    }
}
