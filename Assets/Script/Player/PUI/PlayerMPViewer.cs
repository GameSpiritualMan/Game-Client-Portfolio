using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMPViewer : MonoBehaviour
{
    private PlayerHUD playerMP;
    private Slider sliderMP;

    // Start is called before the first frame update
    void Start()
    {
        playerMP = GameObject.FindWithTag("Player").GetComponent<PlayerHUD>();
        sliderMP = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        sliderMP.value = playerMP.curMP / playerMP.MaxMP;
    }
}
