using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Breakedsand : MonoBehaviour
{
    [SerializeField] playercontroller player;
    [SerializeField] Inspecter Inspecter;
    // 期待されるキーシーケンス
    private KeyCode[] correctSequence = { KeyCode.UpArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.R, KeyCode.Space };
    private int currentIndex = 0; // 現在の入力インデックス

    public Tilemap tilemap;  // Tilemapの参照
    public Vector3Int tilePosition;  // 破壊したいタイルの位置
    private Rigidbody2D rb2D;


    void Start()
    {
        // Rigidbody2Dの取得
        rb2D = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        if (player.transform.position == tilePosition)
        {
            Inspecter.InspecterStart();
            if (currentIndex < correctSequence.Length)
            {
                if (Input.GetKeyDown(correctSequence[currentIndex]))
                {
                    // 正しいキーが入力された場合、インデックスを進める
                    currentIndex++;

                    // 全てのキーが正しく入力された場合
                    if (currentIndex >= correctSequence.Length)
                    {
                        gameObject.SetActive(false);
                        Inspecter.InspecterEnd();
                    }
                }
                else if (Input.anyKeyDown)
                {
                    // 間違ったキーが押された場合、シーケンスをリセット
                    currentIndex = 0;
                }
            }
        }
 
    }
}







            // 現在の正しいキーを確認



// タイルを破壊するメソッド




