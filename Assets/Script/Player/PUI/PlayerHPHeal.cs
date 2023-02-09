using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPHeal : MonoBehaviour
{
    private float HPHeal;

    private float TotalHPHeal;

    public float Multiple;
    private PlayerHUD PHP;

    Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        HPHeal = GameObject.FindWithTag("Player").GetComponent<PlayerHUD>().MaxHealth;
        PHP = GameObject.FindWithTag("Player").GetComponent<PlayerHUD>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            TotalHPHeal = (HPHeal / 10) * Multiple;
            PHP.HealHP(TotalHPHeal);
            ObjectPool.OBP.ReturnObject(this.gameObject);
            //Destroy(gameObject);
        }
    }
}