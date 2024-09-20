using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playercontroller : MonoBehaviour
{
    [SerializeField, Tooltip("setting Layer")] LayerMask solidObjectsLayer;
    [SerializeField, Tooltip("setting Layer")] LayerMask encountLayer;

    [SerializeField] Battler battler;

    public UnityAction<Battler> OnEncounts;



    // Start is called before the first frame update
   

    // Update is called once per frame
    bool isMoving;

    private Animator animator;

    public Battler Battler { get => battler; }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
       battler.Init();
    }

    void Update()
    {
        if (isMoving == false)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            if (x != 0f)
            {
                y = 0;
            }

            if (x != 0 || y != 0)
            {
                animator.SetFloat("InputX", x);
                animator.SetFloat("InputY", y);
                StartCoroutine(Move(new Vector2(x, y)));
            }




            // プレイヤーの移動処理をコルーチンで呼び出す
            
        }

        animator.SetBool("IsMoving", isMoving);

    }


    IEnumerator Move(Vector3 direction)
    {
        isMoving = true;
        // 目標地点を計算
        Vector3 targetPos = transform.position + direction;

        if(IsWalkable(targetPos) == false)
        {
            isMoving = false;
            yield break;
        }

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            // プレイヤーを目標地点に徐々に移動させる
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 5f * Time.deltaTime);
            yield return null;  // 次のフレームまで待つ
        }
        // 最終的な位置にスナップ
        transform.position = targetPos;
        isMoving = false;

        CheckForEncounts();
    }


    void CheckForEncounts()
    {
        Collider2D encount = Physics2D.OverlapCircle(transform.position, 0.2f, encountLayer);
       if (encount)
        {
            if (Random.Range(0, 100) < 5)
            {
                Battler enemy = encount.GetComponent<EncountArea>().GetRandomBattler();
                OnEncounts?.Invoke(enemy);
            }
        }

        
    }
        


    bool IsWalkable(Vector3 targetPos)
    {
        return Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer) == false;
    }

    public override bool Equals(object obj)
    {
        return obj is playercontroller playercontroller &&
               base.Equals(obj) &&
               EqualityComparer<Battler>.Default.Equals(battler, playercontroller.battler);
    }

    public override int GetHashCode()
    {
        return System.HashCode.Combine(base.GetHashCode(), battler);
    }

    public void playerStop()
    {
        transform.position = new Vector3(-2,  0, 0);
    }

    public void playerRestart()
    {
        Vector3 currentPosition = transform.position;
        transform.position = new Vector3(1, 2, 0);
        
    }
}