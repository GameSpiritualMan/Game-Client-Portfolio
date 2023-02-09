using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DMGText : MonoBehaviour
{
    //�Է¹��� �ӵ���
    public float InputMoveSpeed;
    //���Թ��� �ӵ���
    private float moveSpeed;
    [HideInInspector]
    public TextMeshPro text;
    //������Ʈ�� ����� �ð�
    public float DestroyTime;

    [HideInInspector]
    public float DMG;
    
    //�� ������Ʈ�� Ȱ��ȭ �Ǹ� �����Ѵ�.
    private void OnEnable()
    {
        moveSpeed = InputMoveSpeed;
        //TextMeshPro������Ʈ ������ �����´�.
        text = GetComponent<TextMeshPro>();
        //����Լ��� DestroyObject�Լ��� DestroyTime�� �����ϸ� �����Ѵ�.
        StartCoroutine(DesytroyObject());
        //�ؽ�Ʈ�� �������� �ҷ��´�.
        text.text = DMG.ToString();
    }

    void Update()
    {
        //Y���� �������� + �������� moveSpeed��ŭ �� �����Ӹ��� �̵��Ѵ�.
        this.transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
    }

    IEnumerator DesytroyObject()
    {
        yield return new WaitForSeconds(DestroyTime);
        //�� ������Ʈ�� Ǯ������ ��ȯ�Ѵ�.
        ObjectPool.OBP.ReturnObject(this.gameObject);
    }
}
