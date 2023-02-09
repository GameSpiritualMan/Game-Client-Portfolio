using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //이동속도를 입력하기 위해 선언한다.
    public float InputSpeed;
    //입력받은 속도값을 대입받기위해 선언한다.
    private float Speed;
    //공격력을 갖춘다.
    public float attackDamage;
    //마법 공격력을 갖춘다.
    public float MagicAttack;

    float v;
    float h;

    private float Ah;

    SpriteRenderer spriterenderer;
    Animator anim;

    //속성 효과 부여

    //불속성
    public float FireDamage;                    //화상상태 데미지
    public float FireKeeping;                   //화상상태 지속시간

    //물속성
    public float KeepFreeze;                    //빙결상태 지속시간

    //번개속성
    public float KeepElectric;                  //감전상태 지속시간

    //흙속성
    public float KeepFaint;                     //기절상태 지속시간

    //바람속성
    public float ForceKnockback;                //넉백으로 밀어내는 힘

    //조이스틱
    [SerializeField]
    private JoyStick movejoystick;

    //UI에 표시하기 위해 선언한다.
    public float ATK => attackDamage;           //attackDamage에 접근할 수 있는 프로퍼티
    public float MATk => MagicAttack;           //MagicAttack에 접근할 수 있는 프로퍼티
    public float BurnDMG => FireDamage;         //FireDamage에 접근할 수 있는 프로퍼티
    public float BurnTime => FireKeeping;       //FireKeeping에 접근할 수 있는 프로퍼티
    public float Freeze => KeepFreeze;          //KeepFreeze에 접근할 수 있는 프로퍼티
    public float EShock => KeepElectric;        //KeepElectric에 접근할 수 있는 프로퍼티
    public float Faint => KeepFaint;            //KeepFaint에 접근할 수 있는 프로퍼티
    public float KnockBack => ForceKnockback;   //ForceKnockback에 접근할 수 있는 프로퍼티
    private void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        movejoystick = GameObject.Find("Canvas").transform.Find("MovingJoystick").GetComponent<JoyStick>();
        
        //해당 슬롯에 저장되어 있다면
        if (PlayerPrefs.GetInt("LoadSaved" + SaveID.saveID) == 1)
        {
            //마법기사의 X축 좌표값이 저장되어 있으면
            if(PlayerPrefs.HasKey("MagicKnightX"+SaveID.saveID))
            {
                //해당슬롯에 저장된 마법기사의 물리 공격력을 불러온다.
                attackDamage = PlayerPrefs.GetFloat("MagicKnightAttack" + SaveID.saveID);
                
                //해당슬롯에 저장된 마법기사의 마법 공격력을 불러온다.
                MagicAttack = PlayerPrefs.GetFloat("MagicKnightMagic" + SaveID.saveID);
                
                //해당슬롯에 저장된 마법기사의 화상상태 데미지를 불러온다.
                FireDamage = PlayerPrefs.GetFloat("MagicKnightFireDamage" + SaveID.saveID);
                
                //해당슬롯에 저장된 마법기사의 화상상태 지속시간을 불러온다.
                FireKeeping = PlayerPrefs.GetFloat("MagicKnightFireKeep" + SaveID.saveID);
                
                //해당슬롯에 저장된 마법기사의 빙결상태 지속시간을 불러온다.
                KeepFreeze = PlayerPrefs.GetFloat("MagicKnightFreeze" + SaveID.saveID);
                
                //해당슬롯에 저장된 마법기사의 감전상태 지속시간을 불러온다.
                KeepElectric = PlayerPrefs.GetFloat("MagicKnightElectric" + SaveID.saveID);
                
                //해당슬롯에 저장된 마법기사의 기절상태 지속시간을 불러온다.
                KeepFaint = PlayerPrefs.GetFloat("MagicKnightFaint" + SaveID.saveID);
                
                //해당슬롯에 저장된 마법기사의 넉백으로 밀어내는 힘을 불러온다.
                ForceKnockback = PlayerPrefs.GetFloat("MagicKnightKnockBack" + SaveID.saveID);
            }
            //마법사의 X축 좌표값이 저장되어 있으면
            else if(PlayerPrefs.HasKey("WizardX" + SaveID.saveID)){
                //해당슬롯에 저장된 마법사의 물리 공격력을 불러온다.
                attackDamage = PlayerPrefs.GetFloat("WizardAttack" + SaveID.saveID);
                
                //해당슬롯에 저장된 마법사의 마법 공격력을 불러온다.
                MagicAttack = PlayerPrefs.GetFloat("WizardMagic" + SaveID.saveID);
                
                //해당슬롯에 저장된 마법사의 화상상태 데미지를 불러온다.
                FireDamage = PlayerPrefs.GetFloat("WizardFireDamage" + SaveID.saveID);
                
                //해당슬롯에 저장된 마법사의 화상상태 지속시간을 불러온다.
                FireKeeping = PlayerPrefs.GetFloat("WizardFireKeep" + SaveID.saveID);
                
                //해당슬롯에 저장된 마법사의 빙결상태 지속시간을 불러온다.
                KeepFreeze = PlayerPrefs.GetFloat("WizardFreeze" + SaveID.saveID);
                
                //해당슬롯에 저장된 마법사의 감전상태 지속시간을 불러온다.
                KeepElectric = PlayerPrefs.GetFloat("WizardElectric" + SaveID.saveID);
                
                //해당슬롯에 저장된 마법사의 기절상태 지속시간을 불러온다.
                KeepFaint = PlayerPrefs.GetFloat("WizardFaint" + SaveID.saveID);
                
                //해당슬롯에 저장된 마법사의 넉백으로 밀어내는 힘을 불러온다.
                ForceKnockback = PlayerPrefs.GetFloat("WizardKnockBack" + SaveID.saveID);
            }
            //엘프의 X축 좌표값이 저장되어 있으면
            else if (PlayerPrefs.HasKey("ElfX" + SaveID.saveID))
            {
                //해당슬롯에 저장된 엘프의 물리 공격력을 불러온다.
                attackDamage = PlayerPrefs.GetFloat("ElfAttack" + SaveID.saveID);
                
                //해당슬롯에 저장된 엘프의 마법 공격력을 불러온다.
                MagicAttack = PlayerPrefs.GetFloat("ElfMagic" + SaveID.saveID);
                
                //해당슬롯에 저장된 엘프의 화상상태 데미지를 불러온다.
                FireDamage = PlayerPrefs.GetFloat("ElfFireDamage" + SaveID.saveID);
                
                //해당슬롯에 저장된 엘프의 화상상태 지속시간을 불러온다.
                FireKeeping = PlayerPrefs.GetFloat("ElfFireKeep" + SaveID.saveID);
                
                //해당슬롯에 저장된 엘프의 빙결상태 지속시간을 불러온다.
                KeepFreeze = PlayerPrefs.GetFloat("ElfFreeze" + SaveID.saveID);
                
                //해당슬롯에 저장된 엘프의 감전상태 지속시간을 불러온다.
                KeepElectric = PlayerPrefs.GetFloat("ElftElectric" + SaveID.saveID);
                
                //해당슬롯에 저장된 엘프의 기절상태 지속시간을 불러온다.
                KeepFaint = PlayerPrefs.GetFloat("ElfFaint" + SaveID.saveID);
                
                //해당슬롯에 저장된 엘프의 넉백으로 밀어내는 힘을 불러온다.
                ForceKnockback = PlayerPrefs.GetFloat("ElfKnockBack" + SaveID.saveID);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //가상 조이스틱
        h = movejoystick.Horizontal();      //좌/우
        v = movejoystick.Vertical();        //위/아래

        //공격 조이스틱 가로 움직임
        Ah = GetComponentInChildren<PlayerShoot>().h;
        
        //Speed에 InputSpeed값이 대입된다. 
        Speed = InputSpeed;

        if (h != 0 || v != 0)
        {
            transform.Translate(new Vector2(h, v) * Speed * Time.deltaTime, Space.Self);
            anim.SetBool("Walk", true);
            //조이스틱이 왼쪽으로 기울어지면
            if (h < 0)
            {
                //왼쪽으로 뒤집어진다.
                spriterenderer.flipX = true;
                //공격 조이스틱을 왼쪽으로 기울면
                if (Ah > 0)
                {
                    //플레이어 오브젝트는 오른쪽으로 뒤집는다.
                    spriterenderer.flipX = false;
                }
            }
            //조이스틱이 오른쪽으로 기울어지면
            else if (h > 0)
            {
                //오른쪽으로 뒤집어진다.
                spriterenderer.flipX = false;
                //공격 조이스틱을 오른쪽을 기울이면
                if(Ah < 0)
                {
                    //플레이어 오브젝트는 왼쪽으로 뒤집어진다.
                    spriterenderer.flipX = true;
                }
            }
        }
        else if (h == 0 && v == 0)
        {
            anim.SetBool("Walk", false);
        }
    }

    //물리 공격력 강화 함수
    public void AttackUP(float StrengthUP)
    {
        //물리 공격력은 StrengthUp만큼 증가한다.
        attackDamage += StrengthUP;
    }

    //마법 공격력 강화 함수
    public void MagicUp(float magicUp)
    {
        //마법 공격력은 magicUp만큼 증가한다.
        MagicAttack += magicUp;
    }

    //불속성 강화
    public void BurnStrength(float BurnDamage,float KeepingTime)
    {
        //BurnDamage만큼 화상상태 데미지가 강해진다.
        FireDamage += BurnDamage;

        //KeepingTime만큼 화상상태 지속시간이 증가한다.
        FireKeeping += KeepingTime;
    }

    //물속성 강화
    public void FreezingStrength(float KeepingTime)
    {
        //KeepingTime만큼 빙결상태 지속시간이 증가한다.
        KeepFreeze += KeepingTime;
    }

    //번개속성 강화
    public void ElectricShockStrength(float KeepingTime)
    {
        //KeepingTime만큼 감전상태 지속시간이 증가한다.
        KeepElectric += KeepingTime;
    }

    //흙속성 강화
    public void FaintStrength(float KeepingTime)
    {
        //KeepingTime만큼 기절상태 지속시간이 증가한다.
        KeepFaint += KeepingTime;
    }

    //바람속성 강화
    public void KnockBackStrength(float ForceKnockBack)
    {
        //ForceKnockback만큼 넉백으로 밀어내는 힘이 증가한다.
        ForceKnockback += ForceKnockBack;
    }
}
