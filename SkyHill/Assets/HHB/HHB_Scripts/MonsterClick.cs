using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterClick : MonoBehaviour
{
    public MonsterData monsterData;
    public MonsterData monsterData2;
    public BoxCollider2D collider;
    Animator animator;

    //전투시작하고 몬스터 클릭할 때마다 스타트 코루틴 되버려서 전투여부 확인하고 전투중이면 스타트 코루틴 실행 못하게 하는 bool변수 설정 
    public bool isFight = false;

    public void Start()
    {
        //몬스터 애니메이션 정보 보내주려고 설정 
        animator = GetComponent<Animator>();
        //전투 끝날때 콜라이더 지워버리려고 설정 
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
