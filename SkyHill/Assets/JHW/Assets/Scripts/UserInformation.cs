using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInformation : MonoBehaviour
{

    public static UserInformation player;

    public float hp = 50f;
    public float hunger = 50.0f;
    public float minAttackDamage = 4.0f;
    public float maxAttackDamage = 10.0f;
    public int exp = 0;
    public bool poision = false;
    public int str = 5;
    public int spd = 5;
    public int dex = 5;
    public int hit = 5;
    public int userLevel = 1;
    public int skillPoint = 0;

    public void Awake()
    {
        if(player == null)
        {
            player = this;

        }
        else
        {
            DontDestroyOnLoad(player);
        }

    }
}
