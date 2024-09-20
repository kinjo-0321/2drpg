using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Breakedhole : MonoBehaviour
{
    [SerializeField] playercontroller player;
    [SerializeField] Inspecter Inspecter;
    // ���҂����L�[�V�[�P���X
    private int currentIndex = 0; // ���݂̓��̓C���f�b�N�X

    [SerializeField] Tilemap tilemap;  // Tilemap�̎Q��
    [SerializeField] Vector3Int tilePosition;  // �j�󂵂����^�C���̈ʒu
    private Rigidbody2D rb2D;

    public float detectionRadius = 0.5f; // �^�C���ʒu�Ƃ̋��e�͈�

    private bool isInRange = false; // �v���C���[���^�C���͈͓̔��ɂ��邩�ǂ���
    private bool aKeyPressed = false; // "a"�L�[��������Ă��邩�ǂ���
    private bool bKeyPressed = false;



    void Start()
    {
        // Rigidbody2D�̎擾
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

            // "b"�L�[�������ꂽ���ǂ������m�F
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (aKeyPressed)
                {
                    Destroy(gameObject); // �I�u�W�F�N�g��j�󂷂�
                    Debug.Log("�I�u�W�F�N�g���j�󂳂�܂����B");
                    Inspecter.InspecterEnd();

                }

                // "b"�������ꂽ���"a"�̏�Ԃ����Z�b�g����
                aKeyPressed = false;
            }

            // "a"�������ꂽ�ꍇ
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                aKeyPressed = false;
            }
        }
        
    }
}
