using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poision : MonoBehaviour
{
    public GameObject poisionObj;

    public void PoisionImageControl()
    {
        if (UserInformation.player.poision == true)
        {
            poisionObj.transform.localScale = Vector3.one;
        }

        float minScaleFactor = 0.001f;
        if (UserInformation.player.poision == false)
        {
            poisionObj.transform.localScale = Vector3.one * minScaleFactor;
        }

 
    }
}
