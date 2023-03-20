using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float horizontalMaintained;
    [SerializeField] float speed = 8f;
    float speedDif;
    float movement;
    [SerializeField] float accelRate = 0.5f;

    public float jumpingPower = 16f;
    private bool isFacingRight = false;

    [SerializeField] Rigidbody2D PlayerRB;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    int JumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        
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


        if (Input.GetButtonDown("Jump"))
        {
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, jumpingPower);
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
