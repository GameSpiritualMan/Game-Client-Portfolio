using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    GameObject target;              //ī�޶� ���� ���
    public float moveSpeed;         //ī�޶� ���󰡴� �ӵ�
    private Vector3 targetPosition; //����� ���� ��ġ
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //����� �ִ��� üũ
        if(target.gameObject!=null)
        {
            //this�� ī�޶� �ǹ�(z���� ī�޶��� �״�� ����)
            targetPosition.Set(target.transform.position.x,
                target.transform.position.y, this.transform.position.z);

            //ī�޶󿡼� Ÿ�ٱ��� �Էµ� ���� �ӵ��� �̵�
            this.transform.position = Vector3.Lerp(this.transform.position,
                targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
