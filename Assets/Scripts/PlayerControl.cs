using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using JetBrains.Annotations;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{   
    //=================================================================
    public float moveIt = 5f;               public GameObject gameOver;
    public float jumpIt = 10f;              public GameObject bulletObject;
    private bool isGrounded;                public Transform barrel;
    private bool lookright;                 public bool coolDown;
    private Rigidbody2D rb;                 public float noUh = 2f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;
    private UnityEngine.Vector2 movement;

    //==================================================================
    public Animator animator;
    //==================================================================
    void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius, groundLayer);
        if(Input.GetKeyDown(KeyCode.L))
        {
            Debugger();
        }

        if(coolDown == false && Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("BLACK INDIVIDUAL SPOTTED" , true);
            Shoot();
            coolDown = true;
        }
        else
        {
            animator.SetBool("BLACK INDIVIDUAL SPOTTED" , false);
        }

        #region MOVEMENT

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new UnityEngine.Vector2(rb.velocity.x, jumpIt);
            animator.SetBool("isJump?" , true);
            Debug.Log("JUMPIN");
        }
        if(isGrounded)
        {
            animator.SetBool("isJump?" , false);
        }
        else
        {
            animator.SetBool("isJump?", true);
        }

        animator.SetBool("isWalk?" , movement.x !=0);
        if(movement.x > 0 && !lookright)
        {
            Flip();
        }
        else if(movement.x < 0 && lookright)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement * moveIt * Time.fixedDeltaTime);    
        rb.velocity = new UnityEngine.Vector2(movement.x * moveIt, rb.velocity.y);
    }

        #endregion

    private void Flip()
    {
        lookright = !lookright;
        UnityEngine.Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
    //==================================================================
    //MECHANICS
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }
        if(other.CompareTag("border"))
        {
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void Shoot()
    {
        //Debug.Log("Shooting. Lookright: " + lookright);
        GameObject bullet = Instantiate(bulletObject, barrel.position, UnityEngine.Quaternion.identity);
        UnityEngine.Vector2 bulletDirection = lookright ? UnityEngine.Vector2.right : UnityEngine.Vector2.left;
        bullet.GetComponent<Projectile>().Initialize(bulletDirection);
        coolDown = true;
        StartCoroutine(HotBarrel());
    }

    private IEnumerator HotBarrel()
    {
        yield return new WaitForSeconds(noUh);
        coolDown = false;
    }
    
    //==================================================================
    //NON PRIORITY
    public void ToRight()
    {
        rb.velocity = new UnityEngine.Vector2(moveIt, rb.velocity.y);
        Input.GetKeyDown(KeyCode.D); 
        Debug.Log("RIGHT");
        lookright = true;
    }
    public void ToLeft()
    {
        rb.velocity = new UnityEngine.Vector2(-moveIt, rb.velocity.y);
        Debug.Log("LEFT");
        lookright = false;
    }
    public void ToJump()
    {
        Input.GetButtonDown("Jump");
    }

    
    //==================================================================
    void Debugger()
    {
        if(isGrounded == true)
        {
            Debug.Log("IsGrounded");
        }
        else
        {
            Debug.Log("NOTgrounded");
        }
    }
    //==================================================================
}
