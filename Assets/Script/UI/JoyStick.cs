using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Image imagebackground;
    private Image imageController;
    [HideInInspector]
    public Vector2 touchPosition;
    private void Awake()
    {
        imagebackground = GetComponent<Image>();
        imageController = transform.GetChild(0).GetComponent<Image>();
    }
    //��ġ�����϶� �� ������
    /*IDragHandler �������̽��� �θ�� ��ӹ��� ���*/
    public void OnDrag(PointerEventData eventData)
    {
        touchPosition = Vector2.zero;
        /*���̽�ƽ�� ��ġ�� ��� �ֵ� ������ ���� �����ϱ�
         ���� touchPosition�� ��ġ ���� �̹����� ���� ��ġ��
        �������� �󸶳� ������ �ִ����� ���� �ٸ��� ���´�*/
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle
            (imagebackground.rectTransform, eventData.position,
            eventData.pressEventCamera, out touchPosition))
        {
            /*touchPosition ���� ����ȭ[0~1]
             touchPositino�� �̹��� ũ��� ������.*/
            touchPosition.x = (touchPosition.x / imagebackground.rectTransform.sizeDelta.x);
            touchPosition.y = (touchPosition.y / imagebackground.rectTransform.sizeDelta.y);

            /*touchPosition ���� ����ȭ[-n~n]
             ����(-1), �߽�(0), ������(1)�� �����ϱ� ���� touchPosition.x*2-1
             �Ʒ�(-1), �߽�(0), ����(1)�� �����ϱ� ���� touchPosition.y*2-1
             �� ������ Pivot�� ���� �޶�����.(���ϴ� Pivot ����)            
             ��
             ����(-1), �߽�(0), ������(1)�� �����ϱ� ���� touchPosition.x*2
             �Ʒ�(-1), �߽�(0), ����(1)�� �����ϱ� ���� touchPosition.y*2
             �� ������ Pivot�� ���� �޶�����.(���ϴ� Pivot ����)  */
            touchPosition = new Vector2(touchPosition.x * 2, touchPosition.y * 2);

            /*touchPositino ���� ����ȭ[-1~1]
             ���� ���̽�ƽ ��� �̹��� ������ ��ġ�� ������ �Ǹ� -1 ~ 1����
            ū ���� ���� �� �ִ�.
            �̶� normalized�� �̿��� -1 ~ 1������ ������ ����ȭ*/
            touchPosition = (touchPosition.magnitude > 1) ? touchPosition.normalized : touchPosition;

            //���� ���̽�ƽ ��Ʈ�ѷ� �̹��� �̵�
            imageController.rectTransform.anchoredPosition = new Vector2(
                touchPosition.x * imagebackground.rectTransform.sizeDelta.x / 2,
                touchPosition.y * imagebackground.rectTransform.sizeDelta.y / 2);

        }
    }

    //��ġ ���۽� 1ȸ
    /*IPointerDownHandler �������̽��� �θ�� ��ӹ��� ���*/
    public void OnPointerDown(PointerEventData eventData)
    {

    }

    //��ġ ����� 1ȸ
    /*IPointerUpHandler �������̽��� �θ�� ��ӹ��� ���*/
    public void OnPointerUp(PointerEventData eventData)
    {
        //��ġ ���� �� �̹����� ��ġ�� �߾����� �ٽ� ���ư���.
        imageController.rectTransform.anchoredPosition = Vector2.zero;

        //�ٸ� ������Ʈ���� �̵� �������� ����ϱ� ������ �̵� ���⵵ �ʱ�ȭ
        touchPosition = Vector2.zero;
    }

    public float Horizontal()
    {
        return touchPosition.x;
    }

    public float Vertical()
    {
        return touchPosition.y;
    }
}
