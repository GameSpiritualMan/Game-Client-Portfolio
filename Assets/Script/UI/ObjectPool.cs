using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool OBP; // �̱��� (���� ����)

    //�������� �������� �����ϱ� ���� �����Ѵ�.
    public GameObject[] prefabs;
    //�����Ҷ� 50���� �������� �̸� ����� �д�.
    public int firstCount = 50;

    private Dictionary<string, GameObject> prefabDictionary;
    public Dictionary<string, Queue<GameObject>> poolDictionary;


    private void Awake()
    {
        OBP = this; // �̱���
        
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        prefabDictionary = new Dictionary<string, GameObject>();

        //���Ե� �������� ������ŭ �ݺ��Ѵ�.
        foreach (GameObject prefab in prefabs)
        {
            //prefabDictionary�� prefab�� �̸����� prefab�� ������ �Ѵ�.
            prefabDictionary.Add(prefab.name, prefab);
            //poolDictionary�� prefab�� �̸��� Queue���·� ������Ʈ �ڷḦ ����ִ´�.
            poolDictionary.Add(prefab.name, new Queue<GameObject>());
        }

        InitQueue();
    }

    //������Ʈ�� ���� �����Ѵ�.
    private GameObject CreateNewObject(string poolTag)
    {
        //prefab�� prefabDictionary�� ����� ������Ʈ���� �����Ѵ�.
        GameObject prefab = prefabDictionary[poolTag];
        //newObejct�� prefab�� �����Ѵ�.
        GameObject newObject = Instantiate(prefab);
        
        //������ ������Ʈ���� �̸��� ����� ������Ʈ���� �̸��̴�.
        newObject.name = poolTag;
        //��Ȱ��ȭ �Ǿ� �ִ� �����̴�.
        newObject.SetActive(false);
        //newObject�� ��ȯ�Ѵ�.
        return newObject;
    }
    
    //Queue�� ������Ʈ���� �����Ѵ�.
    private void InitQueue()
    {
        //poolDictionary�� ���̸�ŭ �ݺ��Ѵ�.
        foreach (var keyValuePair in poolDictionary)
        {
            //poolTag�� Key���� �ȴ�.
            string poolTag = keyValuePair.Key;
            //queue�� keyValiePair�� ������ ������.
            Queue<GameObject> queue = keyValuePair.Value;

            //firstCount���� �ݺ��Ѵ�.
            for (int i = 0; i < firstCount; i++)
            {
                queue.Enqueue(CreateNewObject(poolTag));
            }
        }
    }

    //������Ʈ ��������
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

    //������Ʈ ��ȯ
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);

        Queue<GameObject> queue = poolDictionary[obj.name];
        queue.Enqueue(obj);
    }
}
