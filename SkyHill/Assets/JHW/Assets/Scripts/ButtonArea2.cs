using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonArea2 : MonoBehaviour
{
    // Start is called before the first frame update

    public void AttackAreaButton()
    {
        FightCoroutine.fight.attackButton_L2 = true;
    }
    public void AttackAreaButton2()
    {
        FightCoroutine.fight.attackButton_M2 = true;
    }
    public void AttackAreaButton3()
    {
        FightCoroutine.fight.attackButton_R2 = true;
    }
}
