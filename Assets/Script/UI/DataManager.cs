using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character
{
    MagicKnight, Wizard, Elf
}
public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) return;

        //�� �̵��ÿ� �����͸Ŵ����� ������� �ʵ��� �����Ѵ�.
        DontDestroyOnLoad(this);

        //���� StartPoint��� ������Ʈ�� �����ϸ�
        if(GameObject.Find("StartPoint"))
        {
            //���õ� �÷��̾� ĳ���ʹ� ���� �Ѿ�� �ı����� �ʴ´�.
            DontDestroyOnLoad(gameObject);
        }        
    }

    public Character currentCharacter;
}
