using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;
    // ��������� ������ ����
    public GameObject[] prefabs;

    // Ǯ ����� �ϴ� ����Ʈ
    // ������ ����Ʈ�� ���� 1:1�� �ʿ��ϴ� ��, ���� 2�� => ����Ʈ 2��
    List<GameObject>[] pools;

    public GameObject[] Weaponprefabs;

    void Awake()
    {
        instance = this;
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;
        // ������ Ǯ�� ��� �ִ�(��Ȱ��ȭ��ä��) �����ϴ� ���ӿ�����Ʈ ����
            
        foreach(GameObject item in pools[index])
        {
            if(!item.activeSelf) // activeSelf : ���빰 ������Ʈ�� ��Ȱ��ȭ(��� ����)���� Ȯ�� ��, �����°� !(�ƴ϶��)
            {
                // �߰��ϸ� select ������ �Ҵ�
                select = item;
                select.SetActive(true); //Ȱ��ȭ ��
                break; //���̻� foreach������ �ݺ����� �ʿ� ���� ������ �ݺ��� ����
            }

        }
        // ������Ʈ Ǯ�� �ִ� ��� ������Ʈ�� ȭ�鿡�� Ȱ��ȭ�Ǿ� ���� ���̶�� ��, ����� �� �ִ� ������Ʈ�� ���ٸ�
       
        if (!select) // select�� ����ִٸ�, null�� false�̱� ������ !�� ����
        {
            // ���Ӱ� �����ؼ� select ������ �Ҵ�
            // Instantiate : ���� ������Ʈ�� �����Ͽ� ��鿡 �����ϴ� �Լ�
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select); // pools�� ���
        }

        return select;
    }
}
