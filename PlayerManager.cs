using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float speed=3;
    private Rigidbody2D playerRb;
    //public GameManager gameManager;
    private Vector2 moveInput;
    private Animator animator;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        //animator.SetFloat("Vertical",(moveY));
        if (moveY< 0)
        { 
            animator.SetBool("Frente", true);
            
        }
        if (moveY > 0)
        {
            
            animator.SetBool("Espalda", true);
        }
        if (moveY == 0)
        {
            animator.SetBool("Espalda", false);
            animator.SetBool("Frente", false);
        }
        if (moveX < 0)
        {
            animator.SetBool("IZQ", true);
            animator.SetBool("DER", false);

        }
        if (moveX > 0)
        {

            animator.SetBool("DER", true);
            animator.SetBool("IZQ", false); 
        }
        if (moveX == 0)
        {
            animator.SetBool("DER", false);
            animator.SetBool("IZQ", false);
        }

        //animator.SetFloat("Vertical",Mathf.Abs(moveY));
        moveInput = new Vector2(moveX, moveY).normalized;
    }
    private void FixedUpdate()
    {
        playerRb.MovePosition( playerRb.position + moveInput * speed * Time.fixedDeltaTime );
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.LoseLife();
        }
        else if (collision.gameObject.CompareTag("Point")) {
            GameManager.Instance.AddPoints(1);
        }
        else if (collision.gameObject.CompareTag("CheckPoint"))
        {
            GameManager.Instance.LoadScene("Casa");
        }
    }

}
