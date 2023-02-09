using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    public Character character;
    SpriteRenderer sr;
    public SelectCharacter[] chars;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        //character가 DataManager스크립트의 정적변수 instance의 currentCharacter랑 같으면 OnSelect()를 실행한다.
        if (DataManager.instance.currentCharacter == character) OnSelect();
        //character가 DataManager스크립트의 정적변수 instance의 currentCharacter랑 다르면 OnDeSelect()를 실행한다.
        else if (DataManager.instance.currentCharacter != character) OnDeSelect();
    }

    //마우스로 클릭되면 실행한다.
    private void OnMouseUpAsButton()
    {
        //DataManager스크립트의 정적변수 instance의 currentCharacter에 character변수가 대입된다.
        DataManager.instance.currentCharacter = character;
        //OnSelect함수가 실행된다.
        OnSelect();
        for(int i=0;i<chars.Length;i++)
        {
            //캐릭터 순번에 포함되지 않으면 포함되지 않은 선택란은 OnDeSelect함수를 실행한다.
            if (chars[i] != this) chars[i].OnDeSelect();
        }
    }

    void OnDeSelect()
    {
        //이미지의 색은 어둡게 변한다.
        sr.color = new Color(0.5f, 0.5f, 0.5f);
    }

    void OnSelect()
    {
        //이미지 색은 원래대로 돌아온다.
        sr.color = new Color(1f, 1f, 1f);
    }
}
