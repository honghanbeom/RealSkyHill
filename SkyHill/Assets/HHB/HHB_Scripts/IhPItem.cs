using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IhPItem
{
    // 체력 아이템
    public void UseHealthItem(int itemId);

    // 음식 아이템
    public void UseFoodItem(int itemId);

    // 상한 음식 아이템
    public void UseSpoiledFood(int itemId);
}
