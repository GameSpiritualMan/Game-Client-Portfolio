using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PHPText : MonoBehaviour
{
    private PlayerHUD playerHP;
    private Text textHP;

    void Start()
    {
        playerHP = GameObject.FindWithTag("Player").GetComponent<PlayerHUD>();
        textHP = GetComponent<Text>();
    }

    void Update()
    {
        textHP.text = "HP : " + playerHP.curHP + "/" + playerHP.MaxHP;
    }
}
