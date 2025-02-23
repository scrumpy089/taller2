using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float speed = 6f;
    public float JumpForce = 6f;
    private float movement;

    public float mudSpeed = 3f;
    public float mudJumpForce = 3f;

    public float coins;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float groundRadius;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private LayerMask MudLayer;

    bool canJump;

    // Start is called before the first frame update
    void Start()    
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGroundType();

        movement = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector2(movement * speed, rb.velocity.y);
        //rb.AddForce(new Vector2(movement * speed, 0), ForceMode2D.Impulse);

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(movement * speed, rb.velocity.y);
            //rb.AddForce(new Vector2(movement * speed, 0), ForceMode2D.Force);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
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
