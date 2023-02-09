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
        //Slider UI가 쫓아다닐 target설정
        targetTransform = target;

        //적의 이름 별로 슬라이더 위치 표시
        switch (targetTransform.gameObject.name)
        {
            case "SmallEnemy1":
                //슬라이더 바의 위치는 y축으로 10만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 10.0f;
                break;
            case "SmallEnemy2":
                //슬라이더 바의 위치는 y축으로 10만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 10.0f;
                break;
            case "SmallEnemy3":
                //슬라이더 바의 위치는 y축으로 10만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 10.0f;
                break;
            case "SmallEnemy4":
                //슬라이더 바의 위치는 y축으로 15만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 15.0f;
                break;
            case "SmallEnemy5":
                //슬라이더 바의 위치는 y축으로 15만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 15.0f;
                break;
            case "SmallEnemy6":
                //슬라이더 바의 위치는 y축으로 15만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 15.0f;
                break;
            case "SmallEnemy7":
                //슬라이더 바의 위치는 y축으로 15만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 15.0f;
                break;
            case "SmallEnemy8":
                //슬라이더 바의 위치는 y축으로 15만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 15.0f;
                break;
            case "SmallEnemy9":
                //슬라이더 바의 위치는 y축으로 15만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 15.0f;
                break;
            case "SmallEnemy10":
                //슬라이더 바의 위치는 y축으로 15만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 15.0f;
                break;
            case "SmallEnemy11":
                //슬라이더 바의 위치는 y축으로 15만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 15.0f;
                break;
            case "SmallEnemy12":
                //슬라이더 바의 위치는 y축으로 15만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 15.0f;
                break;
            case "SmallEnemy13":
                //슬라이더 바의 위치는 y축으로 15만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 15.0f;
                break;
            case "SmallEnemy14":
                //슬라이더 바의 위치는 y축으로 15만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 15.0f;
                break;
            case "SmallEnemy15":
                //슬라이더 바의 위치는 y축으로 15만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 15.0f;
                break;
            case "BigEnemy1":
                //슬라이더 바의 위치는 y축으로 30만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 30.0f;
                break;
            case "BigEnemy2":
                //슬라이더 바의 위치는 y축으로 30만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 30.0f;
                break;
            case "BigEnemy3":
                //슬라이더 바의 위치는 y축으로 30만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 30.0f;
                break;
            case "BigEnemy4":
                //슬라이더 바의 위치는 y축으로 40만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 40.0f;
                break;
            case "BigEnemy5":
                //슬라이더 바의 위치는 y축으로 30만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 30.0f;
                break;
            case "BigEnemy6":
                //슬라이더 바의 위치는 y축으로 30만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 30.0f;
                break;
            case "BigEnemy7":
                //슬라이더 바의 위치는 y축으로 30만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 30.0f;
                break;
            case "BigEnemy8":
                //슬라이더 바의 위치는 y축으로 40만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 40.0f;
                break;
            case "BigEnemy9":
                //슬라이더 바의 위치는 y축으로 30만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 30.0f;
                break;
            case "BigEnemy10":
                //슬라이더 바의 위치는 y축으로 30만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 30.0f;
                break;
            case "Boss1":
                //슬라이더 바의 위치는 y축으로 40만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 40.0f;
                break;
            case "Boss2":
                //슬라이더 바의 위치는 y축으로 30만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 30.0f;
                break;
            case "Boss3":
                //슬라이더 바의 위치는 y축으로 30만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 30.0f;
                break;
            case "Boss4":
                //슬라이더 바의 위치는 y축으로 30만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 30.0f;
                break;
            case "Boss5":
                //슬라이더 바의 위치는 y축으로 30만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 30.0f;
                break;
            case "FinalBoss":
                //슬라이더 바의 위치는 y축으로 35만큼 아래로 떨어진 위치에 배치한다.
                distance = Vector3.down * 35.0f;
                break;
        }
        ////BigEnemy라는 태그를 가진 오브젝트이면
        //if(targetTransform.gameObject.tag=="BigEnemy")
        //{
        //    //슬라이더 바의 위치는 y축으로 40만큼 아래로 떨어진 위치에 배치한다.
        //    distance = Vector3.down * 40.0f;
        //}
        ////Boss라는 태그를 가진 오브젝트 이면
        //else if(targetTransform.gameObject.tag=="Boss")
        //{
        //    //슬라이더 바의 위치는 y축으로 60만큼 아래로 떨어진 위치에 배치한다.
        //    distance = Vector3.down * 60.0f;
        //}
        //RectTransform 컴포넌트 정보 얻어오기
        RectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        //적이 파괴되어 쫓아다닐 대상이 사라지면 Slider UI도 삭제된다.
        if(targetTransform==null)
        {
            //Destroy(gameObject);
            //오브젝트 풀을 위해 반납한다.
            ObjectPool.OBP.ReturnObject(this.gameObject);
            return;
        }

        /*오브젝트의 위치가 갱신된 이후에 Slider UI도 함께 위치를 설정하도록 하기 위해
         LateUpdate()에서 호출된다.*/

        //오브젝트의 월드 좌표를 기준으로 화면에서의 좌표 값을 구한다.
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetTransform.position);
        //화면 내에서 좌표 + distance만큼 떨어진 위치를 Slider UI의 위치로 설정
        RectTransform.position = screenPosition + distance;
    }
}