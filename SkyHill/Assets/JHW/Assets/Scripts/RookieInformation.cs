using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookieInformation : MonoBehaviour
{

    public static RookieInformation rookieInformation;

    static public float hp = 20;
    static public float minAttackDamage = 4.0f;
    static public float maxAttackDamage = 10.0f;



    public void Awake()
    {
        if(rookieInformation == null)
        {
            rookieInformation = this;
        }
        else
        {
            DontDestroyOnLoad(rookieInformation);
        }
    }
}
