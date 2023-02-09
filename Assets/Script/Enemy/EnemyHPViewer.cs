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
        //���� ���� HP�� 0���Ϸ� ��������
        if(EHP.CurrentHP<=0)
        {
            //������Ʈ Ǯ������ �ٽ� ��ȯ�Ͽ� ��Ȱ��ȭ �ȴ�.
            ObjectPool.OBP.ReturnObject(this.gameObject);
        }
    }
}
