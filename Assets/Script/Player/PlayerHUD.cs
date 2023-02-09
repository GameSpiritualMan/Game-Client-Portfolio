using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHUD : MonoBehaviour
{
    public float MaxHP;                 //�ִ� ü��
    public float MaxMP;                 //�ִ� ����

    [HideInInspector]
    public float currentHP;            //���� ü��

    [HideInInspector]
    public float currentMP;            //���� ����

    public float MaxHealth => MaxHP;    //MaxHP�� ������ �� �ִ� ������Ƽ(get�� ����)
    public float curHP => currentHP;    //currentHP�� ������ �� �ִ� ������Ƽ(get�� ����)
    public float MaxMana => MaxMP;      //MaxMP�� ������ �� �ִ� ������Ƽ(get�� ����)
    public float curMP => currentMP;    //currentHP�� ������ �� �ִ� ������Ƽ(get�� ����)



    private SpriteRenderer sprite;
    private void Start()
    {
        currentHP = MaxHP;              //���� ü���� �ִ� ü�°� ���� �����Ѵ�.
        currentMP = MaxMP;              //���� ������ �ִ� ���°� ���� �����Ѵ�.
        
        sprite = GetComponent<SpriteRenderer>();


        //�ش罽�Կ� ������ �Ǿ� ������
        if(PlayerPrefs.GetInt("LoadSaved" + SaveID.saveID) == 1)
        {
            //��������� X�� ��ǥ���� ����Ǿ� ������
            if (PlayerPrefs.HasKey("MagicKnightX" + SaveID.saveID))
            {
                //�ش罽�Կ� ����� ��������� �ִ�HP�� �ҷ��´�.
                MaxHP = PlayerPrefs.GetFloat("MagicKnightMaxHP" + SaveID.saveID);
                
                //�ش罽�Կ� ����� ��������� �ִ�MP�� �ҷ��´�.
                MaxMP = PlayerPrefs.GetFloat("MagicKnightMaxMP" + SaveID.saveID);
                
                //�ش罽�Կ� ����� ��������� ����HP�� �ҷ��´�.
                currentHP = PlayerPrefs.GetFloat("MagicKnightCurHPStrength" + SaveID.saveID);
                
                //�ش罽�Կ� ����� ��������� ����MP�� �ҷ��´�.
                currentMP = PlayerPrefs.GetFloat("MagicKnightCurMPStrength" + SaveID.saveID);
            }
            //�������� X�� ��ǥ���� ����Ǿ� ������
            else if (PlayerPrefs.HasKey("WizardX" + SaveID.saveID))
            {
                //�ش罽�Կ� ����� �������� �ִ�HP�� �ҷ��´�.
                MaxHP = PlayerPrefs.GetFloat("WizardMaxHP" + SaveID.saveID);
                
                //�ش罽�Կ� ����� �������� �ִ�MP�� �ҷ��´�.
                MaxMP = PlayerPrefs.GetFloat("WizardMaxMP" + SaveID.saveID);
                
                //�ش罽�Կ� ����� �������� ����HP�� �ҷ��´�.
                currentHP = PlayerPrefs.GetFloat("WizardCurHPStrength" + SaveID.saveID);
                
                //�ش罽�Կ� ����� �������� ����MP�� �ҷ��´�.
                currentMP = PlayerPrefs.GetFloat("WizardCurMPStrength" + SaveID.saveID);
            }
            //������ X�� ��ǥ���� ����Ǿ� ������
            else if (PlayerPrefs.HasKey("ElfX" + SaveID.saveID))
            {
                //�ش罽�Կ� ����� ������ �ִ�HP�� �ҷ��´�.
                MaxHP = PlayerPrefs.GetFloat("ElfMaxHP" + SaveID.saveID);
                
                //�ش罽�Կ� ����� ������ �ִ�MP�� �ҷ��´�.
                MaxMP = PlayerPrefs.GetFloat("ElfMaxMP" + SaveID.saveID);
                
                //�ش罽�Կ� ����� ������ ����HP�� �ҷ��´�.
                currentHP = PlayerPrefs.GetFloat("ElfCurHPStrength" + SaveID.saveID);
                
                //�ش罽�Կ� ����� ������ ����MP�� �ҷ��´�.
                currentMP = PlayerPrefs.GetFloat("ElfCurMPStrength" + SaveID.saveID);
            }
        }
    }

    public void TakeDamage(float Damage)
    {
        //���� ü�°��� Damage��ŭ�� �����Ѵ�.
        currentHP -= Damage;
        //���� ü�°��� 0�����̸�
        if(currentHP<=0)
        {
            //BadEnding������ �̵��Ѵ�.
            SceneManager.LoadScene("BadEnding");
        }
    }
    
    //������ ����Ҷ�
    public void useMagic(float useMP)
    {
        //���� ������ ����� ���º��� ũ�ų� ������
        if(currentMP>=useMP)
        {
            //���� ������ ����� ���¸�ŭ �����Ѵ�.
            currentMP -= useMP;
        }
    }

    //HPȸ��
    public void HealHP(float healhp)
    {
        //���� HP�� healhp��ŭ ȸ���Ѵ�.
        currentHP += healhp;
        //���� HP�� �ִ� HP���� ũ��
        if(currentHP>=MaxHP)
        {
            //���� HP�� �ִ�HP��ŭ ä������.
            currentHP = MaxHP;
        }
    }

    //MPȸ��
    public void HealMP(float healmp)
    {

        //����MP�� healmp��ŭ ȸ���Ѵ�.
        currentMP += healmp;
        //���� MP�� �ִ� MP���� ũ��
        if(currentMP>=MaxMP)
        {
            //���� MP�� �ִ�MP��ŭ ä������.
            currentMP = MaxMP;
        }
    }

    //������ �ִ� �ִ� HP�� �����Ѵ�.
    public void StrengthHP(float StrengthHP)
    {
        //�ִ� HP���� StrengthHP��ŭ �����Ѵ�.
        MaxHP += StrengthHP;
    }

    //������ �ִ� �ִ� MP�� �����Ѵ�.
    public void StrengthMP(float StrengthMP)
    {
        //�ִ� MP���� StrengthMP��ŭ �����Ѵ�.
        MaxMP += StrengthMP;
    }

    //���ͷκ��� �ǰ��� ������
    public IEnumerator DamageDelay()
    {
        //�÷��̾�� ��ο� ������ ���Ѵ�.
        sprite.color = Color.gray;
        //������ ���°� �ȴ�.
        this.gameObject.layer = 6;
        //5�ʵ�
        yield return new WaitForSeconds(5f);
        //�÷��̾�� ������ ������ ���Ѵ�.
        sprite.color = Color.white;
        //���� ���̾�� ���ƿ´�.
        this.gameObject.layer = 3;
    }
}