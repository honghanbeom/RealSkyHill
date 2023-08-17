using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInformation : MonoBehaviour
{

    public static UserInformation Instance;

    static public float hp = 100.0f;
    static public float hunger = 50.0f;
    static public float minAttackDamage = 4.0f;
    static public float maxAttackDamage = 10.0f;
    static public int exp = 0;
    static public bool poision = false;
    static public int str = 5;
    static public int spd = 5;
    static public int dex = 5;
    static public int hit = 5;
    static public int userLevel = 1;
    static public int skillPoint = 0;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;

        }
        else
        {
            DontDestroyOnLoad(Instance);
        }

    }
}
