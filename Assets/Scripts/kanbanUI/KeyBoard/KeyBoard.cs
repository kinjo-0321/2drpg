using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBoard : MonoBehaviour
{
    [SerializeField] Image UPKey;
    [SerializeField] Image DownKey;
    [SerializeField] Image RigntKey;
    [SerializeField] Image LeftKey;
    [SerializeField] Image aKey;
    [SerializeField] Image bKey;

    private Color defaultColor;
    private Color pressedColor = Color.yellow;

    void Start()
    {
        // すべてのテキストのデフォルトの色を設定（必要に応じて）
        defaultColor = UPKey.color;
    }

    void Update()
    {
        // 各キー入力に対して色を変更
        HandleKeyPress(KeyCode.UpArrow, UPKey);
        HandleKeyPress(KeyCode.DownArrow, DownKey);
        HandleKeyPress(KeyCode.LeftArrow, LeftKey);
        HandleKeyPress(KeyCode.RightArrow, RigntKey);
        HandleKeyPress(KeyCode.Space, aKey);
        HandleKeyPress(KeyCode.R, bKey);
    }

    void HandleKeyPress(KeyCode key, Image keyImage)
    {
        if (Input.GetKeyDown(key))
        {
            keyImage.color = pressedColor;  // キーが押されたら色を変更
        }
        else if (Input.GetKeyUp(key))
        {
            keyImage.color = defaultColor;  // キーが離されたら元に戻す
        }
    }

}
