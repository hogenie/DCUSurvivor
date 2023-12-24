using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId; //poolmanager에 있는 prefab 번호
    public float damage;
    public int count;
    public float speed;

    public 

    float timer;
    Player player;
    void Awake()
    {
        player = GetComponentInParent<Player>();    //GetComponentInParent부모의 컴포넌트 가져오기
        player = GameManager.instance.player;
    }

      void Update()
    {
        if (!GameManager.instance.isLive)
            return;

        switch (id) //무기 id별로 구분
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime); //update에서 무언가 이동하게 만들었을 때 Time.deltaTime을 꼭 써주기
                break;
            case 5:
                transform.Rotate(Vector3.back * speed * Time.deltaTime); //update에서 무언가 이동하게 만들었을 때 Time.deltaTime을 꼭 써주기
                break;
            case 10:
                transform.Rotate(Vector3.back * speed * Time.deltaTime); //update에서 무언가 이동하게 만들었을 때 Time.deltaTime을 꼭 써주기
                break;
            case 15:
                transform.Rotate(Vector3.back * speed * Time.deltaTime); //update에서 무언가 이동하게 만들었을 때 Time.deltaTime을 꼭 써주기
                break;
            case 20:
                transform.Rotate(Vector3.back * speed * Time.deltaTime); //update에서 무언가 이동하게 만들었을 때 Time.deltaTime을 꼭 써주기
                break;
            case 25:
                timer += Time.deltaTime;

                if (timer > speed) //연사 속도
                {
                    timer = 0f;
                    Fire1();
                }
                break;
            case 26:
                timer += Time.deltaTime;

                if (timer > speed) //연사 속도
                {
                    timer = 0f;
                    Fire();
                }
                break;
            default:
                timer += Time.deltaTime;

                if (timer > speed) //연사 속도
                {
                    timer = 0f;
                    Fire();
                }
                break;
        }
    }
    public void LevelUp(float damage, int count)
    {
        this.damage = damage * Character.Damage1 * Character.Damage2 * Character.Damage3;
        this.count += count;
        if (id == 0 || id == 5 || id == 10 || id == 15 || id == 20) 
        {
            Batch();

        }
            


        player.BroadcastMessage("ApplyGear",SendMessageOptions.DontRequireReceiver);
    }

    public void Init(ItemData data)
    {
        // Basic Set
        name = "Weapon " + data.itemId;
        transform.parent = player.transform; //부모 오브젝트 지정 -> 플레이어로
        transform.localPosition = Vector3.zero; //지역 위치 즉, 플레이어 안에서의 위치

        // Property Set 수치 세팅
        id = data.itemId;
        damage = data.baseDamage * Character.Damage1 * Character.Damage2 * Character.Damage3;
        count = data.baseCount;

        for(int index = 0; index < GameManager.instance.pool.prefabs.Length; index++)
        {
            if(data.projectile== GameManager.instance.pool.prefabs[index]) // 좌측 = 투사체 == 우측 = 프리펩 아이디(index)
                                                                                                // 즉, 투사체 변수에 프리펩아이디가 인덱스인 프리펩을 넣어준다
            {
                prefabId = index;
                break;
            }
        }

        switch (id) //무기 id별로 구분
        {
            case 0:
                speed = 150; //-로 해야 시계방향
                Batch();
                break;
            case 5:
                speed = 150; //-로 해야 시계방향
                Batch();
                break;
            case 10:
                speed = 150; //-로 해야 시계방향
                Batch();
                break;
            case 15:
                speed = 150; //-로 해야 시계방향
                Batch();
                break;
            case 20:
                speed = 150; //-로 해야 시계방향
                Batch();
                break;
            case 25:
                speed = 3.9f;
                break;
            case 26:
                speed = 2.3f;
                break;
            default:
                speed = 0.5f;
                break;
        }

        // Hand Set
        //Hand hand = player.hands[(int)data.itemType];
        //hand.spriter.sprite = data.hand;
        //hand.gameObject.SetActive(true);

        player.BroadcastMessage("ApplyGear",SendMessageOptions.DontRequireReceiver); //BroadcastMessage : 특정 함수 호출을 모든 자식에게 방송하는 함수
    }
    void Batch() //무기 배치 함수
    {
        for(int index = 0; index < count; index++)
        {
            Transform bullet;
            if (index < transform.childCount) //현재 내가 활성화 시킨 오브젝트를 재사용하고 나서
            {
                bullet = transform.GetChild(index);
            }
            else //부족한 개수만큼만 새로 생성 -> 풀링에서 가져옴
            {
                bullet = GameManager.instance.pool.Get(prefabId).transform;
                //parent 속성을 통해 부모 변경 -> 위에 if문은 이미 부모가 변경되었기 때문에 부모 변경을 할 필요가 없음
                bullet.parent = transform;
            }
            
            
            bullet.localPosition = Vector3.zero;
            bullet.localRotation = Quaternion.identity; //회전

            Vector3 rotVec = Vector3.forward * 360 * index / count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);
            bullet.GetComponent<Bullet>().Init(damage, -1, Vector3.zero);// -1 => 근접 회전 무기는 무조건 관통이기 때문에 
        }
    }
    
    void Fire()
    {
        if (!player.scanner.nearsetTarget)
            return;
        Vector3 targetPos = player.scanner.nearsetTarget.position;
        Vector3 dir = targetPos - transform.position; //크기가 포함된 방향 : 목표 위치 - 나의 위치
        dir = dir.normalized; //nomalized(정규화) : 현재 벡터의 방향은 유지하고 크기를 1로 변환된 속성
        
        Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
        bullet.position = transform.position;
        //bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir); //FromToRotation : 지정된 축을 중심으로 목표를 향해 회전하는 함수 비활성화 하면 총알이 회전 안함
        bullet.GetComponent<Bullet>().Init(damage, count, dir);

        AudioManager.instance.PlaySfx(AudioManager.Sfx.Range);
    }
    void Fire1()
    {
        if (!player.scanner.nearsetTarget)
            return;

        Vector3 dir = Vector3.up;
        dir = dir.normalized; //nomalized(정규화) : 현재 벡터의 방향은 유지하고 크기를 1로 변환된 속성

        Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
        bullet.position = transform.position;
        bullet.GetComponent<Bullet>().Init(damage, count, dir);

        AudioManager.instance.PlaySfx(AudioManager.Sfx.Range);

    }
}
