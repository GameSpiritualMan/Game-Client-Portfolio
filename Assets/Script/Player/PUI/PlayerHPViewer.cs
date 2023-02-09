using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPViewer : MonoBehaviour
{
    /*
     * 변경점
     * 스크립트 실행 순서 조정용 LateStart() 함수 추가 -> LateStart()는 Start()보다 1프레임 후에 실행하도록 기존 Start()에 Invoke를 주기
     * canUpdate 변수 추가 -> 이게 True일 때만 Update()가 작동. -> 이게 왜 있나면 Update()를 LateStart() 실행 이후에 작동되도록 만들어야 하기 때문입니다.
     */
    private PlayerHUD playerHP;
    private Slider sliderHP;
    private bool canUpdate = false;

    private void Start()
    {
        Invoke("LateStart", Time.deltaTime);
        //playerHP = GameObject.FindWithTag("Player").GetComponent<PlayerHUD>();
        //sliderHP = GetComponent<Slider>();
    }

    void LateStart()
    {
        playerHP = GameObject.FindWithTag("Player").GetComponent<PlayerHUD>();
        sliderHP = GetComponent<Slider>();
        canUpdate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canUpdate == false)
            return;

        sliderHP.value = playerHP.curHP / playerHP.MaxHP;
    }
}
