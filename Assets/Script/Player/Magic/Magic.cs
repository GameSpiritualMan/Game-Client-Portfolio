using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    //마법 공격력
    private float Damage;
    //소모할 플레이어의 MP
    public float useMP;

    //속성효과

    //불속성
    //화상상태 데미지
    private float BurnDamage;
    //화상상태 지속시간
    private float BurnKeeping;

    //물속성 강화
    //빙결상태 지속시간
    private float FreezingKeep;

    //번개속성 강화
    //감전상태 지속시간
    private float Electric_Shock;

    //흙속성
    //기절상태 지속시간
    private float FaintKeep;

    //바람속성
    //넉백으로 밀어내는 힘
    private float Knockback;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //PlayerController의 마법 공격력의 변수를 가져온다.
        Damage = GameObject.FindWithTag("Player").GetComponent<PlayerController>().MagicAttack;
        //속성 효과
        //불속성 정보
        //플레이어캐릭터의 PlayerController컴포넌트에서 FireDamage를 재정의한다.
        BurnDamage = GameObject.FindWithTag("Player").GetComponent<PlayerController>().FireDamage;
        //플레이어캐릭터의 PlayerController컴포넌트의 FireKeeping를 재정의한다.
        BurnKeeping = GameObject.FindWithTag("Player").GetComponent<PlayerController>().FireKeeping;

        //물속성 정보
        //플레이어 캐릭터의 PlayerController컴포넌트의 KeepFreeze를 재정의한다.
        FreezingKeep = GameObject.FindWithTag("Player").GetComponent<PlayerController>().KeepFreeze;

        //번개속성 정보
        //플레이어 캐릭터의 PlayerController컴포넌트의 KeepElectric를 재정의한다.
        Electric_Shock = GameObject.FindWithTag("Player").GetComponent<PlayerController>().KeepElectric;

        //흙속성 정보
        //플레이어 캐릭터의 PlayerController컴포넌트의 KeepFaint를 재정의한다.
        FaintKeep = GameObject.FindWithTag("Player").GetComponent<PlayerController>().KeepFaint;

        //바람속성 정보
        //플레이어 캐릭터의 PlayerController컴포넌트의 ForceKnockback를 재정의한다.
        Knockback = GameObject.FindWithTag("Player").GetComponent<PlayerController>().ForceKnockback;

        if (collision.CompareTag("SmallEnemy")||collision.CompareTag("BigEnemy")||collision.CompareTag("Boss"))
        {
            collision.GetComponent<EnemyHP>().TakeDamage(Damage);
            if (this.gameObject.name == "FireMagic1" || this.gameObject.name == "FireMagic2")
            {
                //BurnKeeping초 동안 BurnDamage만큼의 데미지를 1.5초 동안 입히는 화상상태를 지속한다.
                collision.GetComponent<EnemyHP>().BurnStart(BurnDamage, BurnKeeping);
                //EnemyHP의 HUDDMGText변수를 가져온다.
                GameObject DMG = collision.GetComponent<EnemyHP>().HUDDMGText;
                //텍스트의 색은 빨간색으로 변한다.
                DMG.GetComponent<DMGText>().text.color = Color.red;
            }
            else if(this.gameObject.name == "WaterMagic1Attack" || this.gameObject.name=="WaterMagic2Attack")
            {
                //FreezingKeep초 동안 빙결상태를 지속한다.
                collision.GetComponent<EnemyController>().FreezeStart(FreezingKeep);
                //EnemyHP의 HUDDMGText변수를 가져온다.
                GameObject DMG = collision.GetComponent<EnemyHP>().HUDDMGText;
                //텍스트의 색은 파란색으로 변한다.
                DMG.GetComponent<DMGText>().text.color = Color.blue;
            }
            else if (this.gameObject.name == "ThunderMagic1" || this.gameObject.name == "ThunderMagic2")
            {
                //Electric_Shock초 동안 감전상태를 지속한다.
                collision.GetComponent<EnemyController>().ElectricsShockStart(Electric_Shock);
                //EnemyHP의 HUDDMGText변수를 가져온다.
                GameObject DMG = collision.GetComponent<EnemyHP>().HUDDMGText;
                //텍스트의 색은 노란색으로 변한다.
                DMG.GetComponent<DMGText>().text.color = Color.yellow;
            }
            else if (this.gameObject.name == "EarthMagic1" || this.gameObject.name == "EarthMagic2")
            {
                //FaintKeep초 동안 기절상태를 지속한다.
                collision.GetComponent<EnemyController>().FaintStart(FaintKeep);
                //EnemyHP의 HUDDMGText변수를 가져온다.
                GameObject DMG = collision.GetComponent<EnemyHP>().HUDDMGText;
                //텍스트의 색은 갈색으로 변한다.
                DMG.GetComponent<DMGText>().text.color = new Color(255 / 255f, 90 / 255f, 0 / 255f, 255 / 255f);
            }
            else if (this.gameObject.name == "WindMagic1" || this.gameObject.name == "WindMagic2")
            {
                //현재 위치에서 Knockback만큼의 힘으로 밀어낸다.
                collision.GetComponent<EnemyController>().KnockBack(this.gameObject.transform.position,Knockback);
                //EnemyHP의 HUDDMGText변수를 가져온다.
                GameObject DMG = collision.GetComponent<EnemyHP>().HUDDMGText;
                //텍스트의 색은 초록색으로 변한다.
                DMG.GetComponent<DMGText>().text.color = Color.green;
            }
        }
    }
}
