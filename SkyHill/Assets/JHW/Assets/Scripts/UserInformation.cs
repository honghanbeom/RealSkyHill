using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInformation : MonoBehaviour
{

    public static UserInformation player;


    // 내가 장착한 아이템 배열
    // 이거 읽어서 이미지 출력하고 관리해야할듯
    public List<int> myEquipWeapon = new List<int>() { -1, -1 };

    // 이전 플레이어 스텟
    // {lastWeaponID, playerLastMinDamage, playerLastMaxDamage, playerLastDEX, playerLastSTR, playerLastSPD}
    //       [0]             [1]             [2]          [3]         [4]         [5]             [6]
    // IDEA
    // 내가 장착전의 나의 데이터를 항상 가지고 있다가 돌려줌
    public List<float> lastStats = new List<float>();


    public float hp = 100.0f;
    public float hunger = 50.0f;
    public float minAttackDamage = 1.0f;
    public float maxAttackDamage = 2.0f;
    public int exp = 0;
    public int maxEXP = 50;
    public bool poision = false;
    public int dex = 5;
    public int str = 5;
    public int spd = 5;
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
        SaveLastItemData(-1);

    }

    private void Update()
    {

    }


    // !!!!! 레벨 업시 반드시 이 함수 호출해야함.!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    // 마지막 유저 정보 저장
    public void SaveLastItemData(int id)
    {
        //{ lastWeaponID, playerLastMinDamage, playerLastMaxDamage, playerLastDEX, playerLastSTR, playerLastSPD}
        //       [0]             [1]             [2]          [3]         [4]         [5]             [6]

        // 유저의 마지막 스텟 상태
        lastStats.Clear();
        lastStats.Add(id);
        lastStats.Add(1f);
        lastStats.Add(2f);
        lastStats.Add(dex);
        lastStats.Add(str);
        lastStats.Add(spd);
    }
    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

    // 유저 정보 갱신
    public void LoadLastItemData(int id)
    {
        //{ lastWeaponID, playerLastMinDamage, playerLastMaxDamage, playerLastDEX, playerLastSTR, playerLastSPD}
        //       [0]             [1]             [2]          [3]         [4]         [5]             [6]

        // 유저가 아이템 장착전의 스텟
        id = (int)lastStats[0];
        minAttackDamage = lastStats[1];
        maxAttackDamage = lastStats[2];
        dex = (int)lastStats[3];
        str = (int)lastStats[4];
        spd = (int)lastStats[5];
    }

    //public void UserEXP()
    //{
    //    StatUI.statUI.StatUIRoutine();
    //}
}
