using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kanbanBase : MonoBehaviour
{
    [SerializeField] playercontroller player;
    [SerializeField] Plate1UI plate1;
    [SerializeField] Palet2UI plate2;
    [SerializeField] Vector3Int tilePosition;
    [SerializeField] Vector3Int tilePosition2;// ”j‰ó‚µ‚½‚¢ƒ^ƒCƒ‹‚ÌˆÊ’u
    private Rigidbody2D rb2D;

    void Start()
    {
        // Rigidbody2D‚ÌŽæ“¾
        rb2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position == tilePosition)
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                plate1.Plate1Open();
                player.gameObject.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                plate1.Plate1Close();
                player.gameObject.SetActive(true);
            }
            
        }

        if(player.transform.position == tilePosition2)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                plate2.Plate2Open();
                player.gameObject.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                plate2.Plate2Close();
                player.gameObject.SetActive(true);
            }

        }
    }
}
