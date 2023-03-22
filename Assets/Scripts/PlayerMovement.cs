using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float horizontalMaintained;
    [SerializeField] public float speed = 8f;
    float speedDif;
    float movement;
    [SerializeField] float accelRate = 0.5f;

    [SerializeField] int JumpBonus = 3;
    [SerializeField] int JumpCounter = 0;

    [SerializeField] public float jumpingPower = 2f;

    [SerializeField] float updatedJumpingPower = 2f;

    public bool isFacingRight = false;

    [SerializeField] public Rigidbody2D PlayerRB;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    int JumpHeight;

    // Start is called before the first frame update
    void Start()
    {
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
            horizontalMaintained = horizontalInput;
        }

        if (PlayerRB.velocity.magnitude == 0f)
        {
            updatedJumpingPower = jumpingPower;
            JumpCounter = 0;
        }


        if (Input.GetButtonDown("Jump"))
        {
            JumpCounter++;
            if (JumpCounter <= JumpBonus)
            {
                updatedJumpingPower = jumpingPower*JumpCounter;
            }

            //updatedJumpingPower = jumpingPower * jumpingPower;

            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, updatedJumpingPower);
        }
        if (Input.GetButtonUp("Jump") && PlayerRB.velocity.y > 0f)
        {
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, PlayerRB.velocity.y * 0.5f);
            //PlayerRB.AddForce(movement * Vector2.right);
        }

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
