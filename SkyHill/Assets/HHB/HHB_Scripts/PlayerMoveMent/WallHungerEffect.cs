using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallHungerEffect : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogFormat("���� �ߵ� ���� : {0}", UserInformation.player.poision);
        float userHunger = UserInformation.player.hunger;
        float userHp = UserInformation.player.hp;
        bool userPoision = UserInformation.player.poision;
        if (collision.tag == "Player")
        {
            if (userHunger > 0)
            {
                userHunger -= 1;
                if (userPoision == true)
                {
                    userHp -= 1;
                }
            }
            else if (userHunger <= 0)
            {
                userHp -= 1;
                if (userPoision == true)
                {
                    userHp -= 1;
                }
            }

            // ���氪�� ����
            UserInformation.player.hunger = userHunger;
            UserInformation.player.hp = userHp;
            UserInformation.player.poision = userPoision;   
        }
    }

    
}
