using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterReposition : MonoBehaviour
{
    public Button moveButton; // 버튼 오브젝트를 인스펙터에서 할당
    public GameObject playerObject; // 플레이어 오브젝트를 인스펙터에서 할당

    private void Start()
    {
        // 버튼 클릭 시 이벤트 메서드 연결
        moveButton.onClick.AddListener(move);
    }

    void move()
    {
        Vector3 currentPosition = playerObject.transform.position;

        currentPosition.y = -2f;

        playerObject.transform.position = currentPosition;
    }
}
