using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraChace : MonoBehaviour
{
    [SerializeField]
    Transform player;  // プレイヤーのTransform

    [SerializeField]
    Vector3 offset;    // プレイヤーとの距離

    void Update()
    {
        // プレイヤーの位置に基づいてカメラを追従させる
        transform.position = player.position + offset;
    }
}


