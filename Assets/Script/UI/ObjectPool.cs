using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool OBP; // 싱글톤 (공유 가능)

    //여러개의 프리팹을 저장하기 위해 선언한다.
    public GameObject[] prefabs;
    //시작할때 50개의 프리팹을 미리 만들어 둔다.
    public int firstCount = 50;

    private Dictionary<string, GameObject> prefabDictionary;
    public Dictionary<string, Queue<GameObject>> poolDictionary;


    private void Awake()
    {
        OBP = this; // 싱글톤
        
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        prefabDictionary = new Dictionary<string, GameObject>();

        //삽입된 프리팹의 개수만큼 반복한다.
        foreach (GameObject prefab in prefabs)
        {
            //prefabDictionary에 prefab의 이름으로 prefab을 저장을 한다.
            prefabDictionary.Add(prefab.name, prefab);
            //poolDictionary에 prefab의 이름을 Queue형태로 오브젝트 자료를 집어넣는다.
            poolDictionary.Add(prefab.name, new Queue<GameObject>());
        }

        InitQueue();
    }

    //오브젝트를 새로 생성한다.
    private GameObject CreateNewObject(string poolTag)
    {
        //prefab에 prefabDictionary에 저장된 오브젝트들을 삽입한다.
        GameObject prefab = prefabDictionary[poolTag];
        //newObejct는 prefab을 생성한다.
        GameObject newObject = Instantiate(prefab);
        
        //꺼내올 오브젝트들의 이름은 저장된 오브젝트들의 이름이다.
        newObject.name = poolTag;
        //비활성화 되어 있는 상태이다.
        newObject.SetActive(false);
        //newObject를 반환한다.
        return newObject;
    }
    
    //Queue에 오브젝트들을 삽입한다.
    private void InitQueue()
    {
        //poolDictionary의 길이만큼 반복한다.
        foreach (var keyValuePair in poolDictionary)
        {
            //poolTag는 Key값이 된다.
            string poolTag = keyValuePair.Key;
            //queue는 keyValiePair의 값들을 가진다.
            Queue<GameObject> queue = keyValuePair.Value;

            //firstCount까지 반복한다.
            for (int i = 0; i < firstCount; i++)
            {
                queue.Enqueue(CreateNewObject(poolTag));
            }
        }
    }

    //오브젝트 꺼내오기
    public GameObject GetObject(string poolTag)
    {
        Queue<GameObject> queue = poolDictionary[poolTag];
        if (queue.Count > 0)
        {
            return queue.Dequeue();
        }
        else
        {
            return CreateNewObject(poolTag);
        }
    }

    //오브젝트 반환
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);

        Queue<GameObject> queue = poolDictionary[obj.name];
        queue.Enqueue(obj);
    }
}
