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
        Debug.LogFormat("{0}�� ��������", name);

        float userHP = UserInformation.player.hp;
        float userEXP = UserInformation.player.exp;
        float userMaxDmg = UserInformation.player.maxAttackDamage;
        float userMinDmg = UserInformation.player.minAttackDamage;
        int userHit = UserInformation.player.hit;

        float randomDmg = default;
        float monsterRandomDmg = Random.Range(maxDmg, minDmg);
        // �ʿ�� �ٸ� �μ����
        // �ּҰ�, �߰���, �ִ밪 �־����� �ʿ信 ���� ���


        while (hP > 0 && userHP > 0)
        {
            Debug.Log("-------------------------------------------------");

            Debug.Log("�÷��̾���");
            // �̹��� ����
            // �̹��� Ŭ���ϸ� �׿� �´� ������ ����

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


            // Ŭ���� �� ���� wait 
            // �÷��̾� �ִϸ��̼� ���� -> �ִϸ��̼ǿ� �̺�Ʈ �ִ� ������� �����ҵ�

            hP -= randomDmg;

            Debug.LogFormat("������ �� ������ : {0}",randomDmg);
            Debug.LogFormat("���� ü�� : {0}/{1}",hP,20);

            Debug.Log("-------------------------------------------------");
            Debug.Log("���� ��");
            // ���� �ִϸ��̼� ����
            userHP -= monsterRandomDmg;
            Debug.LogFormat("���Ͱ� �� ������ : {0}", monsterRandomDmg);
            Debug.LogFormat("�÷��̾� ü�� : {0}/{1}",userHP,100);
            Debug.Log("-------------------------------------------------");

        }
        if (userHP >= 0 && hP <= 0)
        {
            Debug.Log("-------------------------------------------------");
            Debug.LogFormat("�÷��̾� �¸�");
            userEXP += EXP;
            Debug.LogFormat("���� ȹ�� ����ġ : {0}",userEXP);
            // ����� ü�°� ����
            UserInformation.player.hp = userHP;
            Debug.Log("-------------------------------------------------");
            // ���� ������ �� ���ƾ��� �� �߰�
        }
        if (userHP <= 0)
        {
            Debug.Log("����");
            // ���� ����
        }
    
    }

    // Neighbour 45%, 85%, 70%
    // Rookie 50%, 90%, 80%
    // hit ���ݴ� 2% �� ���

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
