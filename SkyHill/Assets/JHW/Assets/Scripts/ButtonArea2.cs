using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonArea2 : MonoBehaviour
{
    FightCoroutine fightCoroutine;
    // Start is called before the first frame update
    private void Awake()
    {
        fightCoroutine  = FindObjectOfType<FightCoroutine>();
    }


    public void AttackAreaButton()
    {
        fightCoroutine.attackButton_L2 = true;
    }
    public void AttackAreaButton2()
    {
        fightCoroutine.attackButton_M2 = true;
    }
    public void AttackAreaButton3()
    {
        fightCoroutine.attackButton_R2 = true;
    }
}
