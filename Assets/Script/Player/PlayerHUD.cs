using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHUD : MonoBehaviour
{
    public float MaxHP;                 //최대 체력
    public float MaxMP;                 //최대 마력

    [HideInInspector]
    public float currentHP;            //현재 체력

    [HideInInspector]
    public float currentMP;            //현재 마력

    public float MaxHealth => MaxHP;    //MaxHP에 접근할 수 있는 프로퍼티(get만 가능)
    public float curHP => currentHP;    //currentHP에 접근할 수 있는 프로퍼티(get만 가능)
    public float MaxMana => MaxMP;      //MaxMP에 접근할 수 있는 프로퍼티(get만 가능)
    public float curMP => currentMP;    //currentHP에 접근할 수 있는 프로퍼티(get만 가능)



    private SpriteRenderer sprite;
    private void Start()
    {
        currentHP = MaxHP;              //현재 체력은 최대 체력과 같게 설정한다.
        currentMP = MaxMP;              //현재 마력은 최대 마력과 같게 설정한다.
        
        sprite = GetComponent<SpriteRenderer>();


        //해당슬롯에 저장이 되어 있으면
        if(PlayerPrefs.GetInt("LoadSaved" + SaveID.saveID) == 1)
        {
            //마법기사의 X축 좌표값이 저장되어 있으면
            if (PlayerPrefs.HasKey("MagicKnightX" + SaveID.saveID))
            {
                //해당슬롯에 저장된 마법기사의 최대HP를 불러온다.
                MaxHP = PlayerPrefs.GetFloat("MagicKnightMaxHP" + SaveID.saveID);
                
                //해당슬롯에 저장된 마법기사의 최대MP를 불러온다.
                MaxMP = PlayerPrefs.GetFloat("MagicKnightMaxMP" + SaveID.saveID);
                
                //해당슬롯에 저장된 마법기사의 현재HP를 불러온다.
                currentHP = PlayerPrefs.GetFloat("MagicKnightCurHPStrength" + SaveID.saveID);
                
                //해당슬롯에 저장된 마법기사의 현재MP를 불러온다.
                currentMP = PlayerPrefs.GetFloat("MagicKnightCurMPStrength" + SaveID.saveID);
            }
            //마법사의 X축 좌표값이 저장되어 있으면
            else if (PlayerPrefs.HasKey("WizardX" + SaveID.saveID))
            {
                //해당슬롯에 저장된 마법사의 최대HP를 불러온다.
                MaxHP = PlayerPrefs.GetFloat("WizardMaxHP" + SaveID.saveID);
                
                //해당슬롯에 저장된 마법사의 최대MP를 불러온다.
                MaxMP = PlayerPrefs.GetFloat("WizardMaxMP" + SaveID.saveID);
                
                //해당슬롯에 저장된 마법사의 현재HP를 불러온다.
                currentHP = PlayerPrefs.GetFloat("WizardCurHPStrength" + SaveID.saveID);
                
                //해당슬롯에 저장된 마법사의 현재MP를 불러온다.
                currentMP = PlayerPrefs.GetFloat("WizardCurMPStrength" + SaveID.saveID);
            }
            //엘프의 X축 좌표값이 저장되어 있으면
            else if (PlayerPrefs.HasKey("ElfX" + SaveID.saveID))
            {
                //해당슬롯에 저장된 엘프의 최대HP를 불러온다.
                MaxHP = PlayerPrefs.GetFloat("ElfMaxHP" + SaveID.saveID);
                
                //해당슬롯에 저장된 엘프의 최대MP를 불러온다.
                MaxMP = PlayerPrefs.GetFloat("ElfMaxMP" + SaveID.saveID);
                
                //해당슬롯에 저장된 엘프의 현재HP를 불러온다.
                currentHP = PlayerPrefs.GetFloat("ElfCurHPStrength" + SaveID.saveID);
                
                //해당슬롯에 저장된 엘프의 현재MP를 불러온다.
                currentMP = PlayerPrefs.GetFloat("ElfCurMPStrength" + SaveID.saveID);
            }
        }
    }

    public void TakeDamage(float Damage)
    {
        //현재 체력값은 Damage만큼씩 감소한다.
        currentHP -= Damage;
        //현재 체력값이 0이하이면
        if(currentHP<=0)
        {
            //BadEnding씬으로 이동한다.
            SceneManager.LoadScene("BadEnding");
        }
    }
    
    //마법을 사용할때
    public void useMagic(float useMP)
    {
        //현재 마력이 사용할 마력보다 크거나 같으면
        if(currentMP>=useMP)
        {
            //현재 마력은 사용할 마력만큼 감소한다.
            currentMP -= useMP;
        }
    }

    //HP회복
    public void HealHP(float healhp)
    {
        //현재 HP은 healhp만큼 회복한다.
        currentHP += healhp;
        //현재 HP가 최대 HP보다 크면
        if(currentHP>=MaxHP)
        {
            //현재 HP는 최대HP만큼 채워진다.
            currentHP = MaxHP;
        }
    }

    //MP회복
    public void HealMP(float healmp)
    {

        //현재MP는 healmp만큼 회복한다.
        currentMP += healmp;
        //현재 MP가 최대 MP보다 크면
        if(currentMP>=MaxMP)
        {
            //현재 MP는 최대MP만큼 채워진다.
            currentMP = MaxMP;
        }
    }

    //가질수 있는 최대 HP가 증가한다.
    public void StrengthHP(float StrengthHP)
    {
        //최대 HP값은 StrengthHP만큼 증가한다.
        MaxHP += StrengthHP;
    }

    //가질수 있는 최대 MP가 증가한다.
    public void StrengthMP(float StrengthMP)
    {
        //최대 MP값은 StrengthMP만큼 증가한다.
        MaxMP += StrengthMP;
    }

    //몬스터로부터 피격을 받으면
    public IEnumerator DamageDelay()
    {
        //플레이어는 어두운 색으로 변한다.
        sprite.color = Color.gray;
        //딜레이 상태가 된다.
        this.gameObject.layer = 6;
        //5초뒤
        yield return new WaitForSeconds(5f);
        //플레이어는 원래의 색으로 변한다.
        sprite.color = Color.white;
        //원래 레이어로 돌아온다.
        this.gameObject.layer = 3;
    }
}