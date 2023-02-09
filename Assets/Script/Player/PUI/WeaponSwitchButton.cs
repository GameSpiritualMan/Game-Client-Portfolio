using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitchButton : MonoBehaviour
{
    PlayerWeaponInventory PAttack;

    void Start()
    {
        PAttack = GameObject.FindWithTag("Player").GetComponentInChildren<PlayerWeaponInventory>();
    }

    public void WeaponChange(int WeaponNum)
    {
        PAttack.SelectWeapon(WeaponNum);
    }
}
