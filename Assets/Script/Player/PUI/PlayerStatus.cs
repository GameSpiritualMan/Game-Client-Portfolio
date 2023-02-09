using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    private PlayerController PCon;
    private Text PText;
    private bool canUpdate = false;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LateStart", Time.deltaTime);
    }

    void LateStart()
    {
        PCon = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        PText = GetComponent<Text>();
        canUpdate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canUpdate == false)
            return;

        PText.text = "ATK : " + PCon.ATK + "  MATK : " + PCon.MATk;
    }
}
