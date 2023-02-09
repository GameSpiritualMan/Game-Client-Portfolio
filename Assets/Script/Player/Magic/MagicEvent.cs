using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicEvent : MonoBehaviour
{
    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public GameObject MagicAttack;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Finish()
    {
        //������Ʈ Ǯ������ ��Ȱ��ȭ �Ѵ�.
        ObjectPool.OBP.ReturnObject(this.gameObject);
    }
    public void Attack()
    {
        if(this.gameObject.name=="WaterMagic1Ready")
        {
            MagicAttack = ObjectPool.OBP.GetObject("WaterMagic1Attack");
            MagicAttack.transform.position = this.transform.position;
            MagicAttack.SetActive(true);
        }
        else if(this.gameObject.name=="WaterMagic2Ready")
        {
            MagicAttack = ObjectPool.OBP.GetObject("WaterMagic2Attack");
            MagicAttack.transform.position = this.transform.position;
            MagicAttack.SetActive(true);
        }
    }
}
