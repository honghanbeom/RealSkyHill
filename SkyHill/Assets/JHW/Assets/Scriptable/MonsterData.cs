using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Monster Data")]
public class MonsterData : ScriptableObject
{

    

    public string MonsterName = "Rookie";
    public int MonsterHP = 20;
    public int MonsterMaxDamage = 4;
    public int MonsterMidDamage = 3;
    public int MonsterMinDamage = 2;
    public int MonsterEXP = 20;




}
