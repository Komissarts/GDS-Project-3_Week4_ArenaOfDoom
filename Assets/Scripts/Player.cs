using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    BoxCollider2D bc;
    Rigidbody2D rb;
    [SerializeField] int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Lvl1Enemy":
            if(collision.gameObject.transform.position.y > this.transform.position.y)
            {
                Death(this);
                if(lives > 0)
                {
                    lives = lives - 1;
                }
                else
                {
                    //Send to "Game Over" scene
                }
            }
            else
            {
                Death(collision.gameObject);
            }
            break;
        }
    }

    void Death(Object obj)
    {
        Destroy(obj);
    }
}
