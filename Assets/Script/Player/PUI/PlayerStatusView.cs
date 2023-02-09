using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusView : MonoBehaviour
{
    private PlayerController PController;   //PlayerController 스크립트의 정보를 가져오기 위해 선언한다.
    private PlayerHUD PHUD;                 //PlayerHUD 스크립트의 정보를 가져오기 위해 선언한다.
    private Text Status;                    //Text 컴포넌트의 정보를 가져오기 위해 선언한다.
    // Start is called before the first frame update
    void Start()
    {
        PController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();    //PlayerController 스크립트를 재정의 한다.
        PHUD = GameObject.FindWithTag("Player").GetComponent<PlayerHUD>();                  //PlayerHUD 스크립트를 저정의 한다.
        Status=GetComponent<Text>();                                                        //Text컴포넌트를 재정의 한다.
    }

    // Update is called once per frame
    void Update()
    {
        //현재 이 오브젝트의 이름에 따라서 표시가 달라진다.
        switch (this.gameObject.name)
        {
            //이 게임오브젝트의 이름이 Attack이면
            case "Attack":
                //직업에 따라 계산하는 값이 달라진다.
                //플레이어가 마법기사이면
                if (GameObject.Find("MagicKnight(Clone)"))
                {
                    /*마법기사의 물리 공격력
                    강화전 : 이전 물리 공격력 → 강화후 : 현재 물리 공격력*/
                    Status.text = "물리 공격력\n강화전 : " + PlayerPrefs.GetFloat("MagicKnightAttack" + SaveID.saveID).ToString() + " → 강화후 : " + PController.ATK.ToString();
                }
                //플레이어가 마법사이면
                else if (GameObject.Find("Wizard(Clone)"))
                {
                    /*마법사의 물리 공격력
                    강화전 : 이전 물리 공격력 → 강화후 : 현재 물리 공격력*/
                    Status.text = "물리 공격력\n강화전 : " + PlayerPrefs.GetFloat("WizardAttack" + SaveID.saveID).ToString() + " → 강화후 : " + PController.ATK.ToString();
                }
                //플레이어가 엘프이면
                else if (GameObject.Find("Elf(Clone"))
                {
                    /*엘프의 물리 공격력
                    강화전 : 이전 물리 공격력 → 강화후 : 현재 물리 공격력*/
                    Status.text = "물리 공격력\n강화전 : " + PlayerPrefs.GetFloat("ElfAttack" + SaveID.saveID).ToString() + " → 강화후 : " + PController.ATK.ToString();
                }
                break;
            //이 게임오브젝트의 이름이 MagicAttack이면
            case "MagicAttack":
                //직업에 따라 계산하는 값이 달라진다.
                //플레이어가 마법기사이면
                if (GameObject.Find("MagicKnight(Clone)"))
                {
                    /*마법기사의 마법 공격력
                    강화전 : 이전 마법 공격력 → 강화후 : 현재 마법 공격력*/
                    Status.text = "마법 공격력\n강화전 : " + PlayerPrefs.GetFloat("MagicKnightMagic" + SaveID.saveID).ToString() + " → 강화후 : " + PController.MATk.ToString();
                }
                //플레이어가 마법사이면
                else if (GameObject.Find("Wizard(Clone)"))
                {
                    /*마법사의 마법 공격력
                    강화전 : 이전 마법 공격력 → 강화후 : 현재 마법 공격력*/
                    Status.text = "마법 공격력\n강화전 : " + PlayerPrefs.GetFloat("WizardMagic" + SaveID.saveID).ToString() + " → 강화후 : " + PController.MATk.ToString();
                }
                //플레이어가 엘프이면
                else if (GameObject.Find("Elf(Clone"))
                {
                    /*엘프의 마법 공격력
                    강화전 : 이전 마법 공격력 → 강화후 : 현재 마법 공격력*/
                    Status.text = "마법 공격력\n강화전 : " + PlayerPrefs.GetFloat("ElfMagic" + SaveID.saveID).ToString() + " → 강화후 : " + PController.MATk.ToString();
                }
                break;
            //이 게임오브젝트의 이름이 MaxHP이면
            case "MaxHP":
                //직업에 따라 계산하는 값이 달라진다.
                //플레이어가 마법기사이면
                if (GameObject.Find("MagicKnight(Clone)"))
                {
                    /*마법기사의 최대 HP
                    강화전 : 이전 최대 HP → 강화후 : 현재 최대 HP*/
                    Status.text = "최대 HP\n강화전 : " + PlayerPrefs.GetFloat("MagicKnightMaxHP" + SaveID.saveID).ToString() + " → 강화후 : " + PHUD.MaxHealth.ToString();
                }
                //플레이어가 마법사이면
                else if (GameObject.Find("Wizard(Clone)"))
                {
                    /*마법사의 최대 HP
                    강화전 : 이전 최대 HP → 강화후 : 현재 최대 HP*/
                    Status.text = "최대 HP\n강화전 : " + PlayerPrefs.GetFloat("WizardMaxHP" + SaveID.saveID).ToString() + " → 강화후 : " + PHUD.MaxHealth.ToString();
                }
                //플레이어가 엘프이면
                else if (GameObject.Find("Elf(Clone"))
                {
                    /*엘프의 최대 HP
                    강화전 : 이전 최대 HP → 강화후 : 현재 최대 HP*/
                    Status.text = "최대 HP\n강화전 : " + PlayerPrefs.GetFloat("ElfMaxHP" + SaveID.saveID).ToString() + " → 강화후 : " + PHUD.MaxHealth.ToString();
                }
                break;
            //이 게임오브젝트의 이름이 MaxMP이면
            case "MaxMP":
                //직업에 따라 계산하는 값이 달라진다.
                //플레이어가 마법기사이면
                if (GameObject.Find("MagicKnight(Clone)"))
                {
                    /*마법기사의 최대 MP
                    강화전 : 이전 최대 MP → 강화후 : 현재 최대 MP*/
                    Status.text = "최대 MP\n강화전 : " + PlayerPrefs.GetFloat("MagicKnightMaxMP" + SaveID.saveID).ToString() + " → 강화후 : " + PHUD.MaxMana.ToString();
                }
                //플레이어가 마법사이면
                else if (GameObject.Find("Wizard(Clone)"))
                {
                    /*마법사의 최대 MP
                    강화전 : 이전 최대 MP → 강화후 : 현재 최대 MP*/
                    Status.text = "최대 MP\n강화전 : " + PlayerPrefs.GetFloat("WizardMaxMP" + SaveID.saveID).ToString() + " → 강화후 : " + PHUD.MaxMana.ToString();
                }
                //플레이어가 엘프이면
                else if (GameObject.Find("Elf(Clone"))
                {
                    /*엘프의 최대 MP
                    강화전 : 이전 최대 MP → 강화후 : 현재 최대 MP*/
                    Status.text = "최대 MP\n강화전 : " + PlayerPrefs.GetFloat("ElfMaxMP" + SaveID.saveID).ToString() + " → 강화후 : " + PHUD.MaxMana.ToString();
                }
                break;
            //이 게임오브젝트의 이름이 BurnDMG이면
            case "BurnDMG":
                //직업에 따라 계산하는 값이 달라진다.
                //플레이어가 마법기사이면
                if (GameObject.Find("MagicKnight(Clone)"))
                {
                    /*마법기사의 화상상태 데미지
                    강화전 : 이전 화상상태 데미지 → 강화후 : 현재 화상상태 데미지*/
                    Status.text = "화상상태 데미지\n강화전 : " + PlayerPrefs.GetFloat("MagicKnightFireDamage" + SaveID.saveID).ToString() + " → 강화후 : " + PController.BurnDMG.ToString();
                }
                //플레이어가 마법사이면
                else if (GameObject.Find("Wizard(Clone)"))
                {
                    /*마법사의 화상상태 데미지
                    강화전 : 이전 화상상태 데미지 → 강화후 : 현재 화상상태 데미지*/
                    Status.text = "화상상태 데미지\n강화전 : " + PlayerPrefs.GetFloat("WizardFireDamage" + SaveID.saveID).ToString() + " → 강화후 : " + PController.BurnDMG.ToString();
                }
                //플레이어가 엘프이면
                else if (GameObject.Find("Elf(Clone"))
                {
                    /*엘프의 화상상태 데미지
                    강화전 : 이전 화상상태 데미지 → 강화후 : 현재 화상상태 데미지*/
                    Status.text = "화상상태 데미지\n강화전 : " + PlayerPrefs.GetFloat("ElfFireDamage" + SaveID.saveID).ToString() + " → 강화후 : " + PController.BurnDMG.ToString();
                }
                break;
            case "BurnTime":
                //직업에 따라 계산하는 값이 달라진다.
                //플레이어가 마법기사이면
                if (GameObject.Find("MagicKnight(Clone)"))
                {
                    /*마법기사의 화상상태 지속시간
                    강화전 : 이전 화상상태 지속시간 → 강화후 : 현재 화상상태 지속시간*/
                    Status.text = "화상상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("MagicKnightFireKeep" + SaveID.saveID).ToString() + " → 강화후 : " + PController.BurnTime.ToString();
                }
                //플레이어가 마법사이면
                else if (GameObject.Find("Wizard(Clone)"))
                {
                    /*마법사의 화상상태 지속시간
                    강화전 : 이전 화상상태 지속시간 → 강화후 : 현재 화상상태 지속시간*/
                    Status.text = "화상상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("WizardFireKeep" + SaveID.saveID).ToString() + " → 강화후 : " + PController.BurnTime.ToString();
                }
                //플레이어가 엘프이면
                else if (GameObject.Find("Elf(Clone"))
                {
                    /*엘프의 화상상태 지속시간
                    강화전 : 이전 화상상태 지속시간 → 강화후 : 현재 화상상태 지속시간*/
                    Status.text = "화상상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("ElfFireKeep" + SaveID.saveID).ToString() + " → 강화후 : " + PController.BurnTime.ToString();
                }
                break;
            case "FreezeTime":
                //직업에 따라 계산하는 값이 달라진다.
                //플레이어가 마법기사이면
                if (GameObject.Find("MagicKnight(Clone)"))
                {
                    /*마법기사의 빙결상태 지속시간
                    강화전 : 이전 빙결상태 지속시간 → 강화후 : 현재 빙결상태 지속시간*/
                    Status.text = "빙결상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("MagicKnightFreeze" + SaveID.saveID).ToString() + " → 강화후 : " + PController.Freeze.ToString();
                }
                //플레이어가 마법사이면
                else if (GameObject.Find("Wizard(Clone)"))
                {
                    /*마법사의 빙결상태 지속시간
                    강화전 : 이전 빙결상태 지속시간 → 강화후 : 현재 빙결상태 지속시간*/
                    Status.text = "빙결상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("WizardFreeze" + SaveID.saveID).ToString() + " → 강화후 : " + PController.Freeze.ToString();
                }
                //플레이어가 엘프이면
                else if (GameObject.Find("Elf(Clone"))
                {
                    /*엘프의 빙결상태 지속시간
                    강화전 : 이전 빙결상태 지속시간 → 강화후 : 현재 빙결상태 지속시간*/
                    Status.text = "빙결상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("ElfFreeze" + SaveID.saveID).ToString() + " → 강화후 : " + PController.Freeze.ToString();
                }
                break;
            case "EShockTime":
                //직업에 따라 계산하는 값이 달라진다.
                //플레이어가 마법기사이면
                if (GameObject.Find("MagicKnight(Clone)"))
                {
                    /*마법기사의 감전상태 지속시간
                    강화전 : 이전 감전상태 지속시간 → 강화후 : 현재 감전상태 지속시간*/
                    Status.text = "감전상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("MagicKnightElectric" + SaveID.saveID).ToString() + " → 강화후 : " + PController.EShock.ToString();
                }
                //플레이어가 마법사이면
                else if (GameObject.Find("Wizard(Clone)"))
                {
                    /*마법사의 감전상태 지속시간
                    강화전 : 이전 감전상태 지속시간 → 강화후 : 현재 감전상태 지속시간*/
                    Status.text = "감전상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("WizardElectric" + SaveID.saveID).ToString() + " → 강화후 : " + PController.EShock.ToString();
                }
                //플레이어가 엘프이면
                else if (GameObject.Find("Elf(Clone"))
                {
                    /*엘프의 감전상태 지속시간
                    강화전 : 이전 감전상태 지속시간 → 강화후 : 현재 감전상태 지속시간간*/
                    Status.text = "감전상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("ElftElectric" + SaveID.saveID).ToString() + " → 강화후 : " + PController.EShock.ToString();
                }
                break;
            case "FaintTime":
                //직업에 따라 계산하는 값이 달라진다.
                //플레이어가 마법기사이면
                if (GameObject.Find("MagicKnight(Clone)"))
                {
                    /*마법기사의 기절상태 지속시간
                    강화전 : 이전 기절상태 지속시간 → 강화후 : 현재 기절상태 지속시간*/
                    Status.text = "화상상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("MagicKnightFreeze" + SaveID.saveID).ToString() + " → 강화후 : " + PController.Faint.ToString();
                }
                //플레이어가 마법사이면
                else if (GameObject.Find("Wizard(Clone)"))
                {
                    /*마법사의 기절상태 지속시간
                    강화전 : 이전 기절상태 지속시간 → 강화후 : 현재 기절상태 지속시간*/
                    Status.text = "화상상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("WizardFreeze" + SaveID.saveID).ToString() + " → 강화후 : " + PController.Faint.ToString();
                }
                //플레이어가 엘프이면
                else if (GameObject.Find("Elf(Clone"))
                {
                    /*엘프의 기절상태 지속시간
                    강화전 : 이전 기절상태 지속시간 → 강화후 : 현재 기절상태 지속시간*/
                    Status.text = "화상상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("ElfFreeze" + SaveID.saveID).ToString() + " → 강화후 : " + PController.Faint.ToString();
                }
                break;
            case "KnockBackPower":
                //직업에 따라 계산하는 값이 달라진다.
                //플레이어가 마법기사이면
                if (GameObject.Find("MagicKnight(Clone)"))
                {
                    /*마법기사의 넉백으로 미는 힘
                    강화전 : 이전 넉백으로 미는 힘 → 강화후 : 현재 넉백으로 미는 힘*/
                    Status.text = "화상상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("MagicKnightFreeze" + SaveID.saveID).ToString() + " → 강화후 : " + PController.KnockBack.ToString();
                }
                //플레이어가 마법사이면
                else if (GameObject.Find("Wizard(Clone)"))
                {
                    /*마법사의 넉백으로 미는 힘
                    강화전 : 이전 넉백으로 미는 힘 → 강화후 : 현재 넉백으로 미는 힘*/
                    Status.text = "화상상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("WizardFreeze" + SaveID.saveID).ToString() + " → 강화후 : " + PController.KnockBack.ToString();
                }
                //플레이어가 엘프이면
                else if (GameObject.Find("Elf(Clone"))
                {
                    /*엘프의 넉백으로 미는 힘
                    강화전 : 이전 넉백으로 미는 힘 → 강화후 : 현재 넉백으로 미는 힘*/
                    Status.text = "화상상태 지속시간\n강화전 : " + PlayerPrefs.GetFloat("ElfFreeze" + SaveID.saveID).ToString() + " → 강화후 : " + PController.KnockBack.ToString();
                }
                break;
        }
    }
}
