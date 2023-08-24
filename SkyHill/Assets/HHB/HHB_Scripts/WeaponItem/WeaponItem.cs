using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponItem : MonoBehaviour, IWeaponItem
{
    public static WeaponItem weaponItem;

    //ID / LOW_DAMAGE / MAX_DAMAGE / REQ_DEX / REQ_STR  /REQ_SPD
    // ���� �����ϴ� �Լ�

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

    // ���� �з��ϴ� �Լ�
    public void StatsClassify(float lowDamage, float maxDamage,
        int reqDEX, int reqSTR, int reqSPD, int id)
    {
        // ��� ������ ������ ���
        if (UserInformation.player.dex >= reqDEX &&
            UserInformation.player.str >= reqSTR &&
            UserInformation.player.spd >= reqSPD)
        {
            //Debug.Log("����");
            SatisfyStat(lowDamage, maxDamage, id);
        }
        // ���� ������
        else
        {
            //Debug.Log("������");
            UnSatisfyStat(lowDamage, maxDamage, id);
        }

    }

    // ���� ���� ����
    public void SatisfyStat(float lowDamage, float maxDamage, int id)
    {

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
                float minDamage = lowDamage + DamageApply();
                float highDamage = maxDamage + DamageApply();
                UserInformation.player.minAttackDamage += minDamage;
                UserInformation.player.maxAttackDamage += highDamage;
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
                float minDamage = lowDamage + DamageApply();
                float highDamage = maxDamage + DamageApply();
                UserInformation.player.minAttackDamage += minDamage;
                UserInformation.player.maxAttackDamage += highDamage;
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
                if (!CompareStat())
                {
                    /*Do Nothing*/
                    return;
                }
                // 2. �������ؼ� �Լ��� �ٽõ��� ���
                // ���� ��ġ�� �� �����Ͱ� �ٸ� ��� -> �������� �� ����
                else
                {
                    //Debug.LogFormat("�� min: {0}",UserInformation.player.minAttackDamage);
                    //Debug.LogFormat("�� max: {0}",UserInformation.player.maxAttackDamage);

                    //Debug.LogFormat("����� min : {0}",UserInformation.player.lastStats[1]);
                    //Debug.LogFormat("����� max : {0}",UserInformation.player.lastStats[2]);

                    UserInformation.player.LoadLastItemData(id);

                    float minDamage = lowDamage + DamageApply();
                    float highDamage = maxDamage + DamageApply();
                    UserInformation.player.minAttackDamage += minDamage;
                    UserInformation.player.maxAttackDamage += highDamage;

                    //Debug.LogFormat("����� min : {0}", UserInformation.player.lastStats[1]);
                    //Debug.LogFormat("����� max : {0}", UserInformation.player.lastStats[2]);

                    //Debug.LogFormat("�� min: {0}", UserInformation.player.minAttackDamage);
                    //Debug.LogFormat("�� max: {0}", UserInformation.player.maxAttackDamage);
                }

            }
        }

    }
    // ���� ���� ����
    public void UnSatisfyStat(float lowDamage, float maxDamage, int id)
    {

        // ������ ������ magicNumber ���� ����� �Ÿ� ���̰� �ִ�.
        float magicNumber = 0.66f;
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
                UserInformation.player.LoadLastItemData(id);
                float minDamage = (lowDamage * magicNumber) +
                    (DamageApply());
                float highDamage = (maxDamage * magicNumber) +
                    (DamageApply());
                UserInformation.player.minAttackDamage += minDamage;
                UserInformation.player.maxAttackDamage += highDamage;
            }
            // �� �� �����ΰ��
            else if (UserInformation.player.myEquipWeapon.Count >= 3)
            {
                UserInformation.player.myEquipWeapon.Clear();
            }
            // �������� ����ִ� ��� ����
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
                    return;
                }
                // 2. �������ؼ� �Լ��� �ٽõ��� ���
                // ���� ��ġ�� �� �����Ͱ� �ٸ� ��� -> �������� �� ����
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
        // 0���� 1�� �Ѵ� ��� ��� -> 0���� �ֱ�
        if (UserInformation.player.myEquipWeapon[0] == -1 && UserInformation.player.myEquipWeapon[1] == -1)
        {
            UserInformation.player.myEquipWeapon[0] = id;
        }
        // 1���� ��� ��� -> 1���� �ֱ�
        else if (UserInformation.player.myEquipWeapon[0] != -1 && UserInformation.player.myEquipWeapon[1] == -1)
        {
            UserInformation.player.myEquipWeapon[1] = id;
        }
        // ����
        else if (UserInformation.player.myEquipWeapon.Count >= 3)
        {
            Debug.Log("������ ����� �� ������ ����");
            UserInformation.player.myEquipWeapon.Clear();
        }
        // 0�� �� 1�� �Ѵ� �ִ� ��� -> 0���� �����
        else if (UserInformation.player.myEquipWeapon[0] != -1 && UserInformation.player.myEquipWeapon[1] != -1)
        {
            UserInformation.player.myEquipWeapon[0] = id;
        }
        // 0���� ��� 1���� �ִ� ��� -> 0���� �ֱ�
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




