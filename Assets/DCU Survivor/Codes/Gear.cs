using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public ItemData.ItemType type;
    public float rate; //����� Ÿ�԰� ��ġ�� ������ ���� ����

    public void Init(ItemData data)
    {
        // Basic Set
        name = "Gear " + data.itemId;
        transform.parent = GameManager.instance.player.transform;
        transform.localPosition = Vector3.zero;

        // Property Set
        type = data.itemType;
        rate = data.damages[0];
        ApplyGear();
    }

    public void LevelUp(float rate)
    {
        this.rate = rate;
        ApplyGear();
    }

    void ApplyGear() //Ÿ�Կ� ���� �����ϰ� ������ ��������ִ� �Լ� �߰�
    {
        switch (type)
        {
            case ItemData.ItemType.Glove:
                RateUp();
                break;
            case ItemData.ItemType.Shoe:
                SpeedUp();
                break;
        }
    }

    void RateUp() //�尩�� ����� ������� �ø��� �Լ� �ۼ�
    {
        Weapon[] weapons = transform.parent.GetComponentsInChildren<Weapon>();

        foreach(Weapon weapon in weapons)
        {
            switch (weapon.id)
            {
                case 0:
                    weapon.speed = 150 + (150 * rate); // ���� ���� ����
                    break;
                case 5:
                    weapon.speed = 150 + (150 * rate); // ���� ���� ����
                    break;
                case 10:
                    weapon.speed = 150 + (150 * rate); // ���� ���� ����
                    break;
                case 15:
                    weapon.speed = 150 + (150 * rate); // ���� ���� ����
                    break;
                case 20:
                    weapon.speed = 150 + (150 * rate); // ���� ���� ����
                    break;
                default:
                    weapon.speed = 0.5f * (1f - rate); // ���Ÿ� ���� ����
                    break;
            }
        }
    }

    void SpeedUp()
    {
        float speed = 3 * Character.Speed1 * Character.Speed2 * Character.Speed3;
        GameManager.instance.player.speed = speed + (speed * rate);
    }
}
