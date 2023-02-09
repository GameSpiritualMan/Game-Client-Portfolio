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
        //character�� DataManager��ũ��Ʈ�� �������� instance�� currentCharacter�� ������ OnSelect()�� �����Ѵ�.
        if (DataManager.instance.currentCharacter == character) OnSelect();
        //character�� DataManager��ũ��Ʈ�� �������� instance�� currentCharacter�� �ٸ��� OnDeSelect()�� �����Ѵ�.
        else if (DataManager.instance.currentCharacter != character) OnDeSelect();
    }

    //���콺�� Ŭ���Ǹ� �����Ѵ�.
    private void OnMouseUpAsButton()
    {
        //DataManager��ũ��Ʈ�� �������� instance�� currentCharacter�� character������ ���Եȴ�.
        DataManager.instance.currentCharacter = character;
        //OnSelect�Լ��� ����ȴ�.
        OnSelect();
        for(int i=0;i<chars.Length;i++)
        {
            //ĳ���� ������ ���Ե��� ������ ���Ե��� ���� ���ö��� OnDeSelect�Լ��� �����Ѵ�.
            if (chars[i] != this) chars[i].OnDeSelect();
        }
    }

    void OnDeSelect()
    {
        //�̹����� ���� ��Ӱ� ���Ѵ�.
        sr.color = new Color(0.5f, 0.5f, 0.5f);
    }

    void OnSelect()
    {
        //�̹��� ���� ������� ���ƿ´�.
        sr.color = new Color(1f, 1f, 1f);
    }
}
