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
        //�����Ҷ� ���������� ��Ӱ� £������.
        weaponslotUI[currentWeaponIndex].WeaponImage.color = Color.gray;

        //ĳ���� ���� ���� ������ Image ������Ʈ�� �����Ѵ�.
        switch (DataManager.instance.currentCharacter)
        {
            case Character.MagicKnight: //��������̸�
                //�÷��̾ ����� �˱� ������ WeaponSlotUI�� �����Ѵ�.
                weaponslotUI[0] = GameObject.Find("Canvas").transform.Find("SwordPanel").transform.Find("RoyalSwordSlotPanel").GetComponent<WeaponSlotUI>();
                //�÷��̾ ����� �ҼӼ� �˱� ������ WeaponSlotUI�� �����Ѵ�.
                weaponslotUI[1] = GameObject.Find("Canvas").transform.Find("SwordPanel").transform.Find("FireSwordSlotPanel").GetComponent<WeaponSlotUI>();
                //�÷��̾ ����� ���Ӽ� �˱� ������ WeaponSlotUI�� �����Ѵ�.
                weaponslotUI[2] = GameObject.Find("Canvas").transform.Find("SwordPanel").transform.Find("AquaSwordSlotPanel").GetComponent<WeaponSlotUI>();
                //�÷��̾ ����� �����Ӽ� �˱� ������ WeaponSlotUI�� �����Ѵ�.
                weaponslotUI[3] = GameObject.Find("Canvas").transform.Find("SwordPanel").transform.Find("ThunderSwordSlotPanel").GetComponent<WeaponSlotUI>();
                //�÷��̾ ����� ��Ӽ� �˱� ������ WeaponSlotUI�� �����Ѵ�.
                weaponslotUI[4] = GameObject.Find("Canvas").transform.Find("SwordPanel").transform.Find("EarthSwordSlotPanel").GetComponent<WeaponSlotUI>();
                //�÷��̾ ����� �ٶ��Ӽ� �˱� ������ WeaponSlotUI�� �����Ѵ�.
                weaponslotUI[5] = GameObject.Find("Canvas").transform.Find("SwordPanel").transform.Find("WindSwordSlotPanel").GetComponent<WeaponSlotUI>();
                break;
            case Character.Wizard:  //�������̸�
                //�÷��̾ ��� �ҼӼ� ���� ������ WeaoponSlotUI�� �����Ѵ�.
                weaponslotUI[0] = GameObject.Find("Canvas").transform.Find("BulletPanel").transform.Find("FireBulletSlotPanel").GetComponent<WeaponSlotUI>();
                //�÷��̾ ��� ���Ӽ� ���� ������ WeaoponSlotUI�� �����Ѵ�.
                weaponslotUI[1] = GameObject.Find("Canvas").transform.Find("BulletPanel").transform.Find("AquaBulletSlotPanel").GetComponent<WeaponSlotUI>();
                //�÷��̾ ��� �����Ӽ� ���� ������ WeaoponSlotUI�� �����Ѵ�.
                weaponslotUI[2] = GameObject.Find("Canvas").transform.Find("BulletPanel").transform.Find("ThunderBulletSlotPanel").GetComponent<WeaponSlotUI>();
                //�÷��̾ ��� ��Ӽ� ���� ������ WeaoponSlotUI�� �����Ѵ�.
                weaponslotUI[3] = GameObject.Find("Canvas").transform.Find("BulletPanel").transform.Find("EarthBulletSlotPanel").GetComponent<WeaponSlotUI>();
                //�÷��̾ ��� �ٶ��Ӽ� ���� ������ WeaoponSlotUI�� �����Ѵ�.
                weaponslotUI[4] = GameObject.Find("Canvas").transform.Find("BulletPanel").transform.Find("WindBulletSlotPanel").GetComponent<WeaponSlotUI>();
                break;
            case Character.Elf: //�����̸�
                //�÷��̾ ��� ȭ�� ������ WeaponSlotUI�� �����Ѵ�.
                weaponslotUI[0] = GameObject.Find("Canvas").transform.Find("ArrowPanel").transform.Find("ArrowSlotPanel").GetComponent<WeaponSlotUI>();
                //�÷��̾ ��� �ҼӼ�ȭ�� ������ WeaponSlotUI�� �����Ѵ�.
                weaponslotUI[1] = GameObject.Find("Canvas").transform.Find("ArrowPanel").transform.Find("FireArrowSlotPanel").GetComponent<WeaponSlotUI>();
                //�÷��̾ ��� ���Ӽ�ȭ�� ������ WeaponSlotUI�� �����Ѵ�.
                weaponslotUI[2] = GameObject.Find("Canvas").transform.Find("ArrowPanel").transform.Find("AquaArrowSlotPanel").GetComponent<WeaponSlotUI>();
                //�÷��̾ ��� �ٶ�ȭ�� ������ WeaponSlotUI�� �����Ѵ�.
                weaponslotUI[3] = GameObject.Find("Canvas").transform.Find("ArrowPanel").transform.Find("WindArrowSlotPanel").GetComponent<WeaponSlotUI>();
                break;
        }
        //ù��° ������ ����� �����Ѵ�.
        currentWeapon = allWeaponInPossesion[0];
        //���õ� ù��° ���� ������Ʈ�� Ȱ��ȭ �ȴ�.
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
        //���콺 ���� ������ ������
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            //���� ���⸦ �����Ѵ�.
            weaponIndexToGoTo--;
        }
        //���콺 ���� �ڷ� ������
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            //���� ���⸦ �����Ѵ�.
            weaponIndexToGoTo++;
        }
        /*���� weaponIndexToGoTo���� 0���� ���ų�
         allWeaponInPosesion.Count���̶� ���ų�
        currentWeaponIndex�� ������ �������� �ʴ´�.*/
        if (weaponIndexToGoTo < 0
            ||weaponIndexToGoTo == allWeaponInPossesion.Count
            ||weaponIndexToGoTo==currentWeaponIndex)
        {
            return;
        }
        //���� ���õ� ������ ��Ȱ��ȭ�� �ȴ�.
        //weaponslotUI[currentWeaponIndex].selectionWeapon.SetActive(false);
        //�ٲ� ������ Ȱ��ȭ�� �ȴ�.
        //weaponslotUI[weaponIndexToGoTo].selectionWeapon.SetActive(true);

        //currentWeapon�� allWeaponInPosesion�� �������� ������.
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
        //������ ���⽽���� ���� ��Ӱ� ���Ѵ�.
        weaponslotUI[currentWeaponIndex].WeaponImage.color = Color.gray;
        //���� ���õ� ���⽽���� ���� ��� ���Ѵ�.
        //weaponslotUI[weaponIndex].selectionWeapon.SetActive(true);
        weaponslotUI[weaponIndex].WeaponImage.color = Color.white;        
        //���� ���õ� ����� ���콺�� �� ���Ⱑ �ȴ�.
        currentWeapon = allWeaponInPossesion[weaponIndex];
        currentWeaponIndex = weaponIndex;
        PS.SetWeaponChange(currentWeaponIndex);
    }
}