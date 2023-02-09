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
        // �Ʒ� ������ Awake���� Start�� �̵� ( ���� : PlayerMInventory�� �ʱ�ȭ�� �غ� ���� ���� ���¿��� �����ϴ°� ����)
        useMP = PlayerMInventory.currentWeapon.GetComponent<Magic>();
    }

    // Update is called once per frame
    void Update()
    {
        TrySpell();
    }

    private void TrySpell()
    {
        //�����߿� �ϳ��� ������ �Ǿ� ������
        if (PlayerMInventory.currentMagicIndex != -1)
        {
            //���� ���� ���ð��� 0���� �۰ų� ������
            if(curtime<=0)
            {
                //���콺 ���� ��ư�� ������ �ô� �ϸ�
                if(Input.GetMouseButtonUp(0))
                {
                    //���� �����ִ� MP�� ����� MP���� �� ���ų� ������
                    if(playerMP.curMP>=useMP.useMP)
                    {
                        //Spell�� �����Ѵ�.
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
        //MainCamera�±׸� ���� ������Ʈ�� Camera ������Ʈ�� ������ �Ͽ� ȭ����� ���� ��ǥ��� ���콺�� ��ġ�� ����.
        Vector3 SpellPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        SpellPos.z = 1;
        //Instantiate(PlayerMInventory.currentWeapon, SpellPos, Quaternion.identity);
        //Canvas������Ʈ��5��° �ڽĿ�����Ʈ�� MagicPanel�� Ȱ��ȭ �Ǿ� ������
        if (GameObject.Find("Canvas").transform.GetChild(5).gameObject.activeSelf == true)
        {
            GameObject obj;
            //� ������ ���ô��Ŀ� ���� ������Ʈ Ǯ������ Ȱ��ȭ �Ѵ�.
            switch (PlayerMInventory.currentMagicIndex)
            {
                case 0: //0���̸�                    
                    //������Ʈ Ǯ���̿��� FireMagic1�� �����Ѵ�.
                    obj = ObjectPool.OBP.GetObject("FireMagic1");

                    //Ȱ��ȭ �Ѵ�.
                    obj.SetActive(true);

                    //Ȱ��ȭ�� ��ġ�� SpellPos���� �����Ѵ�.
                    obj.transform.position = SpellPos;
                    break;
                case 1:
                    //������Ʈ Ǯ���̿��� FireMagic2�� �����Ѵ�.
                    obj = ObjectPool.OBP.GetObject("FireMagic2");

                    //Ȱ��ȭ �Ѵ�.
                    obj.SetActive(true);

                    //Ȱ��ȭ�� ��ġ�� SpellPos���� �����Ѵ�.
                    obj.transform.position = SpellPos;
                    break;
                case 2:
                    //������Ʈ Ǯ���̿��� WaterMagic1Ready�� �����Ѵ�.
                    obj = ObjectPool.OBP.GetObject("WaterMagic1Ready");

                    //Ȱ��ȭ �Ѵ�.
                    obj.SetActive(true);

                    //Ȱ��ȭ�� ��ġ�� SpellPos���� �����Ѵ�.
                    obj.transform.position = SpellPos;
                    break;
                case 3:
                    //������Ʈ Ǯ���̿��� WaterMagic2Ready�� �����Ѵ�.
                    obj = ObjectPool.OBP.GetObject("WaterMagic2Ready");

                    //Ȱ��ȭ �Ѵ�.
                    obj.SetActive(true);

                    //Ȱ��ȭ�� ��ġ�� SpellPos���� �����Ѵ�.
                    obj.transform.position = SpellPos;
                    break;
                case 4:
                    //������Ʈ Ǯ���̿��� ThunderMagic1�� �����Ѵ�.
                    obj = ObjectPool.OBP.GetObject("ThunderMagic1");

                    //Ȱ��ȭ �Ѵ�.
                    obj.SetActive(true);

                    //Ȱ��ȭ�� ��ġ�� SpellPos���� �����Ѵ�.
                    obj.transform.position = SpellPos;
                    break;
                case 5:
                    //������Ʈ Ǯ���̿��� ThunderMagic2�� �����Ѵ�.
                    obj = ObjectPool.OBP.GetObject("ThunderMagic2");

                    //Ȱ��ȭ �Ѵ�.
                    obj.SetActive(true);

                    //Ȱ��ȭ�� ��ġ�� SpellPos���� �����Ѵ�.
                    obj.transform.position = SpellPos;
                    break;
                case 6:
                    //������Ʈ Ǯ���̿��� EarthMagic1�� �����Ѵ�.
                    obj = ObjectPool.OBP.GetObject("EarthMagic1");
                    //Ȱ��ȭ �Ѵ�.
                    obj.SetActive(true);
                    obj.transform.position = SpellPos;
                    break;
                case 7:
                    //������Ʈ Ǯ���̿��� EarthMagic2�� �����Ѵ�.
                    obj = ObjectPool.OBP.GetObject("EarthMagic2");

                    //Ȱ��ȭ �Ѵ�.
                    obj.SetActive(true);

                    //Ȱ��ȭ�� ��ġ�� SpellPos���� �����Ѵ�.
                    obj.transform.position = SpellPos;
                    break;
                case 8:
                    //������Ʈ Ǯ���̿��� WindMagic1�� �����Ѵ�.
                    obj = ObjectPool.OBP.GetObject("WindMagic1");

                    //Ȱ��ȭ �Ѵ�.
                    obj.SetActive(true);

                    //Ȱ��ȭ�� ��ġ�� SpellPos���� �����Ѵ�.
                    obj.transform.position = SpellPos;
                    break;
                case 9:
                    //������Ʈ Ǯ���̿��� WindMagic2�� �����Ѵ�.
                    obj = ObjectPool.OBP.GetObject("WindMagic2");

                    //Ȱ��ȭ �Ѵ�.
                    obj.SetActive(true);

                    //Ȱ��ȭ�� ��ġ�� SpellPos���� �����Ѵ�.
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
