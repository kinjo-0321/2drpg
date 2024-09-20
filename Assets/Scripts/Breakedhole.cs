using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Breakedhole : MonoBehaviour
{
    [SerializeField] playercontroller player;
    [SerializeField] Inspecter Inspecter;
    // 期待されるキーシーケンス
    private int currentIndex = 0; // 現在の入力インデックス

    [SerializeField] Tilemap tilemap;  // Tilemapの参照
    [SerializeField] Vector3Int tilePosition;  // 破壊したいタイルの位置
    private Rigidbody2D rb2D;

    public float detectionRadius = 0.5f; // タイル位置との許容範囲

    private bool isInRange = false; // プレイヤーがタイルの範囲内にいるかどうか
    private bool aKeyPressed = false; // "a"キーが押されているかどうか
    private bool bKeyPressed = false;



    void Start()
    {
        // Rigidbody2Dの取得
        rb2D = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if(player.transform.position == tilePosition)
        {
            Inspecter.InspecterStart();
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                aKeyPressed = true;
            }

            // "b"キーが押されたかどうかを確認
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (aKeyPressed)
                {
                    Destroy(gameObject); // オブジェクトを破壊する
                    Debug.Log("オブジェクトが破壊されました。");
                    Inspecter.InspecterEnd();

                }

                // "b"が押された後は"a"の状態をリセットする
                aKeyPressed = false;
            }

            // "a"が離された場合
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                aKeyPressed = false;
            }
        }
        
    }
}
