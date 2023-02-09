using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;             //�����ؼ� ������ �� ĳ���� ������

    [SerializeField]
    private float spawnTime;                    //�����ֱ�

    [SerializeField]
    private GameObject enemyHPSliderPrefab;     //�� ü���� ��Ÿ���� Slider UI ������

    [SerializeField]
    private Transform canvaseTransform;         //UI�� ǥ���ϴ� Canvas ������Ʈ�� Transform
    
    public int maxEnemyCounter;                 //���� �����ɼ� �ִ� �ִ� ����

    [HideInInspector]
    public int currentEnemyCounter;            //���� ������ ���� ��

    GameObject enemyclone;

    private void Start()
    {
        //SpawnEnemy�ڷ�ƾ�� �����Ѵ�.
        StartCoroutine("SpawnEnemy");
        //�±� �̸��� Boss�̸�
        if(enemyPrefab.gameObject.tag=="Boss")
        {
            //SpawnEnemy�ڷ�ƾ�� �����.
            StopCoroutine("SpawnEnemy");
        }
    }

    private IEnumerator SpawnEnemy()
    {
        while(true)
        {
            //���� ���� ������ �ִ� �����Ҽ� �ִ� ������ ������
            if(currentEnemyCounter < maxEnemyCounter)
            {
                //������Ʈ�� �±װ� SmallEnemy1Spawner�̸�
                if(this.gameObject.tag == "SmallEnemy1Spawner")
                {
                    //SmallEnemy1������Ʈ�� Ǯ���� �����´�.
                    PollingOBJ("SmallEnemy1");
                }
                //������Ʈ�� �±װ� SmallEnemy2Spawner�̸�
                else if (this.gameObject.tag == "SmallEnemy2Spawner")
                {
                    //SmallEnemy2������Ʈ�� Ǯ���� �����´�.
                    PollingOBJ("SmallEnemy2");
                }
                //������Ʈ�� �±װ� SmallEnemy3Spawner�̸�
                else if (this.gameObject.tag == "SmallEnemy3Spawner")
                {
                    //SmallEnemy3������Ʈ�� Ǯ���� �����´�.
                    PollingOBJ("SmallEnemy3");
                }
                //������Ʈ�� �±װ� SmallEnemy4Spawner�̸�
                else if (this.gameObject.tag == "SmallEnemy4Spawner")
                {
                    //SmallEnemy4������Ʈ�� Ǯ���� �����´�.
                    PollingOBJ("SmallEnemy4");
                }
                //������Ʈ�� �±װ� SmallEnemy5Spawner�̸�
                else if (this.gameObject.tag == "SmallEnemy5Spawner")
                {
                    //SmallEnemy5������Ʈ�� Ǯ���� �����´�.
                    PollingOBJ("SmallEnemy5");
                }
                //������Ʈ�� �±װ� SmallEnemy6Spawner�̸�
                else if (this.gameObject.tag == "SmallEnemy6Spawner")
                {
                    //SmallEnemy6������Ʈ�� Ǯ���� �����´�.
                    PollingOBJ("SmallEnemy6");
                }
                //������Ʈ�� �±װ� SmallEnemy7Spawner�̸�
                else if (this.gameObject.tag == "SmallEnemy7Spawner")
                {
                    //SmallEnemy7������Ʈ�� Ǯ���� �����´�.
                    PollingOBJ("SmallEnemy7");
                }
                //������Ʈ�� �±װ� SmallEnemy8Spawner�̸�
                else if (this.gameObject.tag == "SmallEnemy8Spawner")
                {
                    //SmallEnemy8������Ʈ�� Ǯ���� �����´�.
                    PollingOBJ("SmallEnemy8");
                }
                //������Ʈ�� �±װ� SmallEnemy9Spawner�̸�
                else if (this.gameObject.tag == "SmallEnemy9Spawner")
                {
                    //SmallEnemy9������Ʈ�� Ǯ���� �����´�.
                    PollingOBJ("SmallEnemy9");
                }
                //������Ʈ�� �±װ� SmallEnemy10Spawner�̸�
                else if (this.gameObject.tag == "SmallEnemy10Spawner")
                {
                    //SmallEnemy10������Ʈ�� Ǯ���� �����´�.
                    PollingOBJ("SmallEnemy10");
                }
                //������Ʈ�� �±װ� SmallEnemy11Spawner�̸�
                else if (this.gameObject.tag == "SmallEnemy11Spawner")
                {
                    //SmallEnemy11������Ʈ�� Ǯ���� �����´�.
                    PollingOBJ("SmallEnemy11");
                }
                //������Ʈ�� �±װ� SmallEnemy12Spawner�̸�
                else if (this.gameObject.tag == "SmallEnemy12Spawner")
                {
                    //SmallEnemy12������Ʈ�� Ǯ���� �����´�.
                    PollingOBJ("SmallEnemy12");
                }
                //������Ʈ�� �±װ� SmallEnemy13Spawner�̸�
                else if (this.gameObject.tag == "SmallEnemy13Spawner")
                {
                    //SmallEnemy13������Ʈ�� Ǯ���� �����´�.
                    PollingOBJ("SmallEnemy13");
                }
                //������Ʈ�� �±װ� SmallEnemy14Spawner�̸�
                else if (this.gameObject.tag == "SmallEnemy14Spawner")
                {
                    //SmallEnemy14������Ʈ�� Ǯ���� �����´�.
                    PollingOBJ("SmallEnemy14");
                }
                //������Ʈ�� �±װ� SmallEnemy15Spawner�̸�
                else if (this.gameObject.tag == "SmallEnemy15Spawner")
                {
                    //SmallEnemy15������Ʈ�� Ǯ���� �����´�.
                    PollingOBJ("SmallEnemy15");
                }

                //������Ʈ�� �±װ� BigEnemy1Spawner�̸�
                if (this.gameObject.tag == "BigEnemy1Spawner")
                {
                    //BigEnemy1������Ʈ�� Ǯ���� �����´�.
                    PollingOBJ("BigEnemy1");
                }
                //������Ʈ�� �±װ� BigEnemy2Spawner�̸�
                else if (this.gameObject.tag == "BigEnemy2Spawner")
                {
                    //BigEnemy2������Ʈ�� Ǯ���� �����´�.
                    PollingOBJ("BigEnemy2");
                }
                //������Ʈ�� �±װ� BigEnemy3Spawner�̸�
                else if (this.gameObject.tag == "BigEnemy3Spawner")
                {
                    //BigEnemy1������Ʈ�� Ǯ���� �����´�.
                    PollingOBJ("BigEnemy3");
                }
                //������Ʈ�� �±װ� BigEnemy4Spawner�̸�
                else if (this.gameObject.tag == "BigEnemy4Spawner")
                {
                    //BigEnemy4������Ʈ�� Ǯ���� �����´�.
                    PollingOBJ("BigEnemy4");
                }
                //������Ʈ�� �±װ� BigEnemy5Spawner�̸�
                else if (this.gameObject.tag == "BigEnemy5Spawner")
                {
                    //BigEnemy5������Ʈ�� Ǯ���� �����´�.
                    PollingOBJ("BigEnemy5");
                }
                //������Ʈ�� �±װ� BigEnemy6Spawner�̸�
                else if (this.gameObject.tag == "BigEnemy6Spawner")
                {
                    //BigEnemy6������Ʈ�� Ǯ���� �����´�.
                    PollingOBJ("BigEnemy6");
                }
                //������Ʈ�� �±װ� BigEnemy7Spawner�̸�
                else if (this.gameObject.tag == "BigEnemy7Spawner")
                {
                    //BigEnemy7������Ʈ�� Ǯ���� �����´�.
                    PollingOBJ("BigEnemy7");
                }
                //������Ʈ�� �±װ� BigEnemy8Spawner�̸�
                else if (this.gameObject.tag == "BigEnemy8Spawner")
                {
                    //BigEnemy8������Ʈ�� Ǯ���� �����´�.
                    PollingOBJ("BigEnemy8");
                }
                //������Ʈ�� �±װ� BigEnemy9Spawner�̸�
                else if (this.gameObject.tag == "BigEnemy9Spawner")
                {
                    //BigEnemy9������Ʈ�� Ǯ���� �����´�.
                    PollingOBJ("BigEnemy9");
                }
                //������Ʈ�� �±װ� BigEnemy10Spawner�̸�
                else if (this.gameObject.tag == "BigEnemy10Spawner")
                {
                    //BigEnemy10������Ʈ�� Ǯ���� �����´�.
                    PollingOBJ("BigEnemy10");
                }
                else if(this.gameObject.name=="BossEnemySpawner")
                {
                    switch (SceneManager.GetActiveScene().buildIndex)
                    {
                        case 6:
                            PollingOBJ("Boss1");
                            break;
                        case 7:
                            PollingOBJ("Boss2");
                            break;
                        case 8:
                            PollingOBJ("Boss3");
                            break;
                        case 9:
                            PollingOBJ("Boss4");
                            break;
                        case 10:
                            PollingOBJ("Boss5");
                            break;
                        case 11:
                            PollingOBJ("FinalBoss");
                            break;
                    }
                }
                //EnemyHP��ũ��Ʈ�� Link������ ������ �� ������Ʈ�� �����Ų��.
                enemyclone.GetComponent<EnemyHP>().Link = this;
                //���� ���� ������ �����Ѵ�.
                currentEnemyCounter++;
                //�� ü���� ��Ÿ���� Slider UI ���� �� ����
                SpawnEnemyHPSlider(enemyclone);
            }
            //���� ���� ������ ���� ������ �ִ��̻��̸�
            else if(currentEnemyCounter>=maxEnemyCounter) 
            {
                //���� ������ �ִ���� �����Ѵ�.
                currentEnemyCounter = maxEnemyCounter;
            }
            //spawnTime��ŭ ���
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void SpawnEnemyHPSlider(GameObject enemy)
    {        
        //�� ü���� ��Ÿ���� Slider UI�� ��Ȱ��ȭ ���·� ���� �Ѵ�.
        GameObject sliderclone = ObjectPool.OBP.GetObject("EnemyHPSlider");
        sliderclone.transform.Find("EnemyHP").Find("Text").gameObject.SetActive(true);
        sliderclone.SetActive(true);
        //Instantiate(enemyHPSliderPrefab);

        enemy.GetComponent<EnemyController>().HPbar = sliderclone;

        /*Slider UI ������Ʈ�� parent("canvas"������Ʈ)�� �ڽ����� ����
         Tip. UI�� ĵ������ �ڽ� ������Ʈ�� �����Ǿ� �־�� ȭ�鿡 ���δ�.*/
        sliderclone.transform.SetParent(canvaseTransform);

        //���� �������� �ٲ� ũ�⸦ �ٽ�(1.5,2,1)�� ����
        sliderclone.transform.localScale = new Vector3(1.5f, 2, 1);

        //�±װ� BigEnemy�̰ų� Boss�̸�
        if(enemyPrefab.gameObject.tag=="BigEnemy"||enemyPrefab.gameObject.tag=="Boss")
        {
            //���� �������� �ٲ� ũ�⸦ �ٽ� (2,2,2)�� �����Ѵ�.
            sliderclone.transform.localScale = new Vector3(2,2,2);
        }

        //Slider UI�� �Ѿƴٴ� ����� �������� ����
        sliderclone.GetComponent<SliderPositionAutoSetter>().SetUp(enemy.transform);

        //Slider UI�� �ڽ��� ü�� ������ ǥ���ϵ��� ����.
        sliderclone.GetComponent<EnemyHPViewer>().SetUp(enemy.GetComponent<EnemyHP>());
        //Slider UI�� �ڽ� ������Ʈ�� �ڽ��� ü�� ������ ǥ���ϵ��� ����.
        sliderclone.transform.Find("EnemyHP").GetComponentInChildren<EHPText>().SetUp(enemy.GetComponent<EnemyHP>());
    }

    //������Ʈ Ǯ�� �Լ�
    public void PollingOBJ(string name)
    {
        //name�̶� �̸��� ���� ������Ʈ�� �ٽ� �����´�.
        enemyclone = ObjectPool.OBP.GetObject(name);
        //������ ������Ʈ�� Ȱ��ȭ �Ѵ�.
        enemyclone.SetActive(true);
        //��ġ�� �ڽ��� ��ġ�� �����Ѵ�.
        enemyclone.transform.position = this.transform.position;
    }
}
