using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerWeaponInventory : MonoBehaviour
{
    public WeaponSlotUI[] weaponslotUI;

    public List<GameObject> allWeaponInPossesion;

    public int currentWeaponIndex;
    
    //[HideInInspector]
    public GameObject currentWeapon;

    private PlayerShoot PS;

    private void Start()
    {
        //시작할때 마법슬롯은 어둡게 짙어진다.
        weaponslotUI[currentWeaponIndex].WeaponImage.color = Color.gray;

        //캐릭터 별로 무기 슬롯의 Image 컴포넌트에 접근한다.
        switch (DataManager.instance.currentCharacter)
        {
            case Character.MagicKnight: //마법기사이면
                //플레이어가 남기는 검기 슬롯의 WeaponSlotUI에 접근한다.
                weaponslotUI[0] = GameObject.Find("Canvas").transform.Find("SwordPanel").transform.Find("RoyalSwordSlotPanel").GetComponent<WeaponSlotUI>();
                //플레이어가 남기는 불속성 검기 슬롯의 WeaponSlotUI에 접근한다.
                weaponslotUI[1] = GameObject.Find("Canvas").transform.Find("SwordPanel").transform.Find("FireSwordSlotPanel").GetComponent<WeaponSlotUI>();
                //플레이어가 남기는 물속성 검기 슬롯의 WeaponSlotUI에 접근한다.
                weaponslotUI[2] = GameObject.Find("Canvas").transform.Find("SwordPanel").transform.Find("AquaSwordSlotPanel").GetComponent<WeaponSlotUI>();
                //플레이어가 남기는 번개속성 검기 슬롯의 WeaponSlotUI에 접근한다.
                weaponslotUI[3] = GameObject.Find("Canvas").transform.Find("SwordPanel").transform.Find("ThunderSwordSlotPanel").GetComponent<WeaponSlotUI>();
                //플레이어가 남기는 흙속성 검기 슬롯의 WeaponSlotUI에 접근한다.
                weaponslotUI[4] = GameObject.Find("Canvas").transform.Find("SwordPanel").transform.Find("EarthSwordSlotPanel").GetComponent<WeaponSlotUI>();
                //플레이어가 남기는 바람속성 검기 슬롯의 WeaponSlotUI에 접근한다.
                weaponslotUI[5] = GameObject.Find("Canvas").transform.Find("SwordPanel").transform.Find("WindSwordSlotPanel").GetComponent<WeaponSlotUI>();
                break;
            case Character.Wizard:  //마법사이면
                //플레이어가 쏘는 불속성 총을 슬롯의 WeaoponSlotUI에 접근한다.
                weaponslotUI[0] = GameObject.Find("Canvas").transform.Find("BulletPanel").transform.Find("FireBulletSlotPanel").GetComponent<WeaponSlotUI>();
                //플레이어가 쏘는 물속성 총을 슬롯의 WeaoponSlotUI에 접근한다.
                weaponslotUI[1] = GameObject.Find("Canvas").transform.Find("BulletPanel").transform.Find("AquaBulletSlotPanel").GetComponent<WeaponSlotUI>();
                //플레이어가 쏘는 번개속성 총을 슬롯의 WeaoponSlotUI에 접근한다.
                weaponslotUI[2] = GameObject.Find("Canvas").transform.Find("BulletPanel").transform.Find("ThunderBulletSlotPanel").GetComponent<WeaponSlotUI>();
                //플레이어가 쏘는 흙속성 총을 슬롯의 WeaoponSlotUI에 접근한다.
                weaponslotUI[3] = GameObject.Find("Canvas").transform.Find("BulletPanel").transform.Find("EarthBulletSlotPanel").GetComponent<WeaponSlotUI>();
                //플레이어가 쏘는 바람속성 총을 슬롯의 WeaoponSlotUI에 접근한다.
                weaponslotUI[4] = GameObject.Find("Canvas").transform.Find("BulletPanel").transform.Find("WindBulletSlotPanel").GetComponent<WeaponSlotUI>();
                break;
            case Character.Elf: //엘프이면
                //플레이어가 쏘는 화살 슬롯의 WeaponSlotUI에 접근한다.
                weaponslotUI[0] = GameObject.Find("Canvas").transform.Find("ArrowPanel").transform.Find("ArrowSlotPanel").GetComponent<WeaponSlotUI>();
                //플레이어가 쏘는 불속성화살 슬롯의 WeaponSlotUI에 접근한다.
                weaponslotUI[1] = GameObject.Find("Canvas").transform.Find("ArrowPanel").transform.Find("FireArrowSlotPanel").GetComponent<WeaponSlotUI>();
                //플레이어가 쏘는 물속성화살 슬롯의 WeaponSlotUI에 접근한다.
                weaponslotUI[2] = GameObject.Find("Canvas").transform.Find("ArrowPanel").transform.Find("AquaArrowSlotPanel").GetComponent<WeaponSlotUI>();
                //플레이어가 쏘는 바람화살 슬롯의 WeaponSlotUI에 접근한다.
                weaponslotUI[3] = GameObject.Find("Canvas").transform.Find("ArrowPanel").transform.Find("WindArrowSlotPanel").GetComponent<WeaponSlotUI>();
                break;
        }
        //첫번째 슬롯의 무기로 선택한다.
        currentWeapon = allWeaponInPossesion[0];
        //선택된 첫번째 슬롯 오브젝트는 활성화 된다.
        weaponslotUI[0].WeaponImage.color = Color.white;

        PS = this.GetComponent<PlayerShoot>();
    }
    // Update is called once per frame
    void Update()
    {
        TrySwitchWeapon();
    }

    private void TrySwitchWeapon()
    {
        int weaponIndexToGoTo = currentWeaponIndex;
        //마우스 휠을 앞으로 돌리면
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            //이전 무기를 선택한다.
            weaponIndexToGoTo--;
        }
        //마우스 휠을 뒤로 돌리면
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            //다음 무기를 선택한다.
            weaponIndexToGoTo++;
        }
        /*만약 weaponIndexToGoTo값이 0보다 적거나
         allWeaponInPosesion.Count값이랑 같거나
        currentWeaponIndex랑 같으면 움직이지 않는다.*/
        if (weaponIndexToGoTo < 0
            ||weaponIndexToGoTo == allWeaponInPossesion.Count
            ||weaponIndexToGoTo==currentWeaponIndex)
        {
            return;
        }
        //현재 선택된 슬롯은 비활성화가 된다.
        //weaponslotUI[currentWeaponIndex].selectionWeapon.SetActive(false);
        //바뀐 슬롯은 활성화가 된다.
        //weaponslotUI[weaponIndexToGoTo].selectionWeapon.SetActive(true);

        //currentWeapon은 allWeaponInPosesion의 순서값을 가진다.
        currentWeapon = allWeaponInPossesion[weaponIndexToGoTo];
        currentWeaponIndex = weaponIndexToGoTo;
    }

    //public void ChangeWeapon(GameObject weaponchange)
    //{
    //    weaponslotUI[allWeaponInPossesion.Count - 1].WeaponImage.sprite =
    //        weaponchange.GetComponent<SpriteRenderer>().sprite;
    //}

    public void SelectWeapon(int weaponIndex)
    {
        //이전의 무기슬롯의 색은 어둡게 변한다.
        weaponslotUI[currentWeaponIndex].WeaponImage.color = Color.gray;
        //현재 선택된 무기슬롯의 색은 밝게 변한다.
        //weaponslotUI[weaponIndex].selectionWeapon.SetActive(true);
        weaponslotUI[weaponIndex].WeaponImage.color = Color.white;        
        //현재 선택된 무기는 마우스로 고른 무기가 된다.
        currentWeapon = allWeaponInPossesion[weaponIndex];
        currentWeaponIndex = weaponIndex;
        PS.SetWeaponChange(currentWeaponIndex);
    }
}