using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IhPItem
{
    // ü�� ������
    public void UseHealthItem(int itemId);

    // ���� ������
    public void UseFoodItem(int itemId);

    // ���� ���� ������
    public void UseSpoiledFood(int itemId);
}
