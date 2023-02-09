using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //�޴�â
    public GameObject MenuSet;
    //�������ͽ�
    public GameObject Status;

    public Text Attack;                        //�Ѿ� ���ݷ��� ǥ���ϱ����� ����
    public Text MagicAttack;                   //���� ���ݷ��� ǥ���ϱ� ���� ����
    public Text MaxHP;                         //�ִ� HP�� ǥ���ϱ� ���� ����
    public Text MaxMP;                         //�ִ� MP�� ǥ���ϱ� ���� ����
    public Text BurnDMG;                       //ȭ����� �������� ǥ���ϱ� ���� �����Ѵ�.
    public Text BurnTime;                      //ȭ����� ���ӽð��� ǥ���ϱ� ���� �����Ѵ�.
    public Text FreezeTime;                    //������� ���ӽð��� ǥ���ϱ� ���� �����Ѵ�.
    public Text EShockTime;                    //�������� ���ӽð��� ǥ���ϱ� ���� �����Ѵ�.
    public Text FaintTime;                     //�������� ���ӽð��� ǥ���ϱ� ���� �����Ѵ�.
    public Text KnockBackPower;                //�˹����� �о�� ���� ǥ���ϱ� ���� �����Ѵ�.

    private PlayerController PController;       //PlayerController������Ʈ�� ������ �ϱ� ���� ����
    private PlayerHUD PHUD;                     //PlayerHUD������Ʈ�� ������ �ϱ� ���� ����

    //�������ͽ��� Ȱ��ȭ �ǵ� ǥ�õǴ� ���� �����ϱ� ���� �����Ѵ�.
    public GameObject Minimap;
    public GameObject AttackText;
    public GameObject StatusButton;

    void Awake()
    {
        //��� ������Ʈ���� �����δ�.
        Time.timeScale = 1;        
    }

    void Update()
    {
        //EscŰ�� ��������
        if (Input.GetButtonDown("Cancel"))
        {
            MenuActive();
        }        
    }

    //�������ͽ� â
    public void StatusActive()
    {
        //��Ȱ��ȭ�� �Ǿ� ������
        if (Status.activeSelf == false)
        {
            //Ȱ��ȭ �Ѵ�.
            Status.SetActive(true);
            //��� ������Ʈ���� �������� �ʴ´�.
            Time.timeScale = 0;

            //Player�±׸� ���� ������Ʈ�� PlayerContorller������Ʈ�� �����Ѵ�.
            PController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
            //Player�±׸� ���� ������Ʈ�� PlayerHUD������Ʈ�� �����Ѵ�.
            PHUD = GameObject.FindWithTag("Player").GetComponent<PlayerHUD>();

            //Canvas�� 4��° ���� ������Ʈ�� Attack�� Text������Ʈ�� �����Ѵ�.
            Attack = GameObject.Find("Canvas").transform.Find("StatusPanel").transform.Find("ScrollRect").transform.Find("Contents").transform.Find("Attack").GetComponent<Text>();
            //Canvas�� 4��° ���� ������Ʈ�� MagicAttack�� Text������Ʈ�� �����Ѵ�.
            MagicAttack = GameObject.Find("Canvas").transform.Find("StatusPanel").transform.Find("ScrollRect").transform.Find("Contents").transform.Find("MagicAttack").GetComponent<Text>();
            //Canvas�� 4��° ���� ������Ʈ�� MaxHP�� Text������Ʈ�� �����Ѵ�.
            MaxHP = GameObject.Find("Canvas").transform.Find("StatusPanel").transform.Find("ScrollRect").transform.Find("Contents").transform.Find("MaxHP").GetComponent<Text>();
            //Canvas�� 4��° ���� ������Ʈ�� MaxMP�� Text������Ʈ�� �����Ѵ�.
            MaxMP = GameObject.Find("Canvas").transform.Find("StatusPanel").transform.Find("ScrollRect").transform.Find("Contents").transform.Find("MaxMP").GetComponent<Text>();
            //Canvas�� 4��° ���� ������Ʈ�� BurnDMG�� Text������Ʈ�� �����Ѵ�.
            BurnDMG = GameObject.Find("Canvas").transform.Find("StatusPanel").transform.Find("ScrollRect").transform.Find("Contents").transform.Find("BurnDMG").GetComponent<Text>();
            //Canvas�� 4��° ���� ������Ʈ�� BurnTime�� Text������Ʈ�� �����Ѵ�.
            BurnTime = GameObject.Find("Canvas").transform.Find("StatusPanel").transform.Find("ScrollRect").transform.Find("Contents").transform.Find("BurnTime").GetComponent<Text>();
            //Canvas�� 4��° ���� ������Ʈ�� FreezeTime�� Text������Ʈ�� �����Ѵ�.
            FreezeTime = GameObject.Find("Canvas").transform.Find("StatusPanel").transform.Find("ScrollRect").transform.Find("Contents").transform.Find("FreezeTime").GetComponent<Text>();
            //Canvas�� 4��° ���� ������Ʈ�� EShockTime�� Text������Ʈ�� �����Ѵ�.
            EShockTime = GameObject.Find("Canvas").transform.Find("StatusPanel").transform.Find("ScrollRect").transform.Find("Contents").transform.Find("EShockTime").GetComponent<Text>();
            //Canvas�� 4��° ���� ������Ʈ�� FaintTime�� Text������Ʈ�� �����Ѵ�.
            FaintTime = GameObject.Find("Canvas").transform.Find("StatusPanel").transform.Find("ScrollRect").transform.Find("Contents").transform.Find("FaintTime").GetComponent<Text>();
            //Canvas�� 4��° ���� ������Ʈ�� KnockBackPower�� Text������Ʈ�� �����Ѵ�.
            KnockBackPower = GameObject.Find("Canvas").transform.Find("StatusPanel").transform.Find("ScrollRect").transform.Find("Contents").transform.Find("KnockBackPower").GetComponent<Text>();

            /*�÷��̾��� ĳ���Ϳ� ���� ����ϴ� ���� �޶�����.*/
            //�÷��̾��� ĳ���Ͱ� ��������̸�
            if (GameObject.Find("MagicKnight(Clone)"))
            {
                //����� ������� X�� ��ǥ�� ������ �����Ѵ�.
                if (PlayerPrefs.HasKey("MagicKnightX" + SaveID.saveID))
                {
                    /*��������� ���� ���ݷ�
                    ��ȭ�� : ���� ���� ���ݷ� �� ��ȭ�� : ���� ���� ���ݷ�*/
                    Attack.text = "���� ���ݷ�\n��ȭ�� : " + PlayerPrefs.GetFloat("MagicKnightAttack" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.ATK.ToString();
                    /*��������� ���� ���ݷ�
                    ��ȭ�� : ���� ���� ���ݷ� �� ��ȭ�� : ���� ���� ���ݷ�*/
                    MagicAttack.text = "���� ���ݷ�\n��ȭ�� : " + PlayerPrefs.GetFloat("MagicKnightMagic" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.MATk.ToString();
                    /*��������� �ִ�HP
                    ��ȭ�� : ���� �ִ� HP �� ��ȭ�� : ���� �ִ� HP*/
                    MaxHP.text = "�ִ� HP\n��ȭ�� : " + PlayerPrefs.GetFloat("MagicKnightMaxHP" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PHUD.MaxHealth.ToString();
                    /*��������� �ִ�MP
                    ��ȭ�� : ���� �ִ� MP �� ��ȭ�� : ���� �ִ� MP*/
                    MaxMP.text = "�ִ� MP\n��ȭ�� : " + PlayerPrefs.GetFloat("MagicKnightMaxMP" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PHUD.MaxMana.ToString();
                    /*��������� ȭ����� ������
                    ��ȭ�� : ���� ȭ����� ������ �� ��ȭ�� : ���� ȭ����� ������*/
                    BurnDMG.text = "ȭ����� ������\n��ȭ�� : " + PlayerPrefs.GetFloat("MagicKnightFireDamage" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.BurnDMG.ToString();
                    /*��������� ȭ����� ���ӽð�
                    ��ȭ�� : ���� ȭ����� ���ӽð� �� ��ȭ�� : ���� ȭ����� ���ӽð�*/
                    BurnTime.text = "ȭ����� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("MagicKnightFireKeep" + SaveID.saveID).ToString() + "�� �� ��ȭ�� : " + PController.BurnTime.ToString() + "��";
                    /*��������� ������� ���ӽð�
                    ��ȭ�� : ���� ������� ���ӽð� �� ��ȭ�� : ���� ������� ���ӽð�*/
                    FreezeTime.text = "������� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("MagicKnightFreeze" + SaveID.saveID).ToString() + "�� �� ��ȭ�� : " + PController.Freeze.ToString() + "��";
                    /*��������� �������� ���ӽð�
                    ��ȭ�� : ���� �������� ���ӽð� �� ��ȭ�� : ���� �������� ���ӽð�*/
                    EShockTime.text = "�������� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("MagicKnightElectric" + SaveID.saveID).ToString() + "�� �� ��ȭ�� : " + PController.EShock.ToString() + "��";
                    /*��������� �������� ���ӽð�
                    ��ȭ�� : ���� �������� ���ӽð� �� ��ȭ�� : ���� �������� ���ӽð�*/
                    FaintTime.text = "�������� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("MagicKnightFaint" + SaveID.saveID).ToString() + "�� ��ȭ�� : " + PController.Faint.ToString() + "��";
                    /*��������� �˹����� �̴� ��
                    ��ȭ�� : ���� �˹����� �̴� �� �� ��ȭ�� : ���� �˹����� �̴� ��*/
                    KnockBackPower.text = "�˹����� �̴� ��\n��ȭ�� : " + PlayerPrefs.GetFloat("MagicKnightKnockBack" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.KnockBack.ToString();
                }
                //������� X�� ��ǥ�� ������ �����Ѵ�.
                else
                {
                    /*��������� ���� ���ݷ� : ���� ���� ���ݷ�*/
                    Attack.text = "���� ���ݷ� : " + PController.ATK.ToString();
                    /*��������� ���� ���ݷ� : ���� ���� ���ݷ�*/
                    MagicAttack.text = "���� ���ݷ� : " + PController.MATk.ToString();
                    /*��������� �ִ�HP : ���� �ִ� HP*/
                    MaxHP.text = "�ִ� HP : " + PHUD.MaxHealth.ToString();
                    /*��������� �ִ�MP : ���� �ִ� MP*/
                    MaxMP.text = "�ִ� MP : " + PHUD.MaxMana.ToString();
                    /*��������� ȭ����� ������ : ���� ȭ����� ������*/
                    BurnDMG.text = "ȭ����� ������ : " + PController.BurnDMG.ToString();
                    /*��������� ȭ����� ���ӽð� : ���� ȭ����� ���ӽð�*/
                    BurnTime.text = "ȭ����� ���ӽð� : " + PController.BurnTime.ToString() + "��";
                    /*��������� ������� ���ӽð� : ���� ������� ���ӽð�*/
                    FreezeTime.text = "������� ���ӽð� : " + PController.Freeze.ToString() + "��";
                    /*��������� �������� ���ӽð� : ���� �������� ���ӽð�*/
                    EShockTime.text = "�������� ���ӽð� : " + PController.EShock.ToString() + "��";
                    /*��������� �������� ���ӽð� : ���� �������� ���ӽð�*/
                    FaintTime.text = "�������� ���ӽð� : " + PController.Faint.ToString() + "��";
                    /*��������� �˹����� �̴� �� : ���� �˹����� �̴� ��*/
                    KnockBackPower.text = "�˹����� �̴� �� : " + PController.KnockBack.ToString();
                }
            }
            //�÷��̾��� ĳ���Ͱ� �������̸�
            else if (GameObject.Find("Wizard(Clone)"))
            {
                //����� �������� X�� ��ǥ�� ������ �����Ѵ�.
                if (PlayerPrefs.HasKey("WizardX" + SaveID.saveID))
                {
                    /*�������� ���� ���ݷ�
                    ��ȭ�� : ���� ���� ���ݷ� �� ��ȭ�� : ���� ���� ���ݷ�*/
                    Attack.text = "���� ���ݷ�\n��ȭ�� : " + PlayerPrefs.GetFloat("WizardAttack" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.ATK.ToString();
                    /*�������� ���� ���ݷ�
                    ��ȭ�� : ���� ���� ���ݷ� �� ��ȭ�� : ���� ���� ���ݷ�*/
                    MagicAttack.text = "���� ���ݷ�\n��ȭ�� : " + PlayerPrefs.GetFloat("WizardMagic" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.MATk.ToString();
                    /*�������� �ִ�HP
                    ��ȭ�� : ���� �ִ� HP �� ��ȭ�� : ���� �ִ� HP*/
                    MaxHP.text = "�ִ� HP\n��ȭ�� : " + PlayerPrefs.GetFloat("WizardMaxHP" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PHUD.MaxHealth.ToString();
                    /*�������� �ִ�MP
                    ��ȭ�� : ���� �ִ� MP �� ��ȭ�� : ���� �ִ� MP*/
                    MaxMP.text = "�ִ� MP\n��ȭ�� : " + PlayerPrefs.GetFloat("WizardMaxMP" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PHUD.MaxMana.ToString();
                    /*�������� ȭ����� ������
                    ��ȭ�� : ���� ȭ����� ������ �� ��ȭ�� : ���� ȭ����� ������*/
                    BurnDMG.text = "ȭ����� ������\n��ȭ�� : " + PlayerPrefs.GetFloat("WizardFireDamage" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.BurnDMG.ToString();
                    /*�������� ȭ����� ���ӽð�
                    ��ȭ�� : ���� ȭ����� ���ӽð� �� ��ȭ�� : ���� ȭ����� ���ӽð�*/
                    BurnTime.text = "ȭ����� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("WizardFireKeep" + SaveID.saveID).ToString() + "�� �� ��ȭ�� : " + PController.BurnTime.ToString() + "��";
                    /*�������� ������� ���ӽð�
                    ��ȭ�� : ���� ������� ���ӽð� �� ��ȭ�� : ���� ������� ���ӽð�*/
                    FreezeTime.text = "������� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("WizardFreeze" + SaveID.saveID).ToString() + "�� �� ��ȭ�� : " + PController.Freeze.ToString() + "��";
                    /*�������� �������� ���ӽð�
                    ��ȭ�� : ���� �������� ���ӽð� �� ��ȭ�� : ���� �������� ���ӽð�*/
                    EShockTime.text = "�������� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("WizardElectric" + SaveID.saveID).ToString() + "�� �� ��ȭ�� : " + PController.EShock.ToString() + "��";
                    /*�������� �������� ���ӽð�
                    ��ȭ�� : ���� �������� ���ӽð� �� ��ȭ�� : ���� �������� ���ӽð�*/
                    FaintTime.text = "�������� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("WizardFaint" + SaveID.saveID).ToString() + "�� ��ȭ�� : " + PController.Faint.ToString() + "��";
                    /*�������� �˹����� �̴� ��
                    ��ȭ�� : ���� �˹����� �̴� �� �� ��ȭ�� : ���� �˹����� �̴� ��*/
                    KnockBackPower.text = "�˹����� �̴� ��\n��ȭ�� : " + PlayerPrefs.GetFloat("WizardKnockBack" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.KnockBack.ToString() + "��";
                }
                //����� �������� X�� ��ǥ�� ������ �����Ѵ�.
                else
                {
                    /*�������� ���� ���ݷ� : ���� ���� ���ݷ�*/
                    Attack.text = "���� ���ݷ� : " + PController.ATK.ToString();
                    /*�������� ���� ���ݷ� : ���� ���� ���ݷ�*/
                    MagicAttack.text = "���� ���ݷ� : " + PController.MATk.ToString();
                    /*�������� �ִ�HP : ���� �ִ� HP*/
                    MaxHP.text = "�ִ� HP : " + PHUD.MaxHealth.ToString();
                    /*�������� �ִ�MP : ���� �ִ� MP*/
                    MaxMP.text = "�ִ� MP : " + PHUD.MaxMana.ToString();
                    /*�������� ȭ����� ������ : ���� ȭ����� ������*/
                    BurnDMG.text = "ȭ����� ������ : " + PController.BurnDMG.ToString();
                    /*�������� ȭ����� ���ӽð� : ���� ȭ����� ���ӽð�*/
                    BurnTime.text = "ȭ����� ���ӽð� : " + PController.BurnTime.ToString() + "��";
                    /*�������� ������� ���ӽð� : ���� ������� ���ӽð�*/
                    FreezeTime.text = "������� ���ӽð� : " + PController.Freeze.ToString() + "��";
                    /*�������� �������� ���ӽð� : ���� �������� ���ӽð�*/
                    EShockTime.text = "�������� ���ӽð� : " + PController.EShock.ToString() + "��";
                    /*�������� �������� ���ӽð� : ���� �������� ���ӽð�*/
                    FaintTime.text = "�������� ���ӽð� : " + PController.Faint.ToString() + "��";
                    /*�������� �˹����� �̴� �� : ���� �˹����� �̴� ��*/
                    KnockBackPower.text = "�˹����� �̴� �� : " + PController.KnockBack.ToString();
                }
            }
            //�÷��̾��� ĳ���Ͱ� �����̸�
            else if (GameObject.Find("Elf(Clone)"))
            {
                //����� ������ X�� ��ǥ�� �����ϸ� �����Ѵ�.
                if (PlayerPrefs.HasKey("ElfX" + SaveID.saveID))
                {
                    /*������ ���� ���ݷ�
                    ��ȭ�� : ���� ���� ���ݷ� �� ��ȭ�� : ���� ���� ���ݷ�*/
                    Attack.text = "���� ���ݷ�\n��ȭ�� : " + PlayerPrefs.GetFloat("ElfAttack" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.ATK.ToString();
                    /*������ ���� ���ݷ�
                    ��ȭ�� : ���� ���� ���ݷ� �� ��ȭ�� : ���� ���� ���ݷ�*/
                    MagicAttack.text = "���� ���ݷ�\n��ȭ�� : " + PlayerPrefs.GetFloat("ElfMagic" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.MATk.ToString();
                    /*������ �ִ�HP
                    ��ȭ�� : ���� �ִ� HP �� ��ȭ�� : ���� �ִ� HP*/
                    MaxHP.text = "�ִ� HP\n��ȭ�� : " + PlayerPrefs.GetFloat("ElfMaxHP" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PHUD.MaxHealth.ToString();
                    /*������ �ִ�MP
                    ��ȭ�� : ���� �ִ� MP �� ��ȭ�� : ���� �ִ� MP*/
                    MaxMP.text = "�ִ� MP\n��ȭ�� : " + PlayerPrefs.GetFloat("ElfMaxMP" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PHUD.MaxMana.ToString();
                    /*������ ȭ����� ������
                    ��ȭ�� : ���� ȭ����� ������ �� ��ȭ�� : ���� ȭ����� ������*/
                    BurnDMG.text = "ȭ����� ������\n��ȭ�� : " + PlayerPrefs.GetFloat("ElfFireDamage" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.BurnDMG.ToString();
                    /*������ ȭ����� ���ӽð�
                    ��ȭ�� : ���� ȭ����� ���ӽð� �� ��ȭ�� : ���� ȭ����� ���ӽð�*/
                    BurnTime.text = "ȭ����� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("ElfFireKeep" + SaveID.saveID).ToString() + "�� �� ��ȭ�� : " + PController.BurnTime.ToString() + "��";
                    /*������ ������� ���ӽð�
                    ��ȭ�� : ���� ������� ���ӽð� �� ��ȭ�� : ���� ������� ���ӽð�*/
                    FreezeTime.text = "������� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("ElfFreeze" + SaveID.saveID).ToString() + "�� �� ��ȭ�� : " + PController.Freeze.ToString() + "��";
                    /*������ �������� ���ӽð�
                    ��ȭ�� : ���� �������� ���ӽð� �� ��ȭ�� : ���� �������� ���ӽð�*/
                    EShockTime.text = "�������� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("ElftElectric" + SaveID.saveID).ToString() + "�� �� ��ȭ�� : " + PController.EShock.ToString() + "��";
                    /*������ �������� ���ӽð�
                    ��ȭ�� : ���� �������� ���ӽð� �� ��ȭ�� : ���� �������� ���ӽð�*/
                    FaintTime.text = "�������� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("ElfFaint" + SaveID.saveID).ToString() + "�� �� ��ȭ�� : " + PController.Faint.ToString() + "��";
                    /*������ �˹����� �̴� ��
                    ��ȭ�� : ���� �˹����� �̴� �� �� ��ȭ�� : ���� �˹����� �̴� ��*/
                    KnockBackPower.text = "�˹����� �̴� ��\n��ȭ�� : " + PlayerPrefs.GetFloat("ElfKnockBack" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.KnockBack.ToString();
                }
                //����� ������ X�� ��ǥ�� �������� ������ �����Ѵ�.
                else
                {
                    /*������ ���� ���ݷ� : ���� ���� ���ݷ�*/
                    Attack.text = "���� ���ݷ� : " + PController.ATK.ToString();
                    /*������ ���� ���ݷ� : ���� ���� ���ݷ�*/
                    MagicAttack.text = "���� ���ݷ� : " + PController.MATk.ToString();
                    /*������ �ִ�HP : ���� �ִ� HP*/
                    MaxHP.text = "�ִ� HP : " + PHUD.MaxHealth.ToString();
                    /*������ �ִ�MP : ���� �ִ� MP*/
                    MaxMP.text = "�ִ� MP : " + PHUD.MaxMana.ToString();
                    /*������ ȭ����� ������ : ���� ȭ����� ������*/
                    BurnDMG.text = "ȭ����� ������ : " + PController.BurnDMG.ToString();
                    /*������ ȭ����� ���ӽð� : ���� ȭ����� ���ӽð�*/
                    BurnTime.text = "ȭ����� ���ӽð� : " + PController.BurnTime.ToString() + "��";
                    /*������ ������� ���ӽð� : ���� ������� ���ӽð�*/
                    FreezeTime.text = "������� ���ӽð� : " + PController.Freeze.ToString() + "��";
                    /*������ �������� ���ӽð� : ���� �������� ���ӽð�*/
                    EShockTime.text = "�������� ���ӽð� : " + PController.EShock.ToString() + "��";
                    /*������ �������� ���ӽð� : ���� �������� ���ӽð�*/
                    FaintTime.text = "�������� ���ӽð� : " + PController.Faint.ToString() + "��";
                    /*������ �˹����� �̴� �� : ���� �˹����� �̴� ��*/
                    KnockBackPower.text = "�˹����� �̴� �� : " + PController.KnockBack.ToString();
                }
            }

            Minimap.SetActive(false);
            AttackText.SetActive(false);
            StatusButton.SetActive(false);
        }
        //Ȱ��ȭ�� �Ǿ� ������
        else
        {
            //��Ȱ��ȭ �Ѵ�.
            Status.SetActive(false);
            //��� ������Ʈ���� �����δ�.
            Time.timeScale = 1;
            Minimap.SetActive(true);
            AttackText.SetActive(true);
            StatusButton.SetActive(true);
        }
    }

    //�޴�â
    public void MenuActive()
    {
        //��Ȱ��ȭ�� �Ǿ� ������
        if (MenuSet.activeSelf==false)
        {
            //Ȱ��ȭ �Ѵ�.
            MenuSet.SetActive(true);
            //��� ������Ʈ���� �������� �ʴ´�.
            Time.timeScale = 0;

            //�̴ϸ��� ��Ȱ��ȭ ��Ų��.
            Minimap.SetActive(false);
            //���ݷ� ǥ��â�� ��Ȱ��ȭ ��Ų��.
            AttackText.SetActive(false);
            //�������ͽ� ǥ�� ��ư�� ��Ȱ��ȭ ��Ų��.
            StatusButton.SetActive(false);
        }
        //Ȱ��ȭ�� �Ǿ� ������
        else
        {
            //��Ȱ��ȭ �Ѵ�.
            MenuSet.SetActive(false);
            //��� ������Ʈ���� �����δ�.
            Time.timeScale = 1;

            //�̴ϸ��� Ȱ��ȭ ��Ų��.
            Minimap.SetActive(true);
            //���ݷ� ǥ��â�� Ȱ��ȭ ��Ų��.
            AttackText.SetActive(true);
            //�������ͽ� ǥ�� ��ư�� Ȱ��ȭ ��Ų��.
            StatusButton.SetActive(true);
        }
    }

    public void GameExit()
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
        Debug.Log("�ش罽�Կ� ����� ����Ǿ����ϴ�.");
        SceneManager.LoadScene("Main");
    }

    public void SceneMove(string SceneName)
    {
        //SceneName�̸��� ������ �̵��Ѵ�.
        SceneManager.LoadScene(SceneName);
    }

    public void QuitGame()
    {
        //������ �����Ѵ�.
        Application.Quit();
    }
}