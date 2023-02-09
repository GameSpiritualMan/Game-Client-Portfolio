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
    //터치상태일때 매 프레임
    /*IDragHandler 인터페이스를 부모로 상속받을 경우*/
    public void OnDrag(PointerEventData eventData)
    {
        touchPosition = Vector2.zero;
        /*조이스틱의 위치가 어디에 있든 동일한 값을 연산하기
         위해 touchPosition의 위치 값은 이미지의 현재 위치를
        기준으로 얼마나 떨어져 있는지에 따라 다르게 나온다*/
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle
            (imagebackground.rectTransform, eventData.position,
            eventData.pressEventCamera, out touchPosition))
        {
            /*touchPosition 값이 정규화[0~1]
             touchPositino을 이미지 크기로 나눈다.*/
            touchPosition.x = (touchPosition.x / imagebackground.rectTransform.sizeDelta.x);
            touchPosition.y = (touchPosition.y / imagebackground.rectTransform.sizeDelta.y);

            /*touchPosition 값의 정규화[-n~n]
             왼쪽(-1), 중심(0), 오른쪽(1)로 변경하기 위해 touchPosition.x*2-1
             아래(-1), 중심(0), 위쪽(1)로 변경하기 위해 touchPosition.y*2-1
             이 수식은 Pivot에 따라 달라진다.(좌하단 Pivot 기준)            
             →
             왼쪽(-1), 중심(0), 오른쪽(1)로 변경하기 위해 touchPosition.x*2
             아래(-1), 중심(0), 위쪽(1)로 변경하기 위해 touchPosition.y*2
             이 수식은 Pivot에 따라 달라진다.(좌하단 Pivot 기준)  */
            touchPosition = new Vector2(touchPosition.x * 2, touchPosition.y * 2);

            /*touchPositino 값의 정규화[-1~1]
             가상 조이스틱 배경 이미지 밖으로 터치가 나가게 되면 -1 ~ 1보다
            큰 값이 나올 수 있다.
            이때 normalized를 이용해 -1 ~ 1사이의 값으로 졍규화*/
            touchPosition = (touchPosition.magnitude > 1) ? touchPosition.normalized : touchPosition;

            //가상 조이스틱 컨트롤러 이미지 이동
            imageController.rectTransform.anchoredPosition = new Vector2(
                touchPosition.x * imagebackground.rectTransform.sizeDelta.x / 2,
                touchPosition.y * imagebackground.rectTransform.sizeDelta.y / 2);

        }
    }

    //터치 시작시 1회
    /*IPointerDownHandler 인터페이스를 부모로 상속받을 경우*/
    public void OnPointerDown(PointerEventData eventData)
    {

    }

    //터치 종료시 1회
    /*IPointerUpHandler 인터페이스를 부모로 상속받을 경우*/
    public void OnPointerUp(PointerEventData eventData)
    {
        //터치 종료 시 이미지의 위치를 중앙으로 다시 돌아간다.
        imageController.rectTransform.anchoredPosition = Vector2.zero;

        //다른 오브젝트에서 이동 방향으로 사용하기 때문에 이동 방향도 초기화
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
