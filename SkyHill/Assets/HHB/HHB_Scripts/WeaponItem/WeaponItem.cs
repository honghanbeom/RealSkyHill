using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponItem : MonoBehaviour, IWeaponItem
{
    public static WeaponItem weaponItem;

    //ID / LOW_DAMAGE / MAX_DAMAGE / REQ_DEX / REQ_STR  /REQ_SPD
    // 무기 적용하는 함수

    private void Awake()
    {
        weaponItem = this;
    }

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
            //Debug.Log("충족");
            SatisfyStat(lowDamage, maxDamage, id);
        }
        // 조건 불충족
        else
        {
            //Debug.Log("불충족");
            UnSatisfyStat(lowDamage, maxDamage, id);
        }

    }

    // 스텟 증가 적용
    public void SatisfyStat(float lowDamage, float maxDamage, int id)
    {

        // 아이템이 2개로 가득 차면 1번 자리를 바꿈 (우선 마우스 오른쪽만 가능하게)
        // 장착이 안되어 있는 상태
        // !플레이어 초기값으로 돌려주고 아이템 장착
        if (!UserInformation.player.myEquipWeapon.Contains(id))
        {
            if (UserInformation.player.myEquipWeapon.Count == 2)
            {
                // 이전 플레이어 데이터로 수치로 변경 -> 아이템 장착
                UserInformation.player.LoadLastItemData(id);

                // 아이템 장착 리스트에 추가
                MyEquipControll(id);

                // 공격력을 바꿈
                float minDamage = lowDamage + DamageApply();
                float highDamage = maxDamage + DamageApply();
                UserInformation.player.minAttackDamage += minDamage;
                UserInformation.player.maxAttackDamage += highDamage;
            }
            // 개 쌉 버그인경우
            else if (UserInformation.player.myEquipWeapon.Count >= 3)
            {
                UserInformation.player.myEquipWeapon.Clear();
            }
            // 아이템이 비어있는 경우 넣음
            else
            {
                UserInformation.player.LoadLastItemData(id);
                float minDamage = lowDamage + DamageApply();
                float highDamage = maxDamage + DamageApply();
                UserInformation.player.minAttackDamage += minDamage;
                UserInformation.player.maxAttackDamage += highDamage;
                MyEquipControll(id);
            }
        }
        // !가지고 있는 경우 1. 레벨업해서 함수가 다시도는 경우 2. 다시 장착시킨경우
        else if (UserInformation.player.myEquipWeapon.Contains(id))
        {
            // (조건)마지막 장착 데이터가 내 장착 리스트를 가지고 있는 경우
            if (UserInformation.player.myEquipWeapon.Contains((int)UserInformation.player.lastStats[0]))
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
                    //Debug.LogFormat("전 min: {0}",UserInformation.player.minAttackDamage);
                    //Debug.LogFormat("전 max: {0}",UserInformation.player.maxAttackDamage);

                    //Debug.LogFormat("저장된 min : {0}",UserInformation.player.lastStats[1]);
                    //Debug.LogFormat("저장된 max : {0}",UserInformation.player.lastStats[2]);

                    UserInformation.player.LoadLastItemData(id);

                    float minDamage = lowDamage + DamageApply();
                    float highDamage = maxDamage + DamageApply();
                    UserInformation.player.minAttackDamage += minDamage;
                    UserInformation.player.maxAttackDamage += highDamage;

                    //Debug.LogFormat("저장된 min : {0}", UserInformation.player.lastStats[1]);
                    //Debug.LogFormat("저장된 max : {0}", UserInformation.player.lastStats[2]);

                    //Debug.LogFormat("후 min: {0}", UserInformation.player.minAttackDamage);
                    //Debug.LogFormat("후 max: {0}", UserInformation.player.maxAttackDamage);
                }

            }
        }

    }
    // 스텟 감소 적용
    public void UnSatisfyStat(float lowDamage, float maxDamage, int id)
    {

        // 만족과 같지만 magicNumber 값이 적용된 거만 차이가 있다.
        float magicNumber = 0.66f;
        // 아이템이 2개로 가득 차면 1번 자리를 바꿈 (우선 마우스 오른쪽만 가능하게)
        // 장착이 안되어 있는 상태
        // !플레이어 초기값으로 돌려주고 아이템 장착
        if (!UserInformation.player.myEquipWeapon.Contains(id))
        {
            if (UserInformation.player.myEquipWeapon.Count == 2)
            {
                // 이전 플레이어 데이터로 수치로 변경 -> 아이템 장착
                UserInformation.player.LoadLastItemData(id);

                // 아이템 장착 리스트에 추가
                MyEquipControll(id);

                // 공격력을 바꿈
                UserInformation.player.LoadLastItemData(id);
                float minDamage = (lowDamage * magicNumber) +
                    (DamageApply());
                float highDamage = (maxDamage * magicNumber) +
                    (DamageApply());
                UserInformation.player.minAttackDamage += minDamage;
                UserInformation.player.maxAttackDamage += highDamage;
            }
            // 개 쌉 버그인경우
            else if (UserInformation.player.myEquipWeapon.Count >= 3)
            {
                UserInformation.player.myEquipWeapon.Clear();
            }
            // 아이템이 비어있는 경우 넣음
            else
            {
                //UserInformation.player.LoadLastItemData(id);
                //MyEquipControll(id);
                //UserInformation.player.LoadLastItemData(id);
                //float minDamage = (lowDamage * magicNumber) +
                //    (DamageApply());
                //float highDamage = (maxDamage * magicNumber) +
                //    (DamageApply());
                //UserInformation.player.minAttackDamage += minDamage;
                //UserInformation.player.maxAttackDamage += highDamage;
            }
        }
        // !가지고 있는 경우 1. 레벨업해서 함수가 다시도는 경우 2. 다시 장착시킨경우
        else if (UserInformation.player.myEquipWeapon.Contains(id))
        {
            // (조건)마지막 장착 데이터가 내 장착 리스트를 가지고 있는 경우
            if (UserInformation.player.myEquipWeapon.Contains((int)UserInformation.player.lastStats[0]))
            {
                // 1. 다시 장착시킨경우
                // 이전수치와 내 데이터가 같은지를 비교
                if (!CompareStat())
                {
                    return;
                }
                // 2. 레벨업해서 함수가 다시도는 경우
                // 이전 수치와 내 데이터가 다른 경우 -> 레벨업을 한 상태
                else
                {
                    UserInformation.player.LoadLastItemData(id);
                    float minDamage = (lowDamage * magicNumber) +
                        (DamageApply());
                    float highDamage = (maxDamage * magicNumber) +
                        (DamageApply());
                    UserInformation.player.minAttackDamage += minDamage;
                    UserInformation.player.maxAttackDamage += highDamage;

                }
            }
        }
    }

    // 레벨업을 한지 판단하는 함수
    public bool CompareStat()
    {
        if (UserInformation.player.dex == (int)UserInformation.player.lastStats[3] &&
            UserInformation.player.str == (int)UserInformation.player.lastStats[4] &&
            UserInformation.player.spd == (int)UserInformation.player.lastStats[5])
        {
            return true; // 모든 조건이 충족될 경우 true 반환
        }

        return false; // 조건을 충족하지 않을 경우 false 반환
    }

    // 2개의 아이템 칸 중 어디로 들어갈지 결정하는 함수
    public void MyEquipControll(int id)
    {
        // 0번과 1번 둘다 비는 경우 -> 0번에 넣기
        if (UserInformation.player.myEquipWeapon[0] == -1 && UserInformation.player.myEquipWeapon[1] == -1)
        {
            UserInformation.player.myEquipWeapon[0] = id;
        }
        // 1번만 비는 경우 -> 1번에 넣기
        else if (UserInformation.player.myEquipWeapon[0] != -1 && UserInformation.player.myEquipWeapon[1] == -1)
        {
            UserInformation.player.myEquipWeapon[1] = id;
        }
        // 버그
        else if (UserInformation.player.myEquipWeapon.Count >= 3)
        {
            Debug.Log("버그임 뜬거임 님 ㅈ됬음 ㅅㄱ");
            UserInformation.player.myEquipWeapon.Clear();
        }
        // 0번 과 1번 둘다 있는 경우 -> 0번에 덮어쓰기
        else if (UserInformation.player.myEquipWeapon[0] != -1 && UserInformation.player.myEquipWeapon[1] != -1)
        {
            UserInformation.player.myEquipWeapon[0] = id;
        }
        // 0번이 비고 1번이 있는 경우 -> 0번에 넣기
        else if (UserInformation.player.myEquipWeapon[0] == -1
            && UserInformation.player.myEquipWeapon[1] != -1)
        {
            UserInformation.player.myEquipWeapon[0] = id;
        }
    }

    public int DamageApply()
    {
        int applyDEX = UserInformation.player.dex - 5;
        int applySTR = UserInformation.player.str - 5;
        int applySPD = UserInformation.player.spd - 5;

        //Debug.LogFormat("applyDex : {0}", applyDEX);
        //Debug.LogFormat("applystr : {0}", applySTR);
        //Debug.LogFormat("applyspd : {0}", applySPD);


        int applyDamage = applyDEX + applySTR + applySPD;
        //Debug.LogFormat("applyDamage : {0}", applyDamage);
        return applyDamage;
    }
}




