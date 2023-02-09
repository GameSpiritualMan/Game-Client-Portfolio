using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PMPText : MonoBehaviour
{
    private PlayerHUD playerMP;
    private Text textMP;
    //Update()�� LateStart() ���� ���Ŀ� �۵��ǵ��� ������ �ϱ� ����
    private bool canUpdate = false;         

    // Start is called before the first frame update
    void Start()
    {
        //Start()�Լ����� 1������ �Ŀ� �����Ű�� ���� Invoke�� �߰��Ѵ�.
        Invoke("LateStart", Time.deltaTime);
    }

    
    void LateStart()
    {
        playerMP = GameObject.FindWithTag("Player").GetComponent<PlayerHUD>();
        textMP = GetComponent<Text>();
        canUpdate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canUpdate == false)
            return;

        textMP.text = "MP : " + playerMP.curMP + "/" + playerMP.MaxMP;
    }
}
