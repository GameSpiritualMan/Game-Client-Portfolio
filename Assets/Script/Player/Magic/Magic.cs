using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    //���� ���ݷ�
    private float Damage;
    //�Ҹ��� �÷��̾��� MP
    public float useMP;

    //�Ӽ�ȿ��

    //�ҼӼ�
    //ȭ����� ������
    private float BurnDamage;
    //ȭ����� ���ӽð�
    private float BurnKeeping;

    //���Ӽ� ��ȭ
    //������� ���ӽð�
    private float FreezingKeep;

    //�����Ӽ� ��ȭ
    //�������� ���ӽð�
    private float Electric_Shock;

    //��Ӽ�
    //�������� ���ӽð�
    private float FaintKeep;

    //�ٶ��Ӽ�
    //�˹����� �о�� ��
    private float Knockback;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //PlayerController�� ���� ���ݷ��� ������ �����´�.
        Damage = GameObject.FindWithTag("Player").GetComponent<PlayerController>().MagicAttack;
        //�Ӽ� ȿ��
        //�ҼӼ� ����
        //�÷��̾�ĳ������ PlayerController������Ʈ���� FireDamage�� �������Ѵ�.
        BurnDamage = GameObject.FindWithTag("Player").GetComponent<PlayerController>().FireDamage;
        //�÷��̾�ĳ������ PlayerController������Ʈ�� FireKeeping�� �������Ѵ�.
        BurnKeeping = GameObject.FindWithTag("Player").GetComponent<PlayerController>().FireKeeping;

        //���Ӽ� ����
        //�÷��̾� ĳ������ PlayerController������Ʈ�� KeepFreeze�� �������Ѵ�.
        FreezingKeep = GameObject.FindWithTag("Player").GetComponent<PlayerController>().KeepFreeze;

        //�����Ӽ� ����
        //�÷��̾� ĳ������ PlayerController������Ʈ�� KeepElectric�� �������Ѵ�.
        Electric_Shock = GameObject.FindWithTag("Player").GetComponent<PlayerController>().KeepElectric;

        //��Ӽ� ����
        //�÷��̾� ĳ������ PlayerController������Ʈ�� KeepFaint�� �������Ѵ�.
        FaintKeep = GameObject.FindWithTag("Player").GetComponent<PlayerController>().KeepFaint;

        //�ٶ��Ӽ� ����
        //�÷��̾� ĳ������ PlayerController������Ʈ�� ForceKnockback�� �������Ѵ�.
        Knockback = GameObject.FindWithTag("Player").GetComponent<PlayerController>().ForceKnockback;

        if (collision.CompareTag("SmallEnemy")||collision.CompareTag("BigEnemy")||collision.CompareTag("Boss"))
        {
            collision.GetComponent<EnemyHP>().TakeDamage(Damage);
            if (this.gameObject.name == "FireMagic1" || this.gameObject.name == "FireMagic2")
            {
                //BurnKeeping�� ���� BurnDamage��ŭ�� �������� 1.5�� ���� ������ ȭ����¸� �����Ѵ�.
                collision.GetComponent<EnemyHP>().BurnStart(BurnDamage, BurnKeeping);
                //EnemyHP�� HUDDMGText������ �����´�.
                GameObject DMG = collision.GetComponent<EnemyHP>().HUDDMGText;
                //�ؽ�Ʈ�� ���� ���������� ���Ѵ�.
                DMG.GetComponent<DMGText>().text.color = Color.red;
            }
            else if(this.gameObject.name == "WaterMagic1Attack" || this.gameObject.name=="WaterMagic2Attack")
            {
                //FreezingKeep�� ���� ������¸� �����Ѵ�.
                collision.GetComponent<EnemyController>().FreezeStart(FreezingKeep);
                //EnemyHP�� HUDDMGText������ �����´�.
                GameObject DMG = collision.GetComponent<EnemyHP>().HUDDMGText;
                //�ؽ�Ʈ�� ���� �Ķ������� ���Ѵ�.
                DMG.GetComponent<DMGText>().text.color = Color.blue;
            }
            else if (this.gameObject.name == "ThunderMagic1" || this.gameObject.name == "ThunderMagic2")
            {
                //Electric_Shock�� ���� �������¸� �����Ѵ�.
                collision.GetComponent<EnemyController>().ElectricsShockStart(Electric_Shock);
                //EnemyHP�� HUDDMGText������ �����´�.
                GameObject DMG = collision.GetComponent<EnemyHP>().HUDDMGText;
                //�ؽ�Ʈ�� ���� ��������� ���Ѵ�.
                DMG.GetComponent<DMGText>().text.color = Color.yellow;
            }
            else if (this.gameObject.name == "EarthMagic1" || this.gameObject.name == "EarthMagic2")
            {
                //FaintKeep�� ���� �������¸� �����Ѵ�.
                collision.GetComponent<EnemyController>().FaintStart(FaintKeep);
                //EnemyHP�� HUDDMGText������ �����´�.
                GameObject DMG = collision.GetComponent<EnemyHP>().HUDDMGText;
                //�ؽ�Ʈ�� ���� �������� ���Ѵ�.
                DMG.GetComponent<DMGText>().text.color = new Color(255 / 255f, 90 / 255f, 0 / 255f, 255 / 255f);
            }
            else if (this.gameObject.name == "WindMagic1" || this.gameObject.name == "WindMagic2")
            {
                //���� ��ġ���� Knockback��ŭ�� ������ �о��.
                collision.GetComponent<EnemyController>().KnockBack(this.gameObject.transform.position,Knockback);
                //EnemyHP�� HUDDMGText������ �����´�.
                GameObject DMG = collision.GetComponent<EnemyHP>().HUDDMGText;
                //�ؽ�Ʈ�� ���� �ʷϻ����� ���Ѵ�.
                DMG.GetComponent<DMGText>().text.color = Color.green;
            }
        }
    }
}
