using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float horizontalMaintained;
    [SerializeField] public float speed = 5f;
    float speedDif;
    float movement;
    [SerializeField] float accelRate = 0.5f;

    [SerializeField] int JumpBonus = 3;
    [SerializeField] int JumpCounter = 0;
    [SerializeField] private bool isJumping; //anim

    [SerializeField] public float jumpingPower = 2f;

    [SerializeField] float updatedJumpingPower = 2f;

    public bool isFacingRight = false;

    [SerializeField] public Rigidbody2D PlayerRB;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    int JumpHeight;

    private Animator animator;

    // Start is called before the first frame update
    private void Awake()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        animator = GetComponent<Animator>();

        JumpCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        speedDif = speed - PlayerRB.velocity.x;
        movement = speedDif * accelRate;

        horizontalInput = Input.GetAxisRaw("Horizontal");
        
        if(horizontalInput != 0f)
        {
            animator.SetBool("IsMoving", true); //anim
            horizontalMaintained = horizontalInput;
        }
        else
        {
            animator.SetBool("IsMoving", false); //anim
        }

        if (PlayerRB.velocity.y == 0f)
        {
            updatedJumpingPower = jumpingPower;
            horizontalMaintained = 0f;
            JumpCounter = 0;
        }


        if (Input.GetButtonDown("Jump"))
        {
            JumpCounter++;
            animator.SetBool("IsJumping", true); //anim
            isJumping = true; //anim
            if (JumpCounter <= JumpBonus)
            {
                updatedJumpingPower = jumpingPower*JumpCounter;
            }

            //updatedJumpingPower = jumpingPower * jumpingPower;

            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, updatedJumpingPower);
            AudioManager.Instance.PlaySFX("S4PlayerCollide");

        }
        if (Input.GetButtonUp("Jump") && PlayerRB.velocity.y > 0f)
        {
            animator.SetBool("IsJumping", false); //anim
            isJumping = false; //anim
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, PlayerRB.velocity.y * 0.5f);
            //PlayerRB.AddForce(movement * Vector2.right);
        }

        /*while (PlayerRB.velocity.x != 0f){
            AudioManager.Instance.PlaySFX("S1Walk");
        }
        */
        Flip();
    }

    private void FixedUpdate()
    {
        PlayerRB.velocity = new Vector2(horizontalMaintained * speed, PlayerRB.velocity.y);
    }

    private void Flip()
    {
        if(isFacingRight && horizontalMaintained < 0f || !isFacingRight && horizontalMaintained > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}
