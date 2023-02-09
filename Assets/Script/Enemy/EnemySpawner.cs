using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;             //복제해서 생성할 적 캐릭터 프리팹

    [SerializeField]
    private float spawnTime;                    //생성주기

    [SerializeField]
    private GameObject enemyHPSliderPrefab;     //적 체력을 나타내는 Slider UI 프리팹

    [SerializeField]
    private Transform canvaseTransform;         //UI를 표현하는 Canvas 오브젝트의 Transform
    
    public int maxEnemyCounter;                 //적이 생성될수 있는 최대 갯수

    [HideInInspector]
    public int currentEnemyCounter;            //현재 생성된 적의 수

    GameObject enemyclone;

    private void Start()
    {
        //SpawnEnemy코루틴을 시작한다.
        StartCoroutine("SpawnEnemy");
        //태그 이름이 Boss이면
        if(enemyPrefab.gameObject.tag=="Boss")
        {
            //SpawnEnemy코루틴을 멈춘다.
            StopCoroutine("SpawnEnemy");
        }
    }

    private IEnumerator SpawnEnemy()
    {
        while(true)
        {
            //현재 적의 개수가 최대 생성할수 있는 수보다 적으면
            if(currentEnemyCounter < maxEnemyCounter)
            {
                //오브젝트의 태그가 SmallEnemy1Spawner이면
                if(this.gameObject.tag == "SmallEnemy1Spawner")
                {
                    //SmallEnemy1오브젝트를 풀에서 꺼내온다.
                    PollingOBJ("SmallEnemy1");
                }
                //오브젝트의 태그가 SmallEnemy2Spawner이면
                else if (this.gameObject.tag == "SmallEnemy2Spawner")
                {
                    //SmallEnemy2오브젝트를 풀에서 꺼내온다.
                    PollingOBJ("SmallEnemy2");
                }
                //오브젝트의 태그가 SmallEnemy3Spawner이면
                else if (this.gameObject.tag == "SmallEnemy3Spawner")
                {
                    //SmallEnemy3오브젝트를 풀에서 꺼내온다.
                    PollingOBJ("SmallEnemy3");
                }
                //오브젝트의 태그가 SmallEnemy4Spawner이면
                else if (this.gameObject.tag == "SmallEnemy4Spawner")
                {
                    //SmallEnemy4오브젝트를 풀에서 꺼내온다.
                    PollingOBJ("SmallEnemy4");
                }
                //오브젝트의 태그가 SmallEnemy5Spawner이면
                else if (this.gameObject.tag == "SmallEnemy5Spawner")
                {
                    //SmallEnemy5오브젝트를 풀에서 꺼내온다.
                    PollingOBJ("SmallEnemy5");
                }
                //오브젝트의 태그가 SmallEnemy6Spawner이면
                else if (this.gameObject.tag == "SmallEnemy6Spawner")
                {
                    //SmallEnemy6오브젝트를 풀에서 꺼내온다.
                    PollingOBJ("SmallEnemy6");
                }
                //오브젝트의 태그가 SmallEnemy7Spawner이면
                else if (this.gameObject.tag == "SmallEnemy7Spawner")
                {
                    //SmallEnemy7오브젝트를 풀에서 꺼내온다.
                    PollingOBJ("SmallEnemy7");
                }
                //오브젝트의 태그가 SmallEnemy8Spawner이면
                else if (this.gameObject.tag == "SmallEnemy8Spawner")
                {
                    //SmallEnemy8오브젝트를 풀에서 꺼내온다.
                    PollingOBJ("SmallEnemy8");
                }
                //오브젝트의 태그가 SmallEnemy9Spawner이면
                else if (this.gameObject.tag == "SmallEnemy9Spawner")
                {
                    //SmallEnemy9오브젝트를 풀에서 꺼내온다.
                    PollingOBJ("SmallEnemy9");
                }
                //오브젝트의 태그가 SmallEnemy10Spawner이면
                else if (this.gameObject.tag == "SmallEnemy10Spawner")
                {
                    //SmallEnemy10오브젝트를 풀에서 꺼내온다.
                    PollingOBJ("SmallEnemy10");
                }
                //오브젝트의 태그가 SmallEnemy11Spawner이면
                else if (this.gameObject.tag == "SmallEnemy11Spawner")
                {
                    //SmallEnemy11오브젝트를 풀에서 꺼내온다.
                    PollingOBJ("SmallEnemy11");
                }
                //오브젝트의 태그가 SmallEnemy12Spawner이면
                else if (this.gameObject.tag == "SmallEnemy12Spawner")
                {
                    //SmallEnemy12오브젝트를 풀에서 꺼내온다.
                    PollingOBJ("SmallEnemy12");
                }
                //오브젝트의 태그가 SmallEnemy13Spawner이면
                else if (this.gameObject.tag == "SmallEnemy13Spawner")
                {
                    //SmallEnemy13오브젝트를 풀에서 꺼내온다.
                    PollingOBJ("SmallEnemy13");
                }
                //오브젝트의 태그가 SmallEnemy14Spawner이면
                else if (this.gameObject.tag == "SmallEnemy14Spawner")
                {
                    //SmallEnemy14오브젝트를 풀에서 꺼내온다.
                    PollingOBJ("SmallEnemy14");
                }
                //오브젝트의 태그가 SmallEnemy15Spawner이면
                else if (this.gameObject.tag == "SmallEnemy15Spawner")
                {
                    //SmallEnemy15오브젝트를 풀에서 꺼내온다.
                    PollingOBJ("SmallEnemy15");
                }

                //오브젝트의 태그가 BigEnemy1Spawner이면
                if (this.gameObject.tag == "BigEnemy1Spawner")
                {
                    //BigEnemy1오브젝트를 풀에서 꺼내온다.
                    PollingOBJ("BigEnemy1");
                }
                //오브젝트의 태그가 BigEnemy2Spawner이면
                else if (this.gameObject.tag == "BigEnemy2Spawner")
                {
                    //BigEnemy2오브젝트를 풀에서 꺼내온다.
                    PollingOBJ("BigEnemy2");
                }
                //오브젝트의 태그가 BigEnemy3Spawner이면
                else if (this.gameObject.tag == "BigEnemy3Spawner")
                {
                    //BigEnemy1오브젝트를 풀에서 꺼내온다.
                    PollingOBJ("BigEnemy3");
                }
                //오브젝트의 태그가 BigEnemy4Spawner이면
                else if (this.gameObject.tag == "BigEnemy4Spawner")
                {
                    //BigEnemy4오브젝트를 풀에서 꺼내온다.
                    PollingOBJ("BigEnemy4");
                }
                //오브젝트의 태그가 BigEnemy5Spawner이면
                else if (this.gameObject.tag == "BigEnemy5Spawner")
                {
                    //BigEnemy5오브젝트를 풀에서 꺼내온다.
                    PollingOBJ("BigEnemy5");
                }
                //오브젝트의 태그가 BigEnemy6Spawner이면
                else if (this.gameObject.tag == "BigEnemy6Spawner")
                {
                    //BigEnemy6오브젝트를 풀에서 꺼내온다.
                    PollingOBJ("BigEnemy6");
                }
                //오브젝트의 태그가 BigEnemy7Spawner이면
                else if (this.gameObject.tag == "BigEnemy7Spawner")
                {
                    //BigEnemy7오브젝트를 풀에서 꺼내온다.
                    PollingOBJ("BigEnemy7");
                }
                //오브젝트의 태그가 BigEnemy8Spawner이면
                else if (this.gameObject.tag == "BigEnemy8Spawner")
                {
                    //BigEnemy8오브젝트를 풀에서 꺼내온다.
                    PollingOBJ("BigEnemy8");
                }
                //오브젝트의 태그가 BigEnemy9Spawner이면
                else if (this.gameObject.tag == "BigEnemy9Spawner")
                {
                    //BigEnemy9오브젝트를 풀에서 꺼내온다.
                    PollingOBJ("BigEnemy9");
                }
                //오브젝트의 태그가 BigEnemy10Spawner이면
                else if (this.gameObject.tag == "BigEnemy10Spawner")
                {
                    //BigEnemy10오브젝트를 풀에서 꺼내온다.
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
                //EnemyHP스크립트의 Link변수를 가져와 이 오브젝트에 적용시킨다.
                enemyclone.GetComponent<EnemyHP>().Link = this;
                //현재 적의 개수는 증가한다.
                currentEnemyCounter++;
                //적 체력을 나타내는 Slider UI 생성 및 설정
                SpawnEnemyHPSlider(enemyclone);
            }
            //만약 현재 생성된 적의 개수가 최대이상이면
            else if(currentEnemyCounter>=maxEnemyCounter) 
            {
                //적의 개수는 최대까지 생성한다.
                currentEnemyCounter = maxEnemyCounter;
            }
            //spawnTime만큼 대기
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void SpawnEnemyHPSlider(GameObject enemy)
    {        
        //적 체력을 나타내는 Slider UI를 비활성화 상태로 생성 한다.
        GameObject sliderclone = ObjectPool.OBP.GetObject("EnemyHPSlider");
        sliderclone.transform.Find("EnemyHP").Find("Text").gameObject.SetActive(true);
        sliderclone.SetActive(true);
        //Instantiate(enemyHPSliderPrefab);

        enemy.GetComponent<EnemyController>().HPbar = sliderclone;

        /*Slider UI 오브젝트를 parent("canvas"오브젝트)의 자식으로 설정
         Tip. UI는 캔버스의 자식 오브젝트로 설정되어 있어야 화면에 보인다.*/
        sliderclone.transform.SetParent(canvaseTransform);

        //계층 설정으로 바뀐 크기를 다시(1.5,2,1)로 설정
        sliderclone.transform.localScale = new Vector3(1.5f, 2, 1);

        //태그가 BigEnemy이거나 Boss이면
        if(enemyPrefab.gameObject.tag=="BigEnemy"||enemyPrefab.gameObject.tag=="Boss")
        {
            //계층 설저으로 바뀐 크기를 다시 (2,2,2)로 설정한다.
            sliderclone.transform.localScale = new Vector3(2,2,2);
        }

        //Slider UI가 쫓아다닐 대상을 본인으로 설정
        sliderclone.GetComponent<SliderPositionAutoSetter>().SetUp(enemy.transform);

        //Slider UI에 자신의 체력 정보를 표시하도록 설정.
        sliderclone.GetComponent<EnemyHPViewer>().SetUp(enemy.GetComponent<EnemyHP>());
        //Slider UI의 자식 오브젝트에 자신의 체력 정보를 표시하도록 설정.
        sliderclone.transform.Find("EnemyHP").GetComponentInChildren<EHPText>().SetUp(enemy.GetComponent<EnemyHP>());
    }

    //오브젝트 풀링 함수
    public void PollingOBJ(string name)
    {
        //name이란 이름을 가진 오브젝트를 다시 가져온다.
        enemyclone = ObjectPool.OBP.GetObject(name);
        //가져온 오브젝트를 활성화 한다.
        enemyclone.SetActive(true);
        //위치는 자신을 위치로 지정한다.
        enemyclone.transform.position = this.transform.position;
    }
}
