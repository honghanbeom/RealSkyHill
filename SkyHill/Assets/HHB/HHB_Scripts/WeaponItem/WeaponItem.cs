using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class WeaponItem : MonoBehaviour, IWeaponItem
{
    public static WeaponItem weaponItem;

    //ID / LOW_DAMAGE / MAX_DAMAGE / REQ_DEX / REQ_STR  /REQ_SPD
    // ���� �����ϴ� �Լ�
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

    // ���� �з��ϴ� �Լ�
    public void StatsClassify(float lowDamage, float maxDamage,
        int reqDEX, int reqSTR, int reqSPD, int id)
    {
        // ��� ������ ������ ���
        if (UserInformation.player.dex >= reqDEX &&
            UserInformation.player.str >= reqSTR &&
            UserInformation.player.spd >= reqSPD)
        {
            Debug.Log("����");
            SatisfyStat(lowDamage,maxDamage, id);
        }
        // ���� ������
        else
        {
            Debug.Log("������");
            UnSatisfyStat(lowDamage, maxDamage, id);
        }

    }

    // ���� ���� ����
    public void SatisfyStat(float lowDamage, float maxDamage, int id)
    {
        int applyDEX = default;
        int applySTR = default;
        int applySPD = default;
        // �������� 2���� ���� ���� 1�� �ڸ��� �ٲ� (�켱 ���콺 �����ʸ� �����ϰ�)
        // ������ �ȵǾ� �ִ� ����
        // !�÷��̾� �ʱⰪ���� �����ְ� ������ ����
        if (!UserInformation.player.myEquipWeapon.Contains(id))
        {
            if (UserInformation.player.myEquipWeapon.Count == 2)
            {
                // ���� �÷��̾� �����ͷ� ��ġ�� ���� -> ������ ����
                UserInformation.player.LoadLastItemData(id);

                // ������ ���� ����Ʈ�� �߰�
                MyEquipControll(id);

                // ���ݷ��� �ٲ�
                UserInformation.player.minAttackDamage += (lowDamage +
                    DamageApply(applyDEX, applySTR, applySPD));
                UserInformation.player.maxAttackDamage += (maxDamage +
                    DamageApply(applyDEX, applySTR, applySPD));
            }
            // �� �� �����ΰ��
            else if (UserInformation.player.myEquipWeapon.Count >= 3)
            {
                UserInformation.player.myEquipWeapon.Clear();
            }
            // �������� ����ִ� ��� ����
            else
            {
                UserInformation.player.LoadLastItemData(id);
                UserInformation.player.minAttackDamage += (lowDamage +
                    DamageApply(applyDEX, applySTR, applySPD));
                UserInformation.player.maxAttackDamage += (maxDamage +
                    DamageApply(applyDEX, applySTR, applySPD));
                MyEquipControll(id);
            }
        }
        // !������ �ִ� ��� 1. �������ؼ� �Լ��� �ٽõ��� ��� 2. �ٽ� ������Ų���
        else if (UserInformation.player.myEquipWeapon.Contains(id))
        {
            // (����)������ ���� �����Ͱ� �� ���� ����Ʈ�� ������ �ִ� ���
            if (UserInformation.player.myEquipWeapon.Contains((int)UserInformation.player.lastStats[0]))
            {
                // 1. �ٽ� ������Ų���
                // ������ġ�� �� �����Ͱ� �������� ��
                if (CompareStat())
                {
                    /*Do Nothing*/
                    return;
                }
                // 2. �������ؼ� �Լ��� �ٽõ��� ���
                // ���� ��ġ�� �� �����Ͱ� �ٸ� ��� -> �������� �� ����
                else
                {
                    UserInformation.player.LoadLastItemData(id);
                    UserInformation.player.minAttackDamage += (lowDamage +
                        DamageApply(applyDEX, applySTR, applySPD));
                    UserInformation.player.maxAttackDamage += (maxDamage +
                        DamageApply(applyDEX, applySTR, applySPD));
                }

            }
        }

    } 
    // ���� ���� ����
    public void UnSatisfyStat(float lowDamage, float maxDamage, int id)
    {
        int applyDEX = default;
        int applySTR = default;
        int applySPD = default;
        // ������ ������ magicNumber ���� ����� �Ÿ� ���̰� �ִ�.
        float magicNumber = 0.33f;
        // �������� 2���� ���� ���� 1�� �ڸ��� �ٲ� (�켱 ���콺 �����ʸ� �����ϰ�)
        // ������ �ȵǾ� �ִ� ����
        // !�÷��̾� �ʱⰪ���� �����ְ� ������ ����
        if (!UserInformation.player.myEquipWeapon.Contains(id))
        {
            if (UserInformation.player.myEquipWeapon.Count == 2)
            {
                // ���� �÷��̾� �����ͷ� ��ġ�� ���� -> ������ ����
                UserInformation.player.LoadLastItemData(id);

                // ������ ���� ����Ʈ�� �߰�
                MyEquipControll(id);

                // ���ݷ��� �ٲ�
                UserInformation.player.minAttackDamage += 
                    (lowDamage * magicNumber + DamageApply(applyDEX, applySTR, applySPD));
                UserInformation.player.maxAttackDamage +=
                    (maxDamage * magicNumber + DamageApply(applyDEX, applySTR, applySPD));
            }
            // �� �� �����ΰ��
            else if (UserInformation.player.myEquipWeapon.Count >= 3)
            {
                UserInformation.player.myEquipWeapon.Clear();
            }
            // �������� ����ִ� ��� ����
            else
            {
                UserInformation.player.LoadLastItemData(id);
                MyEquipControll(id);
                UserInformation.player.minAttackDamage +=
                    (lowDamage * magicNumber + DamageApply(applyDEX, applySTR, applySPD));
                UserInformation.player.maxAttackDamage +=
                    (maxDamage * magicNumber + DamageApply(applyDEX, applySTR, applySPD));
            }
        }
        // !������ �ִ� ��� 1. �������ؼ� �Լ��� �ٽõ��� ��� 2. �ٽ� ������Ų���
        else if (UserInformation.player.myEquipWeapon.Contains(id))
        {
            // (����)������ ���� �����Ͱ� �� ���� ����Ʈ�� ������ �ִ� ���
            if (UserInformation.player.myEquipWeapon.Contains((int)UserInformation.player.lastStats[0]))
            {
                // 1. �ٽ� ������Ų���
                // ������ġ�� �� �����Ͱ� �������� ��
                if (!CompareStat())
                {
                    /*Do Nothing*/
                    return;
                }
                // 2. �������ؼ� �Լ��� �ٽõ��� ���
                // ���� ��ġ�� �� �����Ͱ� �ٸ� ��� -> �������� �� ����
                else
                {
                    UserInformation.player.LoadLastItemData(id);
                    UserInformation.player.minAttackDamage +=
                        (lowDamage * magicNumber + DamageApply(applyDEX, applySTR, applySPD));
                    UserInformation.player.maxAttackDamage +=
                        (maxDamage * magicNumber + DamageApply(applyDEX, applySTR, applySPD));
                }
            }
            // !���� ������ ȿ���� ������ �ʿ��� ���
            // EX (0,1) ������ �Ѵ� ������ �ִµ� 1�� ������ ���� ���¿��� 0�� �������� ������ ���

            //! �������� �����ϴ� ���

            
        }
    }

    // �������� ���� �Ǵ��ϴ� �Լ�
    public bool CompareStat()
    {
        if (UserInformation.player.dex == (int)UserInformation.player.lastStats[3] &&
            UserInformation.player.str == (int)UserInformation.player.lastStats[4] &&
            UserInformation.player.spd == (int)UserInformation.player.lastStats[5])
        {
            return true; // ��� ������ ������ ��� true ��ȯ
        }

        return false; // ������ �������� ���� ��� false ��ȯ
    }

    // 2���� ������ ĭ �� ���� ���� �����ϴ� �Լ�
    public void MyEquipControll(int id)
    {
        if (UserInformation.player.myEquipWeapon[0] == -1 && UserInformation.player.myEquipWeapon[1] == -1)
        {
            UserInformation.player.myEquipWeapon[0] = id;
        }
        else if (UserInformation.player.myEquipWeapon[0] != -1 && UserInformation.player.myEquipWeapon[1] == -1)
        {
            UserInformation.player.myEquipWeapon[1] = id;
        }
        else if (UserInformation.player.myEquipWeapon.Count >= 3)
        {
            Debug.Log("������ ����� �� ������ ����");
            UserInformation.player.myEquipWeapon.Clear();
        }
        else if (UserInformation.player.myEquipWeapon[0] != -1 && UserInformation.player.myEquipWeapon[1] != -1)
        {
            UserInformation.player.myEquipWeapon[0] = id;
        }
    }

    public int DamageApply(int applyDEX, int applySTR, int applySPD)
    {
        applyDEX = UserInformation.player.dex - 5;
        applySTR = UserInformation.player.str - 5;
        applySTR = UserInformation.player.spd - 5;

        int applyDamage = applyDEX + applySTR + applySPD;
        return applyDamage;
    }
}
