using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //������ �ӵ���
    public float defaultSpeed;
    //���� ���Ե� �ӵ���
    [SerializeField] private float speed;

    //�÷��̾��� ���� ���ݷ��� �����´�.
    private float Damage;

    private Animator anim;

    //ȭ����� ȿ��
    private float BurnDamage;    //ȭ����� ������
    private float BurnKeeping;   //ȭ����� ���ӽð�

    //������� ȿ��
    private float FreezingKeeping;   //������� ���ӽð�

    //�������� ȿ��
    private float Electric_Shock_Keeping;    //�������� ���ӽð�

    //�������� ȿ��
    private float FaintKeeping;  //�������� ���ӽð�

    //�˹� �Ŀ�
    private float KnockBack;     //�˹����� �о�� ��

    private AudioSource Hitaudio;

    //�ִϸ��̼� �� �̹��� ȿ��
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
        //�������Ӹ��� ������ �������� �����δ�.
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);
    }

    void DestroyWeapon()
    {
        //������Ʈ Ǯ�� ���� ��ȯ�ϸ� ��Ȱ��ȭ �ȴ�.
        ObjectPool.OBP.ReturnObject(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //������ �ִ� ���ط��� �÷��̾� ĳ������ PlayerController������Ʈ�� attackDamage�� ������ �Ѵ�.
        Damage = GameObject.FindWithTag("Player").GetComponent<PlayerController>().attackDamage;        
        //���� ����, ū ����, ������� �ε�������
        if (collision.CompareTag("SmallEnemy")||collision.CompareTag("BigEnemy")||collision.CompareTag("Boss"))
        {
            //Audio�� ����Ѵ�.
            Hitaudio.Play();
            //ȭ����� ���ط�
            BurnDamage = GameObject.FindWithTag("Player").GetComponent<PlayerController>().FireDamage;
            //ȭ����� ���ӽð�
            BurnKeeping = GameObject.FindWithTag("Player").GetComponent<PlayerController>().FireKeeping;
            //������� ���ӽð�
            FreezingKeeping = GameObject.FindWithTag("Player").GetComponent<PlayerController>().KeepFreeze;
            //�������� ���ӽð�
            Electric_Shock_Keeping = GameObject.FindWithTag("Player").GetComponent<PlayerController>().KeepElectric;
            //�������� ���ӽð�
            FaintKeeping = GameObject.FindWithTag("Player").GetComponent<PlayerController>().KeepFaint;
            //�˹����� �о�� ��
            KnockBack = GameObject.FindWithTag("Player").GetComponent<PlayerController>().ForceKnockback;
            //Damage��ŭ ���� HP�� �پ���.
            collision.gameObject.GetComponent<EnemyHP>().TakeDamage(Damage);
            //�÷��̾��� �˱Ⱑ �ƴϸ�
            if (this.gameObject.tag != "PlayerSword")
            {
                //���ǵ�� 0�� �ȴ�.
                speed = 0;
                //collision �Ķ���͸� �����Ѵ�.
                anim.SetBool("collision", true);
            }
            else
            {
                //�� ������Ʈ�� �̸��� ���� �����Ѵ�.
                switch (this.gameObject.name)
                {
                    //RoyalSword�̸�
                    case "RoyalSword":
                        //HitEffect ������Ʈ�� �����´�.
                        Effect = ObjectPool.OBP.GetObject("HitEffect");
                        //�浹ü(����)�� RoyalSword ������ ������� ��ġ�Ѵ�.
                        Effect.transform.position = collision.transform.position;
                        //HitEffect ������Ʈ�� Ȱ��ȭ �Ѵ�.
                        Effect.SetActive(true);
                        break;
                    //FireSword�̸�
                    case "FireSword":
                        //FireHitEffect ������Ʈ�� �����´�.
                        Effect = ObjectPool.OBP.GetObject("FireHitEffect");
                        //�浹ü(����)�� FireSword ������ ������� ��ġ�Ѵ�.
                        Effect.transform.position = collision.transform.position;
                        //FireHitEffect ������Ʈ�� Ȱ��ȭ �Ѵ�.
                        Effect.SetActive(true);
                        break;
                    case "AquaSword":
                        //AquaHitEffect ������Ʈ�� �����´�.
                        Effect = ObjectPool.OBP.GetObject("AquaHitEffect");
                        //�浹ü(����)�� AquaSword ������ ������� ��ġ�Ѵ�.
                        Effect.transform.position = collision.transform.position;
                        //AquaHitEffect ������Ʈ�� Ȱ��ȭ �Ѵ�.
                        Effect.SetActive(true);
                        break;
                    case "ThunderSword":
                        //ThunderHitEffect ������Ʈ�� �����´�.
                        Effect = ObjectPool.OBP.GetObject("ThunderHitEffect");
                        //�浹ü(����)�� ThunderSword ������ ������� ��ġ�Ѵ�.
                        Effect.transform.position = collision.transform.position;
                        //ThunderHitEffect ������Ʈ�� Ȱ��ȭ �Ѵ�.
                        Effect.SetActive(true);
                        break;
                    case "EarthSword":
                        //�浹ü(����)�� EarthSword ������ ������� ��ġ�Ѵ�.
                        Effect = ObjectPool.OBP.GetObject("EarthHitEffect");
                        //�浹ü(����)�� EarthSword ������ ������� ��ġ�Ѵ�.
                        Effect.transform.position = collision.transform.position;
                        //EarthHitEffect ������Ʈ�� Ȱ��ȭ �Ѵ�.
                        Effect.SetActive(true);
                        break;
                    case "WindSword":
                        //�浹ü(����)�� WindSword ������ ������� ��ġ�Ѵ�.
                        Effect = ObjectPool.OBP.GetObject("WindHitEffect");
                        //�浹ü(����)�� WindSword ������ ������� ��ġ�Ѵ�.
                        Effect.transform.position = collision.transform.position;
                        //WindHitEffect ������Ʈ�� Ȱ��ȭ �Ѵ�.
                        Effect.SetActive(true);
                        break;
                }
            }
            //�ҼӼ� �Ѿ�, �ҼӼ� �˱��̰ų� �ҼӼ� ȭ���̸�
            if (this.gameObject.name == "FireBullet" || this.gameObject.name == "FireArrow" || this.gameObject.name=="FireSword")
            {
                //���� ȭ����¸� ������.
                collision.gameObject.GetComponent<EnemyHP>().BurnStart(BurnDamage, BurnKeeping);
                //EnemyHP�� HUDDMGText������ �����´�.
                GameObject DMG = collision.GetComponent<EnemyHP>().HUDDMGText;
                //������ �ؽ�Ʈ�� �ؽ�Ʈ ���� ���������� ���Ѵ�.
                DMG.GetComponent<DMGText>().text.color = Color.red;
            }
            //���Ӽ� �Ѿ�, ���Ӽ� �˱��̰ų� ���Ӽ� ȭ���̸�
            else if (this.gameObject.name == "AquaBullet" || this.gameObject.name == "AquaArrow" || this.gameObject.name=="AquaSword")
            {
                //���� ������¿� ������.
                collision.gameObject.GetComponent<EnemyController>().FreezeStart(FreezingKeeping);
                //EnemyHP�� HUDDMGText������ �����´�.
                GameObject DMG = collision.GetComponent<EnemyHP>().HUDDMGText;
                //������ �ؽ�Ʈ�� �ؽ�Ʈ ���� �Ķ������� ���Ѵ�.
                DMG.GetComponent<DMGText>().text.color = Color.blue;
            }
            //�����Ӽ� �Ѿ��̰ų� �����Ӽ� �˱��̸�
            else if (this.gameObject.name == "ThunderBullet" || this.gameObject.name == "ThunderSword")
            {
                //���� �������¿� ������.
                collision.gameObject.GetComponent<EnemyController>().ElectricsShockStart(Electric_Shock_Keeping);
                //EnemyHP�� HUDDMGText������ �����´�.
                GameObject DMG = collision.GetComponent<EnemyHP>().HUDDMGText;
                //������ �ؽ�Ʈ�� �ؽ�Ʈ ���� ��������� ���Ѵ�.
                DMG.GetComponent<DMGText>().text.color = Color.yellow;
            }
            //��Ӽ� �Ѿ��̰ų� ��Ӽ� �˱��̸�
            else if (this.gameObject.name == "EarthBullet" || this.gameObject.name == "EarthSword" )
            {
                //���� �������°� �ȴ�.
                collision.gameObject.GetComponent<EnemyController>().FaintStart(FaintKeeping);
                //EnemyHP�� HUDDMGText������ �����´�.
                GameObject DMG = collision.GetComponent<EnemyHP>().HUDDMGText;
                //������ �ؽ�Ʈ�� �ؽ�Ʈ ���� �������� ���Ѵ�.
                DMG.GetComponent<DMGText>().text.color = new Color(255/255f, 90/255f, 0/255f,255/255f);
            }
            //�ٶ��Ӽ� �Ѿ�, �ٶ��Ӽ� �˱��̰ų� �ٶ��Ӽ� ȭ���̸�
            else if (this.gameObject.name == "WindBullet" || this.gameObject.name == "WindArrow" || this.gameObject.name == "WindSword")
            {
                //�� ������Ʈ�� ��ġ���� KnockBack��ŭ�� ������ �о��.
                collision.gameObject.GetComponent<EnemyController>().KnockBack(this.transform.position,KnockBack);
                //EnemyHP�� HUDDMGText������ �����´�.
                GameObject DMG = collision.GetComponent<EnemyHP>().HUDDMGText;
                //������ �ؽ�Ʈ�� �ؽ�Ʈ ���� �ʷϻ����� ���Ѵ�.
                DMG.GetComponent<DMGText>().text.color = Color.green;
            }
        }
    }
}
