using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterClick : MonoBehaviour
{
    public MonsterData monsterData;
    public MonsterData monsterData2;
    public BoxCollider2D collider;
    Animator animator;
    public bool isFight = false;

    public void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
    }

    public void Update()
    {
        
    }

    private void OnMouseDown()
    {


        // 플레이어와 콜라이더 맞다는 조건
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
            if (!isFight)
            {
                isFight=true;
                FightCoroutine fightCoroutine = FindObjectOfType<FightCoroutine>();
                StartCoroutine(fightCoroutine.MonsterFight(monsterName, monsterHp, monsterMaxDamage, monstetMidDamage,
                    monsterMinDamage, monsterEXP, animator ));
            }
        }



        // 플레이어와 콜라이더 맞다는 조건
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
            if (!isFight)
            {
                FightCoroutine fightCoroutine = FindObjectOfType<FightCoroutine>();
                StartCoroutine(fightCoroutine.MonsterFight(monsterName, monsterHp, monsterMaxDamage, monstetMidDamage,
                    monsterMinDamage, monsterEXP, animator));
            }
        }
    }
}
