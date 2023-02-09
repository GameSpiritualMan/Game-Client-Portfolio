using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPViewer : MonoBehaviour
{
    private EnemyHP EHP;
    private Slider hpslider;

    public void SetUp(EnemyHP enemyHP)
    {
        EHP = enemyHP;
        hpslider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        hpslider.value = EHP.CurrentHP / EHP.MaxHP;
        //현재 적의 HP가 0이하로 떨어지면
        if(EHP.CurrentHP<=0)
        {
            //오브젝트 풀에의해 다시 반환하여 비활성화 된다.
            ObjectPool.OBP.ReturnObject(this.gameObject);
        }
    }
}
