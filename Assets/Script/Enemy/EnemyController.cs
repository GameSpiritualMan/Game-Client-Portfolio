using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;             //�Է¹��� ���� �̵��ӵ�
    private float MoveSpeed;        //���Թ��� �Է¼ӵ�
    public float attackDamage;      //���� ���� ���ݷ�
    private Animator anim;          //�ִϸ��̼� ������Ʈ�� �����´�.
    SpriteRenderer spriterenderer;

    public float Distance_radius;   //�Ÿ�

    private SpriteRenderer sprite;

    GameObject player;

    private Rigidbody2D rb;

    public GameObject HPbar;

    //�������ͽ��� ǥ�ø� Ȱ���ϰ� �ϱ� ���� �����Ѵ�.
    public GameObject FreezingsState;    //�������
    public GameObject EShockState;      //��������
    public GameObject FaintState;       //��������

    //�������ͽ� â�� ������ �������� ���� �����Ѵ�.
    private GameObject StatusScene;
    //���θ޴� â�� ������ �������� ���� �����Ѵ�.
    private GameObject MainMenu;
    void Start()
    {
        //Animator ������Ʈ�� �����´�.
        anim = GetComponent<Animator>();

        //Player�±׸� ���� ������Ʈ�� ã�´�.
        player = GameObject.FindWithTag("Player");

        //SpriteRenderer ������Ʈ�� �����Ѵ�.
        spriterenderer = GetComponent<SpriteRenderer>();

        //SpriteRenderer������Ʈ�� �������Ѵ�.
        sprite = GetComponent<SpriteRenderer>();

        //Rigidbody ������Ʈ�� �������Ѵ�.
        rb = GetComponent<Rigidbody2D>();

        //MoveSpeed�� �Էµ� ���� �����Ѵ�.
        MoveSpeed = speed;
        //�ִϸ��̼� ����ӵ��� 1.0f�� �����Ѵ�.
        anim.speed = 1.0f;

        HPbar.transform.Find("EnemyHP").gameObject.SetActive(false);
        FreezingsState.SetActive(false);    //������� ǥ�ø� ���� �ʴ´�.
        EShockState.SetActive(false);       //�������� ǥ�ø� ���� �ʴ´�.
        FaintState.SetActive(false);        //�������� ǥ�ø� ���� �ʴ´�.

        //�������ͽ��� ������ �����´�.
        StatusScene = GameObject.Find("MenuManager").GetComponent<MainMenu>().Status;
        //���θ޴��� ������ �����´�.
        MainMenu = GameObject.Find("MenuManager").GetComponent<MainMenu>().MenuSet;
    }

    void Update()
    {
        //�÷��̾ �ڽŰ��� �Ÿ��� ���� �Ÿ����� ª����
        if(Vector3.Distance(transform.position, player.transform.position) <= Distance_radius)
        {
            //Move �ִϸ��̼� �Ķ���͸� Ȱ��ȭ �Ѵ�.
            anim.SetBool("Move", true);
            //�� �����Ӹ��� �÷��̾ ���� �̵��Ѵ�.
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, MoveSpeed * Time.deltaTime);
            Vector3 delta = player.transform.position - this.transform.position;
            //�÷��̾������� �ٶ󺻴�.
            spriterenderer.flipX = (delta.x < 0);

            HPbar.transform.Find("EnemyHP").gameObject.SetActive(true);

        }        
        else
        {
            //Move �ִϸ��̼� �Ķ���͸� ��Ȱ��ȭ �Ѵ�.
            anim.SetBool("Move", false);

            HPbar.transform.Find("EnemyHP").gameObject.SetActive(false);
        }

        //�������ͽ� ���� Ȱ��ȭ �ǰų� ���θ޴��� Ȱ��ȭ �Ǹ� �� HP �����̵�� ��Ȱ��ȭ �ȴ�.
        if (StatusScene.activeSelf == true || MainMenu.activeSelf == true)
        {
            HPbar.transform.Find("EnemyHP").gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            //���ݷ¸�ŭ �÷��̾��� HP���� ����߸���.
            collision.gameObject.GetComponent<PlayerHUD>().TakeDamage(attackDamage);
            //�÷��̾��� DamageDelay �ڷ�ƾ�� �����Ѵ�.
            collision.gameObject.GetComponent<PlayerHUD>().StartCoroutine("DamageDelay");
        }
    }

    //������� ����
    public void FreezeStart(float FreezeKeeping)
    {
        //�ִϸ��̼� ���ǵ带 �Ͻ������� 0�� �ȴ�.
        anim.speed = 0.0f;
        //�̵��ӵ��� 0�̵ȴ�.
        MoveSpeed = 0;
        //���� �Ķ��� ���Ѵ�.
        sprite.color = Color.blue;
        //������¸� ǥ���Ѵ�.
        FreezingsState.SetActive(true);
        //���̾��Ű�� Ȱ��ȭ�Ǿ� ������
        if (this.gameObject.activeInHierarchy)
        {
            //Freeze�Լ��� FreezeKeeping�ð� ���� �����Ѵ�.
            StartCoroutine(Freeze(FreezeKeeping));
        }
    }

    private IEnumerator Freeze(float FreezeKeeping)
    {
        //FreezeKeeping�� ���������� ���ӵȴ�.
        yield return new WaitForSeconds(FreezeKeeping);

        //FreezeKeeping�� �ٵǸ�
        if (FreezeKeeping <= 0.0f)
        {
            //������Ʈ�� ���� ������� ���ƿ´�.
            spriterenderer.color = Color.white;
            //������¸� ǥ������ �ʴ´�.
            FreezingsState.SetActive(false);
            //�ִϸ��̼�
            anim.speed = 1.0f;
            //���ǵ�� �ٽ� ���� ���ǵ�� ���ƿ´�.
            MoveSpeed = speed;
        }
    }

    //�������� ����
    public void ElectricsShockStart(float KeepingTime)
    {
        //�ӵ��� �������� �پ���.
        MoveSpeed /= 2.0f;
        //�ִϸ��̼� �ӵ��� �������� �پ���.
        anim.speed = 0.5f;
        //������Ʈ�� ���� ����� ���Ѵ�.
        sprite.color = Color.yellow;
        //�������¸� ǥ���Ѵ�.
        EShockState.SetActive(true);
        //���̾��Ű�� Ȱ��ȭ�Ǿ� ������
        if (this.gameObject.activeInHierarchy)
        {
            //ElectricShock �ڷ�ƾ�� �����Ѵ�.
            StartCoroutine(ElectricShock(KeepingTime));
        }
    }

    private IEnumerator ElectricShock(float ElectricKeeping)
    {
        //ElectricKeeping�� ���������� ��ӵȴ�.
        yield return new WaitForSeconds(ElectricKeeping);

        //���ӽð��� �ٵǸ�
        if(ElectricKeeping <= 0.0f)
        {
            //�ӵ��� �ٽ� ������� ���ƿ´�.
            MoveSpeed = speed;
            //�ִϸ��̼� �ӵ��� ������� ���ƿ´�.
            anim.speed = 1.0f;
            //������Ʈ�� ���� ������� ���ƿ´�.
            sprite.color = Color.white;
            //�������¸� ǥ������ �ʴ´�.
            EShockState.SetActive(false);
        }
    }

    //���� ����
    public void FaintStart(float FaintTime)
    {
        //�ִϸ��̼� �ӵ��� �����.
        anim.speed = 0.0f;
        //�̵��� �����.
        MoveSpeed = 0;
        //�������¸� ǥ���Ѵ�.
        FaintState.SetActive(true);
        if (this.gameObject.activeInHierarchy)
        {
            StartCoroutine(FaintKeep(FaintTime));
        }
    }

    private IEnumerator FaintKeep(float Faint)
    {
        yield return new WaitForSeconds(Faint);
        if (Faint <= 0.0f)
        {
            //�ֳ����̼� �ӵ��� ������� ���ƿ´�.
            anim.speed = 1.0f;
            //�ٽ� ������� �����δ�.
            MoveSpeed = speed;
            //�������¸� ǥ������ �ʴ´�.
            FaintState.SetActive(false);
        }
    }

    //�˹�
    public void KnockBack(Vector2 PWeapon, float Force)
    {
        //X�� ������ ����Ѵ�.
        int dirX = this.transform.position.x - PWeapon.x > 0 ? 1 : -1;
        //Y�� ������ ����Ѵ�.
        int dirY = this.transform.position.y - PWeapon.y > 0 ? 1 : -1;
        //����� �������� �о��.
        rb.AddForce(new Vector2(dirX, dirY) * Force, ForceMode2D.Impulse);
    }
}
