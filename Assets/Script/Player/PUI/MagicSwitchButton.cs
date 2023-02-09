using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSwitchButton : MonoBehaviour
{
    private PlayerMagicInventory PMagic;

    void Start()
    {
        PMagic = GameObject.FindWithTag("Player").GetComponentInChildren<PlayerMagicInventory>();
    }

    public void ChangeMagic(int MagicNum)
    {
        PMagic.MagicChange(MagicNum);
    }
}
