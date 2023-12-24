using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId; //poolmanager�� �ִ� prefab ��ȣ
    public float damage;
    public int count;
    public float speed;

    public 

    float timer;
    Player player;
    void Awake()
    {
        player = GetComponentInParent<Player>();    //GetComponentInParent�θ��� ������Ʈ ��������
        player = GameManager.instance.player;
    }

      void Update()
    {
        if (!GameManager.instance.isLive)
            return;

        switch (id) //���� id���� ����
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime); //update���� ���� �̵��ϰ� ������� �� Time.deltaTime�� �� ���ֱ�
                break;
            case 5:
                transform.Rotate(Vector3.back * speed * Time.deltaTime); //update���� ���� �̵��ϰ� ������� �� Time.deltaTime�� �� ���ֱ�
                break;
            case 10:
                transform.Rotate(Vector3.back * speed * Time.deltaTime); //update���� ���� �̵��ϰ� ������� �� Time.deltaTime�� �� ���ֱ�
                break;
            case 15:
                transform.Rotate(Vector3.back * speed * Time.deltaTime); //update���� ���� �̵��ϰ� ������� �� Time.deltaTime�� �� ���ֱ�
                break;
            case 20:
                transform.Rotate(Vector3.back * speed * Time.deltaTime); //update���� ���� �̵��ϰ� ������� �� Time.deltaTime�� �� ���ֱ�
                break;
            case 25:
                timer += Time.deltaTime;

                if (timer > speed) //���� �ӵ�
                {
                    timer = 0f;
                    Fire1();
                }
                break;
            case 26:
                timer += Time.deltaTime;

                if (timer > speed) //���� �ӵ�
                {
                    timer = 0f;
                    Fire();
                }
                break;
            default:
                timer += Time.deltaTime;

                if (timer > speed) //���� �ӵ�
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
        transform.parent = player.transform; //�θ� ������Ʈ ���� -> �÷��̾��
        transform.localPosition = Vector3.zero; //���� ��ġ ��, �÷��̾� �ȿ����� ��ġ

        // Property Set ��ġ ����
        id = data.itemId;
        damage = data.baseDamage * Character.Damage1 * Character.Damage2 * Character.Damage3;
        count = data.baseCount;

        for(int index = 0; index < GameManager.instance.pool.prefabs.Length; index++)
        {
            if(data.projectile== GameManager.instance.pool.prefabs[index]) // ���� = ����ü == ���� = ������ ���̵�(index)
                                                                                                // ��, ����ü ������ ��������̵� �ε����� �������� �־��ش�
            {
                prefabId = index;
                break;
            }
        }

        switch (id) //���� id���� ����
        {
            case 0:
                speed = 150; //-�� �ؾ� �ð����
                Batch();
                break;
            case 5:
                speed = 150; //-�� �ؾ� �ð����
                Batch();
                break;
            case 10:
                speed = 150; //-�� �ؾ� �ð����
                Batch();
                break;
            case 15:
                speed = 150; //-�� �ؾ� �ð����
                Batch();
                break;
            case 20:
                speed = 150; //-�� �ؾ� �ð����
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

        player.BroadcastMessage("ApplyGear",SendMessageOptions.DontRequireReceiver); //BroadcastMessage : Ư�� �Լ� ȣ���� ��� �ڽĿ��� ����ϴ� �Լ�
    }
    void Batch() //���� ��ġ �Լ�
    {
        for(int index = 0; index < count; index++)
        {
            Transform bullet;
            if (index < transform.childCount) //���� ���� Ȱ��ȭ ��Ų ������Ʈ�� �����ϰ� ����
            {
                bullet = transform.GetChild(index);
            }
            else //������ ������ŭ�� ���� ���� -> Ǯ������ ������
            {
                bullet = GameManager.instance.pool.Get(prefabId).transform;
                //parent �Ӽ��� ���� �θ� ���� -> ���� if���� �̹� �θ� ����Ǿ��� ������ �θ� ������ �� �ʿ䰡 ����
                bullet.parent = transform;
            }
            
            
            bullet.localPosition = Vector3.zero;
            bullet.localRotation = Quaternion.identity; //ȸ��

            Vector3 rotVec = Vector3.forward * 360 * index / count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);
            bullet.GetComponent<Bullet>().Init(damage, -1, Vector3.zero);// -1 => ���� ȸ�� ����� ������ �����̱� ������ 
        }
    }
    
    void Fire()
    {
        if (!player.scanner.nearsetTarget)
            return;
        Vector3 targetPos = player.scanner.nearsetTarget.position;
        Vector3 dir = targetPos - transform.position; //ũ�Ⱑ ���Ե� ���� : ��ǥ ��ġ - ���� ��ġ
        dir = dir.normalized; //nomalized(����ȭ) : ���� ������ ������ �����ϰ� ũ�⸦ 1�� ��ȯ�� �Ӽ�
        
        Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
        bullet.position = transform.position;
        //bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir); //FromToRotation : ������ ���� �߽����� ��ǥ�� ���� ȸ���ϴ� �Լ� ��Ȱ��ȭ �ϸ� �Ѿ��� ȸ�� ����
        bullet.GetComponent<Bullet>().Init(damage, count, dir);

        AudioManager.instance.PlaySfx(AudioManager.Sfx.Range);
    }
    void Fire1()
    {
        if (!player.scanner.nearsetTarget)
            return;

        Vector3 dir = Vector3.up;
        dir = dir.normalized; //nomalized(����ȭ) : ���� ������ ������ �����ϰ� ũ�⸦ 1�� ��ȯ�� �Ӽ�

        Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
        bullet.position = transform.position;
        bullet.GetComponent<Bullet>().Init(damage, count, dir);

        AudioManager.instance.PlaySfx(AudioManager.Sfx.Range);

    }
}
