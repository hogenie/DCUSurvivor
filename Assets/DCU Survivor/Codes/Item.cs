using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public static Item instance;

    public ItemData data;
    public int level;
    public Weapon weapon;
    public Gear gear;

    Image icon;
    Text textLevel;
    Text textName;
    Text textDesc;

    private void Awake()
    {
        instance = this;

        icon = GetComponentsInChildren<Image>()[1]; //GetComponentsInchilden���� �ι�° ������ �������� (ù��°�� �ڱ��ڽ�)
        icon.sprite = data.itemIcon;

        Text[] texts = GetComponentsInChildren<Text>();
        textLevel = texts[0];
        textName = texts[1];
        textDesc = texts[2];
        textName.text = data.itemName;
    }

    private void OnEnable()
    {
        textLevel.text = "Lv." + (level + 1);
        switch (data.itemType)
        {
            case ItemData.ItemType.Melee:
            case ItemData.ItemType.Range:
            case ItemData.ItemType.Range1:
            case ItemData.ItemType.Range2:
                textDesc.text = string.Format(data.itemDesc, data.damages[level] * 100, data.counts[level]);
                break;
            case ItemData.ItemType.Glove:
            case ItemData.ItemType.Shoe:
                textDesc.text = string.Format(data.itemDesc, data.damages[level] * 100);
                break;
            default:
                textDesc.text = string.Format(data.itemDesc);
                break;
        }
    }
    public void init()
    {
        icon = GetComponentsInChildren<Image>()[1]; //GetComponentsInchilden���� �ι�° ������ �������� (ù��°�� �ڱ��ڽ�)
        icon.sprite = data.itemIcon;

        Text[] texts = GetComponentsInChildren<Text>();
        textLevel = texts[0];
        textName = texts[1];
        textDesc = texts[2];
        textName.text = data.itemName;
    }

    public void OnClick() //��ư Ŭ�� �̺�Ʈ�� ������ �Լ�
    {
        switch(data.itemType)
        {
            case ItemData.ItemType.Melee:
            case ItemData.ItemType.Range:
            case ItemData.ItemType.Range1:
                if (level == 0)
                {
                    GameObject newWeapon = new GameObject();  //���ο� ���ӿ�����Ʈ�� �ڵ�� ����
                    weapon = newWeapon.AddComponent<Weapon>(); //AddComponent<T> : ���ӿ�����Ʈ�� T ������Ʈ�� �߰��ϴ� �Լ�
                    weapon.Init(data);
                }
                else
                {
                    float nextDamage = data.baseDamage;
                    int nextCount = 0;

                    nextDamage += data.baseDamage *  data.damages[level]; //ó�� ������ �������� �������� Ƚ���� ���
                    nextCount += data.counts[level];

                    weapon.LevelUp(nextDamage, nextCount);
                }
                level++;
                break;

            case ItemData.ItemType.Range2:
                GameManager.instance.pet.SetActive(true);

                if (level == 0)
                {
                    GameObject newWeapon = new GameObject();  //���ο� ���ӿ�����Ʈ�� �ڵ�� ����
                    weapon = newWeapon.AddComponent<Weapon>(); //AddComponent<T> : ���ӿ�����Ʈ�� T ������Ʈ�� �߰��ϴ� �Լ�
                    weapon.Init(data);
                }
                else
                {
                    float nextDamage = data.baseDamage;
                    int nextCount = 0;

                    nextDamage += data.baseDamage * data.damages[level]; //ó�� ������ �������� �������� Ƚ���� ���
                    nextCount += data.counts[level];

                    weapon.LevelUp(nextDamage, nextCount);
                }
                level++;
                break;
            case ItemData.ItemType.Glove:
            case ItemData.ItemType.Shoe:
                if (level == 0)
                {
                    GameObject newGear = new GameObject();
                    gear = newGear.AddComponent<Gear>();
                    gear.Init(data);
                }
                else
                {
                    float nextRate = data.damages[level];
                    gear.LevelUp(nextRate);
                }
                level++;
                break;
            case ItemData.ItemType.Heal:
                GameManager.instance.health = GameManager.instance.maxHealth;
                break;
        }


        if(level==data.damages.Length)
        {
            GetComponent<Button>().interactable = false;
        }
    }
    public void DataChange1()
    {
        switch(GameManager.instance.playerId)
        {
            case 0:
                GameManager.instance.LevelUPItems[0].data = GameManager.instance.NormalDiku[0];
                GameManager.instance.LevelUPItems[1].data = GameManager.instance.NormalDiku[1];
                GameManager.instance.LevelUPItems[2].data = GameManager.instance.NormalDiku[2];
                GameManager.instance.LevelUPItems[3].data = GameManager.instance.NormalDiku[3];
                GameManager.instance.LevelUPItems[4].data = GameManager.instance.NormalDiku[4];
                break;
            case 1:
                GameManager.instance.LevelUPItems[0].data = GameManager.instance.DoctorDiku[0];
                GameManager.instance.LevelUPItems[1].data = GameManager.instance.DoctorDiku[1];
                GameManager.instance.LevelUPItems[2].data = GameManager.instance.DoctorDiku[2];
                GameManager.instance.LevelUPItems[3].data = GameManager.instance.DoctorDiku[3];
                GameManager.instance.LevelUPItems[4].data = GameManager.instance.DoctorDiku[4];
                break;
            case 2:
                GameManager.instance.LevelUPItems[0].data = GameManager.instance.MusicDiku[0];
                GameManager.instance.LevelUPItems[1].data = GameManager.instance.MusicDiku[1];
                GameManager.instance.LevelUPItems[2].data = GameManager.instance.MusicDiku[2];
                GameManager.instance.LevelUPItems[3].data = GameManager.instance.MusicDiku[3];
                GameManager.instance.LevelUPItems[4].data = GameManager.instance.MusicDiku[4];
                break;
            case 3:
                GameManager.instance.LevelUPItems[0].data = GameManager.instance.CatolicDiku[0];
                GameManager.instance.LevelUPItems[1].data = GameManager.instance.CatolicDiku[1];
                GameManager.instance.LevelUPItems[2].data = GameManager.instance.CatolicDiku[2];
                GameManager.instance.LevelUPItems[3].data = GameManager.instance.CatolicDiku[3];
                GameManager.instance.LevelUPItems[4].data = GameManager.instance.CatolicDiku[4];
                break;
            case 4:
                GameManager.instance.LevelUPItems[0].data = GameManager.instance.BatteryDiku[0];
                GameManager.instance.LevelUPItems[1].data = GameManager.instance.BatteryDiku[1];
                GameManager.instance.LevelUPItems[2].data = GameManager.instance.BatteryDiku[2];
                GameManager.instance.LevelUPItems[3].data = GameManager.instance.BatteryDiku[3];
                GameManager.instance.LevelUPItems[4].data = GameManager.instance.BatteryDiku[4];
                break;
        }
    }
}
