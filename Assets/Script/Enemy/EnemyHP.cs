using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHP : MonoBehaviour
{
    public float maxHP;         //�ִ� ü��
    private float currentHP;    //���� ü��

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    public GameObject[] HealItem;

    public GameObject[] StatusStrengthItems;

    public GameObject[] ElementalStrengthItems;

    public string PassAStage;

    [HideInInspector]
    public EnemySpawner Link;   //EnemySpawner��ũ��Ʈ�� currentEnemyCount������ �������� ���� �����Ѵ�.

    private SpriteRenderer sprite;

    //�ӵ����� �������� ���� �����Ѵ�.
    private float speed;
    //������ �ӵ����� �����ϱ� ���� �����Ѵ�.
    [HideInInspector]
    public float Savespeed;
    
    private int spawnHeal;          //ȸ�� ������ ������ ����
    private int spawnStatus;        //�÷��̾� ���� ��ȭ ������ ������ ����
    private int spawnElemental;     //�÷��̾� �Ӽ� ��ȭ ������ ������ ����

    private GameObject spawn;

    private EnemyController enemyController;

    //ȭ����� ǥ��
    public GameObject BurningState;

    //������ �ؽ�Ʈ ǥ��
    public GameObject HUDDMGText;
    public Transform DMGPos;
    private void Awake()
    {
        Link = GetComponent<EnemySpawner>();    //EnemySpawner�� �����´�.
        sprite = GetComponent<SpriteRenderer>();    //SpriteRenderer������Ʈ�� �������Ѵ�.
        enemyController = GetComponent<EnemyController>();
        //Ȱ��ȭ�� �����̸� �����Ѵ�.
        OnEnable();
    }

    void OnEnable()
    {
        currentHP = maxHP;          //ó�� HP�� ���� ä���� �ִ�.
        sprite.color = Color.white; //���� ������ �����Ѵ�.
        BurningState.SetActive(false);  //ȭ����¸� ǥ������ �ʴ´�.
    }

    public void TakeDamage(float Damage)
    {
        //EnemyDMG������Ʈ�� Ǯ���Ͽ� �����´�.
        HUDDMGText = ObjectPool.OBP.GetObject("EnemyDMG");
        //DMGText������Ʈ��DMG�� Damage���� �����Ѵ�.
        HUDDMGText.GetComponent<DMGText>().DMG = Damage;
        //DMG�� ������ ��ġ�� DMGPos��ġ���� �����ȴ�.
        HUDDMGText.transform.position = DMGPos.position;
        //Ǯ���� ������Ʈ�� Ȱ��ȭ �Ѵ�.
        HUDDMGText.SetActive(true);
        currentHP -= Damage;    //ü���� Damage��ŭ �����Ѵ�.
        if(currentHP<=0)
        {
            if (IsInvoking("StartBurn"))
            {
                //ȭ����´� �����.
                CancelInvoke("BurnStart");
            }
            else if (enemyController.IsInvoking("FreezeStart"))
            {
                //������´� �����.
                enemyController.CancelInvoke("FreezeStart");
            }
            else if (enemyController.IsInvoking("ElectricsShockStart"))
            {
                //�������´� �����.
                enemyController.CancelInvoke("ElectricsShockStart");
            }
            else if (enemyController.IsInvoking("FaintStart"))
            {
                //�������´� �����.
                enemyController.CancelInvoke("FaintStart");
            }
            //����HP�� 0�� �ȴ�.
            currentHP = 0;
            //������Ʈ Ǯ�� ���� ��ȯ�Ѵ�.
            ObjectPool.OBP.ReturnObject(this.gameObject);
            //�±װ� ���������̸� �ڱ��ڽ��� �������.
            if(this.gameObject.tag=="Boss")
            {
                Destroy(this.gameObject);
            }
            //���� ��ġ���� ������ ������ �پ���.
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
        //HealItem�� �߰��� ������Ʈ�� ���� ������ ��´�.
        spawnHeal = Random.Range(0, HealItem.Length);
        //StatusStrengthItems�� �߰��� ������Ʈ�� ���� ������ ��´�.
        spawnStatus = Random.Range(0, StatusStrengthItems.Length);
        //ElementalStrengthItems�� �߰��� ������Ʈ�� ���� ������ ��´�.
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

    //ȭ����� ����
    public void BurnStart(float FireDamage, float Firetime)
    {
        //������Ʈ�� ���� �Ӱ� ���Ѵ�.
        sprite.color = Color.red;
        //ȭ����� �������� ǥ���Ѵ�.
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
            //���� 3�ʸ� ��ٸ���.
            yield return new WaitForSeconds(1.5f);
            //ȭ����� ���ӽð��� ���� ������
            if (Firetime > 0)
            {
                //EnemyDMG ������Ʈ�� Ǯ������ �����´�.
                HUDDMGText = ObjectPool.OBP.GetObject("EnemyDMG");
                //Ǯ���� ������Ʈ�� ������ ���� FireDamage�� ����.
                HUDDMGText.GetComponent<DMGText>().DMG = FireDamage;
                //EnemyDMG ������Ʈ�� �ؽ�Ʈ ���� ���� ���� �ȴ�.
                HUDDMGText.GetComponent<DMGText>().text.color = Color.red;
                //Ǯ���� ��ġ�� DMGPos��ġ���� �����Ѵ�.
                HUDDMGText.transform.position = DMGPos.position;
                //Ǯ���� ������Ʈ�� Ȱ��ȭ �ȴ�.
                HUDDMGText.SetActive(true);
                //ȭ�� ������
                TakeBurnDamage(FireDamage);
            }
            else
            {
                //�����ı�� ���ƿ´�.
                sprite.color = Color.white;
                //ȭ����� �������� ǥ������ �ʴ´�.
                BurningState.SetActive(false);
                //�ƴ϶�� Burning()����
                yield return null;
            }
        }
    }

    //��ȭ�� ���� ������
    private void TakeBurnDamage(float FireDamage)
    {
        //���� HP�� FireDamage��ŭ �����Ѵ�.
        currentHP -= FireDamage;
        if (CurrentHP <= 0)
        {
            //ȭ����´� �����.
            CancelInvoke("BurnStart");
            //������´� �����.
            enemyController.CancelInvoke("FreezeStart");
            //�������´� �����.
            enemyController.CancelInvoke("ElectricsShockStart");
            //�������´� �����.
            enemyController.CancelInvoke("FaintStart");
            //����HP�� 0�� �ȴ�.
            currentHP = 0;
            //������Ʈ Ǯ�� ���� ��ȯ�Ѵ�.
            ObjectPool.OBP.ReturnObject(this.gameObject);
            //�±װ� ���������̸� �ڱ��ڽ��� �������.
            if (this.gameObject.tag == "Boss")
            {
                Destroy(this.gameObject);
            }
            //���� ���� �پ���.
            Link.currentEnemyCounter--;
            //���� ���� ���� 0���� ������
            if (Link.currentEnemyCounter < 0)
            {
                //���� ���� ���� 0�� 
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
            //�÷��̾��� ĳ���Ͱ� ��������̸�
            if (GameObject.Find("MagicKnight(Clone)"))
            {
                //�ش罽�Կ� ��������� X�� ��ǥ�� �����Ѵ�.
                PlayerPrefs.SetFloat("MagicKnightX" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").transform.position.x);

                //�ش罽�Կ� ��������� Y�� ��ǥ�� �����Ѵ�.
                PlayerPrefs.SetFloat("MagicKnightY" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").transform.position.y);

                //�ش罽�Կ� ��������� ���� ���� ���ݷ� �����Ѵ�.
                PlayerPrefs.SetFloat("MagicKnightAttack" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerController>().attackDamage);

                //�ش罽�Կ� ��������� ���� ���� ���ݷ� �����Ѵ�.
                PlayerPrefs.SetFloat("MagicKnightMagic" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerController>().MagicAttack);
                
                //�ش罽�Կ� ��������� �ִ� HP ���� �����Ѵ�.
                PlayerPrefs.SetFloat("MagicKnightMaxHP" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerHUD>().MaxHealth);

                //�ش罽�Կ� ��������� �ִ� MP ���� �����Ѵ�.
                PlayerPrefs.SetFloat("MagicKnightMaxMP" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerHUD>().MaxMana);
                
                //�ش罽�Կ� ��������� ���� HP�� �����Ѵ�.
                PlayerPrefs.SetFloat("MagicKnightCurHPStrength" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerHUD>().curHP);

                //�ش罽�Կ� ��������� ���� MP�� �����Ѵ�.
                PlayerPrefs.SetFloat("MagicKnightCurMPStrength" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerHUD>().curMP);

                //�ش罽�Կ� ��������� ȭ����� �������� �����Ѵ�.
                PlayerPrefs.SetFloat("MagicKnightFireDamage" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerController>().FireDamage);
                
                //�ش罽�Կ� ��������� ȭ����� ���ӽð��� �����Ѵ�.
                PlayerPrefs.SetFloat("MagicKnightFireKeep" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerController>().FireKeeping);
                
                //�ش罽�Կ� ��������� ������� ���ӽð��� �����Ѵ�.
                PlayerPrefs.SetFloat("MagicKnightFreeze" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerController>().KeepFreeze);
                
                //�ش罽�Կ� ��������� �������� ���ӽð��� �����Ѵ�.
                PlayerPrefs.SetFloat("MagicKnightElectric" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerController>().KeepElectric);
                
                //�ش罽�Կ� ��������� �������� ���ӽð��� �����Ѵ�.
                PlayerPrefs.SetFloat("MagicKnightFaint" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerController>().KeepFaint);
                
                //�ش罽�Կ� ��������� �˹����� �о�� ���� �����Ѵ�.
                PlayerPrefs.SetFloat("MagicKnightKnockBack" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerController>().ForceKnockback);
            }

            //�÷��̾��� ĳ���Ͱ� �������̸�
            else if (GameObject.Find("Wizard(Clone)"))
            {
                //���罽�Կ� �������� X�� ��ǥ�� �����Ѵ�.
                PlayerPrefs.SetFloat("WizardX" + SaveID.saveID, GameObject.Find("Wizard(Clone)").transform.position.x);

                //�ش罽�Կ� �������� Y�� ��ǥ�� �����Ѵ�.
                PlayerPrefs.SetFloat("WizardY" + SaveID.saveID, GameObject.Find("Wizard(Clone)").transform.position.y);

                //�ش罽�Կ� �������� ���� ���� ���ݷ��� �����Ѵ�.
                PlayerPrefs.SetFloat("WizardAttack" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerController>().attackDamage);

                //�ش罽�Կ� �������� ���� ���� ���ݷ��� �����Ѵ�.
                PlayerPrefs.SetFloat("WizardMagic" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerController>().MagicAttack);
                
                //�ش罽�Կ� �������� �ִ� HP�� �����Ѵ�.
                PlayerPrefs.SetFloat("WizardMaxHP" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerHUD>().MaxHealth);

                //�ش罽�Կ� �������� �ִ� MP�� �����Ѵ�.
                PlayerPrefs.SetFloat("WizardMaxMP" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerHUD>().MaxMana);
                
                //�ش罽�Կ� �������� ���� HP�� �����Ѵ�.
                PlayerPrefs.SetFloat("WizardCurHPStrength" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerHUD>().curHP);

                //�ش罽�Կ� �������� ���� MP�� �����Ѵ�.
                PlayerPrefs.SetFloat("WizardCurMPStrength" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerHUD>().curMP);

                //�ش罽�Կ� �������� ȭ����� �������� �����Ѵ�.
                PlayerPrefs.SetFloat("WizardFireDamage" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerController>().FireDamage);
                
                //�ش罽�Կ� �������� ȭ����� ���ӽð��� �����Ѵ�.
                PlayerPrefs.SetFloat("WizardFireKeep" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerController>().FireKeeping);
                
                //�ش罽�Կ� �������� ������� ���ӽð��� �����Ѵ�.
                PlayerPrefs.SetFloat("WizardFreeze" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerController>().KeepFreeze);
                
                //�ش罽�Կ� �������� �������� ���ӽð��� �����Ѵ�.
                PlayerPrefs.SetFloat("WizardElectric" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerController>().KeepElectric);
                
                //�ش罽�Կ� �������� �������� ���ӽð��� �����Ѵ�.
                PlayerPrefs.SetFloat("WizardFaint" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerController>().KeepFaint);
                
                //�ش罽�Կ� �������� �˹����� �о�� ���� �����Ѵ�.
                PlayerPrefs.SetFloat("WizardKnockBack" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerController>().ForceKnockback);
            }

            //�÷��̾��� ĳ���Ͱ� �����̸�
            else if (GameObject.Find("Elf(Clone)"))
            {
                //�ش罽�Կ� ������ X�� ��ǥ�� �����Ѵ�.
                PlayerPrefs.SetFloat("ElfX" + SaveID.saveID, GameObject.Find("Elf(Clone)").transform.position.x);

                //�ش罽�Կ� ������ Y�� ��ǥ�� �����Ѵ�.
                PlayerPrefs.SetFloat("ElfY" + SaveID.saveID, GameObject.Find("Elf(Clone)").transform.position.y);

                //�ش罽�Կ� ������ ���� ���� ���ݷ��� �����Ѵ�.
                PlayerPrefs.SetFloat("ElfAttack" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerController>().attackDamage);

                //�ش罽�Կ� ������ ���� ���� ���ݷ��� �����Ѵ�.
                PlayerPrefs.SetFloat("ElfMagic" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerController>().MagicAttack);
                
                //�ش罽�Կ� ������ �ִ� HP�� �����Ѵ�.
                PlayerPrefs.SetFloat("ElfMaxHP" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerHUD>().MaxHealth);

                //�ش�ַԿ� ������ �ִ� MP�� �����Ѵ�.
                PlayerPrefs.SetFloat("ElfMaxMP" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerHUD>().MaxMana);
                
                //�ش罽�Կ� ������ ���� HP�� �����Ѵ�.
                PlayerPrefs.SetFloat("ElfCurHPStrength" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerHUD>().curHP);

                //�ش罽�Կ� ������ ���� MP�� �����Ѵ�.
                PlayerPrefs.SetFloat("ElfCurMPStrength" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerHUD>().curMP);

                //�ش罽�Կ� ������ ȭ����� �������� �����Ѵ�.
                PlayerPrefs.SetFloat("ElfFireDamage" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerController>().FireDamage);
                
                //�ش罽�Կ� ������ ȭ����� ���ӽð��� �����Ѵ�.
                PlayerPrefs.SetFloat("ElfFireKeep" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerController>().FireKeeping);
                
                //�ش罽�Կ� ������ ������� ���ӽð��� �����Ѵ�.
                PlayerPrefs.SetFloat("ElfFreeze" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerController>().KeepFreeze);
                
                //�ش罽�Կ� ������ �������� ���ӽð��� �����Ѵ�.
                PlayerPrefs.SetFloat("ElftElectric" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerController>().KeepElectric);
                
                //�ش罽�Կ� ������ �������� ���ӽð��� �����Ѵ�.
                PlayerPrefs.SetFloat("ElfFaint" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerController>().KeepFaint);
                
                //�ش罽�Կ� ������ �˹����� �о�� ���� �����Ѵ�.
                PlayerPrefs.SetFloat("ElfKnockBack" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerController>().ForceKnockback);
            }
            PlayerPrefs.SetInt("SlotSaved" + SaveID.saveID, 1);
            PlayerPrefs.SetInt("LoadSaved" + SaveID.saveID, 1);
            PlayerPrefs.SetInt("SavedScene" + SaveID.saveID, SceneManager.GetActiveScene().buildIndex);

            //�ش� ���Կ� ���� �����͵��� �����Ѵ�.
            PlayerPrefs.Save();
            SceneManager.LoadScene(PassAStage);

        }
    }
}
