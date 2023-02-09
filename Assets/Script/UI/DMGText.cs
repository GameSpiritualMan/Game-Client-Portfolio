using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DMGText : MonoBehaviour
{
    //입력받을 속도값
    public float InputMoveSpeed;
    //대입받을 속도값
    private float moveSpeed;
    [HideInInspector]
    public TextMeshPro text;
    //오브젝트가 사라질 시간
    public float DestroyTime;

    [HideInInspector]
    public float DMG;
    
    //이 오브젝트가 활성화 되면 실행한다.
    private void OnEnable()
    {
        moveSpeed = InputMoveSpeed;
        //TextMeshPro컴포넌트 정보를 가져온다.
        text = GetComponent<TextMeshPro>();
        //재귀함수로 DestroyObject함수를 DestroyTime에 도달하면 실행한다.
        StartCoroutine(DesytroyObject());
        //텍스트에 데미지를 불러온다.
        text.text = DMG.ToString();
    }

    void Update()
    {
        //Y축을 기준으로 + 방향으로 moveSpeed만큼 매 프레임마다 이동한다.
        this.transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
    }

    IEnumerator DesytroyObject()
    {
        yield return new WaitForSeconds(DestroyTime);
        //이 오브젝트를 풀링으로 반환한다.
        ObjectPool.OBP.ReturnObject(this.gameObject);
    }
}
