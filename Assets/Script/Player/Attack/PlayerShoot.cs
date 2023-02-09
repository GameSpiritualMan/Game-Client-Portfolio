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

    //가상조이스틱
    [HideInInspector]
    public float h;
    float v;

    private GameObject Slots;

    [SerializeField]
    private JoyStick AttackJoyStick;

    //자동 총알 발사
    //public float AttackDistance;    //공격반경
    //private Transform SmallEnemy;   //작은 적 
    //private Transform BigEnemy;     //큰 적
    //private Transform Boss;         //보스
    //private Transform Player;       //플레이어

    //private Vector2 Enemypoint;     //적들의 위치
    //private float angle;            //적들의 방향z
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
        //가상 조이스틱
        h = AttackJoyStick.Horizontal();      //좌/우
        v = AttackJoyStick.Vertical();        //위/아래

        Vector2 len = new Vector2(x: h, y: v);
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(x: 0, y: 0, z);

        //TryShoot();

        if (h != 0 || v != 0)
        {
            if (curtime <= 0)
            {
                //Pos.position에서 PlayerWInventory를 transform.rotation각도만큼 기울인 채로 생성한다.
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
        //게임에서 마법기사가 선택되었으면
        if (DataManager.instance.currentCharacter==Character.MagicKnight)
        {
            //weaponNum에 따라서 오브젝트 풀링할 오브젝트가 나뉘어진다.
            switch (weaponNum)
            {
                //0번이면
                case 0:
                    //RoyalSword오브젝트를 풀에서 꺼내어 활성화 한다.
                    obj = ObjectPool.OBP.GetObject("RoyalSword");
                    //처음 위치는 Pos에서 시작한다.
                    obj.transform.position = Pos.position;
                    //기울기는 Pos의 기울기랑 같다.
                    obj.transform.rotation = this.transform.rotation;
                    //활성화 한다.
                    obj.SetActive(true);
                    break;
                case 1:
                    obj = ObjectPool.OBP.GetObject("FireSword");
                    //처음 위치는 Pos에서 시작한다.
                    obj.transform.position = Pos.position;
                    //기울기는 Pos의 기울기랑 같다.
                    obj.transform.rotation = this.transform.rotation;
                    //활성화 한다.
                    obj.SetActive(true);
                    break;
                case 2:
                    obj = ObjectPool.OBP.GetObject("AquaSword");
                    //처음 위치는 Pos에서 시작한다.
                    obj.transform.position = Pos.position;
                    //기울기는 Pos의 기울기랑 같다.
                    obj.transform.rotation = transform.rotation;
                    //활성화 한다.
                    obj.SetActive(true);
                    break;
                case 3:
                    obj = ObjectPool.OBP.GetObject("ThunderSword");
                    //처음 위치는 Pos에서 시작한다.
                    obj.transform.position = Pos.position;
                    //기울기는 Pos의 기울기랑 같다.
                    obj.transform.rotation = transform.rotation;
                    //활성화 한다.
                    obj.SetActive(true);
                    break;
                case 4:
                    obj = ObjectPool.OBP.GetObject("EarthSword");
                    //처음 위치는 Pos에서 시작한다.
                    obj.transform.position = Pos.position;
                    //기울기는 Pos의 기울기랑 같다.
                    obj.transform.rotation = transform.rotation;
                    //활성화 한다.
                    obj.SetActive(true);
                    break;
                case 5:
                    obj = ObjectPool.OBP.GetObject("WindSword");
                    //처음 위치는 Pos에서 시작한다.
                    obj.transform.position = Pos.position;
                    //기울기는 Pos의 기울기랑 같다.
                    obj.transform.rotation = transform.rotation;
                    //활성화 한다.
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
                    //처음 위치는 Pos에서 시작한다.
                    obj.transform.position = Pos.position;
                    //기울기는 Pos의 기울기랑 같다.
                    obj.transform.rotation = this.transform.rotation;
                    //활성화 한다.
                    obj.SetActive(true);
                    break;
                case 1:
                    obj = ObjectPool.OBP.GetObject("AquaBullet");
                    //처음 위치는 Pos에서 시작한다.
                    obj.transform.position = Pos.position;
                    //기울기는 Pos의 기울기랑 같다.
                    obj.transform.rotation = this.transform.rotation;
                    //활성화 한다.
                    obj.SetActive(true);
                    break;
                case 2:
                    obj = ObjectPool.OBP.GetObject("ThunderBullet");
                    //처음 위치는 Pos에서 시작한다.
                    obj.transform.position = Pos.position;
                    //기울기는 Pos의 기울기랑 같다.
                    obj.transform.rotation = transform.rotation;
                    //활성화 한다.
                    obj.SetActive(true);
                    break;
                case 3:
                    obj = ObjectPool.OBP.GetObject("EarthBullet");
                    //처음 위치는 Pos에서 시작한다.
                    obj.transform.position = Pos.position;
                    //기울기는 Pos의 기울기랑 같다.
                    obj.transform.rotation = transform.rotation;
                    //활성화 한다.
                    obj.SetActive(true);
                    break;
                case 4:
                    obj = ObjectPool.OBP.GetObject("WindBullet");
                    //처음 위치는 Pos에서 시작한다.
                    obj.transform.position = Pos.position;
                    //기울기는 Pos의 기울기랑 같다.
                    obj.transform.rotation = transform.rotation;
                    //활성화 한다.
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
                    //처음 위치는 Pos에서 시작한다.
                    obj.transform.position = Pos.position;
                    //기울기는 Pos의 기울기랑 같다.
                    obj.transform.rotation = transform.rotation;
                    //활성화 한다.
                    obj.SetActive(true);
                    break;
                case 1:
                    obj = ObjectPool.OBP.GetObject("FireArrow");
                    //처음 위치는 Pos에서 시작한다.
                    obj.transform.position = Pos.position;
                    //기울기는 Pos의 기울기랑 같다.
                    obj.transform.rotation = transform.rotation;
                    //활성화 한다.
                    obj.SetActive(true);
                    break;
                case 2:
                    obj = ObjectPool.OBP.GetObject("AquaArrow");
                    //처음 위치는 Pos에서 시작한다.
                    obj.transform.position = Pos.position;
                    //기울기는 Pos의 기울기랑 같다.
                    obj.transform.rotation = transform.rotation;
                    //활성화 한다.
                    obj.SetActive(true);
                    break;
                case 3:
                    obj = ObjectPool.OBP.GetObject("WindArrow");
                    //처음 위치는 Pos에서 시작한다.
                    obj.transform.position = Pos.position;
                    //기울기는 Pos의 기울기랑 같다.
                    obj.transform.rotation = transform.rotation;
                    //활성화 한다.
                    obj.SetActive(true);
                    break;
            }
        }
    }
}
