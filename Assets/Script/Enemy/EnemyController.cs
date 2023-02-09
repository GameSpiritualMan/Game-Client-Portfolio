using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;             //입력받을 적의 이동속도
    private float MoveSpeed;        //대입받을 입력속도
    public float attackDamage;      //적의 물리 공격력
    private Animator anim;          //애니메이션 컴포넌트를 가져온다.
    SpriteRenderer spriterenderer;

    public float Distance_radius;   //거리

    private SpriteRenderer sprite;

    GameObject player;

    private Rigidbody2D rb;

    public GameObject HPbar;

    //스테이터스의 표시를 활실하게 하기 위해 선언한다.
    public GameObject FreezingsState;    //빙결상태
    public GameObject EShockState;      //감전상태
    public GameObject FaintState;       //기절상태

    //스테이터스 창의 정보를 가져오기 위해 선언한다.
    private GameObject StatusScene;
    //메인메뉴 창의 정보를 가져오기 위해 선언한다.
    private GameObject MainMenu;
    void Start()
    {
        //Animator 컴포넌트를 가져온다.
        anim = GetComponent<Animator>();

        //Player태그를 가진 오브젝트를 찾는다.
        player = GameObject.FindWithTag("Player");

        //SpriteRenderer 컴포넌트에 접근한다.
        spriterenderer = GetComponent<SpriteRenderer>();

        //SpriteRenderer컴포넌트를 재정의한다.
        sprite = GetComponent<SpriteRenderer>();

        //Rigidbody 컴포넌트를 재정의한다.
        rb = GetComponent<Rigidbody2D>();

        //MoveSpeed에 입력된 값을 대입한다.
        MoveSpeed = speed;
        //애니메이션 재생속도는 1.0f로 정의한다.
        anim.speed = 1.0f;

        HPbar.transform.Find("EnemyHP").gameObject.SetActive(false);
        FreezingsState.SetActive(false);    //빙결상태 표시를 하지 않는다.
        EShockState.SetActive(false);       //감전상태 표시를 하지 않는다.
        FaintState.SetActive(false);        //기절상태 표시를 하지 않는다.

        //스테이터스씬 정보를 가져온다.
        StatusScene = GameObject.Find("MenuManager").GetComponent<MainMenu>().Status;
        //메인메뉴씬 정보를 가져온다.
        MainMenu = GameObject.Find("MenuManager").GetComponent<MainMenu>().MenuSet;
    }

    void Update()
    {
        //플레이어가 자신과의 거리가 일정 거리보다 짧을때
        if(Vector3.Distance(transform.position, player.transform.position) <= Distance_radius)
        {
            //Move 애니메이션 파라미터를 활성화 한다.
            anim.SetBool("Move", true);
            //매 프레임마다 플레이어를 향해 이동한다.
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, MoveSpeed * Time.deltaTime);
            Vector3 delta = player.transform.position - this.transform.position;
            //플레이어쪽으로 바라본다.
            spriterenderer.flipX = (delta.x < 0);

            HPbar.transform.Find("EnemyHP").gameObject.SetActive(true);

        }        
        else
        {
            //Move 애니메이션 파라미터를 비활성화 한다.
            anim.SetBool("Move", false);

            HPbar.transform.Find("EnemyHP").gameObject.SetActive(false);
        }

        //스테이터스 씬이 활성화 되거나 메인메뉴가 활성화 되면 적 HP 슬라이드는 비활성화 된다.
        if (StatusScene.activeSelf == true || MainMenu.activeSelf == true)
        {
            HPbar.transform.Find("EnemyHP").gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            //공격력만큼 플레이어의 HP값을 떨어뜨린다.
            collision.gameObject.GetComponent<PlayerHUD>().TakeDamage(attackDamage);
            //플레이어의 DamageDelay 코루틴을 실행한다.
            collision.gameObject.GetComponent<PlayerHUD>().StartCoroutine("DamageDelay");
        }
    }

    //빙결상태 시작
    public void FreezeStart(float FreezeKeeping)
    {
        //애니메이션 스피드를 일시적으로 0이 된다.
        anim.speed = 0.0f;
        //이동속도는 0이된다.
        MoveSpeed = 0;
        //색은 파랗게 변한다.
        sprite.color = Color.blue;
        //빙결상태를 표시한다.
        FreezingsState.SetActive(true);
        //하이어라키에 활성화되어 있으면
        if (this.gameObject.activeInHierarchy)
        {
            //Freeze함수를 FreezeKeeping시간 동안 실행한다.
            StartCoroutine(Freeze(FreezeKeeping));
        }
    }

    private IEnumerator Freeze(float FreezeKeeping)
    {
        //FreezeKeeping이 지날때까지 지속된다.
        yield return new WaitForSeconds(FreezeKeeping);

        //FreezeKeeping이 다되면
        if (FreezeKeeping <= 0.0f)
        {
            //오브젝트의 색은 원래대로 돌아온다.
            spriterenderer.color = Color.white;
            //빙결상태를 표시하지 않는다.
            FreezingsState.SetActive(false);
            //애니메이션
            anim.speed = 1.0f;
            //스피드는 다시 원래 스피드로 돌아온다.
            MoveSpeed = speed;
        }
    }

    //감전상태 시작
    public void ElectricsShockStart(float KeepingTime)
    {
        //속도는 절반으로 줄어든다.
        MoveSpeed /= 2.0f;
        //애니메이션 속도도 절반으로 줄어든다.
        anim.speed = 0.5f;
        //오브젝트의 색은 노랗게 변한다.
        sprite.color = Color.yellow;
        //감전상태를 표시한다.
        EShockState.SetActive(true);
        //하이어라키에 활성화되어 있으면
        if (this.gameObject.activeInHierarchy)
        {
            //ElectricShock 코루틴을 실행한다.
            StartCoroutine(ElectricShock(KeepingTime));
        }
    }

    private IEnumerator ElectricShock(float ElectricKeeping)
    {
        //ElectricKeeping이 지날때까지 계속된다.
        yield return new WaitForSeconds(ElectricKeeping);

        //지속시간이 다되면
        if(ElectricKeeping <= 0.0f)
        {
            //속도는 다시 원래대로 돌아온다.
            MoveSpeed = speed;
            //애니메이션 속도도 원래대로 돌아온다.
            anim.speed = 1.0f;
            //오브젝트의 색깔도 원래대로 돌아온다.
            sprite.color = Color.white;
            //감전상태를 표시하지 않는다.
            EShockState.SetActive(false);
        }
    }

    //기절 상태
    public void FaintStart(float FaintTime)
    {
        //애니메이션 속도를 멈춘다.
        anim.speed = 0.0f;
        //이동을 멈춘다.
        MoveSpeed = 0;
        //기절상태를 표시한다.
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
            //애내메이션 속도는 원래대로 돌아온다.
            anim.speed = 1.0f;
            //다시 원래대로 움직인다.
            MoveSpeed = speed;
            //기절상태를 표시하지 않는다.
            FaintState.SetActive(false);
        }
    }

    //넉백
    public void KnockBack(Vector2 PWeapon, float Force)
    {
        //X축 방향을 계산한다.
        int dirX = this.transform.position.x - PWeapon.x > 0 ? 1 : -1;
        //Y축 방향을 계산한다.
        int dirY = this.transform.position.y - PWeapon.y > 0 ? 1 : -1;
        //계산한 방향으로 밀어낸다.
        rb.AddForce(new Vector2(dirX, dirY) * Force, ForceMode2D.Impulse);
    }
}
