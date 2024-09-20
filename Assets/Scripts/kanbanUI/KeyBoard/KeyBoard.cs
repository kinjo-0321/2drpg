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
        // ���ׂẴe�L�X�g�̃f�t�H���g�̐F��ݒ�i�K�v�ɉ����āj
        defaultColor = UPKey.color;
    }

    void Update()
    {
        // �e�L�[���͂ɑ΂��ĐF��ύX
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
            keyImage.color = pressedColor;  // �L�[�������ꂽ��F��ύX
        }
        else if (Input.GetKeyUp(key))
        {
            keyImage.color = defaultColor;  // �L�[�������ꂽ�猳�ɖ߂�
        }
    }

}
