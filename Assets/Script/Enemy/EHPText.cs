using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EHPText : MonoBehaviour
{
    private EnemyHP EHP;
    private Text enemyHPText;
    // Start is called before the first frame update
    public void SetUp(EnemyHP EHP)
    {
        this.EHP = EHP;
        enemyHPText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //���� HP / �ִ� HP ������ ǥ���Ѵ�.
        enemyHPText.text = EHP.CurrentHP + "/" + EHP.MaxHP;

        //���� ��HP�� 0���Ϸ� ��������
        if(EHP.CurrentHP<=0)
        {
            //������Ʈ Ǯ������ ��ȯ�Ͽ� ��Ȱ��ȭ �Ѵ�.
            ObjectPool.OBP.ReturnObject(this.gameObject);
        }
    }
}
