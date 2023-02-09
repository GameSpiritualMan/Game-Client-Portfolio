using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusView : MonoBehaviour
{
    private PlayerController PController;   //PlayerController ��ũ��Ʈ�� ������ �������� ���� �����Ѵ�.
    private PlayerHUD PHUD;                 //PlayerHUD ��ũ��Ʈ�� ������ �������� ���� �����Ѵ�.
    private Text Status;                    //Text ������Ʈ�� ������ �������� ���� �����Ѵ�.
    // Start is called before the first frame update
    void Start()
    {
        PController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();    //PlayerController ��ũ��Ʈ�� ������ �Ѵ�.
        PHUD = GameObject.FindWithTag("Player").GetComponent<PlayerHUD>();                  //PlayerHUD ��ũ��Ʈ�� ������ �Ѵ�.
        Status=GetComponent<Text>();                                                        //Text������Ʈ�� ������ �Ѵ�.
    }

    // Update is called once per frame
    void Update()
    {
        //���� �� ������Ʈ�� �̸��� ���� ǥ�ð� �޶�����.
        switch (this.gameObject.name)
        {
            //�� ���ӿ�����Ʈ�� �̸��� Attack�̸�
            case "Attack":
                //������ ���� ����ϴ� ���� �޶�����.
                //�÷��̾ ��������̸�
                if (GameObject.Find("MagicKnight(Clone)"))
                {
                    /*��������� ���� ���ݷ�
                    ��ȭ�� : ���� ���� ���ݷ� �� ��ȭ�� : ���� ���� ���ݷ�*/
                    Status.text = "���� ���ݷ�\n��ȭ�� : " + PlayerPrefs.GetFloat("MagicKnightAttack" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.ATK.ToString();
                }
                //�÷��̾ �������̸�
                else if (GameObject.Find("Wizard(Clone)"))
                {
                    /*�������� ���� ���ݷ�
                    ��ȭ�� : ���� ���� ���ݷ� �� ��ȭ�� : ���� ���� ���ݷ�*/
                    Status.text = "���� ���ݷ�\n��ȭ�� : " + PlayerPrefs.GetFloat("WizardAttack" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.ATK.ToString();
                }
                //�÷��̾ �����̸�
                else if (GameObject.Find("Elf(Clone"))
                {
                    /*������ ���� ���ݷ�
                    ��ȭ�� : ���� ���� ���ݷ� �� ��ȭ�� : ���� ���� ���ݷ�*/
                    Status.text = "���� ���ݷ�\n��ȭ�� : " + PlayerPrefs.GetFloat("ElfAttack" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.ATK.ToString();
                }
                break;
            //�� ���ӿ�����Ʈ�� �̸��� MagicAttack�̸�
            case "MagicAttack":
                //������ ���� ����ϴ� ���� �޶�����.
                //�÷��̾ ��������̸�
                if (GameObject.Find("MagicKnight(Clone)"))
                {
                    /*��������� ���� ���ݷ�
                    ��ȭ�� : ���� ���� ���ݷ� �� ��ȭ�� : ���� ���� ���ݷ�*/
                    Status.text = "���� ���ݷ�\n��ȭ�� : " + PlayerPrefs.GetFloat("MagicKnightMagic" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.MATk.ToString();
                }
                //�÷��̾ �������̸�
                else if (GameObject.Find("Wizard(Clone)"))
                {
                    /*�������� ���� ���ݷ�
                    ��ȭ�� : ���� ���� ���ݷ� �� ��ȭ�� : ���� ���� ���ݷ�*/
                    Status.text = "���� ���ݷ�\n��ȭ�� : " + PlayerPrefs.GetFloat("WizardMagic" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.MATk.ToString();
                }
                //�÷��̾ �����̸�
                else if (GameObject.Find("Elf(Clone"))
                {
                    /*������ ���� ���ݷ�
                    ��ȭ�� : ���� ���� ���ݷ� �� ��ȭ�� : ���� ���� ���ݷ�*/
                    Status.text = "���� ���ݷ�\n��ȭ�� : " + PlayerPrefs.GetFloat("ElfMagic" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.MATk.ToString();
                }
                break;
            //�� ���ӿ�����Ʈ�� �̸��� MaxHP�̸�
            case "MaxHP":
                //������ ���� ����ϴ� ���� �޶�����.
                //�÷��̾ ��������̸�
                if (GameObject.Find("MagicKnight(Clone)"))
                {
                    /*��������� �ִ� HP
                    ��ȭ�� : ���� �ִ� HP �� ��ȭ�� : ���� �ִ� HP*/
                    Status.text = "�ִ� HP\n��ȭ�� : " + PlayerPrefs.GetFloat("MagicKnightMaxHP" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PHUD.MaxHealth.ToString();
                }
                //�÷��̾ �������̸�
                else if (GameObject.Find("Wizard(Clone)"))
                {
                    /*�������� �ִ� HP
                    ��ȭ�� : ���� �ִ� HP �� ��ȭ�� : ���� �ִ� HP*/
                    Status.text = "�ִ� HP\n��ȭ�� : " + PlayerPrefs.GetFloat("WizardMaxHP" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PHUD.MaxHealth.ToString();
                }
                //�÷��̾ �����̸�
                else if (GameObject.Find("Elf(Clone"))
                {
                    /*������ �ִ� HP
                    ��ȭ�� : ���� �ִ� HP �� ��ȭ�� : ���� �ִ� HP*/
                    Status.text = "�ִ� HP\n��ȭ�� : " + PlayerPrefs.GetFloat("ElfMaxHP" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PHUD.MaxHealth.ToString();
                }
                break;
            //�� ���ӿ�����Ʈ�� �̸��� MaxMP�̸�
            case "MaxMP":
                //������ ���� ����ϴ� ���� �޶�����.
                //�÷��̾ ��������̸�
                if (GameObject.Find("MagicKnight(Clone)"))
                {
                    /*��������� �ִ� MP
                    ��ȭ�� : ���� �ִ� MP �� ��ȭ�� : ���� �ִ� MP*/
                    Status.text = "�ִ� MP\n��ȭ�� : " + PlayerPrefs.GetFloat("MagicKnightMaxMP" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PHUD.MaxMana.ToString();
                }
                //�÷��̾ �������̸�
                else if (GameObject.Find("Wizard(Clone)"))
                {
                    /*�������� �ִ� MP
                    ��ȭ�� : ���� �ִ� MP �� ��ȭ�� : ���� �ִ� MP*/
                    Status.text = "�ִ� MP\n��ȭ�� : " + PlayerPrefs.GetFloat("WizardMaxMP" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PHUD.MaxMana.ToString();
                }
                //�÷��̾ �����̸�
                else if (GameObject.Find("Elf(Clone"))
                {
                    /*������ �ִ� MP
                    ��ȭ�� : ���� �ִ� MP �� ��ȭ�� : ���� �ִ� MP*/
                    Status.text = "�ִ� MP\n��ȭ�� : " + PlayerPrefs.GetFloat("ElfMaxMP" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PHUD.MaxMana.ToString();
                }
                break;
            //�� ���ӿ�����Ʈ�� �̸��� BurnDMG�̸�
            case "BurnDMG":
                //������ ���� ����ϴ� ���� �޶�����.
                //�÷��̾ ��������̸�
                if (GameObject.Find("MagicKnight(Clone)"))
                {
                    /*��������� ȭ����� ������
                    ��ȭ�� : ���� ȭ����� ������ �� ��ȭ�� : ���� ȭ����� ������*/
                    Status.text = "ȭ����� ������\n��ȭ�� : " + PlayerPrefs.GetFloat("MagicKnightFireDamage" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.BurnDMG.ToString();
                }
                //�÷��̾ �������̸�
                else if (GameObject.Find("Wizard(Clone)"))
                {
                    /*�������� ȭ����� ������
                    ��ȭ�� : ���� ȭ����� ������ �� ��ȭ�� : ���� ȭ����� ������*/
                    Status.text = "ȭ����� ������\n��ȭ�� : " + PlayerPrefs.GetFloat("WizardFireDamage" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.BurnDMG.ToString();
                }
                //�÷��̾ �����̸�
                else if (GameObject.Find("Elf(Clone"))
                {
                    /*������ ȭ����� ������
                    ��ȭ�� : ���� ȭ����� ������ �� ��ȭ�� : ���� ȭ����� ������*/
                    Status.text = "ȭ����� ������\n��ȭ�� : " + PlayerPrefs.GetFloat("ElfFireDamage" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.BurnDMG.ToString();
                }
                break;
            case "BurnTime":
                //������ ���� ����ϴ� ���� �޶�����.
                //�÷��̾ ��������̸�
                if (GameObject.Find("MagicKnight(Clone)"))
                {
                    /*��������� ȭ����� ���ӽð�
                    ��ȭ�� : ���� ȭ����� ���ӽð� �� ��ȭ�� : ���� ȭ����� ���ӽð�*/
                    Status.text = "ȭ����� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("MagicKnightFireKeep" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.BurnTime.ToString();
                }
                //�÷��̾ �������̸�
                else if (GameObject.Find("Wizard(Clone)"))
                {
                    /*�������� ȭ����� ���ӽð�
                    ��ȭ�� : ���� ȭ����� ���ӽð� �� ��ȭ�� : ���� ȭ����� ���ӽð�*/
                    Status.text = "ȭ����� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("WizardFireKeep" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.BurnTime.ToString();
                }
                //�÷��̾ �����̸�
                else if (GameObject.Find("Elf(Clone"))
                {
                    /*������ ȭ����� ���ӽð�
                    ��ȭ�� : ���� ȭ����� ���ӽð� �� ��ȭ�� : ���� ȭ����� ���ӽð�*/
                    Status.text = "ȭ����� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("ElfFireKeep" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.BurnTime.ToString();
                }
                break;
            case "FreezeTime":
                //������ ���� ����ϴ� ���� �޶�����.
                //�÷��̾ ��������̸�
                if (GameObject.Find("MagicKnight(Clone)"))
                {
                    /*��������� ������� ���ӽð�
                    ��ȭ�� : ���� ������� ���ӽð� �� ��ȭ�� : ���� ������� ���ӽð�*/
                    Status.text = "������� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("MagicKnightFreeze" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.Freeze.ToString();
                }
                //�÷��̾ �������̸�
                else if (GameObject.Find("Wizard(Clone)"))
                {
                    /*�������� ������� ���ӽð�
                    ��ȭ�� : ���� ������� ���ӽð� �� ��ȭ�� : ���� ������� ���ӽð�*/
                    Status.text = "������� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("WizardFreeze" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.Freeze.ToString();
                }
                //�÷��̾ �����̸�
                else if (GameObject.Find("Elf(Clone"))
                {
                    /*������ ������� ���ӽð�
                    ��ȭ�� : ���� ������� ���ӽð� �� ��ȭ�� : ���� ������� ���ӽð�*/
                    Status.text = "������� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("ElfFreeze" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.Freeze.ToString();
                }
                break;
            case "EShockTime":
                //������ ���� ����ϴ� ���� �޶�����.
                //�÷��̾ ��������̸�
                if (GameObject.Find("MagicKnight(Clone)"))
                {
                    /*��������� �������� ���ӽð�
                    ��ȭ�� : ���� �������� ���ӽð� �� ��ȭ�� : ���� �������� ���ӽð�*/
                    Status.text = "�������� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("MagicKnightElectric" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.EShock.ToString();
                }
                //�÷��̾ �������̸�
                else if (GameObject.Find("Wizard(Clone)"))
                {
                    /*�������� �������� ���ӽð�
                    ��ȭ�� : ���� �������� ���ӽð� �� ��ȭ�� : ���� �������� ���ӽð�*/
                    Status.text = "�������� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("WizardElectric" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.EShock.ToString();
                }
                //�÷��̾ �����̸�
                else if (GameObject.Find("Elf(Clone"))
                {
                    /*������ �������� ���ӽð�
                    ��ȭ�� : ���� �������� ���ӽð� �� ��ȭ�� : ���� �������� ���ӽð���*/
                    Status.text = "�������� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("ElftElectric" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.EShock.ToString();
                }
                break;
            case "FaintTime":
                //������ ���� ����ϴ� ���� �޶�����.
                //�÷��̾ ��������̸�
                if (GameObject.Find("MagicKnight(Clone)"))
                {
                    /*��������� �������� ���ӽð�
                    ��ȭ�� : ���� �������� ���ӽð� �� ��ȭ�� : ���� �������� ���ӽð�*/
                    Status.text = "ȭ����� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("MagicKnightFreeze" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.Faint.ToString();
                }
                //�÷��̾ �������̸�
                else if (GameObject.Find("Wizard(Clone)"))
                {
                    /*�������� �������� ���ӽð�
                    ��ȭ�� : ���� �������� ���ӽð� �� ��ȭ�� : ���� �������� ���ӽð�*/
                    Status.text = "ȭ����� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("WizardFreeze" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.Faint.ToString();
                }
                //�÷��̾ �����̸�
                else if (GameObject.Find("Elf(Clone"))
                {
                    /*������ �������� ���ӽð�
                    ��ȭ�� : ���� �������� ���ӽð� �� ��ȭ�� : ���� �������� ���ӽð�*/
                    Status.text = "ȭ����� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("ElfFreeze" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.Faint.ToString();
                }
                break;
            case "KnockBackPower":
                //������ ���� ����ϴ� ���� �޶�����.
                //�÷��̾ ��������̸�
                if (GameObject.Find("MagicKnight(Clone)"))
                {
                    /*��������� �˹����� �̴� ��
                    ��ȭ�� : ���� �˹����� �̴� �� �� ��ȭ�� : ���� �˹����� �̴� ��*/
                    Status.text = "ȭ����� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("MagicKnightFreeze" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.KnockBack.ToString();
                }
                //�÷��̾ �������̸�
                else if (GameObject.Find("Wizard(Clone)"))
                {
                    /*�������� �˹����� �̴� ��
                    ��ȭ�� : ���� �˹����� �̴� �� �� ��ȭ�� : ���� �˹����� �̴� ��*/
                    Status.text = "ȭ����� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("WizardFreeze" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.KnockBack.ToString();
                }
                //�÷��̾ �����̸�
                else if (GameObject.Find("Elf(Clone"))
                {
                    /*������ �˹����� �̴� ��
                    ��ȭ�� : ���� �˹����� �̴� �� �� ��ȭ�� : ���� �˹����� �̴� ��*/
                    Status.text = "ȭ����� ���ӽð�\n��ȭ�� : " + PlayerPrefs.GetFloat("ElfFreeze" + SaveID.saveID).ToString() + " �� ��ȭ�� : " + PController.KnockBack.ToString();
                }
                break;
        }
    }
}
