using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponItem
{
    // ���� �����ϴ� �Լ�
    public void ApplyWeapon(int id);

    // ���� �з��ϴ� �Լ�
    public void StatsClassify(float lowDamage, float maxDamage, int reqDEX, int reqSTR, int reqSPD, int id);

    // ���� ���� ����
    public void SatisfyStat(float lowDamage, float maxDamage, int id);

    // ���� ���� ����
    public void UnSatisfyStat(float lowDamage, float maxDamage, int id);
    
    // ������ �� �ٽ� �Ǻ��ϴ� �Լ�
    // ���ݺк� ���͸� �����
}
