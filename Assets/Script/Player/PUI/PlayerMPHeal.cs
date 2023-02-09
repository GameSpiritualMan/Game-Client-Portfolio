using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMPHeal : MonoBehaviour
{
    private float MPHeal;

    private float TotalMPHeal;

    public float Multiple;
    private PlayerHUD PMP;

    Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        MPHeal = GameObject.FindWithTag("Player").GetComponent<PlayerHUD>().MaxMana;
        PMP = GameObject.FindWithTag("Player").GetComponent<PlayerHUD>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            TotalMPHeal = (MPHeal / 10) * Multiple;
            PMP.HealMP(TotalMPHeal);
            ObjectPool.OBP.ReturnObject(this.gameObject);
            //Destroy(gameObject);
        }
    }
}