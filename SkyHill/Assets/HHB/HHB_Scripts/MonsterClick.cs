//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MonsterClick : MonoBehaviour
//{
//    public MonsterData monsterData;

//    private void OnMouseDown()
//    {
//        // �÷��̾�� �ݶ��̴� �´ٴ� ����
//        string gameObjTag = gameObject.tag;
//        if (gameObjTag == "Enemy")
//        {
//            string monsterName = monsterData.MonsterName;
//            float monsterHp = monsterData.MonsterHP;
//            float monsterMaxDamage = monsterData.MonsterMaxDamage;
//            float monstetMidDamage = monsterData.MonsterMidDamage;
//            float monsterMinDamage = monsterData.MonsterMinDamage;
//            float monsterEXP = monsterData.MonsterEXP;

//            Fight.fight.MonsterFight(monsterName, monsterHp, monsterMaxDamage, monstetMidDamage,
//                monsterMinDamage, monsterEXP);
//        }
//    }
//}
