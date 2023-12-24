using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterReposition : MonoBehaviour
{
    public Button moveButton; // ��ư ������Ʈ�� �ν����Ϳ��� �Ҵ�
    public GameObject playerObject; // �÷��̾� ������Ʈ�� �ν����Ϳ��� �Ҵ�

    private void Start()
    {
        // ��ư Ŭ�� �� �̺�Ʈ �޼��� ����
        moveButton.onClick.AddListener(move);
    }

    void move()
    {
        Vector3 currentPosition = playerObject.transform.position;

        currentPosition.y = -2f;

        playerObject.transform.position = currentPosition;
    }
}
