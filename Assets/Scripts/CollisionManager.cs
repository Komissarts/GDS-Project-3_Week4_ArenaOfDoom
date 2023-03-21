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
    PlayerMovement playMoveClass;

    //get reference to movement script
    [SerializeField] float speedMultiplier = 1.5f;
    [SerializeField] float gravMultiplier = 0.5f;
    [SerializeField] int powerupDuration = 5;

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
                //playMoveClass.PlayerRB.gravityScale = playMoveClass.PlayerRB.gravityScale * gravMultiplier;
                StartCoroutine(GravPowerup(powerupDuration));
                break;
            case "SpeedPowerup":
                //playMoveClass.speed = playMoveClass.speed * speedMultiplier;
                StartCoroutine(SpeedPowerup(powerupDuration));
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

    IEnumerator GravPowerup(int seconds)
    {
        yield return new WaitForSeconds(seconds);

        //playMoveClass.PlayerRB.gravityScale = playMoveClass.PlayerRB.gravityScale / gravMultiplier;
    }

    IEnumerator SpeedPowerup(int seconds)
    {
        yield return new WaitForSeconds(seconds);

        //playMoveClass.speed = playMoveClass.speed * speedMultiplier;
    }
}
