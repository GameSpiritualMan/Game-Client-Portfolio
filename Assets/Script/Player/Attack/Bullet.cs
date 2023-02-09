using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //대입할 속도값
    public float defaultSpeed;
    //실제 대입된 속도값
    [SerializeField] private float speed;

    //플레이어의 물리 공격력을 가져온다.
    private float Damage;

    private Animator anim;

    //화상상태 효과
    private float BurnDamage;    //화상상태 데미지
    private float BurnKeeping;   //화상상태 지속시간

    //빙결상태 효과
    private float FreezingKeeping;   //빙결상태 지속시간

    //감전상태 효과
    private float Electric_Shock_Keeping;    //감전상태 지속시간

    //기절상태 효과
    private float FaintKeeping;  //기절상태 지속시간

    //넉백 파워
    private float KnockBack;     //넉백으로 밀어내는 힘

    private AudioSource Hitaudio;

    //애니메이션 및 이미지 효과
    public GameObject Effect;

    private void OnEnable()
    {
        speed = defaultSpeed;
        Invoke("DestroyWeapon", 4);
        anim = GetComponent<Animator>();
        Hitaudio = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        //매프레임마다 지정된 방향으로 움직인다.
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);
    }

    void DestroyWeapon()
    {
        //오브젝트 풀로 인해 반환하며 비활성화 된다.
        ObjectPool.OBP.ReturnObject(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //적에게 주는 피해량은 플레이어 캐릭터의 PlayerController컴포넌트의 attackDamage를 재정의 한다.
        Damage = GameObject.FindWithTag("Player").GetComponent<PlayerController>().attackDamage;        
        //작은 적들, 큰 적들, 보스들과 부딧히히면
        if (collision.CompareTag("SmallEnemy")||collision.CompareTag("BigEnemy")||collision.CompareTag("Boss"))
        {
            //Audio를 재생한다.
            Hitaudio.Play();
            //화상상태 피해량
            BurnDamage = GameObject.FindWithTag("Player").GetComponent<PlayerController>().FireDamage;
            //화상상태 지속시간
            BurnKeeping = GameObject.FindWithTag("Player").GetComponent<PlayerController>().FireKeeping;
            //빙결상태 지속시간
            FreezingKeeping = GameObject.FindWithTag("Player").GetComponent<PlayerController>().KeepFreeze;
            //감전상태 지속시간
            Electric_Shock_Keeping = GameObject.FindWithTag("Player").GetComponent<PlayerController>().KeepElectric;
            //감전상태 지속시간
            FaintKeeping = GameObject.FindWithTag("Player").GetComponent<PlayerController>().KeepFaint;
            //넉백으로 밀어내는 힘
            KnockBack = GameObject.FindWithTag("Player").GetComponent<PlayerController>().ForceKnockback;
            //Damage만큼 적의 HP는 줄어든다.
            collision.gameObject.GetComponent<EnemyHP>().TakeDamage(Damage);
            //플레이어의 검기가 아니면
            if (this.gameObject.tag != "PlayerSword")
            {
                //스피드는 0이 된다.
                speed = 0;
                //collision 파라미터를 실행한다.
                anim.SetBool("collision", true);
            }
            else
            {
                //이 오브젝트의 이름에 따라 실행한다.
                switch (this.gameObject.name)
                {
                    //RoyalSword이면
                    case "RoyalSword":
                        //HitEffect 오브젝트를 꺼내온다.
                        Effect = ObjectPool.OBP.GetObject("HitEffect");
                        //충돌체(적들)와 RoyalSword 사이의 가운데에서 위치한다.
                        Effect.transform.position = collision.transform.position;
                        //HitEffect 오브젝트를 활성화 한다.
                        Effect.SetActive(true);
                        break;
                    //FireSword이면
                    case "FireSword":
                        //FireHitEffect 오브젝트를 꺼내온다.
                        Effect = ObjectPool.OBP.GetObject("FireHitEffect");
                        //충돌체(적들)와 FireSword 사이의 가운데에서 위치한다.
                        Effect.transform.position = collision.transform.position;
                        //FireHitEffect 오브젝트를 활성화 한다.
                        Effect.SetActive(true);
                        break;
                    case "AquaSword":
                        //AquaHitEffect 오브젝트를 꺼내온다.
                        Effect = ObjectPool.OBP.GetObject("AquaHitEffect");
                        //충돌체(적들)와 AquaSword 사이의 가운데에서 위치한다.
                        Effect.transform.position = collision.transform.position;
                        //AquaHitEffect 오브젝트를 활성화 한다.
                        Effect.SetActive(true);
                        break;
                    case "ThunderSword":
                        //ThunderHitEffect 오브젝트를 꺼내온다.
                        Effect = ObjectPool.OBP.GetObject("ThunderHitEffect");
                        //충돌체(적들)와 ThunderSword 사이의 가운데에서 위치한다.
                        Effect.transform.position = collision.transform.position;
                        //ThunderHitEffect 오브젝트를 활성화 한다.
                        Effect.SetActive(true);
                        break;
                    case "EarthSword":
                        //충돌체(적들)와 EarthSword 사이의 가운데에서 위치한다.
                        Effect = ObjectPool.OBP.GetObject("EarthHitEffect");
                        //충돌체(적들)와 EarthSword 사이의 가운데에서 위치한다.
                        Effect.transform.position = collision.transform.position;
                        //EarthHitEffect 오브젝트를 활성화 한다.
                        Effect.SetActive(true);
                        break;
                    case "WindSword":
                        //충돌체(적들)와 WindSword 사이의 가운데에서 위치한다.
                        Effect = ObjectPool.OBP.GetObject("WindHitEffect");
                        //충돌체(적들)와 WindSword 사이의 가운데에서 위치한다.
                        Effect.transform.position = collision.transform.position;
                        //WindHitEffect 오브젝트를 활성화 한다.
                        Effect.SetActive(true);
                        break;
                }
            }
            //불속성 총알, 불속성 검기이거나 불속성 화살이면
            if (this.gameObject.name == "FireBullet" || this.gameObject.name == "FireArrow" || this.gameObject.name=="FireSword")
            {
                //적은 화상상태를 빠진다.
                collision.gameObject.GetComponent<EnemyHP>().BurnStart(BurnDamage, BurnKeeping);
                //EnemyHP의 HUDDMGText변수를 가져온다.
                GameObject DMG = collision.GetComponent<EnemyHP>().HUDDMGText;
                //데미지 텍스트의 텍스트 색은 빨간색으로 변한다.
                DMG.GetComponent<DMGText>().text.color = Color.red;
            }
            //물속성 총알, 물속성 검기이거나 물속성 화살이면
            else if (this.gameObject.name == "AquaBullet" || this.gameObject.name == "AquaArrow" || this.gameObject.name=="AquaSword")
            {
                //적은 빙결상태에 빠진다.
                collision.gameObject.GetComponent<EnemyController>().FreezeStart(FreezingKeeping);
                //EnemyHP의 HUDDMGText변수를 가져온다.
                GameObject DMG = collision.GetComponent<EnemyHP>().HUDDMGText;
                //데미지 텍스트의 텍스트 색은 파란색으로 변한다.
                DMG.GetComponent<DMGText>().text.color = Color.blue;
            }
            //번개속성 총알이거나 번개속성 검기이면
            else if (this.gameObject.name == "ThunderBullet" || this.gameObject.name == "ThunderSword")
            {
                //적은 감전상태에 빠진다.
                collision.gameObject.GetComponent<EnemyController>().ElectricsShockStart(Electric_Shock_Keeping);
                //EnemyHP의 HUDDMGText변수를 가져온다.
                GameObject DMG = collision.GetComponent<EnemyHP>().HUDDMGText;
                //데미지 텍스트의 텍스트 색은 노란색으로 변한다.
                DMG.GetComponent<DMGText>().text.color = Color.yellow;
            }
            //흙속성 총알이거나 흙속성 검기이면
            else if (this.gameObject.name == "EarthBullet" || this.gameObject.name == "EarthSword" )
            {
                //적은 기절상태가 된다.
                collision.gameObject.GetComponent<EnemyController>().FaintStart(FaintKeeping);
                //EnemyHP의 HUDDMGText변수를 가져온다.
                GameObject DMG = collision.GetComponent<EnemyHP>().HUDDMGText;
                //데미지 텍스트의 텍스트 색은 갈색으로 변한다.
                DMG.GetComponent<DMGText>().text.color = new Color(255/255f, 90/255f, 0/255f,255/255f);
            }
            //바람속성 총알, 바람속성 검기이거나 바람속성 화살이면
            else if (this.gameObject.name == "WindBullet" || this.gameObject.name == "WindArrow" || this.gameObject.name == "WindSword")
            {
                //이 오브젝트의 위치에서 KnockBack만큼의 힘으로 밀어낸다.
                collision.gameObject.GetComponent<EnemyController>().KnockBack(this.transform.position,KnockBack);
                //EnemyHP의 HUDDMGText변수를 가져온다.
                GameObject DMG = collision.GetComponent<EnemyHP>().HUDDMGText;
                //데미지 텍스트의 텍스트 색은 초록색으로 변한다.
                DMG.GetComponent<DMGText>().text.color = Color.green;
            }
        }
    }
}
