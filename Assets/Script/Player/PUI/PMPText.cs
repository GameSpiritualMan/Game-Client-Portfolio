using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PMPText : MonoBehaviour
{
    private PlayerHUD playerMP;
    private Text textMP;
    //Update()를 LateStart() 실행 이후에 작동되도록 만들어야 하기 때문
    private bool canUpdate = false;         

    // Start is called before the first frame update
    void Start()
    {
        //Start()함수보다 1프레임 후에 실행시키기 위해 Invoke를 추가한다.
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
