using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraChace : MonoBehaviour
{
    [SerializeField]
    Transform player;  // �v���C���[��Transform

    [SerializeField]
    Vector3 offset;    // �v���C���[�Ƃ̋���

    void Update()
    {
        // �v���C���[�̈ʒu�Ɋ�Â��ăJ������Ǐ]������
        transform.position = player.position + offset;
    }
}


