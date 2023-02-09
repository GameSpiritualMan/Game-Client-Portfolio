using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public PlayerWeaponInventory PlayerWInventory;
    public Transform Pos;
    public float cooltime;
    private float curtime;
    private int weaponNum;

    private AudioSource AttackAudio;

    //�������̽�ƽ
    [HideInInspector]
    public float h;
    float v;

    private GameObject Slots;

    [SerializeField]
    private JoyStick AttackJoyStick;

    //�ڵ� �Ѿ� �߻�
    //public float AttackDistance;    //���ݹݰ�
    //private Transform SmallEnemy;   //���� �� 
    //private Transform BigEnemy;     //ū ��
    //private Transform Boss;         //����
    //private Transform Player;       //�÷��̾�

    //private Vector2 Enemypoint;     //������ ��ġ
    //private float angle;            //������ ����z
    void Start()
    {
        AttackJoyStick = GameObject.Find("Canvas").transform.Find("AttackJoystick").GetComponent<JoyStick>();
        weaponNum = GetComponent<PlayerWeaponInventory>().currentWeaponIndex;
        Slots = GameObject.Find("Canvas");
        AttackAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //���� ���̽�ƽ
        h = AttackJoyStick.Horizontal();      //��/��
        v = AttackJoyStick.Vertical();        //��/�Ʒ�

        Vector2 len = new Vector2(x: h, y: v);
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(x: 0, y: 0, z);

        //TryShoot();

        if (h != 0 || v != 0)
        {
            if (curtime <= 0)
            {
                //Pos.position���� PlayerWInventory�� transform.rotation������ŭ ����� ä�� �����Ѵ�.
                //Instantiate(PlayerWInventory.currentWeapon, Pos.position, transform.rotation);
                Shoot();
                curtime = cooltime;
            }
            curtime -= Time.deltaTime;
        }
    }

    public void SetWeaponChange(int WeaponNum)
    {
        weaponNum = WeaponNum;
    }

    private void Shoot()
    {
        AttackAudio.Play();
        GameObject obj;
        //���ӿ��� ������簡 ���õǾ�����
        if (DataManager.instance.currentCharacter==Character.MagicKnight)
        {
            //weaponNum�� ���� ������Ʈ Ǯ���� ������Ʈ�� ����������.
            switch (weaponNum)
            {
                //0���̸�
                case 0:
                    //RoyalSword������Ʈ�� Ǯ���� ������ Ȱ��ȭ �Ѵ�.
                    obj = ObjectPool.OBP.GetObject("RoyalSword");
                    //ó�� ��ġ�� Pos���� �����Ѵ�.
                    obj.transform.position = Pos.position;
                    //����� Pos�� ����� ����.
                    obj.transform.rotation = this.transform.rotation;
                    //Ȱ��ȭ �Ѵ�.
                    obj.SetActive(true);
                    break;
                case 1:
                    obj = ObjectPool.OBP.GetObject("FireSword");
                    //ó�� ��ġ�� Pos���� �����Ѵ�.
                    obj.transform.position = Pos.position;
                    //����� Pos�� ����� ����.
                    obj.transform.rotation = this.transform.rotation;
                    //Ȱ��ȭ �Ѵ�.
                    obj.SetActive(true);
                    break;
                case 2:
                    obj = ObjectPool.OBP.GetObject("AquaSword");
                    //ó�� ��ġ�� Pos���� �����Ѵ�.
                    obj.transform.position = Pos.position;
                    //����� Pos�� ����� ����.
                    obj.transform.rotation = transform.rotation;
                    //Ȱ��ȭ �Ѵ�.
                    obj.SetActive(true);
                    break;
                case 3:
                    obj = ObjectPool.OBP.GetObject("ThunderSword");
                    //ó�� ��ġ�� Pos���� �����Ѵ�.
                    obj.transform.position = Pos.position;
                    //����� Pos�� ����� ����.
                    obj.transform.rotation = transform.rotation;
                    //Ȱ��ȭ �Ѵ�.
                    obj.SetActive(true);
                    break;
                case 4:
                    obj = ObjectPool.OBP.GetObject("EarthSword");
                    //ó�� ��ġ�� Pos���� �����Ѵ�.
                    obj.transform.position = Pos.position;
                    //����� Pos�� ����� ����.
                    obj.transform.rotation = transform.rotation;
                    //Ȱ��ȭ �Ѵ�.
                    obj.SetActive(true);
                    break;
                case 5:
                    obj = ObjectPool.OBP.GetObject("WindSword");
                    //ó�� ��ġ�� Pos���� �����Ѵ�.
                    obj.transform.position = Pos.position;
                    //����� Pos�� ����� ����.
                    obj.transform.rotation = transform.rotation;
                    //Ȱ��ȭ �Ѵ�.
                    obj.SetActive(true);
                    break;
            }
        }
        else if (DataManager.instance.currentCharacter==Character.Wizard)
        {
            switch (weaponNum)
            {
                case 0:
                    obj = ObjectPool.OBP.GetObject("FireBullet");
                    //ó�� ��ġ�� Pos���� �����Ѵ�.
                    obj.transform.position = Pos.position;
                    //����� Pos�� ����� ����.
                    obj.transform.rotation = this.transform.rotation;
                    //Ȱ��ȭ �Ѵ�.
                    obj.SetActive(true);
                    break;
                case 1:
                    obj = ObjectPool.OBP.GetObject("AquaBullet");
                    //ó�� ��ġ�� Pos���� �����Ѵ�.
                    obj.transform.position = Pos.position;
                    //����� Pos�� ����� ����.
                    obj.transform.rotation = this.transform.rotation;
                    //Ȱ��ȭ �Ѵ�.
                    obj.SetActive(true);
                    break;
                case 2:
                    obj = ObjectPool.OBP.GetObject("ThunderBullet");
                    //ó�� ��ġ�� Pos���� �����Ѵ�.
                    obj.transform.position = Pos.position;
                    //����� Pos�� ����� ����.
                    obj.transform.rotation = transform.rotation;
                    //Ȱ��ȭ �Ѵ�.
                    obj.SetActive(true);
                    break;
                case 3:
                    obj = ObjectPool.OBP.GetObject("EarthBullet");
                    //ó�� ��ġ�� Pos���� �����Ѵ�.
                    obj.transform.position = Pos.position;
                    //����� Pos�� ����� ����.
                    obj.transform.rotation = transform.rotation;
                    //Ȱ��ȭ �Ѵ�.
                    obj.SetActive(true);
                    break;
                case 4:
                    obj = ObjectPool.OBP.GetObject("WindBullet");
                    //ó�� ��ġ�� Pos���� �����Ѵ�.
                    obj.transform.position = Pos.position;
                    //����� Pos�� ����� ����.
                    obj.transform.rotation = transform.rotation;
                    //Ȱ��ȭ �Ѵ�.
                    obj.SetActive(true);
                    break;
            }
        }
        else if (DataManager.instance.currentCharacter==Character.Elf)
        {
            switch (weaponNum)
            {
                case 0:
                    obj = ObjectPool.OBP.GetObject("Arrow");
                    //ó�� ��ġ�� Pos���� �����Ѵ�.
                    obj.transform.position = Pos.position;
                    //����� Pos�� ����� ����.
                    obj.transform.rotation = transform.rotation;
                    //Ȱ��ȭ �Ѵ�.
                    obj.SetActive(true);
                    break;
                case 1:
                    obj = ObjectPool.OBP.GetObject("FireArrow");
                    //ó�� ��ġ�� Pos���� �����Ѵ�.
                    obj.transform.position = Pos.position;
                    //����� Pos�� ����� ����.
                    obj.transform.rotation = transform.rotation;
                    //Ȱ��ȭ �Ѵ�.
                    obj.SetActive(true);
                    break;
                case 2:
                    obj = ObjectPool.OBP.GetObject("AquaArrow");
                    //ó�� ��ġ�� Pos���� �����Ѵ�.
                    obj.transform.position = Pos.position;
                    //����� Pos�� ����� ����.
                    obj.transform.rotation = transform.rotation;
                    //Ȱ��ȭ �Ѵ�.
                    obj.SetActive(true);
                    break;
                case 3:
                    obj = ObjectPool.OBP.GetObject("WindArrow");
                    //ó�� ��ġ�� Pos���� �����Ѵ�.
                    obj.transform.position = Pos.position;
                    //����� Pos�� ����� ����.
                    obj.transform.rotation = transform.rotation;
                    //Ȱ��ȭ �Ѵ�.
                    obj.SetActive(true);
                    break;
            }
        }
    }
}
