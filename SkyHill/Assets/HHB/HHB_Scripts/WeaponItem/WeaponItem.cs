using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WeaponItem : MonoBehaviour, IWeaponItem
{

    //ID / LOW_DAMAGE / MAX_DAMAGE / REQ_DEX / REQ_STR  /REQ_SPD

    // 내가 장착한 아이템 배열
    // 이거 읽어서 이미지 출력하고 관리해야할듯
    public static List<int> myEquipWeapon = new List<int>() { -1, -1};
    // 이전 플레이어 스텟
    // {lastWeaponID, playerLastMinDamage, playerLastMaxDamage, playerLastDEX, playerLastSTR, playerLastSPD}
    //       [0]             [1]             [2]          [3]         [4]         [5]             [6]
    // IDEA
    // 내가 장착전의 나의 데이터를 항상 가지고 있다가 돌려줌
    private List<float> lastStats = new List<float>();

    // 초기값 등록용임....반드시 주석 처리
    private void Awake()
    {
        lastStats.Add(-1f);
        lastStats.Add(4f);
        lastStats.Add(10f);
        lastStats.Add(5f);
        lastStats.Add(5f);
        lastStats.Add(5f);

    }

    // 무기 적용하는 함수
    public void ApplyWeapon(int id)
    {
        float lowDamage = default;
        float maxDamage = default;
        int reqDEX = default;
        int reqSTR = default;
        int reqSPD = default;

        // (400 ~ 406) ROOTWEAPON
        if (id >= 400 && id <= 406)
        {
            List<Dictionary<string, object>> rootWeapon = CSVReader.Read("ROOTWEAPON");
            lowDamage = (float)((int)rootWeapon[id - 400]["LOW_DAMAGE"]);
            maxDamage = (float)((int)rootWeapon[id - 400]["MAX_DAMAGE"]);
            reqDEX = (int)(rootWeapon[id - 400]["REQ_DEX"]);
            reqSTR = (int)(rootWeapon[id - 400]["REQ_STR"]);
            reqSPD = (int)(rootWeapon[id - 400]["REQ_SPD"]);
        }

        // (301 ~ 324) MAKINGWEAPON
        if (id >= 301 && id <= 324)
        {
            List<Dictionary<string, object>> makingWeapon = CSVReader.Read("MAKINGWEAPON");
            lowDamage = (float)((int)makingWeapon[id - 301]["LOW_DAMAGE"]);
            maxDamage = (float)((int)makingWeapon[id - 301]["MAX_DAMAGE"]);
            reqDEX = (int)(makingWeapon[id - 301]["REQ_DEX"]);
            reqSTR = (int)(makingWeapon[id - 301]["REQ_STR"]);
            reqSPD = (int)(makingWeapon[id - 301]["REQ_SPD"]);
        }

        StatsClassify(lowDamage, maxDamage, reqDEX, reqSTR, reqSPD, id);
    }

    // 스텟 분류하는 함수
    public void StatsClassify(float lowDamage, float maxDamage,
        int reqDEX, int reqSTR, int reqSPD, int id)
    {
        // 모든 조건을 충족할 경우
        if (UserInformation.player.dex >= reqDEX &&
            UserInformation.player.str >= reqSTR &&
            UserInformation.player.spd >= reqSPD)
        {
            Debug.Log("충족");
            SatisfyStat(lowDamage,maxDamage, id);
        }
        // 조건 불충족
        else
        {
            Debug.Log("불충족");
            UnSatisfyStat(lowDamage, maxDamage, id);
        }

    }

    // 스텟 증가 적용
    public void SatisfyStat(float lowDamage, float maxDamage, int id)
    {
        // 아이템이 2개로 가득 차면 1번 자리를 바꿈 (우선 마우스 오른쪽만 가능하게)
        // 장착이 안되어 있는 상태
        // !플레이어 초기값으로 돌려주고 아이템 장착
        if (!myEquipWeapon.Contains(id))
        {
            if (myEquipWeapon.Count == 2)
            {
                // 이전 플레이어 데이터로 수치로 변경 -> 아이템 장착
                LoadLastItemData(id);

                // 아이템 장착 리스트에 추가
                MyEquipControll(id);
                
                // 공격력을 바꿈
                UserInformation.player.minAttackDamage += lowDamage;
                UserInformation.player.maxAttackDamage += maxDamage;
            }
            // 개 쌉 버그인경우
            else if (myEquipWeapon.Count >= 3)
            {
                myEquipWeapon.Clear();
            }
            // 아이템이 비어있는 경우 넣음
            else
            {
                LoadLastItemData(id);
                UserInformation.player.minAttackDamage += lowDamage;
                UserInformation.player.maxAttackDamage += maxDamage;
                MyEquipControll(id);
            }
        }
        // !가지고 있는 경우 1. 레벨업해서 함수가 다시도는 경우 2. 다시 장착시킨경우
        else if (myEquipWeapon.Contains(id))
        {
            // (조건)마지막 장착 데이터가 내 장착 리스트를 가지고 있는 경우
            if (myEquipWeapon.Contains((int)lastStats[0]))
            {
                // 1. 다시 장착시킨경우
                // 이전수치와 내 데이터가 같은지를 비교
                if (CompareStat())
                {
                    /*Do Nothing*/
                    return;
                }
                // 2. 레벨업해서 함수가 다시도는 경우
                // 이전 수치와 내 데이터가 다른 경우 -> 레벨업을 한 상태
                else
                {
                    LoadLastItemData(id);
                    UserInformation.player.minAttackDamage += lowDamage;
                    UserInformation.player.maxAttackDamage += maxDamage;
                }

            }
        }

    } 
    // 스텟 감소 적용
    public void UnSatisfyStat(float lowDamage, float maxDamage, int id)
    {
        // 만족과 같지만 magicNumber 값이 적용된 거만 차이가 있다.
        float magicNumber = 0.33f;
        // 아이템이 2개로 가득 차면 1번 자리를 바꿈 (우선 마우스 오른쪽만 가능하게)
        // 장착이 안되어 있는 상태
        // !플레이어 초기값으로 돌려주고 아이템 장착
        if (!myEquipWeapon.Contains(id))
        {
            if (myEquipWeapon.Count == 2)
            {
                // 이전 플레이어 데이터로 수치로 변경 -> 아이템 장착
                LoadLastItemData(id);

                // 아이템 장착 리스트에 추가
                MyEquipControll(id);

                // 공격력을 바꿈
                UserInformation.player.minAttackDamage += lowDamage* magicNumber;
                UserInformation.player.maxAttackDamage += maxDamage* magicNumber;
            }
            // 개 쌉 버그인경우
            else if (myEquipWeapon.Count >= 3)
            {
                myEquipWeapon.Clear();
            }
            // 아이템이 비어있는 경우 넣음
            else
            {
                LoadLastItemData(id);
                MyEquipControll(id);
                UserInformation.player.minAttackDamage += lowDamage * magicNumber;
                UserInformation.player.maxAttackDamage += maxDamage * magicNumber;
            }
        }
        // !가지고 있는 경우 1. 레벨업해서 함수가 다시도는 경우 2. 다시 장착시킨경우
        else if (myEquipWeapon.Contains(id))
        {
            // (조건)마지막 장착 데이터가 내 장착 리스트를 가지고 있는 경우
            if (myEquipWeapon.Contains((int)lastStats[0]))
            {
                // 1. 다시 장착시킨경우
                // 이전수치와 내 데이터가 같은지를 비교
                if (!CompareStat())
                {
                    /*Do Nothing*/
                    return;
                }
                // 2. 레벨업해서 함수가 다시도는 경우
                // 이전 수치와 내 데이터가 다른 경우 -> 레벨업을 한 상태
                else
                {
                    LoadLastItemData(id);
                    UserInformation.player.minAttackDamage += lowDamage * magicNumber;
                    UserInformation.player.maxAttackDamage += maxDamage * magicNumber;
                }
            }
            // !만약 스왑의 효과가 적용이 필요한 경우
            // EX (0,1) 아이템 둘다 가지고 있는데 1번 아이템 장착 상태에서 0번 아이템을 누르는 경우

            //! 아이템을 조합하는 경우

            
        }
    }


    // !!!!! 레벨 업시 반드시 이 함수 호출해야함.!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    // 마지막 유저 정보 저장
    public void SaveLastItemData(int id)
    {
        //{ lastWeaponID, playerLastMinDamage, playerLastMaxDamage, playerLastDEX, playerLastSTR, playerLastSPD}
        //       [0]             [1]             [2]          [3]         [4]         [5]             [6]

        // 유저의 마지막 스텟 상태
        lastStats[0] = id;
        lastStats[1] = UserInformation.player.minAttackDamage;
        lastStats[2] = UserInformation.player.maxAttackDamage;
        lastStats[3] = UserInformation.player.dex;
        lastStats[4] = UserInformation.player.str;
        lastStats[5] = UserInformation.player.spd;
    }
    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


    // 유저 정보 갱신
    public void LoadLastItemData(int id)
    {
        //{ lastWeaponID, playerLastMinDamage, playerLastMaxDamage, playerLastDEX, playerLastSTR, playerLastSPD}
        //       [0]             [1]             [2]          [3]         [4]         [5]             [6]

        // 유저가 아이템 장착전의 스텟
        id = (int)lastStats[0];
        UserInformation.player.minAttackDamage = lastStats[1];
        UserInformation.player.maxAttackDamage = lastStats[2];
        UserInformation.player.dex = (int)lastStats[3];
        UserInformation.player.str = (int)lastStats[4];
        UserInformation.player.spd = (int)lastStats[5];
    }

    // 레벨업을 한지 판단하는 함수
    public bool CompareStat()
    {
        if (UserInformation.player.dex == (int)lastStats[3] &&
            UserInformation.player.str == (int)lastStats[4] &&
            UserInformation.player.spd == (int)lastStats[5])
        {
            return true; // 모든 조건이 충족될 경우 true 반환
        }

        return false; // 조건을 충족하지 않을 경우 false 반환
    }

    // 2개의 아이템 칸 중 어디로 들어갈지 결정하는 함수
    public void MyEquipControll(int id)
    {
        if (myEquipWeapon[0] == -1 && myEquipWeapon[1] == -1)
        {
            myEquipWeapon[0] = id;
        }
        else if (myEquipWeapon[0] != -1 && myEquipWeapon[1] == -1)
        {
            myEquipWeapon[1] = id;
        }
        else if (myEquipWeapon.Count >= 3)
        {
            Debug.Log("버그임 뜬거임 님 ㅈ됬음 ㅅㄱ");
            myEquipWeapon.Clear();
        }
        else if (myEquipWeapon[0] != -1 && myEquipWeapon[1] != -1)
        {
            myEquipWeapon[0] = id;
        }


    }
}
