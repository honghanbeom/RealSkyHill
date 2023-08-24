using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    public static Fight fight;

    private void Awake()
    {
        fight = this;
    }

    public void MonsterFight(string name, float hP, float maxDmg, 
        float minDmg, float midDmg, float EXP)
    {
        Debug.LogFormat("{0}와 전투시작", name);

        float userHP = UserInformation.player.hp;
        float userEXP = UserInformation.player.exp;
        float userMaxDmg = UserInformation.player.maxAttackDamage;
        float userMinDmg = UserInformation.player.minAttackDamage;
        int userHit = UserInformation.player.hit;

        float randomDmg = default;
        float monsterRandomDmg = Random.Range(maxDmg, minDmg);
        // 필요시 다른 인수사용
        // 최소값, 중간값, 최대값 넣었으니 필요에 따라 사용


        while (hP > 0 && userHP > 0)
        {
            Debug.Log("-------------------------------------------------");

            Debug.Log("플레이어턴");
            // 이미지 띄우기
            // 이미지 클릭하면 그에 맞는 데미지 연산

            /// if(leftclicked)
            /// {
            ///     ButtonLeft()
            /// }
            ///
            /// if(midclicked)
            /// {
            ///     ButtonMid()
            /// }
            /// 
            /// if(rightclicked)
            /// {
            ///     ButtonRight()
            /// }


            // 클릭할 때 까지 wait 
            // 플레이어 애니메이션 실행 -> 애니메이션에 이벤트 넣는 방법으로 가능할듯

            hP -= randomDmg;

            Debug.LogFormat("유저가 준 데미지 : {0}",randomDmg);
            Debug.LogFormat("몬스터 체력 : {0}/{1}",hP,20);

            Debug.Log("-------------------------------------------------");
            Debug.Log("몬스터 턴");
            // 몬스터 애니메이션 실행
            userHP -= monsterRandomDmg;
            Debug.LogFormat("몬스터가 준 데미지 : {0}", monsterRandomDmg);
            Debug.LogFormat("플레이어 체력 : {0}/{1}",userHP,100);
            Debug.Log("-------------------------------------------------");

        }
        if (userHP >= 0 && hP <= 0)
        {
            Debug.Log("-------------------------------------------------");
            Debug.LogFormat("플레이어 승리");
            userEXP += EXP;
            Debug.LogFormat("유저 획득 경험치 : {0}",userEXP);
            // 변경된 체력값 적용
            UserInformation.player.hp = userHP;
            Debug.Log("-------------------------------------------------");
            // 여기 레벨업 때 돌아야할 거 추가
        }
        if (userHP <= 0)
        {
            Debug.Log("죽음");
            // 게임 엔딩
        }
    
    }

    // Neighbour 45%, 85%, 70%
    // Rookie 50%, 90%, 80%
    // hit 스텟당 2% 씩 상승

    // ------------------------ Neighbour ---------------------------------------

    // 45%
    public float Neighbour_ButtonLeft(float userMinDmg, float userMaxDmg, int userHit)
    {
        float randomDmg = 0f;

        int userAttackProb = 45 + (userHit - 5) * 2;
        int prob = Random.Range(0, 100);

        if (userAttackProb > prob)
        {
            randomDmg = Random.Range(userMinDmg * 1.5f, userMaxDmg * 1.5f);
        }

        return randomDmg;
    }
    // 85%
    public float Neighbour_ButtonMid(float userMinDmg, float userMaxDmg, int userHit)
    {
        float randomDmg = 0f;

        int userAttackProb = 85 + (userHit - 5) * 2;
        int prob = Random.Range(0, 100);

        if (userAttackProb > prob)
        {
            randomDmg = Random.Range(userMinDmg * 0.4f, userMaxDmg * 0.4f);
        }

        return randomDmg;
    }
    // 70%
    public float Neighbour_ButtonRight(float userMinDmg, float userMaxDmg, int userHit)
    {
        float randomDmg = 0f;

        int userAttackProb = 70 + (userHit - 5) * 2;
        int prob = Random.Range(0, 100);

        if (userAttackProb > prob)
        {
            randomDmg = Random.Range(userMinDmg, userMaxDmg);
        }

        return randomDmg;
    }

    // ------------------------ Rookie ---------------------------------------

    // 50%
    public float Rookie_ButtonLeft(float userMinDmg, float userMaxDmg, int userHit)
    {
        float randomDmg = 0f;

        int userAttackProb = 50 + (userHit - 5) * 2;
        int prob = Random.Range(0, 100);

        if (userAttackProb > prob)
        {
            randomDmg = Random.Range(userMinDmg * 2f, userMaxDmg * 2f);
        }

        return randomDmg;
    }
    // 90%
    public float Rookie_ButtonMid(float userMinDmg, float userMaxDmg, int userHit)
    {
        float randomDmg = 0f;

        int userAttackProb = 90 + (userHit - 5) * 2;
        int prob = Random.Range(0, 100);

        if (userAttackProb > prob)
        {
            randomDmg = Random.Range(userMinDmg * 0.4f, userMaxDmg * 0.4f);
        }

        return randomDmg;
    }
    // 80%
    public float Rookie_ButtonRight(float userMinDmg, float userMaxDmg, int userHit)
    {
        float randomDmg = 0f;

        int userAttackProb = 80 + (userHit - 5) * 2;
        int prob = Random.Range(0, 100);

        if (userAttackProb > prob)
        {
            randomDmg = Random.Range(userMinDmg, userMaxDmg);
        }

        return randomDmg;
    }
}
