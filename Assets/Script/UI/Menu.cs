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

    //플레이어 정보를 가져오기 위해 선언한다.
    private GameObject Player;

    private void Start()
    {
        //플레이어 정보를 가져오기 위해 초기화 한다.
        Player = GameObject.FindWithTag("Player");

        saveNum = SaveID.saveID;
    }

    void Update()
    {
        /*
        * 시작 시 모든 저장 데이터가 보이도록
        * for문을 사용한다.
        */
        for (int i = 0; i < saveIds.Length; i++)
        {
            SaveSlot(i);
        }
    }

    //새로하기 버튼을 누르면 실행한다.
    public void NewGame()
    {
        //PlayExplain1씬으로 이동한다.
        SceneManager.LoadScene("PlayExplain1");
    }    

    //이어하기 버튼을 누르면 실행한다.
    public void LoadGame()
    {
        //LoadSaved상태가 true일때
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
            //불러올때 저장된 SaveScene 정보를 불러와 해당 이름을 가진 씬으로 로드한다.
            SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene" + SaveID.saveID));
            Debug.Log("저장된 위치를 불러왔습니다.");
        }
        //그렇지 않으면
        else
        {
            //강제로 종료한다.
            return;
        }
    }

    public void SetSaveID(int saveID)
    {
        SaveID.saveID = saveID;
    }

    public void ClearSave(int saveID)
    {
        //마법기사 X축 좌표데이터가 저장되어 있으면
        if (PlayerPrefs.HasKey("MagicKnightX" + saveID))
        {
            //해당슬롯에 마법기사의 X축 좌표를 삭제한다.
            PlayerPrefs.DeleteKey("MagicKnightX" + saveID);

            //해당슬롯에 마법기사의 Y축 좌표를 삭제한다.
            PlayerPrefs.DeleteKey("MagicKnightY" + saveID);

            //해당슬롯에 마법기사의 현재 물리 공격력 삭제한다.
            PlayerPrefs.DeleteKey("MagicKnightAttack" + saveID);

            //해당슬롯에 마법기사의 현재 마법 공격력 삭제한다.
            PlayerPrefs.DeleteKey("MagicKnightMagic" + saveID);

            //해당슬롯에 마법기사의 최대 HP 값을 삭제한다.
            PlayerPrefs.DeleteKey("MagicKnightMaxHP" + saveID);

            //해당슬롯에 마법기사의 최대 MP 값을 삭제한다.
            PlayerPrefs.DeleteKey("MagicKnightMaxMP" + saveID);
            
            //해당슬롯에 마법기사의 현재 HP를 삭제한다.
            PlayerPrefs.DeleteKey("MagicKnightCurHPStrength" + saveID);

            //해당슬롯에 마법기사의 현재 MP를 삭제한다.
            PlayerPrefs.DeleteKey("MagicKnightCurMPStrength" + saveID);

            //해당슬롯에 마법기사의 화상상태 데미지를 삭제한다.
            PlayerPrefs.DeleteKey("MagicKnightFireDamage" + saveID);
            
            //해당슬롯에 마법기사의 화상상태 지속시간을 삭제한다.
            PlayerPrefs.DeleteKey("MagicKnightFireKeep" + saveID);
            
            //해당슬롯에 마법기사의 빙결상태 지속시간을 삭제한다.
            PlayerPrefs.DeleteKey("MagicKnightFreeze" + saveID);
            
            //해당슬롯에 마법기사의 감전상태 지속시간을 삭제한다.
            PlayerPrefs.DeleteKey("MagicKnightElectric" + saveID);
            
            //해당슬롯에 마법기사의 기절상태 지속시간을 삭제한다.
            PlayerPrefs.DeleteKey("MagicKnightFaint" + saveID);
            
            //해당슬롯에 마법기사의 넉백으로 밀어내는 힘을 삭제한다.
            PlayerPrefs.DeleteKey("MagicKnightKnockBack" + saveID);
        }
        else if (PlayerPrefs.HasKey("WizardX" + saveID))
        {
            //현재슬롯에 마법사의 X축 좌표를 삭제한다.
            PlayerPrefs.DeleteKey("WizardX" + saveID);

            //해당슬롯에 마법사의 Y축 좌표를 삭제한다.
            PlayerPrefs.DeleteKey("WizardY" + saveID);

            //해당슬롯에 마법사의 현재 물리 공격력을 삭제한다.
            PlayerPrefs.DeleteKey("WizardAttack" + saveID);

            //해당슬롯에 마법사의 현재 마법 공격력을 삭제한다.
            PlayerPrefs.DeleteKey("WizardMagic" + saveID);
            
            //해당슬롯에 마법사의 최대 HP를 삭제한다.
            PlayerPrefs.DeleteKey("WizardMaxHP" + saveID);

            //해당슬롯에 마법사의 최대 MP를 삭제한다.
            PlayerPrefs.DeleteKey("WizardMaxMP" + saveID);
            
            //해당슬롯에 마법사의 현재 HP를 삭제한다.
            PlayerPrefs.DeleteKey("WizardCurHPStrength" + saveID);

            //해당슬롯에 마법사의 현재 MP를 삭제한다.
            PlayerPrefs.DeleteKey("WizardCurMPStrength" + saveID);

            //해당슬롯에 마법사의 화상상태 데미지를 삭제한다.
            PlayerPrefs.DeleteKey("WizardFireDamage" + saveID);
            
            //해당슬롯에 마법사의 화상상태 지속시간을 삭제한다.
            PlayerPrefs.DeleteKey("WizardFireKeep" + saveID);
            
            //해당슬롯에 마법사의 빙결상태 지속시간을 삭제한다.
            PlayerPrefs.DeleteKey("WizardFreeze" + saveID);
            
            //해당슬롯에 마법사의 감전상태 지속시간을 삭제한다.
            PlayerPrefs.DeleteKey("WizardElectric" + saveID);
            
            //해당슬롯에 마법사의 기절상태 지속시간을 삭제한다.
            PlayerPrefs.DeleteKey("WizardFaint" + saveID);
            
            //해당슬롯에 마법사의 넉백으로 밀어내는 힘을 삭제한다.
            PlayerPrefs.DeleteKey("WizardKnockBack" + saveID);
        }
        else if(PlayerPrefs.HasKey("ElfX" + saveID))
        {
            //해당슬롯에 엘프의 X축 좌표를 삭제한다.
            PlayerPrefs.DeleteKey("ElfX" + saveID);

            //해당슬롯에 엘프의 Y축 좌표를 삭제한다.
            PlayerPrefs.DeleteKey("ElfY" + saveID);

            //해당슬롯에 엘프의 현재 물리 공격력을 삭제한다.
            PlayerPrefs.DeleteKey("ElfAttack" + saveID);

            //해당슬롯에 엘프의 현재 마법 공격력을 삭제한다.
            PlayerPrefs.DeleteKey("ElfMagic" + saveID);
            
            //해당슬롯에 엘프의 최대 HP를 삭제한다.
            PlayerPrefs.DeleteKey("ElfMaxHP" + saveID);

            //해당솔롯에 엘프의 최대 MP를 삭제한다.
            PlayerPrefs.DeleteKey("ElfMaxMP" + saveID);
            
            //해당슬롯에 엘프의 현재 HP를 삭제한다.
            PlayerPrefs.DeleteKey("ElfCurHPStrength" + saveID);

            //해당슬롯에 엘프의 현재 MP를 삭제한다.
            PlayerPrefs.DeleteKey("ElfCurMPStrength" + saveID);

            //해당슬롯에 엘프의 화상상태 데미지를 삭제한다.
            PlayerPrefs.DeleteKey("ElfFireDamage" + saveID);
            
            //해당슬롯에 엘프의 화상상태 지속시간을 삭제한다.
            PlayerPrefs.DeleteKey("ElfFireKeep" + saveID);
            
            //해당슬롯에 엘프의 빙결상태 지속시간을 삭제한다.
            PlayerPrefs.DeleteKey("ElfFreeze" + saveID);
            
            //해당슬롯에 엘프의 감전상태 지속시간을 삭제한다.
            PlayerPrefs.DeleteKey("ElftElectric" + saveID);
            
            //해당슬롯에 엘프의 기절상태 지속시간을 삭제한다.
            PlayerPrefs.DeleteKey("ElfFaint" + saveID);
            
            //해당슬롯에 엘프의 넉백으로 밀어내는 힘을 삭제한다.
            PlayerPrefs.DeleteKey("ElfKnockBack" + saveID);
        }
        PlayerPrefs.DeleteKey("LoadScene" + saveID);
        PlayerPrefs.DeleteKey("SlotSaved" + saveID);
        PlayerPrefs.DeleteKey("SavedScene" + saveID);
    }

    private void SaveSlot(int SaveNum)
    {
        //SaveNUm이 saveIds 값보다 크지 않으면
        if(SaveNum <= saveIds.Length)
        {
            //SlotSaved데이터를 불러올때 활성화가 되어 있으면
            if (PlayerPrefs.GetInt("SlotSaved" + saveIds[SaveNum]) == 1)
            {
                //i번째 불러오기 버튼을 활성화한다.
                loadGameButton[SaveNum].SetActive(true);
                //i번째 새로하기 버튼을 비활성화한다.
                newGameButton[SaveNum].SetActive(false);
                /*Class : 저장된 플레이어의 직업
                 ATK : 저장된 현재 플레이어의 공격력, MATK : 저장된 현재 플레이어의 마법 공격력
                 HP : 저장된 플레이어의 HP, MP : 저장된 플레이어의 MP 형식으로 저장한다.*/
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
            //그렇지 않으면
            else if(PlayerPrefs.GetInt("SlotSaved"+saveIds[SaveNum]) != 1)
                // || PlayerPrefs.GetInt("LoadScene" + saveIds[SaveNum]) != 1 || PlayerPrefs.GetInt("SavedScene"+saveIds[SaveNum]) != SceneManager.GetActiveScene().buildIndex)
            {
                //i번째 불러오기 버튼을 비활성화한다.
                loadGameButton[SaveNum].SetActive(false);
                //i번째 새로하기 버튼을 활성화한다.
                newGameButton[SaveNum].SetActive(true);
                //각 슬롯에는 Empty Data 라며 표시한다.
                Status[SaveNum].text = "Empty Data";
            }
        }        
    }
}
