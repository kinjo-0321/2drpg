using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMove : MonoBehaviour
{
    [SerializeField, Tooltip("移動スピード")] private float moveSpeed;

    [SerializeField]
    private Animator PlayerAnim;
    public Rigidbody2D rb;

    [SerializeField]
    private float gridSpeed;

        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    bool isMoving;
    void Update()
    {
        if (isMoving == false)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            /* transform.position += new Vector3(x, y);
           */
            rb.velocity = new Vector2(x, y);
            StartCoroutine(Move(rb.velocity));

            if (x != 0)
            {
                y = 0;
            }

            if (rb.velocity != Vector2.zero)
            {
                if (x != 0)
                {
                    if (x > 0)
                    {
                        PlayerAnim.SetFloat("X", 1f);
                        PlayerAnim.SetFloat("Y", 0f);
                    }
                    else
                    {
                        PlayerAnim.SetFloat("X", -1f);
                        PlayerAnim.SetFloat("Y", 0f);
                    }
                }

                else if (y > 0)
                {

                    PlayerAnim.SetFloat("X", 0f);
                    PlayerAnim.SetFloat("Y", 1f);
                }
                else
                {
                    PlayerAnim.SetFloat("X", 0f);
                    PlayerAnim.SetFloat("Y", -1f);
                }


            }
            else if(!isMoving){ 

                StartCoroutine(Move(rb.velocity));
            }
        }

            IEnumerator Move(Vector2 direction)
            {
                isMoving = true;
                Vector2 targetPos = (Vector2)transform.position + direction;
                while ((targetPos - (Vector2)transform.position).sqrMagnitude > gridSpeed * Mathf.Epsilon)
                {
                    transform.position = Vector2.MoveTowards(transform.position, targetPos, 5f*Time.deltaTime);
                    yield return null;
                }
                transform.position = targetPos;
                isMoving = false;
            }
        
    }
}
