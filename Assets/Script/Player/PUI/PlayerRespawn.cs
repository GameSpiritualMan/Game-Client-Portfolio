using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject[] charPrefabs;
    public GameObject player;    
    
    private GameObject BulletS;         //�������� �������� ����
    private GameObject ArrowS;          //������ ȭ�� ����
    private GameObject SwordS;          //��������� �˱� ����
    private GameObject Magic;           //���� ����
    private GameObject MoveJoyStick;    //�̵� ���̽�ƽ
    private GameObject AttackJoyStick;  //���� ���̽�ƽ

    private float PlayerX;
    private float PlayerY;

    private void Start()
    {
        //�ش� ���Կ� ������ �Ǿ� ������ �����Ѵ�.
        if (PlayerPrefs.HasKey("SavedScene" + SaveID.saveID))
        {
            //�ҷ����� �� ���� ������ ���� ���� ������ ������ �����Ѵ�.
            if(PlayerPrefs.GetInt("SavedScene"+SaveID.saveID) == SceneManager.GetActiveScene().buildIndex)
            {
                //���������X �� ��ǥ�� ����Ǿ� ������
                if (PlayerPrefs.HasKey("MagicKnightX" + SaveID.saveID))
                {
                    //DataManager������Ʈ�� ���������� instace�� currentCharacter�� ������簡 �ȴ�.
                    DataManager.instance.currentCharacter = Character.MagicKnight;
                    /*�÷��̾�� charPrefab���� ���õ� ĳ���Ϳ� ���� ��ȯ�ȴ�.*/
                    player = Instantiate(charPrefabs[(int)DataManager.instance.currentCharacter]);
                    //PlayerX�� ��������� X�� ��ǥ�� �ҷ��´�.
                    PlayerX = PlayerPrefs.GetFloat("MagicKnightX" + SaveID.saveID);
                    //PlayerY�� ��������� Y�� ��ǥ�� �ҷ��´�.
                    PlayerY = PlayerPrefs.GetFloat("MagicKnightY" + SaveID.saveID);
                    //�÷��̾��� ��ġ�� (�ҷ����� X��ǥ, �ҷ����� Y��ǥ, z)���� ���۵ȴ�.
                    player.transform.position = new Vector3(PlayerX, PlayerY, this.transform.position.z);
                }
                else if (PlayerPrefs.HasKey("WizardX" + SaveID.saveID))
                {
                    //DataManager������Ʈ�� ���������� instace�� currentCharacter�� �����簡 �ȴ�.
                    DataManager.instance.currentCharacter = Character.Wizard;
                    /*�÷��̾�� charPrefab���� ���õ� ĳ���Ϳ� ���� ��ȯ�ȴ�.*/
                    player = Instantiate(charPrefabs[(int)DataManager.instance.currentCharacter]);
                    //PlayerX�� �������� X�� ��ǥ�� �ҷ��´�.
                    PlayerX = PlayerPrefs.GetFloat("WizardX" + SaveID.saveID);
                    //PlayerY�� �������� Y�� ��ǥ�� �ҷ��´�.
                    PlayerY = PlayerPrefs.GetFloat("WizardY" + SaveID.saveID);
                    //�÷��̾��� ��ġ�� (�ҷ����� X��ǥ, �ҷ����� Y��ǥ, z)���� ���۵ȴ�.
                    player.transform.position = new Vector3(PlayerX, PlayerY, this.transform.position.z);
                }
                else if (PlayerPrefs.HasKey("ElfX" + SaveID.saveID))
                {
                    //DataManager������Ʈ�� ���������� instace�� currentCharacter�� ������ �ȴ�.
                    DataManager.instance.currentCharacter = Character.Elf;
                    /*�÷��̾�� charPrefab���� ���õ� ĳ���Ϳ� ���� ��ȯ�ȴ�.*/
                    player = Instantiate(charPrefabs[(int)DataManager.instance.currentCharacter]);
                    //PlayerX�� ������ X�� ��ǥ�� �ҷ��´�.
                    PlayerX = PlayerPrefs.GetFloat("ElfX" + SaveID.saveID);
                    //PlayerY�� ������ Y�� ��ǥ�� �ҷ��´�.
                    PlayerY = PlayerPrefs.GetFloat("ElfY" + SaveID.saveID);
                    //�÷��̾��� ��ġ�� (�ҷ����� X��ǥ, �ҷ����� Y��ǥ, z)���� ���۵ȴ�.
                    player.transform.position = new Vector3(PlayerX, PlayerY, this.transform.position.z);
                }
            }
            else
            {
                /*�÷��̾�� charPrefab���� ���õ� ĳ���Ϳ� ���� ��ȯ�ȴ�.*/
                player = Instantiate(charPrefabs[(int)DataManager.instance.currentCharacter]);
                //�÷��̾�� ������ ��ġ���� ��ȯ�ȴ�.
                player.transform.position = this.transform.position;
            }
        }
        else
        {
            /*�÷��̾�� charPrefab���� ���õ� ĳ���Ϳ� ���� ��ȯ�ȴ�.*/
            player = Instantiate(charPrefabs[(int)DataManager.instance.currentCharacter]);
            //�÷��̾�� ������ ��ġ���� ��ȯ�ȴ�.
            player.transform.position = this.transform.position;
        }

        /*GameObject.find("����������Ʈ��").transform.GetChild(int number)
         * - ���� ������Ʈ�ȿ� ��Ȱ��ȭ�Ǿ� �ִ� �����ڽ� ������Ʈ�߿��� number������ �ش��ϴ� ������Ʈ�� ã�µ� �ʿ��� ����*/
        //������������ Canvas������Ʈ�� �ڽ� ������Ʈ�� BulletPanel������Ʈ�� ã�´�.
        BulletS = GameObject.Find("Canvas").transform.GetChild(3).gameObject;
        //������������ Canvas������Ʈ�� �ڽ� ������Ʈ�� ArrowPanel������Ʈ�� ã�´�.
        ArrowS = GameObject.Find("Canvas").transform.GetChild(4).gameObject;
        //������������ Canvas������Ʈ�� �ڽ� ������Ʈ�� SwordPanel������Ʈ�� ã�´�.
        SwordS = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
        //������������ Canvas������Ʈ�� �ڽ� ������Ʈ�� MagicPanel������Ʈ�� ã�´�.
        Magic = GameObject.Find("Canvas").transform.GetChild(5).gameObject;
        //������������ Canvas������Ʈ�� �ڽ� ������Ʈ�� AttackJoyStick������Ʈ�� ã�´�.
        MoveJoyStick = GameObject.Find("Canvas").transform.GetChild(8).gameObject;
        //������������ Canvas������Ʈ�� �ڽ� ������Ʈ�� MovingJoyStick������Ʈ�� ã�´�.
        AttackJoyStick = GameObject.Find("Canvas").transform.GetChild(7).gameObject;
    }
    private void Update()
    {
        //������縦 ��ȯ�ϸ�
        if(DataManager.instance.currentCharacter==Character.MagicKnight)
        {
            //��������� ���⽽���� Ȱ��ȭ�Ѵ�.
            SwordS.SetActive(true);
            
            //�������� ���⽽���� ��Ȱ��ȭ�Ѵ�.
            BulletS.SetActive(false);
            
            //������ ���⽽���� ��Ȱ��ȭ�Ѵ�.
            ArrowS.SetActive(false);
        }
        //�����縦 ��ȯ�ϸ�
        else if(DataManager.instance.currentCharacter == Character.Wizard)
        {
            //��������� ���⽽���� ��Ȱ��ȭ�Ѵ�.
            SwordS.SetActive(false);
            
            //�������� ���⽽���� Ȱ��ȭ�Ѵ�.
            BulletS.SetActive(true);
            
            //������ ���⽽���� ��Ȱ��ȭ�Ѵ�.
            ArrowS.SetActive(false);
        }
        //������ ��ȯ�ϸ�
        else if(DataManager.instance.currentCharacter == Character.Elf)
        {
            //��������� ���⽽���� ��Ȱ��ȭ�Ѵ�.
            SwordS.SetActive(false);
            
            //�������� ���⽽���� ��Ȱ��ȭ�Ѵ�.
            BulletS.SetActive(false);
            
            //������ ���⽽���� Ȱ��ȭ�Ѵ�.
            ArrowS.SetActive(true);
        }
        //���� ���Ե� Ȱ��ȭ ��Ų��.
        Magic.SetActive(true);
        //�÷��̾� �̵� ���̽�ƽ�� Ȱ��ȭ ��Ų��.
        MoveJoyStick.SetActive(true);
        //�÷��̾� ���� ���̽�ƽ�� Ȱ��ȭ ��Ų��.
        AttackJoyStick.SetActive(true);
    }
}
