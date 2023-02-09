using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagic : MonoBehaviour
{
    public PlayerMagicInventory PlayerMInventory;
    private PlayerHUD playerMP;
    private Magic useMP;
    public float cooltime;
    private float curtime;

    void Awake()
    {
        playerMP = GameObject.FindWithTag("Player").GetComponent<PlayerHUD>();
    }

    private void Start()
    {
        // 아래 문장을 Awake에서 Start로 이동 ( 이유 : PlayerMInventory의 초기화가 준비가 되지 않은 상태에서 접근하는것 방지)
        useMP = PlayerMInventory.currentWeapon.GetComponent<Magic>();
    }

    // Update is called once per frame
    void Update()
    {
        TrySpell();
    }

    private void TrySpell()
    {
        //슬롯중에 하나가 선택이 되어 있을때
        if (PlayerMInventory.currentMagicIndex != -1)
        {
            //현재 재사용 대기시간이 0보다 작거나 같으면
            if(curtime<=0)
            {
                //마우스 왼쪽 버튼을 눌렀다 뗐다 하면
                if(Input.GetMouseButtonUp(0))
                {
                    //현재 남아있는 MP가 사용할 MP보다 더 많거나 같으면
                    if(playerMP.curMP>=useMP.useMP)
                    {
                        //Spell을 실행한다.
                        Spell();
                        curtime = cooltime;
                        playerMP.useMagic(useMP.useMP);
                    }
                }
            }
        }
        curtime -= Time.deltaTime;
    }

    private void Spell()
    {
        //MainCamera태그를 가진 오브젝트의 Camera 컴포넌트에 접근을 하여 화면상의 월드 좌표계는 마우스의 위치랑 같다.
        Vector3 SpellPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        SpellPos.z = 1;
        //Instantiate(PlayerMInventory.currentWeapon, SpellPos, Quaternion.identity);
        //Canvas오브젝트의5번째 자식오브젝트인 MagicPanel이 활성화 되어 있으면
        if (GameObject.Find("Canvas").transform.GetChild(5).gameObject.activeSelf == true)
        {
            GameObject obj;
            //어떤 슬롯을 선택느냐에 따라 오브젝트 풀을위해 활성화 한다.
            switch (PlayerMInventory.currentMagicIndex)
            {
                case 0: //0번이면                    
                    //오브젝트 풀을이용해 FireMagic1을 생성한다.
                    obj = ObjectPool.OBP.GetObject("FireMagic1");

                    //활성화 한다.
                    obj.SetActive(true);

                    //활성화할 위치는 SpellPos에서 스폰한다.
                    obj.transform.position = SpellPos;
                    break;
                case 1:
                    //오브젝트 풀을이용해 FireMagic2을 생성한다.
                    obj = ObjectPool.OBP.GetObject("FireMagic2");

                    //활성화 한다.
                    obj.SetActive(true);

                    //활성화할 위치는 SpellPos에서 스폰한다.
                    obj.transform.position = SpellPos;
                    break;
                case 2:
                    //오브젝트 풀을이용해 WaterMagic1Ready을 생성한다.
                    obj = ObjectPool.OBP.GetObject("WaterMagic1Ready");

                    //활성화 한다.
                    obj.SetActive(true);

                    //활성화할 위치는 SpellPos에서 스폰한다.
                    obj.transform.position = SpellPos;
                    break;
                case 3:
                    //오브젝트 풀을이용해 WaterMagic2Ready을 생성한다.
                    obj = ObjectPool.OBP.GetObject("WaterMagic2Ready");

                    //활성화 한다.
                    obj.SetActive(true);

                    //활성화할 위치는 SpellPos에서 스폰한다.
                    obj.transform.position = SpellPos;
                    break;
                case 4:
                    //오브젝트 풀을이용해 ThunderMagic1을 생성한다.
                    obj = ObjectPool.OBP.GetObject("ThunderMagic1");

                    //활성화 한다.
                    obj.SetActive(true);

                    //활성화할 위치는 SpellPos에서 스폰한다.
                    obj.transform.position = SpellPos;
                    break;
                case 5:
                    //오브젝트 풀을이용해 ThunderMagic2을 생성한다.
                    obj = ObjectPool.OBP.GetObject("ThunderMagic2");

                    //활성화 한다.
                    obj.SetActive(true);

                    //활성화할 위치는 SpellPos에서 스폰한다.
                    obj.transform.position = SpellPos;
                    break;
                case 6:
                    //오브젝트 풀을이용해 EarthMagic1을 생성한다.
                    obj = ObjectPool.OBP.GetObject("EarthMagic1");
                    //활성화 한다.
                    obj.SetActive(true);
                    obj.transform.position = SpellPos;
                    break;
                case 7:
                    //오브젝트 풀을이용해 EarthMagic2을 생성한다.
                    obj = ObjectPool.OBP.GetObject("EarthMagic2");

                    //활성화 한다.
                    obj.SetActive(true);

                    //활성화할 위치는 SpellPos에서 스폰한다.
                    obj.transform.position = SpellPos;
                    break;
                case 8:
                    //오브젝트 풀을이용해 WindMagic1을 생성한다.
                    obj = ObjectPool.OBP.GetObject("WindMagic1");

                    //활성화 한다.
                    obj.SetActive(true);

                    //활성화할 위치는 SpellPos에서 스폰한다.
                    obj.transform.position = SpellPos;
                    break;
                case 9:
                    //오브젝트 풀을이용해 WindMagic2을 생성한다.
                    obj = ObjectPool.OBP.GetObject("WindMagic2");

                    //활성화 한다.
                    obj.SetActive(true);

                    //활성화할 위치는 SpellPos에서 스폰한다.
                    obj.transform.position = SpellPos;
                    break;
            }
        }
    }

    public void SetMagicNum(int _magicNum)
    {
        PlayerMInventory.currentMagicIndex = _magicNum;
    }
}
