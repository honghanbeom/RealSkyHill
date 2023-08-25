using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterClick : MonoBehaviour
{
    public MonsterData monsterData;
    public MonsterData monsterData2;

    Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        
    }

    private void OnMouseDown()
    {


        // �÷��̾�� �ݶ��̴� �´ٴ� ����
        string gameObjTag = gameObject.tag;
        if (gameObjTag == "Rookie")
        {
            
            string monsterName = monsterData.MonsterName;
            float monsterHp = monsterData.MonsterHP;
            float monsterMaxDamage = monsterData.MonsterMaxDamage;
            float monstetMidDamage = monsterData.MonsterMidDamage;
            float monsterMinDamage = monsterData.MonsterMinDamage;
            float monsterEXP = monsterData.MonsterEXP;

            //FightCoroutine.fight.MonsterFight(monsterName, monsterHp, monsterMaxDamage, monstetMidDamage,
            //    monsterMinDamage, monsterEXP);

            StartCoroutine(FightCoroutine.fight.MonsterFight(monsterName, monsterHp, monsterMaxDamage, monstetMidDamage,
                monsterMinDamage, monsterEXP , animator));
        }



        // �÷��̾�� �ݶ��̴� �´ٴ� ����
        string gameObjTag2 = gameObject.tag;
        if (gameObjTag2 == "Neighbour")
        {

            string monsterName = monsterData2.MonsterName;
            float monsterHp = monsterData2.MonsterHP;
            float monsterMaxDamage = monsterData2.MonsterMaxDamage;
            float monstetMidDamage = monsterData2.MonsterMidDamage;
            float monsterMinDamage = monsterData2.MonsterMinDamage;
            float monsterEXP = monsterData2.MonsterEXP;

            //FightCoroutine.fight.MonsterFight(monsterName, monsterHp, monsterMaxDamage, monstetMidDamage,
            //    monsterMinDamage, monsterEXP);

            StartCoroutine(FightCoroutine.fight.MonsterFight(monsterName, monsterHp, monsterMaxDamage, monstetMidDamage,
                monsterMinDamage, monsterEXP, animator));
        }
    }
}
