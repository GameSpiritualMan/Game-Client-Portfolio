using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{    
    public GameObject[] newGameButton;
    public GameObject[] loadGameButton;

    public int[] saveIds;
    public Text[] Status;

    private int saveNum;

    //�÷��̾� ������ �������� ���� �����Ѵ�.
    private GameObject Player;

    private void Start()
    {
        //�÷��̾� ������ �������� ���� �ʱ�ȭ �Ѵ�.
        Player = GameObject.FindWithTag("Player");

        saveNum = SaveID.saveID;
    }

    void Update()
    {
        /*
        * ���� �� ��� ���� �����Ͱ� ���̵���
        * for���� ����Ѵ�.
        */
        for (int i = 0; i < saveIds.Length; i++)
        {
            SaveSlot(i);
        }
    }

    //�����ϱ� ��ư�� ������ �����Ѵ�.
    public void NewGame()
    {
        //PlayExplain1������ �̵��Ѵ�.
        SceneManager.LoadScene("PlayExplain1");
    }    

    //�̾��ϱ� ��ư�� ������ �����Ѵ�.
    public void LoadGame()
    {
        //LoadSaved���°� true�϶�
        if (PlayerPrefs.GetInt("LoadSaved" + SaveID.saveID) == 1)
        {
            if(PlayerPrefs.HasKey("MagicKnightX" + SaveID.saveID))
            {
                DataManager.instance.currentCharacter = Character.MagicKnight;
            }
            else if (PlayerPrefs.HasKey("WizardX" + SaveID.saveID))
            {
                DataManager.instance.currentCharacter = Character.Wizard;
            }
            else if (PlayerPrefs.HasKey("ElfX" + SaveID.saveID))
            {
                DataManager.instance.currentCharacter = Character.Elf;
            }
            //�ҷ��ö� ����� SaveScene ������ �ҷ��� �ش� �̸��� ���� ������ �ε��Ѵ�.
            SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene" + SaveID.saveID));
            Debug.Log("����� ��ġ�� �ҷ��Խ��ϴ�.");
        }
        //�׷��� ������
        else
        {
            //������ �����Ѵ�.
            return;
        }
    }

    public void SetSaveID(int saveID)
    {
        SaveID.saveID = saveID;
    }

    public void ClearSave(int saveID)
    {
        //������� X�� ��ǥ�����Ͱ� ����Ǿ� ������
        if (PlayerPrefs.HasKey("MagicKnightX" + saveID))
        {
            //�ش罽�Կ� ��������� X�� ��ǥ�� �����Ѵ�.
            PlayerPrefs.DeleteKey("MagicKnightX" + saveID);

            //�ش罽�Կ� ��������� Y�� ��ǥ�� �����Ѵ�.
            PlayerPrefs.DeleteKey("MagicKnightY" + saveID);

            //�ش罽�Կ� ��������� ���� ���� ���ݷ� �����Ѵ�.
            PlayerPrefs.DeleteKey("MagicKnightAttack" + saveID);

            //�ش罽�Կ� ��������� ���� ���� ���ݷ� �����Ѵ�.
            PlayerPrefs.DeleteKey("MagicKnightMagic" + saveID);

            //�ش罽�Կ� ��������� �ִ� HP ���� �����Ѵ�.
            PlayerPrefs.DeleteKey("MagicKnightMaxHP" + saveID);

            //�ش罽�Կ� ��������� �ִ� MP ���� �����Ѵ�.
            PlayerPrefs.DeleteKey("MagicKnightMaxMP" + saveID);
            
            //�ش罽�Կ� ��������� ���� HP�� �����Ѵ�.
            PlayerPrefs.DeleteKey("MagicKnightCurHPStrength" + saveID);

            //�ش罽�Կ� ��������� ���� MP�� �����Ѵ�.
            PlayerPrefs.DeleteKey("MagicKnightCurMPStrength" + saveID);

            //�ش罽�Կ� ��������� ȭ����� �������� �����Ѵ�.
            PlayerPrefs.DeleteKey("MagicKnightFireDamage" + saveID);
            
            //�ش罽�Կ� ��������� ȭ����� ���ӽð��� �����Ѵ�.
            PlayerPrefs.DeleteKey("MagicKnightFireKeep" + saveID);
            
            //�ش罽�Կ� ��������� ������� ���ӽð��� �����Ѵ�.
            PlayerPrefs.DeleteKey("MagicKnightFreeze" + saveID);
            
            //�ش罽�Կ� ��������� �������� ���ӽð��� �����Ѵ�.
            PlayerPrefs.DeleteKey("MagicKnightElectric" + saveID);
            
            //�ش罽�Կ� ��������� �������� ���ӽð��� �����Ѵ�.
            PlayerPrefs.DeleteKey("MagicKnightFaint" + saveID);
            
            //�ش罽�Կ� ��������� �˹����� �о�� ���� �����Ѵ�.
            PlayerPrefs.DeleteKey("MagicKnightKnockBack" + saveID);
        }
        else if (PlayerPrefs.HasKey("WizardX" + saveID))
        {
            //���罽�Կ� �������� X�� ��ǥ�� �����Ѵ�.
            PlayerPrefs.DeleteKey("WizardX" + saveID);

            //�ش罽�Կ� �������� Y�� ��ǥ�� �����Ѵ�.
            PlayerPrefs.DeleteKey("WizardY" + saveID);

            //�ش罽�Կ� �������� ���� ���� ���ݷ��� �����Ѵ�.
            PlayerPrefs.DeleteKey("WizardAttack" + saveID);

            //�ش罽�Կ� �������� ���� ���� ���ݷ��� �����Ѵ�.
            PlayerPrefs.DeleteKey("WizardMagic" + saveID);
            
            //�ش罽�Կ� �������� �ִ� HP�� �����Ѵ�.
            PlayerPrefs.DeleteKey("WizardMaxHP" + saveID);

            //�ش罽�Կ� �������� �ִ� MP�� �����Ѵ�.
            PlayerPrefs.DeleteKey("WizardMaxMP" + saveID);
            
            //�ش罽�Կ� �������� ���� HP�� �����Ѵ�.
            PlayerPrefs.DeleteKey("WizardCurHPStrength" + saveID);

            //�ش罽�Կ� �������� ���� MP�� �����Ѵ�.
            PlayerPrefs.DeleteKey("WizardCurMPStrength" + saveID);

            //�ش罽�Կ� �������� ȭ����� �������� �����Ѵ�.
            PlayerPrefs.DeleteKey("WizardFireDamage" + saveID);
            
            //�ش罽�Կ� �������� ȭ����� ���ӽð��� �����Ѵ�.
            PlayerPrefs.DeleteKey("WizardFireKeep" + saveID);
            
            //�ش罽�Կ� �������� ������� ���ӽð��� �����Ѵ�.
            PlayerPrefs.DeleteKey("WizardFreeze" + saveID);
            
            //�ش罽�Կ� �������� �������� ���ӽð��� �����Ѵ�.
            PlayerPrefs.DeleteKey("WizardElectric" + saveID);
            
            //�ش罽�Կ� �������� �������� ���ӽð��� �����Ѵ�.
            PlayerPrefs.DeleteKey("WizardFaint" + saveID);
            
            //�ش罽�Կ� �������� �˹����� �о�� ���� �����Ѵ�.
            PlayerPrefs.DeleteKey("WizardKnockBack" + saveID);
        }
        else if(PlayerPrefs.HasKey("ElfX" + saveID))
        {
            //�ش罽�Կ� ������ X�� ��ǥ�� �����Ѵ�.
            PlayerPrefs.DeleteKey("ElfX" + saveID);

            //�ش罽�Կ� ������ Y�� ��ǥ�� �����Ѵ�.
            PlayerPrefs.DeleteKey("ElfY" + saveID);

            //�ش罽�Կ� ������ ���� ���� ���ݷ��� �����Ѵ�.
            PlayerPrefs.DeleteKey("ElfAttack" + saveID);

            //�ش罽�Կ� ������ ���� ���� ���ݷ��� �����Ѵ�.
            PlayerPrefs.DeleteKey("ElfMagic" + saveID);
            
            //�ش罽�Կ� ������ �ִ� HP�� �����Ѵ�.
            PlayerPrefs.DeleteKey("ElfMaxHP" + saveID);

            //�ش�ַԿ� ������ �ִ� MP�� �����Ѵ�.
            PlayerPrefs.DeleteKey("ElfMaxMP" + saveID);
            
            //�ش罽�Կ� ������ ���� HP�� �����Ѵ�.
            PlayerPrefs.DeleteKey("ElfCurHPStrength" + saveID);

            //�ش罽�Կ� ������ ���� MP�� �����Ѵ�.
            PlayerPrefs.DeleteKey("ElfCurMPStrength" + saveID);

            //�ش罽�Կ� ������ ȭ����� �������� �����Ѵ�.
            PlayerPrefs.DeleteKey("ElfFireDamage" + saveID);
            
            //�ش罽�Կ� ������ ȭ����� ���ӽð��� �����Ѵ�.
            PlayerPrefs.DeleteKey("ElfFireKeep" + saveID);
            
            //�ش罽�Կ� ������ ������� ���ӽð��� �����Ѵ�.
            PlayerPrefs.DeleteKey("ElfFreeze" + saveID);
            
            //�ش罽�Կ� ������ �������� ���ӽð��� �����Ѵ�.
            PlayerPrefs.DeleteKey("ElftElectric" + saveID);
            
            //�ش罽�Կ� ������ �������� ���ӽð��� �����Ѵ�.
            PlayerPrefs.DeleteKey("ElfFaint" + saveID);
            
            //�ش罽�Կ� ������ �˹����� �о�� ���� �����Ѵ�.
            PlayerPrefs.DeleteKey("ElfKnockBack" + saveID);
        }
        PlayerPrefs.DeleteKey("LoadScene" + saveID);
        PlayerPrefs.DeleteKey("SlotSaved" + saveID);
        PlayerPrefs.DeleteKey("SavedScene" + saveID);
    }

    private void SaveSlot(int SaveNum)
    {
        //SaveNUm�� saveIds ������ ũ�� ������
        if(SaveNum <= saveIds.Length)
        {
            //SlotSaved�����͸� �ҷ��ö� Ȱ��ȭ�� �Ǿ� ������
            if (PlayerPrefs.GetInt("SlotSaved" + saveIds[SaveNum]) == 1)
            {
                //i��° �ҷ����� ��ư�� Ȱ��ȭ�Ѵ�.
                loadGameButton[SaveNum].SetActive(true);
                //i��° �����ϱ� ��ư�� ��Ȱ��ȭ�Ѵ�.
                newGameButton[SaveNum].SetActive(false);
                /*Class : ����� �÷��̾��� ����
                 ATK : ����� ���� �÷��̾��� ���ݷ�, MATK : ����� ���� �÷��̾��� ���� ���ݷ�
                 HP : ����� �÷��̾��� HP, MP : ����� �÷��̾��� MP �������� �����Ѵ�.*/
                if(PlayerPrefs.HasKey("MagicKnightX" + (SaveNum + 1))){
                    Status[SaveNum].text = "Class : MagicKnight" +
                        "\n ATK : " + PlayerPrefs.GetFloat("MagicKnightAttack" + (SaveNum + 1)) + " , MATK : " + PlayerPrefs.GetFloat("MagicKnightMagic" + (SaveNum + 1)) +
                        "\n HP : " + PlayerPrefs.GetFloat("MagicKnightMaxHP" + (SaveNum + 1)) + ", MP : " + PlayerPrefs.GetFloat("MagicKnightMaxMP" + (SaveNum + 1));
                }
                else if(PlayerPrefs.HasKey("WizardX" + (SaveNum + 1))){
                    Status[SaveNum].text = "Class : Wizard" +
                        "\n ATK : " + PlayerPrefs.GetFloat("WizardAttack" + (SaveNum + 1)) + " , MATK : " + PlayerPrefs.GetFloat("WizardMagic" + (SaveNum + 1)) +
                        "\n HP : " + PlayerPrefs.GetFloat("WizardMaxHP" + (SaveNum + 1)) + ", MP : " + PlayerPrefs.GetFloat("WizardMaxMP" + (SaveNum + 1));
                }
                else if (PlayerPrefs.HasKey("ElfX" + (SaveNum + 1))){
                    Status[SaveNum].text = "Class : Elf" +
                        "\n ATK : " + PlayerPrefs.GetFloat("ElfAttack" + (SaveNum + 1)) + " , MATK : " + PlayerPrefs.GetFloat("ElfMagic" + (SaveNum + 1)) +
                        "\n HP : " + PlayerPrefs.GetFloat("ElfMaxHP" + (SaveNum + 1)) + ", MP : " + PlayerPrefs.GetFloat("ElfMaxMP" + (SaveNum + 1));
                }
            }
            //�׷��� ������
            else if(PlayerPrefs.GetInt("SlotSaved"+saveIds[SaveNum]) != 1)
                // || PlayerPrefs.GetInt("LoadScene" + saveIds[SaveNum]) != 1 || PlayerPrefs.GetInt("SavedScene"+saveIds[SaveNum]) != SceneManager.GetActiveScene().buildIndex)
            {
                //i��° �ҷ����� ��ư�� ��Ȱ��ȭ�Ѵ�.
                loadGameButton[SaveNum].SetActive(false);
                //i��° �����ϱ� ��ư�� Ȱ��ȭ�Ѵ�.
                newGameButton[SaveNum].SetActive(true);
                //�� ���Կ��� Empty Data ��� ǥ���Ѵ�.
                Status[SaveNum].text = "Empty Data";
            }
        }        
    }
}
