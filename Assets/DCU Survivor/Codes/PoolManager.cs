using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;
    // 프리펩들을 보관할 변수
    public GameObject[] prefabs;

    // 풀 담당을 하는 리스트
    // 변수와 리스트는 서로 1:1로 필요하다 즉, 변수 2개 => 리스트 2개
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
        // 선택한 풀에 놀고 있는(비활성화된채로) 존재하는 게임오브젝트 접근
            
        foreach(GameObject item in pools[index])
        {
            if(!item.activeSelf) // activeSelf : 내용물 오브젝트가 비활성화(대기 상태)인지 확인 즉, 대기상태가 !(아니라면)
            {
                // 발견하면 select 변수에 할당
                select = item;
                select.SetActive(true); //활성화 됨
                break; //더이상 foreach문에서 반복문이 필요 없기 때문에 반복문 종료
            }

        }
        // 오브젝트 풀에 있는 모든 오브젝트가 화면에서 활성화되어 동작 중이라면 즉, 사용할 수 있는 오브젝트가 없다면
       
        if (!select) // select가 비어있다면, null은 false이기 때문에 !로 반전
        {
            // 새롭게 생성해서 select 변수에 할당
            // Instantiate : 원본 오브젝트를 복제하여 장면에 생성하는 함수
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select); // pools에 등록
        }

        return select;
    }
}
