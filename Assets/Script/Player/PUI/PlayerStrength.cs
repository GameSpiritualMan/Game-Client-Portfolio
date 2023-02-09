using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStrength : MonoBehaviour
{
    //플레에어 스테이터스 강화
    public float AttackUp;                  //강화할 플레이어 물리 공격력 수치
    public float MagicAttackUP;             //강화할 플레이어 마법 공격력 수치
    public float MaxHPUp;                   //강화할 플레이어 최대 HP 수치
    public float MaxMPUp;                   //강화할 플레이어 최대 MP 수치

    //속성의 효과를 강화
    //불속성 화상상태
    public float BurnDamage;                //화상상태 데미지
    public float BurnKeeping;               //화상상태 지속시간

    //물속성 빙결상태
    public float FreezeKeep;                //빙결상태 지속시간

    //번개속성 감전상태
    public float ElectricShock;             //감전상태 지속시간

    //흙속성 기절상태
    public float FaintKeep;                 //기절상태 지속시간

    //바람속성 넉백
    public float KnockBack;                 //넉백시 밀어내는 힘
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            //플레이어의 물리 공격력 강화
            collision.gameObject.GetComponent<PlayerController>().AttackUP(AttackUp);
            //플레이어의 마법 공격력 강화
            collision.gameObject.GetComponent<PlayerController>().MagicUp(MagicAttackUP);
            //플레이어의 최대 HP 강화
            collision.gameObject.GetComponent<PlayerHUD>().StrengthHP(MaxHPUp);
            //플레이어의 최대 MP 강화
            collision.gameObject.GetComponent<PlayerHUD>().StrengthMP(MaxMPUp);
            //플레이어의 불속성 강화
            collision.gameObject.GetComponent<PlayerController>().BurnStrength(BurnDamage, BurnKeeping);
            //플레이어의 물속성 강화
            collision.gameObject.GetComponent<PlayerController>().FreezingStrength(FreezeKeep);
            //플레이어의 번개속성 강화
            collision.gameObject.GetComponent<PlayerController>().ElectricShockStrength(ElectricShock);
            //플레이어의 흙속성 강화
            collision.gameObject.GetComponent<PlayerController>().FaintStrength(FaintKeep);
            //플렝이어의 바람속성 강화
            collision.gameObject.GetComponent<PlayerController>().KnockBackStrength(KnockBack);
            ObjectPool.OBP.ReturnObject(this.gameObject);
        }
    }
}
