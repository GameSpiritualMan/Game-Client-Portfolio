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

        //씬 이동시에 데이터매니저가 사라지지 않도록 설정한다.
        DontDestroyOnLoad(this);

        //만약 StartPoint라는 오브젝트가 존재하면
        if(GameObject.Find("StartPoint"))
        {
            //선택된 플레이어 캐릭터는 맵이 넘어가도 파괴되지 않는다.
            DontDestroyOnLoad(gameObject);
        }        
    }

    public Character currentCharacter;
}
