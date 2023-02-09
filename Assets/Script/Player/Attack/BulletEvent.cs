using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEvent : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Shoot()
    {
        anim.SetBool("Shoot", true);
    }

    public void Finish()
    {
        //Destroy(gameObject);
        //오브젝트를 반환하며 비활성화 한다.
        ObjectPool.OBP.ReturnObject(this.gameObject);
    }
}
