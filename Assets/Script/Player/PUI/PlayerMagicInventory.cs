using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMagicInventory : MonoBehaviour
{
    public MagicSlotUI[] magicslotUI;

    public List<GameObject> allMagicInPosession;

    //사용할 마법의 순번은 -1 즉 어떤 마법도 사용하지 않는다.
    public int currentMagicIndex = -1;

    //[HideInInspector]
    public GameObject currentWeapon;

    private PlayerMagic PM;

    void Awake() // 스크립트 실행순서 문제로 변수가 준비되지 않아서 Start -> Awake로 변경
    {
        //처음 마법 슬롯은 전부 어두운 색으로 세팅된다.
        //magicslotUI[currentMagicIndex].MagicImage.color = Color.gray;
        //마법 슬롯 별로 MagicSlotUI 컴포넌트에 접근한다.        
        magicslotUI[0] = GameObject.Find("Canvas").transform.Find("MagicPanel").transform.Find("FireMagicSlotPanel1").GetComponent<MagicSlotUI>();
        magicslotUI[1] = GameObject.Find("Canvas").transform.Find("MagicPanel").transform.Find("FireMagicSlotPanel2").GetComponent<MagicSlotUI>();
        magicslotUI[2] = GameObject.Find("Canvas").transform.Find("MagicPanel").transform.Find("AquaMagicSlotPanel1").GetComponent<MagicSlotUI>();
        magicslotUI[3] = GameObject.Find("Canvas").transform.Find("MagicPanel").transform.Find("AquaMagicSlotPanel2").GetComponent<MagicSlotUI>();
        magicslotUI[4] = GameObject.Find("Canvas").transform.Find("MagicPanel").transform.Find("ThunderMagicSlotPanel1").GetComponent<MagicSlotUI>();
        magicslotUI[5] = GameObject.Find("Canvas").transform.Find("MagicPanel").transform.Find("ThunderMagicSlotPanel2").GetComponent<MagicSlotUI>();
        magicslotUI[6] = GameObject.Find("Canvas").transform.Find("MagicPanel").transform.Find("EarthMagicSlotPanel1").GetComponent<MagicSlotUI>();
        magicslotUI[7] = GameObject.Find("Canvas").transform.Find("MagicPanel").transform.Find("EarthMagicSlotPanel2").GetComponent<MagicSlotUI>();
        magicslotUI[8] = GameObject.Find("Canvas").transform.Find("MagicPanel").transform.Find("WindMagicSlotPanel1").GetComponent<MagicSlotUI>();
        magicslotUI[9] = GameObject.Find("Canvas").transform.Find("MagicPanel").transform.Find("WindMagicSlotPanel2").GetComponent<MagicSlotUI>();

        //맨 처음 마법이 선택되어 있다.
        currentWeapon = allMagicInPosession[default];
        //선택된 첫번째 슬롯의 오브젝트는 활성화 된다.
        //magicslotUI[0].MagicImage.color = Color.white;

        PM = this.GetComponent<PlayerMagic>();
    }

    // Update is called once per frame
    void Update()
    {
        TrySwitchMagic();
    }

    private void TrySwitchMagic()
    {
        int MagicIndexToGoTo = currentMagicIndex;
        //q또는 Q키를 누르면
        if(Input.GetKeyDown(KeyCode.Q))
        {
            //이전 무기를 선택한다.
            MagicIndexToGoTo--;
        }
        //e또는 E키를 누르면
        else if(Input.GetKeyDown(KeyCode.E))
        {
            //다음 무기를 선택한다.
            MagicIndexToGoTo++;
        }

        /*만약 MagicIndexToGoTo값이 0보다 적거나
         allMagicInPosesion.Length값이랑 같거나
        currentMagicIndex랑 같으면 움직이지 않는다.*/
        if (MagicIndexToGoTo<0
            ||MagicIndexToGoTo==allMagicInPosession.Count
            ||MagicIndexToGoTo==currentMagicIndex)
        {
            return;
        }

        //currentWeapon은 MagicIndexToGoTo의 값을 가진다.
        currentWeapon = allMagicInPosession[MagicIndexToGoTo];
        currentMagicIndex = MagicIndexToGoTo;
    }
    
    //버튼클릭으로 생성할 마법 바꾸기
    public void MagicChange(int magicIndex)
    {
        //해당 슬롯이 선택되어 있지 않으면
        if (currentMagicIndex != magicIndex)
        {
            //존재하는 슬롯이면
            if (currentMagicIndex != -1)
            {
                //이전에 선택된 마법 이미지의 색은 어둡게 된다.
                magicslotUI[currentMagicIndex].MagicImage.color = Color.gray;
            }
            //현재 선택된 마법 이미지의 색은 밝게 된다.
            magicslotUI[magicIndex].MagicImage.color = Color.white;

            //현재 사용하는 마법은 선택된 슬롯의 마법을 사용한다.
            currentWeapon = allMagicInPosession[magicIndex];
            //마법 순서는 현재 선택된 슬롯의 순번이 된다.
            currentMagicIndex = magicIndex;

            PM.SetMagicNum(currentMagicIndex);
        }
        else  //선택되어 있는 슬롯을 터치하면
        {
            //어둡게 변한다.
            magicslotUI[magicIndex].MagicImage.color = Color.gray;

            //어떤 마법이든 사용되지 않는다.
            currentWeapon = null;
            //마법 순서는 포함되지 않는다.
            currentMagicIndex = -1;
        }
    }
}
