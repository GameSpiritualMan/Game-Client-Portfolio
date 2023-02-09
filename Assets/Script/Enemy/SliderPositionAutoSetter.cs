using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPositionAutoSetter : MonoBehaviour
{
    private Vector3         distance;
    private Transform       targetTransform;
    private RectTransform   RectTransform;
    private ObjectPool      OBP;
    private void Start()
    {
        OBP = GetComponent<ObjectPool>();
    }

    public void SetUp(Transform target)
    {
        //Slider UI�� �Ѿƴٴ� target����
        targetTransform = target;

        //���� �̸� ���� �����̴� ��ġ ǥ��
        switch (targetTransform.gameObject.name)
        {
            case "SmallEnemy1":
                //�����̴� ���� ��ġ�� y������ 10��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 10.0f;
                break;
            case "SmallEnemy2":
                //�����̴� ���� ��ġ�� y������ 10��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 10.0f;
                break;
            case "SmallEnemy3":
                //�����̴� ���� ��ġ�� y������ 10��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 10.0f;
                break;
            case "SmallEnemy4":
                //�����̴� ���� ��ġ�� y������ 15��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 15.0f;
                break;
            case "SmallEnemy5":
                //�����̴� ���� ��ġ�� y������ 15��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 15.0f;
                break;
            case "SmallEnemy6":
                //�����̴� ���� ��ġ�� y������ 15��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 15.0f;
                break;
            case "SmallEnemy7":
                //�����̴� ���� ��ġ�� y������ 15��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 15.0f;
                break;
            case "SmallEnemy8":
                //�����̴� ���� ��ġ�� y������ 15��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 15.0f;
                break;
            case "SmallEnemy9":
                //�����̴� ���� ��ġ�� y������ 15��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 15.0f;
                break;
            case "SmallEnemy10":
                //�����̴� ���� ��ġ�� y������ 15��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 15.0f;
                break;
            case "SmallEnemy11":
                //�����̴� ���� ��ġ�� y������ 15��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 15.0f;
                break;
            case "SmallEnemy12":
                //�����̴� ���� ��ġ�� y������ 15��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 15.0f;
                break;
            case "SmallEnemy13":
                //�����̴� ���� ��ġ�� y������ 15��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 15.0f;
                break;
            case "SmallEnemy14":
                //�����̴� ���� ��ġ�� y������ 15��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 15.0f;
                break;
            case "SmallEnemy15":
                //�����̴� ���� ��ġ�� y������ 15��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 15.0f;
                break;
            case "BigEnemy1":
                //�����̴� ���� ��ġ�� y������ 30��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 30.0f;
                break;
            case "BigEnemy2":
                //�����̴� ���� ��ġ�� y������ 30��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 30.0f;
                break;
            case "BigEnemy3":
                //�����̴� ���� ��ġ�� y������ 30��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 30.0f;
                break;
            case "BigEnemy4":
                //�����̴� ���� ��ġ�� y������ 40��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 40.0f;
                break;
            case "BigEnemy5":
                //�����̴� ���� ��ġ�� y������ 30��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 30.0f;
                break;
            case "BigEnemy6":
                //�����̴� ���� ��ġ�� y������ 30��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 30.0f;
                break;
            case "BigEnemy7":
                //�����̴� ���� ��ġ�� y������ 30��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 30.0f;
                break;
            case "BigEnemy8":
                //�����̴� ���� ��ġ�� y������ 40��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 40.0f;
                break;
            case "BigEnemy9":
                //�����̴� ���� ��ġ�� y������ 30��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 30.0f;
                break;
            case "BigEnemy10":
                //�����̴� ���� ��ġ�� y������ 30��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 30.0f;
                break;
            case "Boss1":
                //�����̴� ���� ��ġ�� y������ 40��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 40.0f;
                break;
            case "Boss2":
                //�����̴� ���� ��ġ�� y������ 30��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 30.0f;
                break;
            case "Boss3":
                //�����̴� ���� ��ġ�� y������ 30��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 30.0f;
                break;
            case "Boss4":
                //�����̴� ���� ��ġ�� y������ 30��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 30.0f;
                break;
            case "Boss5":
                //�����̴� ���� ��ġ�� y������ 30��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 30.0f;
                break;
            case "FinalBoss":
                //�����̴� ���� ��ġ�� y������ 35��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
                distance = Vector3.down * 35.0f;
                break;
        }
        ////BigEnemy��� �±׸� ���� ������Ʈ�̸�
        //if(targetTransform.gameObject.tag=="BigEnemy")
        //{
        //    //�����̴� ���� ��ġ�� y������ 40��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
        //    distance = Vector3.down * 40.0f;
        //}
        ////Boss��� �±׸� ���� ������Ʈ �̸�
        //else if(targetTransform.gameObject.tag=="Boss")
        //{
        //    //�����̴� ���� ��ġ�� y������ 60��ŭ �Ʒ��� ������ ��ġ�� ��ġ�Ѵ�.
        //    distance = Vector3.down * 60.0f;
        //}
        //RectTransform ������Ʈ ���� ������
        RectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        //���� �ı��Ǿ� �Ѿƴٴ� ����� ������� Slider UI�� �����ȴ�.
        if(targetTransform==null)
        {
            //Destroy(gameObject);
            //������Ʈ Ǯ�� ���� �ݳ��Ѵ�.
            ObjectPool.OBP.ReturnObject(this.gameObject);
            return;
        }

        /*������Ʈ�� ��ġ�� ���ŵ� ���Ŀ� Slider UI�� �Բ� ��ġ�� �����ϵ��� �ϱ� ����
         LateUpdate()���� ȣ��ȴ�.*/

        //������Ʈ�� ���� ��ǥ�� �������� ȭ�鿡���� ��ǥ ���� ���Ѵ�.
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetTransform.position);
        //ȭ�� ������ ��ǥ + distance��ŭ ������ ��ġ�� Slider UI�� ��ġ�� ����
        RectTransform.position = screenPosition + distance;
    }
}