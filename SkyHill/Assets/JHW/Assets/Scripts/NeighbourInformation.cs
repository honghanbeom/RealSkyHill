using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighbourInformation : MonoBehaviour
{

    public static NeighbourInformation neighbourInformation;


    static public float hp = 25.0f;
    static public float minAttackDamage = 4.0f;
    static public float maxAttackDamage = 10.0f;

    // Start is called before the first frame update
    public void Awake()
    {
        if(neighbourInformation == null)
        {
            neighbourInformation = this;
        }
        else
        {
            DontDestroyOnLoad(neighbourInformation);
        }
    }
}
