using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public ItemData.ItemType type;
    public float rate; //장비의 타입과 수치를 저장할 변수 선언

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

    void ApplyGear() //타입에 따라 적절하게 로직을 적용시켜주는 함수 추가
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

    void RateUp() //장갑의 기능인 연사력을 올리는 함수 작성
    {
        Weapon[] weapons = transform.parent.GetComponentsInChildren<Weapon>();

        foreach(Weapon weapon in weapons)
        {
            switch (weapon.id)
            {
                case 0:
                    weapon.speed = 150 + (150 * rate); // 근접 무기 수식
                    break;
                case 5:
                    weapon.speed = 150 + (150 * rate); // 근접 무기 수식
                    break;
                case 10:
                    weapon.speed = 150 + (150 * rate); // 근접 무기 수식
                    break;
                case 15:
                    weapon.speed = 150 + (150 * rate); // 근접 무기 수식
                    break;
                case 20:
                    weapon.speed = 150 + (150 * rate); // 근접 무기 수식
                    break;
                default:
                    weapon.speed = 0.5f * (1f - rate); // 원거리 무기 수식
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
