using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStrength : MonoBehaviour
{
    //�÷����� �������ͽ� ��ȭ
    public float AttackUp;                  //��ȭ�� �÷��̾� ���� ���ݷ� ��ġ
    public float MagicAttackUP;             //��ȭ�� �÷��̾� ���� ���ݷ� ��ġ
    public float MaxHPUp;                   //��ȭ�� �÷��̾� �ִ� HP ��ġ
    public float MaxMPUp;                   //��ȭ�� �÷��̾� �ִ� MP ��ġ

    //�Ӽ��� ȿ���� ��ȭ
    //�ҼӼ� ȭ�����
    public float BurnDamage;                //ȭ����� ������
    public float BurnKeeping;               //ȭ����� ���ӽð�

    //���Ӽ� �������
    public float FreezeKeep;                //������� ���ӽð�

    //�����Ӽ� ��������
    public float ElectricShock;             //�������� ���ӽð�

    //��Ӽ� ��������
    public float FaintKeep;                 //�������� ���ӽð�

    //�ٶ��Ӽ� �˹�
    public float KnockBack;                 //�˹�� �о�� ��
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            //�÷��̾��� ���� ���ݷ� ��ȭ
            collision.gameObject.GetComponent<PlayerController>().AttackUP(AttackUp);
            //�÷��̾��� ���� ���ݷ� ��ȭ
            collision.gameObject.GetComponent<PlayerController>().MagicUp(MagicAttackUP);
            //�÷��̾��� �ִ� HP ��ȭ
            collision.gameObject.GetComponent<PlayerHUD>().StrengthHP(MaxHPUp);
            //�÷��̾��� �ִ� MP ��ȭ
            collision.gameObject.GetComponent<PlayerHUD>().StrengthMP(MaxMPUp);
            //�÷��̾��� �ҼӼ� ��ȭ
            collision.gameObject.GetComponent<PlayerController>().BurnStrength(BurnDamage, BurnKeeping);
            //�÷��̾��� ���Ӽ� ��ȭ
            collision.gameObject.GetComponent<PlayerController>().FreezingStrength(FreezeKeep);
            //�÷��̾��� �����Ӽ� ��ȭ
            collision.gameObject.GetComponent<PlayerController>().ElectricShockStrength(ElectricShock);
            //�÷��̾��� ��Ӽ� ��ȭ
            collision.gameObject.GetComponent<PlayerController>().FaintStrength(FaintKeep);
            //�÷��̾��� �ٶ��Ӽ� ��ȭ
            collision.gameObject.GetComponent<PlayerController>().KnockBackStrength(KnockBack);
            ObjectPool.OBP.ReturnObject(this.gameObject);
        }
    }
}
