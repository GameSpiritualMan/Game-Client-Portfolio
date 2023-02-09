using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHP : MonoBehaviour
{
    public float maxHP;         //최대 체력
    private float currentHP;    //현재 체력

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    public GameObject[] HealItem;

    public GameObject[] StatusStrengthItems;

    public GameObject[] ElementalStrengthItems;

    public string PassAStage;

    [HideInInspector]
    public EnemySpawner Link;   //EnemySpawner스크립트의 currentEnemyCount정보를 가져오기 위해 선언한다.

    private SpriteRenderer sprite;

    //속도값을 가져오기 위해 선언한다.
    private float speed;
    //가져온 속도값을 저장하기 위해 선언한다.
    [HideInInspector]
    public float Savespeed;
    
    private int spawnHeal;          //회복 아이템 스폰할 순서
    private int spawnStatus;        //플레이어 스텟 강화 아이템 스폰할 순서
    private int spawnElemental;     //플레이어 속성 강화 아이템 스폰할 순서

    private GameObject spawn;

    private EnemyController enemyController;

    //화상상태 표시
    public GameObject BurningState;

    //데미지 텍스트 표시
    public GameObject HUDDMGText;
    public Transform DMGPos;
    private void Awake()
    {
        Link = GetComponent<EnemySpawner>();    //EnemySpawner를 가져온다.
        sprite = GetComponent<SpriteRenderer>();    //SpriteRenderer컴포넌트를 재정의한다.
        enemyController = GetComponent<EnemyController>();
        //활성화된 상태이면 시작한다.
        OnEnable();
    }

    void OnEnable()
    {
        currentHP = maxHP;          //처음 HP는 가득 채워져 있다.
        sprite.color = Color.white; //원래 색으로 시작한다.
        BurningState.SetActive(false);  //화상상태를 표시하지 않는다.
    }

    public void TakeDamage(float Damage)
    {
        //EnemyDMG오브젝트를 풀링하여 꺼내온다.
        HUDDMGText = ObjectPool.OBP.GetObject("EnemyDMG");
        //DMGText컴포넌트의DMG에 Damage값을 삽입한다.
        HUDDMGText.GetComponent<DMGText>().DMG = Damage;
        //DMG가 생성될 위치는 DMGPos위치에서 생성된다.
        HUDDMGText.transform.position = DMGPos.position;
        //풀링될 오브젝트를 활성화 한다.
        HUDDMGText.SetActive(true);
        currentHP -= Damage;    //체력은 Damage만큼 감소한다.
        if(currentHP<=0)
        {
            if (IsInvoking("StartBurn"))
            {
                //화상상태는 멈춘다.
                CancelInvoke("BurnStart");
            }
            else if (enemyController.IsInvoking("FreezeStart"))
            {
                //빙결상태는 멈춘다.
                enemyController.CancelInvoke("FreezeStart");
            }
            else if (enemyController.IsInvoking("ElectricsShockStart"))
            {
                //감전상태는 멈춘다.
                enemyController.CancelInvoke("ElectricsShockStart");
            }
            else if (enemyController.IsInvoking("FaintStart"))
            {
                //기절상태는 멈춘다.
                enemyController.CancelInvoke("FaintStart");
            }
            //현재HP는 0이 된다.
            currentHP = 0;
            //오브젝트 풀을 위해 반환한다.
            ObjectPool.OBP.ReturnObject(this.gameObject);
            //태그가 보스몬스터이면 자기자신은 사라진다.
            if(this.gameObject.tag=="Boss")
            {
                Destroy(this.gameObject);
            }
            //스폰 위치에서 몬스터의 개수는 줄어든다.
            Link.currentEnemyCounter--;
            if(Link.currentEnemyCounter<0)
            {
                Link.currentEnemyCounter = 0;
            }
            CreateItem();
            NextMap();
        }
    }

    private void CreateItem()
    {
        int spawnRange = Random.Range(0, 101);
        //HealItem에 추가된 오브젝트의 수를 범위로 잡는다.
        spawnHeal = Random.Range(0, HealItem.Length);
        //StatusStrengthItems에 추가된 오브젝트의 수를 범위로 잡는다.
        spawnStatus = Random.Range(0, StatusStrengthItems.Length);
        //ElementalStrengthItems에 추가된 오브젝트의 수를 범위로 잡는다.
        spawnElemental = Random.Range(0, ElementalStrengthItems.Length);

        if (spawnRange < 50)
        {
            switch (spawnHeal)
            {
                case 0:
                    spawn = ObjectPool.OBP.GetObject("PlayerHPHeal(Small)");
                    spawn.transform.position = this.transform.position;
                    spawn.SetActive(true);
                    break;
                case 1:
                    spawn = ObjectPool.OBP.GetObject("PlayerMPHeal(Small)");
                    spawn.transform.position = this.transform.position;
                    spawn.SetActive(true);
                    break;
                case 2:
                    spawn = ObjectPool.OBP.GetObject("PlayerHPHeal(Big)");
                    spawn.transform.position = this.transform.position;
                    spawn.SetActive(true);
                    break;
                case 3:
                    spawn = ObjectPool.OBP.GetObject("PlayerMPHeal(Big)");
                    spawn.transform.position = this.transform.position;
                    spawn.SetActive(true);
                    break;
                case 4:
                    spawn = ObjectPool.OBP.GetObject("PlayerAllHeal(Small)");
                    spawn.transform.position = this.transform.position;
                    spawn.SetActive(true);
                    break;
                case 5:
                    spawn = ObjectPool.OBP.GetObject("PlayerAllHeal(Big)");
                    spawn.transform.position = this.transform.position;
                    spawn.SetActive(true);
                    break;
            }
        }

        if (spawnRange < 40 && this.gameObject.tag == "BigEnemy")
        {
            switch (spawnStatus)
            {
                case 0:
                    spawn = ObjectPool.OBP.GetObject("AttackStrengthItem");
                    spawn.transform.position = this.transform.position;
                    spawn.SetActive(true);
                    break;
                case 1:
                    spawn = ObjectPool.OBP.GetObject("MagicAttackStrengthItem");
                    spawn.transform.position = this.transform.position;
                    spawn.SetActive(true);
                    break;
                case 2:
                    spawn = ObjectPool.OBP.GetObject("MaxHPStrengthItem");
                    spawn.transform.position = this.transform.position;
                    spawn.SetActive(true);
                    break;
                case 3:
                    spawn = ObjectPool.OBP.GetObject("MaxMPStrengthItem");
                    spawn.transform.position = this.transform.position;
                    spawn.SetActive(true);
                    break;
            }
        }

        if (spawnRange < 40 && this.gameObject.tag == "SmallEnemy")
        {
            switch (spawnElemental)
            {
                case 0:
                    spawn = ObjectPool.OBP.GetObject("FireStrength");
                    spawn.transform.position = this.transform.position;
                    spawn.SetActive(true);
                    break;
                case 1:
                    spawn = ObjectPool.OBP.GetObject("AquaStrength");
                    spawn.transform.position = this.transform.position;
                    spawn.SetActive(true);
                    break;
                case 2:
                    spawn = ObjectPool.OBP.GetObject("ThunderStrength");
                    spawn.transform.position = this.transform.position;
                    spawn.SetActive(true);
                    break;
                case 3:
                    spawn = ObjectPool.OBP.GetObject("EarthStrength");
                    spawn.transform.position = this.transform.position;
                    spawn.SetActive(true);
                    break;
                case 4:
                    spawn = ObjectPool.OBP.GetObject("WindStrength");
                    spawn.transform.position = this.transform.position;
                    spawn.SetActive(true);
                    break;
            }
        }
    }

    //화상상태 시작
    public void BurnStart(float FireDamage, float Firetime)
    {
        //오브젝트의 색은 붉게 변한다.
        sprite.color = Color.red;
        //화상상태 아이콘을 표시한다.
        BurningState.SetActive(true);
        if(this.gameObject.activeInHierarchy)
        {
            StartCoroutine(Burning(FireDamage, Firetime));
        }
    }

    private IEnumerator Burning(float FireDamage, float Firetime)
    {
        while (true)
        {
            //먼저 3초를 기다린다.
            yield return new WaitForSeconds(1.5f);
            //화상상태 지속시간이 남아 있으면
            if (Firetime > 0)
            {
                //EnemyDMG 오브젝트를 풀링으로 꺼내온다.
                HUDDMGText = ObjectPool.OBP.GetObject("EnemyDMG");
                //풀링할 오브젝트의 데미지 값은 FireDamage랑 같다.
                HUDDMGText.GetComponent<DMGText>().DMG = FireDamage;
                //EnemyDMG 오브젝트의 텍스트 색은 붉은 색이 된다.
                HUDDMGText.GetComponent<DMGText>().text.color = Color.red;
                //풀링할 위치는 DMGPos위치에서 시작한다.
                HUDDMGText.transform.position = DMGPos.position;
                //풀링할 오브젝트는 활성화 된다.
                HUDDMGText.SetActive(true);
                //화상 데미지
                TakeBurnDamage(FireDamage);
            }
            else
            {
                //원래식깔로 돌아온다.
                sprite.color = Color.white;
                //화상상태 아이콘을 표시하지 않는다.
                BurningState.SetActive(false);
                //아니라면 Burning()중지
                yield return null;
            }
        }
    }

    //발화로 인한 데미지
    private void TakeBurnDamage(float FireDamage)
    {
        //현재 HP는 FireDamage만큼 감소한다.
        currentHP -= FireDamage;
        if (CurrentHP <= 0)
        {
            //화상상태는 멈춘다.
            CancelInvoke("BurnStart");
            //빙결상태는 멈춘다.
            enemyController.CancelInvoke("FreezeStart");
            //감전상태는 멈춘다.
            enemyController.CancelInvoke("ElectricsShockStart");
            //기절상태는 멈춘다.
            enemyController.CancelInvoke("FaintStart");
            //현재HP는 0이 된다.
            currentHP = 0;
            //오브젝트 풀을 위해 반환한다.
            ObjectPool.OBP.ReturnObject(this.gameObject);
            //태그가 보스몬스터이면 자기자신은 사라진다.
            if (this.gameObject.tag == "Boss")
            {
                Destroy(this.gameObject);
            }
            //적의 수는 줄어든다.
            Link.currentEnemyCounter--;
            //현재 적의 수가 0보다 작으면
            if (Link.currentEnemyCounter < 0)
            {
                //현재 적의 수는 0이 
                Link.currentEnemyCounter = 0;                
            }
            CreateItem();
            NextMap();
        }
    }
    
    public void NextMap()
    {
        if(gameObject.tag=="Boss")
        {
            //플레이어의 캐릭터가 마법기사이면
            if (GameObject.Find("MagicKnight(Clone)"))
            {
                //해당슬롯에 마법기사의 X축 좌표를 저장한다.
                PlayerPrefs.SetFloat("MagicKnightX" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").transform.position.x);

                //해당슬롯에 마법기사의 Y축 좌표를 저장한다.
                PlayerPrefs.SetFloat("MagicKnightY" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").transform.position.y);

                //해당슬롯에 마법기사의 현재 물리 공격력 저장한다.
                PlayerPrefs.SetFloat("MagicKnightAttack" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerController>().attackDamage);

                //해당슬롯에 마법기사의 현재 마법 공격력 저장한다.
                PlayerPrefs.SetFloat("MagicKnightMagic" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerController>().MagicAttack);
                
                //해당슬롯에 마법기사의 최대 HP 값을 저장한다.
                PlayerPrefs.SetFloat("MagicKnightMaxHP" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerHUD>().MaxHealth);

                //해당슬롯에 마법기사의 최대 MP 값을 저장한다.
                PlayerPrefs.SetFloat("MagicKnightMaxMP" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerHUD>().MaxMana);
                
                //해당슬롯에 마법기사의 현재 HP를 저장한다.
                PlayerPrefs.SetFloat("MagicKnightCurHPStrength" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerHUD>().curHP);

                //해당슬롯에 마법기사의 현재 MP를 저장한다.
                PlayerPrefs.SetFloat("MagicKnightCurMPStrength" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerHUD>().curMP);

                //해당슬롯에 마법기사의 화상상태 데미지를 저장한다.
                PlayerPrefs.SetFloat("MagicKnightFireDamage" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerController>().FireDamage);
                
                //해당슬롯에 마법기사의 화상상태 지속시간을 저장한다.
                PlayerPrefs.SetFloat("MagicKnightFireKeep" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerController>().FireKeeping);
                
                //해당슬롯에 마법기사의 빙결상태 지속시간을 저장한다.
                PlayerPrefs.SetFloat("MagicKnightFreeze" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerController>().KeepFreeze);
                
                //해당슬롯에 마법기사의 감전상태 지속시간을 저장한다.
                PlayerPrefs.SetFloat("MagicKnightElectric" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerController>().KeepElectric);
                
                //해당슬롯에 마법기사의 기절상태 지속시간을 저장한다.
                PlayerPrefs.SetFloat("MagicKnightFaint" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerController>().KeepFaint);
                
                //해당슬롯에 마법기사의 넉백으로 밀어내는 힘을 저장한다.
                PlayerPrefs.SetFloat("MagicKnightKnockBack" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerController>().ForceKnockback);
            }

            //플레이어의 캐릭터가 마법사이면
            else if (GameObject.Find("Wizard(Clone)"))
            {
                //현재슬롯에 마법사의 X축 좌표를 저장한다.
                PlayerPrefs.SetFloat("WizardX" + SaveID.saveID, GameObject.Find("Wizard(Clone)").transform.position.x);

                //해당슬롯에 마법사의 Y축 좌표를 저장한다.
                PlayerPrefs.SetFloat("WizardY" + SaveID.saveID, GameObject.Find("Wizard(Clone)").transform.position.y);

                //해당슬롯에 마법사의 현재 물리 공격력을 저장한다.
                PlayerPrefs.SetFloat("WizardAttack" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerController>().attackDamage);

                //해당슬롯에 마법사의 현재 마법 공격력을 저장한다.
                PlayerPrefs.SetFloat("WizardMagic" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerController>().MagicAttack);
                
                //해당슬롯에 마법사의 최대 HP를 저장한다.
                PlayerPrefs.SetFloat("WizardMaxHP" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerHUD>().MaxHealth);

                //해당슬롯에 마법사의 최대 MP를 저장한다.
                PlayerPrefs.SetFloat("WizardMaxMP" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerHUD>().MaxMana);
                
                //해당슬롯에 마법사의 현재 HP를 저장한다.
                PlayerPrefs.SetFloat("WizardCurHPStrength" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerHUD>().curHP);

                //해당슬롯에 마법사의 현재 MP를 저장한다.
                PlayerPrefs.SetFloat("WizardCurMPStrength" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerHUD>().curMP);

                //해당슬롯에 마법사의 화상상태 데미지를 저장한다.
                PlayerPrefs.SetFloat("WizardFireDamage" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerController>().FireDamage);
                
                //해당슬롯에 마법사의 화상상태 지속시간을 저장한다.
                PlayerPrefs.SetFloat("WizardFireKeep" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerController>().FireKeeping);
                
                //해당슬롯에 마법사의 빙결상태 지속시간을 저장한다.
                PlayerPrefs.SetFloat("WizardFreeze" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerController>().KeepFreeze);
                
                //해당슬롯에 마법사의 감전상태 지속시간을 저장한다.
                PlayerPrefs.SetFloat("WizardElectric" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerController>().KeepElectric);
                
                //해당슬롯에 마법사의 기절상태 지속시간을 저장한다.
                PlayerPrefs.SetFloat("WizardFaint" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerController>().KeepFaint);
                
                //해당슬롯에 마법사의 넉백으로 밀어내는 힘을 저장한다.
                PlayerPrefs.SetFloat("WizardKnockBack" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerController>().ForceKnockback);
            }

            //플레이어의 캐릭터가 엘프이면
            else if (GameObject.Find("Elf(Clone)"))
            {
                //해당슬롯에 엘프의 X축 좌표를 저장한다.
                PlayerPrefs.SetFloat("ElfX" + SaveID.saveID, GameObject.Find("Elf(Clone)").transform.position.x);

                //해당슬롯에 엘프의 Y축 좌표를 저장한다.
                PlayerPrefs.SetFloat("ElfY" + SaveID.saveID, GameObject.Find("Elf(Clone)").transform.position.y);

                //해당슬롯에 엘프의 현재 물리 공격력을 저장한다.
                PlayerPrefs.SetFloat("ElfAttack" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerController>().attackDamage);

                //해당슬롯에 엘프의 현재 마법 공격력을 저장한다.
                PlayerPrefs.SetFloat("ElfMagic" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerController>().MagicAttack);
                
                //해당슬롯에 엘프의 최대 HP를 저장한다.
                PlayerPrefs.SetFloat("ElfMaxHP" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerHUD>().MaxHealth);

                //해당솔롯에 엘프의 최대 MP를 저장한다.
                PlayerPrefs.SetFloat("ElfMaxMP" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerHUD>().MaxMana);
                
                //해당슬롯에 엘프의 현재 HP를 저장한다.
                PlayerPrefs.SetFloat("ElfCurHPStrength" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerHUD>().curHP);

                //해당슬롯에 엘프의 현재 MP를 저장한다.
                PlayerPrefs.SetFloat("ElfCurMPStrength" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerHUD>().curMP);

                //해당슬롯에 엘프의 화상상태 데미지를 저장한다.
                PlayerPrefs.SetFloat("ElfFireDamage" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerController>().FireDamage);
                
                //해당슬롯에 엘프의 화상상태 지속시간을 저장한다.
                PlayerPrefs.SetFloat("ElfFireKeep" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerController>().FireKeeping);
                
                //해당슬롯에 엘프의 빙결상태 지속시간을 저장한다.
                PlayerPrefs.SetFloat("ElfFreeze" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerController>().KeepFreeze);
                
                //해당슬롯에 엘프의 감전상태 지속시간을 저장한다.
                PlayerPrefs.SetFloat("ElftElectric" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerController>().KeepElectric);
                
                //해당슬롯에 엘프의 기절상태 지속시간을 저장한다.
                PlayerPrefs.SetFloat("ElfFaint" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerController>().KeepFaint);
                
                //해당슬롯에 엘프의 넉백으로 밀어내는 힘을 저장한다.
                PlayerPrefs.SetFloat("ElfKnockBack" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerController>().ForceKnockback);
            }
            PlayerPrefs.SetInt("SlotSaved" + SaveID.saveID, 1);
            PlayerPrefs.SetInt("LoadSaved" + SaveID.saveID, 1);
            PlayerPrefs.SetInt("SavedScene" + SaveID.saveID, SceneManager.GetActiveScene().buildIndex);

            //해당 슬롯에 위의 데이터들을 저장한다.
            PlayerPrefs.Save();
            SceneManager.LoadScene(PassAStage);

        }
    }
}
