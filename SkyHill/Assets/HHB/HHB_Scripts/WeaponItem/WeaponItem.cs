using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WeaponItem : MonoBehaviour, IWeaponItem
{

    //ID / LOW_DAMAGE / MAX_DAMAGE / REQ_DEX / REQ_STR  /REQ_SPD

    // ���� ������ ������ �迭
    // �̰� �о �̹��� ����ϰ� �����ؾ��ҵ�
    public static List<int> myEquipWeapon = new List<int>() { -1, -1};
    // ���� �÷��̾� ����
    // {lastWeaponID, playerLastMinDamage, playerLastMaxDamage, playerLastDEX, playerLastSTR, playerLastSPD}
    //       [0]             [1]             [2]          [3]         [4]         [5]             [6]
    // IDEA
    // ���� �������� ���� �����͸� �׻� ������ �ִٰ� ������
    private List<float> lastStats = new List<float>();

    // �ʱⰪ ��Ͽ���....�ݵ�� �ּ� ó��
    private void Awake()
    {
        lastStats.Add(-1f);
        lastStats.Add(4f);
        lastStats.Add(10f);
        lastStats.Add(5f);
        lastStats.Add(5f);
        lastStats.Add(5f);

    }

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
        // �������� 2���� ���� ���� 1�� �ڸ��� �ٲ� (�켱 ���콺 �����ʸ� �����ϰ�)
        // ������ �ȵǾ� �ִ� ����
        // !�÷��̾� �ʱⰪ���� �����ְ� ������ ����
        if (!myEquipWeapon.Contains(id))
        {
            if (myEquipWeapon.Count == 2)
            {
                // ���� �÷��̾� �����ͷ� ��ġ�� ���� -> ������ ����
                LoadLastItemData(id);

                // ������ ���� ����Ʈ�� �߰�
                MyEquipControll(id);
                
                // ���ݷ��� �ٲ�
                UserInformation.player.minAttackDamage += lowDamage;
                UserInformation.player.maxAttackDamage += maxDamage;
            }
            // �� �� �����ΰ��
            else if (myEquipWeapon.Count >= 3)
            {
                myEquipWeapon.Clear();
            }
            // �������� ����ִ� ��� ����
            else
            {
                LoadLastItemData(id);
                UserInformation.player.minAttackDamage += lowDamage;
                UserInformation.player.maxAttackDamage += maxDamage;
                MyEquipControll(id);
            }
        }
        // !������ �ִ� ��� 1. �������ؼ� �Լ��� �ٽõ��� ��� 2. �ٽ� ������Ų���
        else if (myEquipWeapon.Contains(id))
        {
            // (����)������ ���� �����Ͱ� �� ���� ����Ʈ�� ������ �ִ� ���
            if (myEquipWeapon.Contains((int)lastStats[0]))
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
                    LoadLastItemData(id);
                    UserInformation.player.minAttackDamage += lowDamage;
                    UserInformation.player.maxAttackDamage += maxDamage;
                }

            }
        }

    } 
    // ���� ���� ����
    public void UnSatisfyStat(float lowDamage, float maxDamage, int id)
    {
        // ������ ������ magicNumber ���� ����� �Ÿ� ���̰� �ִ�.
        float magicNumber = 0.33f;
        // �������� 2���� ���� ���� 1�� �ڸ��� �ٲ� (�켱 ���콺 �����ʸ� �����ϰ�)
        // ������ �ȵǾ� �ִ� ����
        // !�÷��̾� �ʱⰪ���� �����ְ� ������ ����
        if (!myEquipWeapon.Contains(id))
        {
            if (myEquipWeapon.Count == 2)
            {
                // ���� �÷��̾� �����ͷ� ��ġ�� ���� -> ������ ����
                LoadLastItemData(id);

                // ������ ���� ����Ʈ�� �߰�
                MyEquipControll(id);

                // ���ݷ��� �ٲ�
                UserInformation.player.minAttackDamage += lowDamage* magicNumber;
                UserInformation.player.maxAttackDamage += maxDamage* magicNumber;
            }
            // �� �� �����ΰ��
            else if (myEquipWeapon.Count >= 3)
            {
                myEquipWeapon.Clear();
            }
            // �������� ����ִ� ��� ����
            else
            {
                LoadLastItemData(id);
                MyEquipControll(id);
                UserInformation.player.minAttackDamage += lowDamage * magicNumber;
                UserInformation.player.maxAttackDamage += maxDamage * magicNumber;
            }
        }
        // !������ �ִ� ��� 1. �������ؼ� �Լ��� �ٽõ��� ��� 2. �ٽ� ������Ų���
        else if (myEquipWeapon.Contains(id))
        {
            // (����)������ ���� �����Ͱ� �� ���� ����Ʈ�� ������ �ִ� ���
            if (myEquipWeapon.Contains((int)lastStats[0]))
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
                    LoadLastItemData(id);
                    UserInformation.player.minAttackDamage += lowDamage * magicNumber;
                    UserInformation.player.maxAttackDamage += maxDamage * magicNumber;
                }
            }
            // !���� ������ ȿ���� ������ �ʿ��� ���
            // EX (0,1) ������ �Ѵ� ������ �ִµ� 1�� ������ ���� ���¿��� 0�� �������� ������ ���

            //! �������� �����ϴ� ���

            
        }
    }


    // !!!!! ���� ���� �ݵ�� �� �Լ� ȣ���ؾ���.!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    // ������ ���� ���� ����
    public void SaveLastItemData(int id)
    {
        //{ lastWeaponID, playerLastMinDamage, playerLastMaxDamage, playerLastDEX, playerLastSTR, playerLastSPD}
        //       [0]             [1]             [2]          [3]         [4]         [5]             [6]

        // ������ ������ ���� ����
        lastStats[0] = id;
        lastStats[1] = UserInformation.player.minAttackDamage;
        lastStats[2] = UserInformation.player.maxAttackDamage;
        lastStats[3] = UserInformation.player.dex;
        lastStats[4] = UserInformation.player.str;
        lastStats[5] = UserInformation.player.spd;
    }
    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


    // ���� ���� ����
    public void LoadLastItemData(int id)
    {
        //{ lastWeaponID, playerLastMinDamage, playerLastMaxDamage, playerLastDEX, playerLastSTR, playerLastSPD}
        //       [0]             [1]             [2]          [3]         [4]         [5]             [6]

        // ������ ������ �������� ����
        id = (int)lastStats[0];
        UserInformation.player.minAttackDamage = lastStats[1];
        UserInformation.player.maxAttackDamage = lastStats[2];
        UserInformation.player.dex = (int)lastStats[3];
        UserInformation.player.str = (int)lastStats[4];
        UserInformation.player.spd = (int)lastStats[5];
    }

    // �������� ���� �Ǵ��ϴ� �Լ�
    public bool CompareStat()
    {
        if (UserInformation.player.dex == (int)lastStats[3] &&
            UserInformation.player.str == (int)lastStats[4] &&
            UserInformation.player.spd == (int)lastStats[5])
        {
            return true; // ��� ������ ������ ��� true ��ȯ
        }

        return false; // ������ �������� ���� ��� false ��ȯ
    }

    // 2���� ������ ĭ �� ���� ���� �����ϴ� �Լ�
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
            Debug.Log("������ ����� �� ������ ����");
            myEquipWeapon.Clear();
        }
        else if (myEquipWeapon[0] != -1 && myEquipWeapon[1] != -1)
        {
            myEquipWeapon[0] = id;
        }


    }
}
