using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPlayer : MonoBehaviour
{
    public float velocidad = 5f;
    public float jumpForce = 70f;
    public GameObject BulletPrefab;

    // Start is called before the first frame update

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    //const
    private const int IDLE = 0;
    private const int JUMP = 1;
    private const int SLIDE = 2;
    private const int RUN = 3;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        changeAnimation(IDLE);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocidad, rb.velocity.y);
            sr.flipX = false;
            changeAnimation(RUN);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);
            sr.flipX = true;
            changeAnimation(RUN);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            changeAnimation(JUMP);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            changeAnimation(SLIDE);
        }

    }

    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
}
