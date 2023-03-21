using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
    BoxCollider2D bc;
    Rigidbody2D rb;

    [SerializeField] int lives = 3;

    int score = 0;
    int scoreMultiplier;

    EnemyMovement enemyMoveClass;

    //get reference to movement script
    [SerializeField] int speedMultiplier = 2;

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
                scoreMultiplier = 1;
                HeightCheck(collision);
                break;
            case "Lvl2Enemy":
                scoreMultiplier = 2;
                HeightCheck(collision);
                break;
            case "Lvl3Enemy":
                scoreMultiplier = 3;
                HeightCheck(collision);
                break;
            case "EnemyDrone":
                scoreMultiplier = 5;
                HeightCheck(collision);
                break;
            case "Lava": //Need to add "Lava" tag to the lava sprites
                Death(this);
                if (lives > 0)
                {
                    lives = lives - 1;
                }
                else
                {
                    SceneManager.LoadScene("GameOver");
                }
                break;
            case "EnemyOrb":
                score = score + (100 * 2);
                break;
            case "GravPowerup":
                //decrease gravity
                break;
            case "SpeedPowerup":
                //increase speed
                break;
            default:
                break;
        }
    }

    void HeightCheck(Collision2D collision)
    {
        if (collision.gameObject.transform.position.y > this.transform.position.y)
        {
            Death(this);
            if (lives > 0)
            {
                lives = lives - 1;
            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        else
        {
            Death(collision.gameObject);
            enemyMoveClass.TakeDamage();
            score = score + (100 * scoreMultiplier);
        }
    }

    void Death(Object obj)
    {
        Destroy(obj);
    }
}
