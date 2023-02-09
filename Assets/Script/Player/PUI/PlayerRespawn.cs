using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject[] charPrefabs;
    public GameObject player;    
    
    private GameObject BulletS;         //마법사의 에너지볼 슬롯
    private GameObject ArrowS;          //엘프의 화살 슬롯
    private GameObject SwordS;          //마법기사의 검기 슬롯
    private GameObject Magic;           //마법 슬롯
    private GameObject MoveJoyStick;    //이동 조이스틱
    private GameObject AttackJoyStick;  //공격 조이스틱

    private float PlayerX;
    private float PlayerY;

    private void Start()
    {
        //해당 슬롯에 저장이 되어 있으면 실행한다.
        if (PlayerPrefs.HasKey("SavedScene" + SaveID.saveID))
        {
            //불러오는 씬 정보 순서가 현재 씬의 순서랑 같으면 실행한다.
            if(PlayerPrefs.GetInt("SavedScene"+SaveID.saveID) == SceneManager.GetActiveScene().buildIndex)
            {
                //마법기사의X 축 좌표가 저장되어 있으면
                if (PlayerPrefs.HasKey("MagicKnightX" + SaveID.saveID))
                {
                    //DataManager컴포넌트의 정적변수인 instace의 currentCharacter는 마법기사가 된다.
                    DataManager.instance.currentCharacter = Character.MagicKnight;
                    /*플레이어는 charPrefab에서 선택된 캐릭터에 따라 소환된다.*/
                    player = Instantiate(charPrefabs[(int)DataManager.instance.currentCharacter]);
                    //PlayerX는 마법기사의 X축 좌표를 불러온다.
                    PlayerX = PlayerPrefs.GetFloat("MagicKnightX" + SaveID.saveID);
                    //PlayerY는 마법기사의 Y축 좌표를 불러온다.
                    PlayerY = PlayerPrefs.GetFloat("MagicKnightY" + SaveID.saveID);
                    //플레이어의 위치는 (불러오는 X좌표, 불러오는 Y좌표, z)에서 시작된다.
                    player.transform.position = new Vector3(PlayerX, PlayerY, this.transform.position.z);
                }
                else if (PlayerPrefs.HasKey("WizardX" + SaveID.saveID))
                {
                    //DataManager컴포넌트의 정적변수인 instace의 currentCharacter는 마법사가 된다.
                    DataManager.instance.currentCharacter = Character.Wizard;
                    /*플레이어는 charPrefab에서 선택된 캐릭터에 따라 소환된다.*/
                    player = Instantiate(charPrefabs[(int)DataManager.instance.currentCharacter]);
                    //PlayerX는 마법사의 X축 좌표를 불러온다.
                    PlayerX = PlayerPrefs.GetFloat("WizardX" + SaveID.saveID);
                    //PlayerY는 마법사의 Y축 좌표를 불러온다.
                    PlayerY = PlayerPrefs.GetFloat("WizardY" + SaveID.saveID);
                    //플레이어의 위치는 (불러오는 X좌표, 불러오는 Y좌표, z)에서 시작된다.
                    player.transform.position = new Vector3(PlayerX, PlayerY, this.transform.position.z);
                }
                else if (PlayerPrefs.HasKey("ElfX" + SaveID.saveID))
                {
                    //DataManager컴포넌트의 정적변수인 instace의 currentCharacter는 엘프가 된다.
                    DataManager.instance.currentCharacter = Character.Elf;
                    /*플레이어는 charPrefab에서 선택된 캐릭터에 따라 소환된다.*/
                    player = Instantiate(charPrefabs[(int)DataManager.instance.currentCharacter]);
                    //PlayerX는 엘프의 X축 좌표를 불러온다.
                    PlayerX = PlayerPrefs.GetFloat("ElfX" + SaveID.saveID);
                    //PlayerY는 엘프의 Y축 좌표를 불러온다.
                    PlayerY = PlayerPrefs.GetFloat("ElfY" + SaveID.saveID);
                    //플레이어의 위치는 (불러오는 X좌표, 불러오는 Y좌표, z)에서 시작된다.
                    player.transform.position = new Vector3(PlayerX, PlayerY, this.transform.position.z);
                }
            }
            else
            {
                /*플레이어는 charPrefab에서 선택된 캐릭터에 따라 소환된다.*/
                player = Instantiate(charPrefabs[(int)DataManager.instance.currentCharacter]);
                //플레이어는 지정된 위치에서 소환된다.
                player.transform.position = this.transform.position;
            }
        }
        else
        {
            /*플레이어는 charPrefab에서 선택된 캐릭터에 따라 소환된다.*/
            player = Instantiate(charPrefabs[(int)DataManager.instance.currentCharacter]);
            //플레이어는 지정된 위치에서 소환된다.
            player.transform.position = this.transform.position;
        }

        /*GameObject.find("상위오브젝트명").transform.GetChild(int number)
         * - 상위 오브젝트안에 비활성화되어 있는 여러자식 오브젝트중에서 number순서에 해당하는 오브젝트를 찾는데 필요한 문법*/
        //스테이지씬의 Canvas오브젝트의 자식 오브젝트인 BulletPanel오브젝트를 찾는다.
        BulletS = GameObject.Find("Canvas").transform.GetChild(3).gameObject;
        //스테이지씬의 Canvas오브젝트의 자식 오브젝트인 ArrowPanel오브젝트를 찾는다.
        ArrowS = GameObject.Find("Canvas").transform.GetChild(4).gameObject;
        //스테이지씬의 Canvas오브젝트의 자식 오브젝트인 SwordPanel오브젝트를 찾는다.
        SwordS = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
        //스테이지씬의 Canvas오브젝트의 자식 오브젝트인 MagicPanel오브젝트를 찾는다.
        Magic = GameObject.Find("Canvas").transform.GetChild(5).gameObject;
        //스테이지씬의 Canvas오브젝트의 자식 오브젝트인 AttackJoyStick오브젝트를 찾는다.
        MoveJoyStick = GameObject.Find("Canvas").transform.GetChild(8).gameObject;
        //스테이지씬의 Canvas오브젝트의 자식 오브젝트인 MovingJoyStick오브젝트를 찾는다.
        AttackJoyStick = GameObject.Find("Canvas").transform.GetChild(7).gameObject;
    }
    private void Update()
    {
        //마법기사를 소환하면
        if(DataManager.instance.currentCharacter==Character.MagicKnight)
        {
            //마법기사의 무기슬롯을 활성화한다.
            SwordS.SetActive(true);
            
            //마법사의 무기슬롯을 비활성화한다.
            BulletS.SetActive(false);
            
            //엘프의 무기슬롯을 비활성화한다.
            ArrowS.SetActive(false);
        }
        //마법사를 소환하면
        else if(DataManager.instance.currentCharacter == Character.Wizard)
        {
            //마법기사의 무기슬롯을 비활성화한다.
            SwordS.SetActive(false);
            
            //마법사의 무기슬롯을 활성화한다.
            BulletS.SetActive(true);
            
            //엘프의 무기슬롯을 비활성화한다.
            ArrowS.SetActive(false);
        }
        //엘프를 소환하면
        else if(DataManager.instance.currentCharacter == Character.Elf)
        {
            //마법기사의 무기슬롯을 비활성화한다.
            SwordS.SetActive(false);
            
            //마법사의 무기슬롯을 비활성화한다.
            BulletS.SetActive(false);
            
            //엘프의 무기슬롯을 활성화한다.
            ArrowS.SetActive(true);
        }
        //마법 슬롯도 활성화 시킨다.
        Magic.SetActive(true);
        //플레이어 이동 조이스틱을 활성화 시킨다.
        MoveJoyStick.SetActive(true);
        //플레이어 공격 조이스틱을 활성화 시킨다.
        AttackJoyStick.SetActive(true);
    }
}
