using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPViewer : MonoBehaviour
{
    /*
     * ������
     * ��ũ��Ʈ ���� ���� ������ LateStart() �Լ� �߰� -> LateStart()�� Start()���� 1������ �Ŀ� �����ϵ��� ���� Start()�� Invoke�� �ֱ�
     * canUpdate ���� �߰� -> �̰� True�� ���� Update()�� �۵�. -> �̰� �� �ֳ��� Update()�� LateStart() ���� ���Ŀ� �۵��ǵ��� ������ �ϱ� �����Դϴ�.
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
