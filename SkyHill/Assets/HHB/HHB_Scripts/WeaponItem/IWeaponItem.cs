using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponItem
{
    // 무기 적용하는 함수
    public void ApplyWeapon(int id);

    // 스텟 분류하는 함수
    public void StatsClassify(float lowDamage, float maxDamage, int reqDEX, int reqSTR, int reqSPD, int id);

    // 스텟 증가 적용
    public void SatisfyStat(float lowDamage, float maxDamage, int id);

    // 스텟 감소 적용
    public void UnSatisfyStat(float lowDamage, float maxDamage, int id);
    
    // 레벨업 시 다시 판별하는 함수
    // 스텟분별 부터만 적용됨
}
