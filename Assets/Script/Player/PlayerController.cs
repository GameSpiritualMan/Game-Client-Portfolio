using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //�̵��ӵ��� �Է��ϱ� ���� �����Ѵ�.
    public float InputSpeed;
    //�Է¹��� �ӵ����� ���Թޱ����� �����Ѵ�.
    private float Speed;
    //���ݷ��� �����.
    public float attackDamage;
    //���� ���ݷ��� �����.
    public float MagicAttack;

    float v;
    float h;

    private float Ah;

    SpriteRenderer spriterenderer;
    Animator anim;

    //�Ӽ� ȿ�� �ο�

    //�ҼӼ�
    public float FireDamage;                    //ȭ����� ������
    public float FireKeeping;                   //ȭ����� ���ӽð�

    //���Ӽ�
    public float KeepFreeze;                    //������� ���ӽð�

    //�����Ӽ�
    public float KeepElectric;                  //�������� ���ӽð�

    //��Ӽ�
    public float KeepFaint;                     //�������� ���ӽð�

    //�ٶ��Ӽ�
    public float ForceKnockback;                //�˹����� �о�� ��

    //���̽�ƽ
    [SerializeField]
    private JoyStick movejoystick;

    //UI�� ǥ���ϱ� ���� �����Ѵ�.
    public float ATK => attackDamage;           //attackDamage�� ������ �� �ִ� ������Ƽ
    public float MATk => MagicAttack;           //MagicAttack�� ������ �� �ִ� ������Ƽ
    public float BurnDMG => FireDamage;         //FireDamage�� ������ �� �ִ� ������Ƽ
    public float BurnTime => FireKeeping;       //FireKeeping�� ������ �� �ִ� ������Ƽ
    public float Freeze => KeepFreeze;          //KeepFreeze�� ������ �� �ִ� ������Ƽ
    public float EShock => KeepElectric;        //KeepElectric�� ������ �� �ִ� ������Ƽ
    public float Faint => KeepFaint;            //KeepFaint�� ������ �� �ִ� ������Ƽ
    public float KnockBack => ForceKnockback;   //ForceKnockback�� ������ �� �ִ� ������Ƽ
    private void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        movejoystick = GameObject.Find("Canvas").transform.Find("MovingJoystick").GetComponent<JoyStick>();
        
        //�ش� ���Կ� ����Ǿ� �ִٸ�
        if (PlayerPrefs.GetInt("LoadSaved" + SaveID.saveID) == 1)
        {
            //��������� X�� ��ǥ���� ����Ǿ� ������
            if(PlayerPrefs.HasKey("MagicKnightX"+SaveID.saveID))
            {
                //�ش罽�Կ� ����� ��������� ���� ���ݷ��� �ҷ��´�.
                attackDamage = PlayerPrefs.GetFloat("MagicKnightAttack" + SaveID.saveID);
                
                //�ش罽�Կ� ����� ��������� ���� ���ݷ��� �ҷ��´�.
                MagicAttack = PlayerPrefs.GetFloat("MagicKnightMagic" + SaveID.saveID);
                
                //�ش罽�Կ� ����� ��������� ȭ����� �������� �ҷ��´�.
                FireDamage = PlayerPrefs.GetFloat("MagicKnightFireDamage" + SaveID.saveID);
                
                //�ش罽�Կ� ����� ��������� ȭ����� ���ӽð��� �ҷ��´�.
                FireKeeping = PlayerPrefs.GetFloat("MagicKnightFireKeep" + SaveID.saveID);
                
                //�ش罽�Կ� ����� ��������� ������� ���ӽð��� �ҷ��´�.
                KeepFreeze = PlayerPrefs.GetFloat("MagicKnightFreeze" + SaveID.saveID);
                
                //�ش罽�Կ� ����� ��������� �������� ���ӽð��� �ҷ��´�.
                KeepElectric = PlayerPrefs.GetFloat("MagicKnightElectric" + SaveID.saveID);
                
                //�ش罽�Կ� ����� ��������� �������� ���ӽð��� �ҷ��´�.
                KeepFaint = PlayerPrefs.GetFloat("MagicKnightFaint" + SaveID.saveID);
                
                //�ش罽�Կ� ����� ��������� �˹����� �о�� ���� �ҷ��´�.
                ForceKnockback = PlayerPrefs.GetFloat("MagicKnightKnockBack" + SaveID.saveID);
            }
            //�������� X�� ��ǥ���� ����Ǿ� ������
            else if(PlayerPrefs.HasKey("WizardX" + SaveID.saveID)){
                //�ش罽�Կ� ����� �������� ���� ���ݷ��� �ҷ��´�.
                attackDamage = PlayerPrefs.GetFloat("WizardAttack" + SaveID.saveID);
                
                //�ش罽�Կ� ����� �������� ���� ���ݷ��� �ҷ��´�.
                MagicAttack = PlayerPrefs.GetFloat("WizardMagic" + SaveID.saveID);
                
                //�ش罽�Կ� ����� �������� ȭ����� �������� �ҷ��´�.
                FireDamage = PlayerPrefs.GetFloat("WizardFireDamage" + SaveID.saveID);
                
                //�ش罽�Կ� ����� �������� ȭ����� ���ӽð��� �ҷ��´�.
                FireKeeping = PlayerPrefs.GetFloat("WizardFireKeep" + SaveID.saveID);
                
                //�ش罽�Կ� ����� �������� ������� ���ӽð��� �ҷ��´�.
                KeepFreeze = PlayerPrefs.GetFloat("WizardFreeze" + SaveID.saveID);
                
                //�ش罽�Կ� ����� �������� �������� ���ӽð��� �ҷ��´�.
                KeepElectric = PlayerPrefs.GetFloat("WizardElectric" + SaveID.saveID);
                
                //�ش罽�Կ� ����� �������� �������� ���ӽð��� �ҷ��´�.
                KeepFaint = PlayerPrefs.GetFloat("WizardFaint" + SaveID.saveID);
                
                //�ش罽�Կ� ����� �������� �˹����� �о�� ���� �ҷ��´�.
                ForceKnockback = PlayerPrefs.GetFloat("WizardKnockBack" + SaveID.saveID);
            }
            //������ X�� ��ǥ���� ����Ǿ� ������
            else if (PlayerPrefs.HasKey("ElfX" + SaveID.saveID))
            {
                //�ش罽�Կ� ����� ������ ���� ���ݷ��� �ҷ��´�.
                attackDamage = PlayerPrefs.GetFloat("ElfAttack" + SaveID.saveID);
                
                //�ش罽�Կ� ����� ������ ���� ���ݷ��� �ҷ��´�.
                MagicAttack = PlayerPrefs.GetFloat("ElfMagic" + SaveID.saveID);
                
                //�ش罽�Կ� ����� ������ ȭ����� �������� �ҷ��´�.
                FireDamage = PlayerPrefs.GetFloat("ElfFireDamage" + SaveID.saveID);
                
                //�ش罽�Կ� ����� ������ ȭ����� ���ӽð��� �ҷ��´�.
                FireKeeping = PlayerPrefs.GetFloat("ElfFireKeep" + SaveID.saveID);
                
                //�ش罽�Կ� ����� ������ ������� ���ӽð��� �ҷ��´�.
                KeepFreeze = PlayerPrefs.GetFloat("ElfFreeze" + SaveID.saveID);
                
                //�ش罽�Կ� ����� ������ �������� ���ӽð��� �ҷ��´�.
                KeepElectric = PlayerPrefs.GetFloat("ElftElectric" + SaveID.saveID);
                
                //�ش罽�Կ� ����� ������ �������� ���ӽð��� �ҷ��´�.
                KeepFaint = PlayerPrefs.GetFloat("ElfFaint" + SaveID.saveID);
                
                //�ش罽�Կ� ����� ������ �˹����� �о�� ���� �ҷ��´�.
                ForceKnockback = PlayerPrefs.GetFloat("ElfKnockBack" + SaveID.saveID);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //���� ���̽�ƽ
        h = movejoystick.Horizontal();      //��/��
        v = movejoystick.Vertical();        //��/�Ʒ�

        //���� ���̽�ƽ ���� ������
        Ah = GetComponentInChildren<PlayerShoot>().h;
        
        //Speed�� InputSpeed���� ���Եȴ�. 
        Speed = InputSpeed;

        if (h != 0 || v != 0)
        {
            transform.Translate(new Vector2(h, v) * Speed * Time.deltaTime, Space.Self);
            anim.SetBool("Walk", true);
            //���̽�ƽ�� �������� ��������
            if (h < 0)
            {
                //�������� ����������.
                spriterenderer.flipX = true;
                //���� ���̽�ƽ�� �������� ����
                if (Ah > 0)
                {
                    //�÷��̾� ������Ʈ�� ���������� �����´�.
                    spriterenderer.flipX = false;
                }
            }
            //���̽�ƽ�� ���������� ��������
            else if (h > 0)
            {
                //���������� ����������.
                spriterenderer.flipX = false;
                //���� ���̽�ƽ�� �������� ����̸�
                if(Ah < 0)
                {
                    //�÷��̾� ������Ʈ�� �������� ����������.
                    spriterenderer.flipX = true;
                }
            }
        }
        else if (h == 0 && v == 0)
        {
            anim.SetBool("Walk", false);
        }
    }

    //���� ���ݷ� ��ȭ �Լ�
    public void AttackUP(float StrengthUP)
    {
        //���� ���ݷ��� StrengthUp��ŭ �����Ѵ�.
        attackDamage += StrengthUP;
    }

    //���� ���ݷ� ��ȭ �Լ�
    public void MagicUp(float magicUp)
    {
        //���� ���ݷ��� magicUp��ŭ �����Ѵ�.
        MagicAttack += magicUp;
    }

    //�ҼӼ� ��ȭ
    public void BurnStrength(float BurnDamage,float KeepingTime)
    {
        //BurnDamage��ŭ ȭ����� �������� ��������.
        FireDamage += BurnDamage;

        //KeepingTime��ŭ ȭ����� ���ӽð��� �����Ѵ�.
        FireKeeping += KeepingTime;
    }

    //���Ӽ� ��ȭ
    public void FreezingStrength(float KeepingTime)
    {
        //KeepingTime��ŭ ������� ���ӽð��� �����Ѵ�.
        KeepFreeze += KeepingTime;
    }

    //�����Ӽ� ��ȭ
    public void ElectricShockStrength(float KeepingTime)
    {
        //KeepingTime��ŭ �������� ���ӽð��� �����Ѵ�.
        KeepElectric += KeepingTime;
    }

    //��Ӽ� ��ȭ
    public void FaintStrength(float KeepingTime)
    {
        //KeepingTime��ŭ �������� ���ӽð��� �����Ѵ�.
        KeepFaint += KeepingTime;
    }

    //�ٶ��Ӽ� ��ȭ
    public void KnockBackStrength(float ForceKnockBack)
    {
        //ForceKnockback��ŭ �˹����� �о�� ���� �����Ѵ�.
        ForceKnockback += ForceKnockBack;
    }
}
