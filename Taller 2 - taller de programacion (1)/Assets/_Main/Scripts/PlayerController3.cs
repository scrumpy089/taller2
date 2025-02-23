using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    public float speed = 6f;
    public float JumpForce = 6f;
    private float movement;

    public float mudSpeed = 3f;
    public float mudJumpForce = 3f;

    public bool evolution;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float groundRadius;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private LayerMask MudLayer;

    bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();  
        evolution = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckGroundType();
        //movement = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.J))
        {
            movement = -1f;
            rb.velocity = new Vector2(movement * speed, rb.velocity.y);
            //rb.AddForce(new Vector2(movement * speed, 0), ForceMode2D.Impulse);
        }
        else
        {
            if (Input.GetKey(KeyCode.L))
            {
                movement = 1f;
                rb.velocity = new Vector2(movement * speed, rb.velocity.y);
            }
        }
        

        if (Input.GetKeyDown(KeyCode.I) && canJump)
        {
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }

        if (evolution)
        {
            spriteRenderer.color = Color.green;
        }
        else 
        { 
            spriteRenderer.color = Color.white; 
        }


    }
    void CheckGroundType()
    {
        canJump = Physics2D.OverlapCircle(GroundCheck.position, groundRadius, GroundLayer);

        if (canJump)
        {
            speed = 6f;
            JumpForce = 6f;
        }
        else if (Physics2D.OverlapCircle(GroundCheck.position, groundRadius, MudLayer))
        {
            speed = mudSpeed;
            JumpForce = mudJumpForce;
            canJump = true;
        }
    }

}
    
