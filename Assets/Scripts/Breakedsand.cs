using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Breakedsand : MonoBehaviour
{
    [SerializeField] playercontroller player;
    [SerializeField] Inspecter Inspecter;
    // ���҂����L�[�V�[�P���X
    private KeyCode[] correctSequence = { KeyCode.UpArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.R, KeyCode.Space };
    private int currentIndex = 0; // ���݂̓��̓C���f�b�N�X

    public Tilemap tilemap;  // Tilemap�̎Q��
    public Vector3Int tilePosition;  // �j�󂵂����^�C���̈ʒu
    private Rigidbody2D rb2D;


    void Start()
    {
        // Rigidbody2D�̎擾
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
                    // �������L�[�����͂��ꂽ�ꍇ�A�C���f�b�N�X��i�߂�
                    currentIndex++;

                    // �S�ẴL�[�����������͂��ꂽ�ꍇ
                    if (currentIndex >= correctSequence.Length)
                    {
                        gameObject.SetActive(false);
                        Inspecter.InspecterEnd();
                    }
                }
                else if (Input.anyKeyDown)
                {
                    // �Ԉ�����L�[�������ꂽ�ꍇ�A�V�[�P���X�����Z�b�g
                    currentIndex = 0;
                }
            }
        }
 
    }
}







            // ���݂̐������L�[���m�F



// �^�C����j�󂷂郁�\�b�h




