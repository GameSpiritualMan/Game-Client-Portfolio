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
        //현재 HP / 최대 HP 식으로 표시한다.
        enemyHPText.text = EHP.CurrentHP + "/" + EHP.MaxHP;

        //현재 적HP가 0이하로 떨어지면
        if(EHP.CurrentHP<=0)
        {
            //오브젝트 풀에의해 반환하여 비활성화 한다.
            ObjectPool.OBP.ReturnObject(this.gameObject);
        }
    }
}
