using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //메뉴창
    public GameObject MenuSet;
    //스테이터스
    public GameObject Status;

    public Text Attack;                        //총알 공격력을 표시하기위해 선언
    public Text MagicAttack;                   //마법 공격력을 표시하기 위해 선언
    public Text MaxHP;                         //최대 HP를 표시하기 위해 선언
    public Text MaxMP;                         //최대 MP를 표시하기 위해 선언
    public Text BurnDMG;                       //화상상태 데미지를 표시하기 위해 선언한다.
    public Text BurnTime;                      //화상상태 지속시간을 표시하기 위해 선언한다.
    public Text FreezeTime;                    //빙결상태 지속시간을 표시하기 위해 선언한다.
    public Text EShockTime;                    //감전상태 지속시간을 표시하기 위해 선언한다.
    public Text FaintTime;                     //기절상태 지속시간을 표시하기 위해 선언한다.
    public Text KnockBackPower;                //넉백으로 밀어내는 힘을 표시하기 위해 선언한다.

    private PlayerController PController;       //PlayerController컴포넌트를 재정의 하기 위해 선언
    private PlayerHUD PHUD;                     //PlayerHUD컴포넌트를 재정의 하기 위해 선언

    //스테이터스가 활성화 되도 표시되는 것을 방지하기 위해 선언한다.
    public GameObject Minimap;
    public GameObject AttackText;
    public GameObject StatusButton;

    void Awake()
    {
        //모든 오브젝트들이 움직인다.
        Time.timeScale = 1;        
    }

    void Update()
    {
        //Esc키를 누렀을때
        if (Input.GetButtonDown("Cancel"))
        {
            MenuActive();
        }        
    }

    //스테이터스 창
    public void StatusActive()
    {
        //비활성화가 되어 있으면
        if (Status.activeSelf == false)
        {
            //활성화 한다.
            Status.SetActive(true);
            //모든 오브젝트들이 움직이지 않는다.
            Time.timeScale = 0;

            //Player태그를 가진 오브젝트의 PlayerContorller컴포넌트에 접근한다.
            PController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
            //Player태그를 가진 오브젝트의 PlayerHUD컴포넌트에 접근한다.
            PHUD = GameObject.FindWithTag("Player").GetComponent<PlayerHUD>();

            //Canvas의 4번째 하위 오브젝트인 Attack의 Text컴포넌트에 접근한다.
            Attack = GameObject.Find("Canvas").transform.Find("StatusPanel").transform.Find("ScrollRect").transform.Find("Contents").transform.Find("Attack").GetComponent<Text>();
            //Canvas의 4번째 하위 오브젝트인 MagicAttack의 Text컴포넌트에 접근한다.
            MagicAttack = GameObject.Find("Canvas").transform.Find("StatusPanel").transform.Find("ScrollRect").transform.Find("Contents").transform.Find("MagicAttack").GetComponent<Text>();
            //Canvas의 4번째 하위 오브젝트인 MaxHP의 Text컴포넌트에 접근한다.
            MaxHP = GameObject.Find("Canvas").transform.Find("StatusPanel").transform.Find("ScrollRect").transform.Find("Contents").transform.Find("MaxHP").GetComponent<Text>();
            //Canvas의 4번째 하위 오브젝트인 MaxMP의 Text컴포넌트에 접근한다.
            MaxMP = GameObject.Find("Canvas").transform.Find("StatusPanel").transform.Find("ScrollRect").transform.Find("Contents").transform.Find("MaxMP").GetComponent<Text>();
            //Canvas의 4번째 하위 오브젝트인 BurnDMG의 Text컴포넌트에 접근한다.
            BurnDMG = GameObject.Find("Canvas").transform.Find("StatusPanel").transform.Find("ScrollRect").transform.Find("Contents").transform.Find("BurnDMG").GetComponent<Text>();
            //Canvas의 4번째 하위 오브젝트인 BurnTime의 Text컴포넌트에 접근한다.
            BurnTime = GameObject.Find("Canvas").transform.Find("StatusPanel").transform.Find("ScrollRect").transform.Find("Contents").transform.Find("BurnTime").GetComponent<Text>();
            //Canvas의 4번째 하위 오브젝트인 FreezeTime의 Text컴포넌트에 접근한다.
            FreezeTime = GameObject.Find("Canvas").transform.Find("StatusPanel").transform.Find("ScrollRect").transform.Find("Contents").transform.Find("FreezeTime").GetComponent<Text>();
            //Canvas의 4번째 하위 오브젝트인 EShockTime의 Text컴포넌트에 접근한다.
            EShockTime = GameObject.Find("Canvas").transform.Find("StatusPanel").transform.Find("ScrollRect").transform.Find("Contents").transform.Find("EShockTime").GetComponent<Text>();
            //Canvas의 4번째 하위 오브젝트인 FaintTime의 Text컴포넌트에 접근한다.
            FaintTime = GameObject.Find("Canvas").transform.Find("StatusPanel").transform.Find("ScrollRect").transform.Find("Contents").transform.Find("FaintTime").GetComponent<Text>();
            //Canvas의 4번째 하위 오브젝트인 KnockBackPower의 Text컴포넌트에 접근한다.
            KnockBackPower = GameObject.Find("Canvas").transform.Find("StatusPanel").transform.Find("ScrollRect").transform.Find("Contents").transform.Find("KnockBackPower").GetComponent<Text>();

            /*플레이어의 캐릭터에 따라 계산하는 값이 달라진다.*/
            //플레이어의 캐릭터가 마법기사이면
            if (GameObject.Find("MagicKnight(Clone)"))
            {
                //저장된 마법기사 X축 좌표가 있으면 실행한다.
                if (PlayerPrefs.HasKey("MagicKnightX" + SaveID.saveID))
                {
                    /*마법기사의 물리 공격력
                    강화전 : 이전 물리 공격력 → 강화후 : 현재 물리 공격력*/
                    Attack.text = "물리 공격력\n강화전 : " + PlayerPrefs.GetFloat("MagicKnightAttack" + SaveID.saveID).ToString() + " → 강화후 : " + PController.ATK.ToString();
                    /*마법기사의 마법 공격력
                    강화전 : 이전 마법 공격력 → 강화후 : 현재 마법 공격력*/
                    MagicAttack.text = "마법 공격력\n강화전 : " + PlayerPrefs.GetFloat("MagicKnightMagic" + SaveID.saveID).ToString() + " → 강화후 : " + PController.MATk.ToString();
                    /*마법기사의 최대HP
                    강화전 : 이전 최대 HP → 강화후 : 현재 최대 HP*/
                    MaxHP.text = "최대 HP\n강화전 : " + PlayerPrefs.GetFloat("MagicKnightMaxHP" + SaveID.saveID).ToString() + " → 강화후 : " + PHUD.MaxHealth.ToString();
                    /*마법기사의 최대MP
                    강화전 : 이전 최대 MP → 강화후 : 현재 최대 MP*/
                    MaxMP.text = "최대 MP\n강화전 : " + PlayerPrefs.GetFloat("MagicKnightMaxMP" + SaveID.saveID).ToString() + " → 강화후 : " + PHUD.MaxMana.ToString();
                    /*마법기사의 화상상태 데미지
                    강화전 : 이전 화상상태 데미지 → 강화후 : 현재 화상상태 데미지*/
                    BurnDMG.text = "화상상태 데미지\n강화전 : " + PlayerPrefs.GetFloat("MagicKnightFireDamage" + SaveID.saveID).ToString() + " → 강화후 : " + PController.BurnDMG.ToString();
                    /*마법기사의 화상상태 지속시간
                    강화전 : 이전 화상상태 지속시간 → 강화후 : 현재 화상상태 지속시간*/
                    BurnTime.text = "화상상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("MagicKnightFireKeep" + SaveID.saveID).ToString() + "초 → 강화후 : " + PController.BurnTime.ToString() + "초";
                    /*마법기사의 빙결상태 지속시간
                    강화전 : 이전 빙결상태 지속시간 → 강화후 : 현재 빙결상태 지속시간*/
                    FreezeTime.text = "빙결상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("MagicKnightFreeze" + SaveID.saveID).ToString() + "초 → 강화후 : " + PController.Freeze.ToString() + "초";
                    /*마법기사의 감전상태 지속시간
                    강화전 : 이전 감전상태 지속시간 → 강화후 : 현재 감전상태 지속시간*/
                    EShockTime.text = "감전상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("MagicKnightElectric" + SaveID.saveID).ToString() + "초 → 강화후 : " + PController.EShock.ToString() + "초";
                    /*마법기사의 기절상태 지속시간
                    강화전 : 이전 기절상태 지속시간 → 강화후 : 현재 기절상태 지속시간*/
                    FaintTime.text = "기절상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("MagicKnightFaint" + SaveID.saveID).ToString() + "초 강화후 : " + PController.Faint.ToString() + "초";
                    /*마법기사의 넉백으로 미는 힘
                    강화전 : 이전 넉백으로 미는 힘 → 강화후 : 현재 넉백으로 미는 힘*/
                    KnockBackPower.text = "넉백으로 미는 힘\n강화전 : " + PlayerPrefs.GetFloat("MagicKnightKnockBack" + SaveID.saveID).ToString() + " → 강화후 : " + PController.KnockBack.ToString();
                }
                //마법기사 X축 좌표가 없으면 실행한다.
                else
                {
                    /*마법기사의 물리 공격력 : 현재 물리 공격력*/
                    Attack.text = "물리 공격력 : " + PController.ATK.ToString();
                    /*마법기사의 마법 공격력 : 현재 마법 공격력*/
                    MagicAttack.text = "마법 공격력 : " + PController.MATk.ToString();
                    /*마법기사의 최대HP : 현재 최대 HP*/
                    MaxHP.text = "최대 HP : " + PHUD.MaxHealth.ToString();
                    /*마법기사의 최대MP : 현재 최대 MP*/
                    MaxMP.text = "최대 MP : " + PHUD.MaxMana.ToString();
                    /*마법기사의 화상상태 데미지 : 현재 화상상태 데미지*/
                    BurnDMG.text = "화상상태 데미지 : " + PController.BurnDMG.ToString();
                    /*마법기사의 화상상태 지속시간 : 현재 화상상태 지속시간*/
                    BurnTime.text = "화상상태 지속시간 : " + PController.BurnTime.ToString() + "초";
                    /*마법기사의 빙결상태 지속시간 : 현재 빙결상태 지속시간*/
                    FreezeTime.text = "빙결상태 지속시간 : " + PController.Freeze.ToString() + "초";
                    /*마법기사의 감전상태 지속시간 : 현재 감전상태 지속시간*/
                    EShockTime.text = "감전상태 지속시간 : " + PController.EShock.ToString() + "초";
                    /*마법기사의 기절상태 지속시간 : 현재 기절상태 지속시간*/
                    FaintTime.text = "기절상태 지속시간 : " + PController.Faint.ToString() + "초";
                    /*마법기사의 넉백으로 미는 힘 : 현재 넉백으로 미는 힘*/
                    KnockBackPower.text = "넉백으로 미는 힘 : " + PController.KnockBack.ToString();
                }
            }
            //플레이어의 캐릭터가 마법사이면
            else if (GameObject.Find("Wizard(Clone)"))
            {
                //저장된 마법사의 X축 좌표가 있으면 실행한다.
                if (PlayerPrefs.HasKey("WizardX" + SaveID.saveID))
                {
                    /*마법사의 물리 공격력
                    강화전 : 이전 물리 공격력 → 강화후 : 현재 물리 공격력*/
                    Attack.text = "물리 공격력\n강화전 : " + PlayerPrefs.GetFloat("WizardAttack" + SaveID.saveID).ToString() + " → 강화후 : " + PController.ATK.ToString();
                    /*마법사의 마법 공격력
                    강화전 : 이전 마법 공격력 → 강화후 : 현재 마법 공격력*/
                    MagicAttack.text = "마법 공격력\n강화전 : " + PlayerPrefs.GetFloat("WizardMagic" + SaveID.saveID).ToString() + " → 강화후 : " + PController.MATk.ToString();
                    /*마법사의 최대HP
                    강화전 : 이전 최대 HP → 강화후 : 현재 최대 HP*/
                    MaxHP.text = "최대 HP\n강화전 : " + PlayerPrefs.GetFloat("WizardMaxHP" + SaveID.saveID).ToString() + " → 강화후 : " + PHUD.MaxHealth.ToString();
                    /*마법사의 최대MP
                    강화전 : 이전 최대 MP → 강화후 : 현재 최대 MP*/
                    MaxMP.text = "최대 MP\n강화전 : " + PlayerPrefs.GetFloat("WizardMaxMP" + SaveID.saveID).ToString() + " → 강화후 : " + PHUD.MaxMana.ToString();
                    /*마법사의 화상상태 데미지
                    강화전 : 이전 화상상태 데미지 → 강화후 : 현재 화상상태 데미지*/
                    BurnDMG.text = "화상상태 데미지\n강화전 : " + PlayerPrefs.GetFloat("WizardFireDamage" + SaveID.saveID).ToString() + " → 강화후 : " + PController.BurnDMG.ToString();
                    /*마법사의 화상상태 지속시간
                    강화전 : 이전 화상상태 지속시간 → 강화후 : 현재 화상상태 지속시간*/
                    BurnTime.text = "화상상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("WizardFireKeep" + SaveID.saveID).ToString() + "초 → 강화후 : " + PController.BurnTime.ToString() + "초";
                    /*마법사의 빙결상태 지속시간
                    강화전 : 이전 빙결상태 지속시간 → 강화후 : 현재 빙결상태 지속시간*/
                    FreezeTime.text = "빙결상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("WizardFreeze" + SaveID.saveID).ToString() + "초 → 강화후 : " + PController.Freeze.ToString() + "초";
                    /*마법사의 감전상태 지속시간
                    강화전 : 이전 감전상태 지속시간 → 강화후 : 현재 감전상태 지속시간*/
                    EShockTime.text = "감전상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("WizardElectric" + SaveID.saveID).ToString() + "초 → 강화후 : " + PController.EShock.ToString() + "초";
                    /*마법사의 기절상태 지속시간
                    강화전 : 이전 기절상태 지속시간 → 강화후 : 현재 기절상태 지속시간*/
                    FaintTime.text = "기절상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("WizardFaint" + SaveID.saveID).ToString() + "초 강화후 : " + PController.Faint.ToString() + "초";
                    /*마법사의 넉백으로 미는 힘
                    강화전 : 이전 넉백으로 미는 힘 → 강화후 : 현재 넉백으로 미는 힘*/
                    KnockBackPower.text = "넉백으로 미는 힘\n강화전 : " + PlayerPrefs.GetFloat("WizardKnockBack" + SaveID.saveID).ToString() + " → 강화후 : " + PController.KnockBack.ToString() + "초";
                }
                //저장된 마법사의 X축 좌표가 없으면 실행한다.
                else
                {
                    /*마법사의 물리 공격력 : 현재 물리 공격력*/
                    Attack.text = "물리 공격력 : " + PController.ATK.ToString();
                    /*마법사의 마법 공격력 : 현재 마법 공격력*/
                    MagicAttack.text = "마법 공격력 : " + PController.MATk.ToString();
                    /*마법사의 최대HP : 현재 최대 HP*/
                    MaxHP.text = "최대 HP : " + PHUD.MaxHealth.ToString();
                    /*마법사의 최대MP : 현재 최대 MP*/
                    MaxMP.text = "최대 MP : " + PHUD.MaxMana.ToString();
                    /*마법사의 화상상태 데미지 : 현재 화상상태 데미지*/
                    BurnDMG.text = "화상상태 데미지 : " + PController.BurnDMG.ToString();
                    /*마법사의 화상상태 지속시간 : 현재 화상상태 지속시간*/
                    BurnTime.text = "화상상태 지속시간 : " + PController.BurnTime.ToString() + "초";
                    /*마법사의 빙결상태 지속시간 : 현재 빙결상태 지속시간*/
                    FreezeTime.text = "빙결상태 지속시간 : " + PController.Freeze.ToString() + "초";
                    /*마법사의 감전상태 지속시간 : 현재 감전상태 지속시간*/
                    EShockTime.text = "감전상태 지속시간 : " + PController.EShock.ToString() + "초";
                    /*마법사의 기절상태 지속시간 : 현재 기절상태 지속시간*/
                    FaintTime.text = "기절상태 지속시간 : " + PController.Faint.ToString() + "초";
                    /*마법사의 넉백으로 미는 힘 : 현재 넉백으로 미는 힘*/
                    KnockBackPower.text = "넉백으로 미는 힘 : " + PController.KnockBack.ToString();
                }
            }
            //플레이어의 캐릭터가 엘프이면
            else if (GameObject.Find("Elf(Clone)"))
            {
                //저장된 엘프의 X축 좌표가 존재하면 실행한다.
                if (PlayerPrefs.HasKey("ElfX" + SaveID.saveID))
                {
                    /*엘프의 물리 공격력
                    강화전 : 이전 물리 공격력 → 강화후 : 현재 물리 공격력*/
                    Attack.text = "물리 공격력\n강화전 : " + PlayerPrefs.GetFloat("ElfAttack" + SaveID.saveID).ToString() + " → 강화후 : " + PController.ATK.ToString();
                    /*엘프의 마법 공격력
                    강화전 : 이전 마법 공격력 → 강화후 : 현재 마법 공격력*/
                    MagicAttack.text = "마법 공격력\n강화전 : " + PlayerPrefs.GetFloat("ElfMagic" + SaveID.saveID).ToString() + " → 강화후 : " + PController.MATk.ToString();
                    /*엘프의 최대HP
                    강화전 : 이전 최대 HP → 강화후 : 현재 최대 HP*/
                    MaxHP.text = "최대 HP\n강화전 : " + PlayerPrefs.GetFloat("ElfMaxHP" + SaveID.saveID).ToString() + " → 강화후 : " + PHUD.MaxHealth.ToString();
                    /*엘프의 최대MP
                    강화전 : 이전 최대 MP → 강화후 : 현재 최대 MP*/
                    MaxMP.text = "최대 MP\n강화전 : " + PlayerPrefs.GetFloat("ElfMaxMP" + SaveID.saveID).ToString() + " → 강화후 : " + PHUD.MaxMana.ToString();
                    /*엘프의 화상상태 데미지
                    강화전 : 이전 화상상태 데미지 → 강화후 : 현재 화상상태 데미지*/
                    BurnDMG.text = "화상상태 데미지\n강화전 : " + PlayerPrefs.GetFloat("ElfFireDamage" + SaveID.saveID).ToString() + " → 강화후 : " + PController.BurnDMG.ToString();
                    /*엘프의 화상상태 지속시간
                    강화전 : 이전 화상상태 지속시간 → 강화후 : 현재 화상상태 지속시간*/
                    BurnTime.text = "화상상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("ElfFireKeep" + SaveID.saveID).ToString() + "초 → 강화후 : " + PController.BurnTime.ToString() + "초";
                    /*엘프의 빙결상태 지속시간
                    강화전 : 이전 빙결상태 지속시간 → 강화후 : 현재 빙결상태 지속시간*/
                    FreezeTime.text = "빙결상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("ElfFreeze" + SaveID.saveID).ToString() + "초 → 강화후 : " + PController.Freeze.ToString() + "초";
                    /*엘프의 감전상태 지속시간
                    강화전 : 이전 감전상태 지속시간 → 강화후 : 현재 감전상태 지속시간*/
                    EShockTime.text = "감전상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("ElftElectric" + SaveID.saveID).ToString() + "초 → 강화후 : " + PController.EShock.ToString() + "초";
                    /*엘프의 기절상태 지속시간
                    강화전 : 이전 기절상태 지속시간 → 강화후 : 현재 기절상태 지속시간*/
                    FaintTime.text = "기절상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("ElfFaint" + SaveID.saveID).ToString() + "초 → 강화후 : " + PController.Faint.ToString() + "초";
                    /*엘프의 넉백으로 미는 힘
                    강화전 : 이전 넉백으로 미는 힘 → 강화후 : 현재 넉백으로 미는 힘*/
                    KnockBackPower.text = "넉백으로 미는 힘\n강화전 : " + PlayerPrefs.GetFloat("ElfKnockBack" + SaveID.saveID).ToString() + " → 강화후 : " + PController.KnockBack.ToString();
                }
                //저장된 엘프의 X축 좌표가 존재하지 않으면 실행한다.
                else
                {
                    /*엘프의 물리 공격력 : 현재 물리 공격력*/
                    Attack.text = "물리 공격력 : " + PController.ATK.ToString();
                    /*엘프의 마법 공격력 : 현재 마법 공격력*/
                    MagicAttack.text = "마법 공격력 : " + PController.MATk.ToString();
                    /*엘프의 최대HP : 현재 최대 HP*/
                    MaxHP.text = "최대 HP : " + PHUD.MaxHealth.ToString();
                    /*엘프의 최대MP : 현재 최대 MP*/
                    MaxMP.text = "최대 MP : " + PHUD.MaxMana.ToString();
                    /*엘프의 화상상태 데미지 : 현재 화상상태 데미지*/
                    BurnDMG.text = "화상상태 데미지 : " + PController.BurnDMG.ToString();
                    /*엘프의 화상상태 지속시간 : 현재 화상상태 지속시간*/
                    BurnTime.text = "화상상태 지속시간 : " + PController.BurnTime.ToString() + "초";
                    /*엘프의 빙결상태 지속시간 : 현재 빙결상태 지속시간*/
                    FreezeTime.text = "빙결상태 지속시간 : " + PController.Freeze.ToString() + "초";
                    /*엘프의 감전상태 지속시간 : 현재 감전상태 지속시간*/
                    EShockTime.text = "감전상태 지속시간 : " + PController.EShock.ToString() + "초";
                    /*엘프의 기절상태 지속시간 : 현재 기절상태 지속시간*/
                    FaintTime.text = "기절상태 지속시간 : " + PController.Faint.ToString() + "초";
                    /*엘프의 넉백으로 미는 힘 : 현재 넉백으로 미는 힘*/
                    KnockBackPower.text = "넉백으로 미는 힘 : " + PController.KnockBack.ToString();
                }
            }

            Minimap.SetActive(false);
            AttackText.SetActive(false);
            StatusButton.SetActive(false);
        }
        //활성화가 되어 있으면
        else
        {
            //비활성화 한다.
            Status.SetActive(false);
            //모든 오브젝트들이 움직인다.
            Time.timeScale = 1;
            Minimap.SetActive(true);
            AttackText.SetActive(true);
            StatusButton.SetActive(true);
        }
    }

    //메뉴창
    public void MenuActive()
    {
        //비활성화가 되어 있으면
        if (MenuSet.activeSelf==false)
        {
            //활성화 한다.
            MenuSet.SetActive(true);
            //모든 오브젝트들이 움직이지 않는다.
            Time.timeScale = 0;

            //미니맵을 비활성화 시킨다.
            Minimap.SetActive(false);
            //공격력 표시창을 비활성화 시킨다.
            AttackText.SetActive(false);
            //스테이터스 표시 버튼을 비활성화 시킨다.
            StatusButton.SetActive(false);
        }
        //활성화가 되어 있으면
        else
        {
            //비활성화 한다.
            MenuSet.SetActive(false);
            //모든 오브젝트들이 움직인다.
            Time.timeScale = 1;

            //미니맵을 활성화 시킨다.
            Minimap.SetActive(true);
            //공격력 표시창을 활성화 시킨다.
            AttackText.SetActive(true);
            //스테이터스 표시 버튼을 활성화 시킨다.
            StatusButton.SetActive(true);
        }
    }

    public void GameExit()
    {
        //플레이어의 캐릭터가 마법기사이면
        if (GameObject.Find("MagicKnight(Clone)"))
        {
            //해당슬롯에 마법기사의 X축 좌표를 저장한다.
            PlayerPrefs.SetFloat("MagicKnightX" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").transform.position.x);
            
            //해당슬롯에 마법기사의 Y축 좌표를 저장한다.
            PlayerPrefs.SetFloat("MagicKnightY" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").transform.position.y);
            
            //해당슬롯에 마법기사의 현재 물리 공격력 저장한다.
            PlayerPrefs.SetFloat("MagicKnightAttack" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerController>().attackDamage);
            
            //해당슬롯에 마법기사의 현재 마법 공격력 저장한다.
            PlayerPrefs.SetFloat("MagicKnightMagic" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerController>().MagicAttack);
            
            //해당슬롯에 마법기사의 최대 HP 값을 저장한다.
            PlayerPrefs.SetFloat("MagicKnightMaxHP" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerHUD>().MaxHealth);
            
            //해당슬롯에 마법기사의 최대 MP 값을 저장한다.
            PlayerPrefs.SetFloat("MagicKnightMaxMP" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerHUD>().MaxMana);
            
            //해당슬롯에 마법기사의 현재 HP를 저장한다.
            PlayerPrefs.SetFloat("MagicKnightCurHPStrength" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerHUD>().curHP);
            
            //해당슬롯에 마법기사의 현재 MP를 저장한다.
            PlayerPrefs.SetFloat("MagicKnightCurMPStrength" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerHUD>().curMP);
            
            //해당슬롯에 마법기사의 화상상태 데미지를 저장한다.
            PlayerPrefs.SetFloat("MagicKnightFireDamage" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerController>().FireDamage);
            
            //해당슬롯에 마법기사의 화상상태 지속시간을 저장한다.
            PlayerPrefs.SetFloat("MagicKnightFireKeep" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerController>().FireKeeping);
            
            //해당슬롯에 마법기사의 빙결상태 지속시간을 저장한다.
            PlayerPrefs.SetFloat("MagicKnightFreeze" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerController>().KeepFreeze);
            
            //해당슬롯에 마법기사의 감전상태 지속시간을 저장한다.
            PlayerPrefs.SetFloat("MagicKnightElectric" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerController>().KeepElectric);
            
            //해당슬롯에 마법기사의 기절상태 지속시간을 저장한다.
            PlayerPrefs.SetFloat("MagicKnightFaint" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerController>().KeepFaint);
            
            //해당슬롯에 마법기사의 넉백으로 밀어내는 힘을 저장한다.
            PlayerPrefs.SetFloat("MagicKnightKnockBack" + SaveID.saveID, GameObject.Find("MagicKnight(Clone)").GetComponent<PlayerController>().ForceKnockback);
        }

        //플레이어의 캐릭터가 마법사이면
        else if (GameObject.Find("Wizard(Clone)"))
        {
            //현재슬롯에 마법사의 X축 좌표를 저장한다.
            PlayerPrefs.SetFloat("WizardX" + SaveID.saveID, GameObject.Find("Wizard(Clone)").transform.position.x);
            
            //해당슬롯에 마법사의 Y축 좌표를 저장한다.
            PlayerPrefs.SetFloat("WizardY" + SaveID.saveID, GameObject.Find("Wizard(Clone)").transform.position.y);
            
            //해당슬롯에 마법사의 현재 물리 공격력을 저장한다.
            PlayerPrefs.SetFloat("WizardAttack" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerController>().attackDamage);
            
            //해당슬롯에 마법사의 현재 마법 공격력을 저장한다.
            PlayerPrefs.SetFloat("WizardMagic" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerController>().MagicAttack);
            
            //해당슬롯에 마법사의 최대 HP를 저장한다.
            PlayerPrefs.SetFloat("WizardMaxHP" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerHUD>().MaxHealth);
            
            //해당슬롯에 마법사의 최대 MP를 저장한다.
            PlayerPrefs.SetFloat("WizardMaxMP" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerHUD>().MaxMana);
            
            //해당슬롯에 마법사의 현재 HP를 저장한다.
            PlayerPrefs.SetFloat("WizardCurHPStrength" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerHUD>().curHP);
            
            //해당슬롯에 마법사의 현재 MP를 저장한다.
            PlayerPrefs.SetFloat("WizardCurMPStrength" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerHUD>().curMP);

            //해당슬롯에 마법사의 화상상태 데미지를 저장한다.
            PlayerPrefs.SetFloat("WizardFireDamage" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerController>().FireDamage);
            
            //해당슬롯에 마법사의 화상상태 지속시간을 저장한다.
            PlayerPrefs.SetFloat("WizardFireKeep" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerController>().FireKeeping);
            
            //해당슬롯에 마법사의 빙결상태 지속시간을 저장한다.
            PlayerPrefs.SetFloat("WizardFreeze" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerController>().KeepFreeze);
            
            //해당슬롯에 마법사의 감전상태 지속시간을 저장한다.
            PlayerPrefs.SetFloat("WizardElectric" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerController>().KeepElectric);
            
            //해당슬롯에 마법사의 기절상태 지속시간을 저장한다.
            PlayerPrefs.SetFloat("WizardFaint" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerController>().KeepFaint);
            
            //해당슬롯에 마법사의 넉백으로 밀어내는 힘을 저장한다.
            PlayerPrefs.SetFloat("WizardKnockBack" + SaveID.saveID, GameObject.Find("Wizard(Clone)").GetComponent<PlayerController>().ForceKnockback);
        }

        //플레이어의 캐릭터가 엘프이면
        else if (GameObject.Find("Elf(Clone)"))
        {
            //해당슬롯에 엘프의 X축 좌표를 저장한다.
            PlayerPrefs.SetFloat("ElfX" + SaveID.saveID, GameObject.Find("Elf(Clone)").transform.position.x);
            
            //해당슬롯에 엘프의 Y축 좌표를 저장한다.
            PlayerPrefs.SetFloat("ElfY" + SaveID.saveID, GameObject.Find("Elf(Clone)").transform.position.y);
            
            //해당슬롯에 엘프의 현재 물리 공격력을 저장한다.
            PlayerPrefs.SetFloat("ElfAttack" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerController>().attackDamage);
            
            //해당슬롯에 엘프의 현재 마법 공격력을 저장한다.
            PlayerPrefs.SetFloat("ElfMagic" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerController>().MagicAttack);
            
            //해당슬롯에 엘프의 최대 HP를 저장한다.
            PlayerPrefs.SetFloat("ElfMaxHP" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerHUD>().MaxHealth);
            
            //해당솔롯에 엘프의 최대 MP를 저장한다.
            PlayerPrefs.SetFloat("ElfMaxMP" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerHUD>().MaxMana);
            
            //해당슬롯에 엘프의 현재 HP를 저장한다.
            PlayerPrefs.SetFloat("ElfCurHPStrength" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerHUD>().curHP);
            
            //해당슬롯에 엘프의 현재 MP를 저장한다.
            PlayerPrefs.SetFloat("ElfCurMPStrength" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerHUD>().curMP);

            //해당슬롯에 엘프의 화상상태 데미지를 저장한다.
            PlayerPrefs.SetFloat("ElfFireDamage" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerController>().FireDamage);
            
            //해당슬롯에 엘프의 화상상태 지속시간을 저장한다.
            PlayerPrefs.SetFloat("ElfFireKeep" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerController>().FireKeeping);
            
            //해당슬롯에 엘프의 빙결상태 지속시간을 저장한다.
            PlayerPrefs.SetFloat("ElfFreeze" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerController>().KeepFreeze);
            
            //해당슬롯에 엘프의 감전상태 지속시간을 저장한다.
            PlayerPrefs.SetFloat("ElftElectric" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerController>().KeepElectric);
            
            //해당슬롯에 엘프의 기절상태 지속시간을 저장한다.
            PlayerPrefs.SetFloat("ElfFaint" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerController>().KeepFaint);
            
            //해당슬롯에 엘프의 넉백으로 밀어내는 힘을 저장한다.
            PlayerPrefs.SetFloat("ElfKnockBack" + SaveID.saveID, GameObject.Find("Elf(Clone)").GetComponent<PlayerController>().ForceKnockback);
        }
        PlayerPrefs.SetInt("SlotSaved" + SaveID.saveID, 1);
        PlayerPrefs.SetInt("LoadSaved" + SaveID.saveID, 1);
        PlayerPrefs.SetInt("SavedScene" + SaveID.saveID, SceneManager.GetActiveScene().buildIndex);

        //해당 슬롯에 위의 데이터들을 저장한다.
        PlayerPrefs.Save();
        Debug.Log("해당슬롯에 기록이 저장되었습니다.");
        SceneManager.LoadScene("Main");
    }

    public void SceneMove(string SceneName)
    {
        //SceneName이름의 씬으로 이동한다.
        SceneManager.LoadScene(SceneName);
    }

    public void QuitGame()
    {
        //게임을 종료한다.
        Application.Quit();
    }
}