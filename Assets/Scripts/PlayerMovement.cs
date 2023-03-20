using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontal;
    float speed = 8f;
    float jumpingPower = 16f;
    private bool isFacingRight = true;

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
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, jumpingPower);
        }
        if (Input.GetButtonUp("Jump") && PlayerRB.velocity.y > 0f)
        {
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, PlayerRB.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        PlayerRB.velocity = new Vector2(horizontal * speed, PlayerRB.velocity.y);
    }

    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}
