using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
    BoxCollider2D bc;
    Rigidbody2D rb;

    [SerializeField]
    public int lives = 3;
    public bool dead { get; set; }

    int score = 0;
    int scoreMultiplier;

    EnemyMovement enemyMoveClass;
    [SerializeField] PlayerMovement playMoveClass;

    //get reference to movement script
    [SerializeField] float speedMultiplier = 1.5f;
    [SerializeField] float gravMultiplier = 0.5f;
    [SerializeField] int powerupDuration = 5;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        dead = false;
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
            case "GravPowerup":
                playMoveClass.PlayerRB.gravityScale = playMoveClass.PlayerRB.gravityScale * gravMultiplier;
                StartCoroutine(GravPowerup(powerupDuration));
                break;
            case "SpeedPowerup":
                playMoveClass.speed = playMoveClass.speed * speedMultiplier;
                StartCoroutine(SpeedPowerup(powerupDuration));
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch(col.gameObject.tag)
        {
            case "Lava":
                Debug.Log("u die");
                Death(this.gameObject);
                break;
            case "EnemyOrb":
                Debug.Log("Orb collected");
                score = score + (100 * 2);
                AudioManager.Instance.PlaySFX("S7PositiveSound");
                break;
        }
    }

    void HeightCheck(Collision2D collision)
    {
        if (collision.gameObject.transform.position.y > this.transform.position.y)
        {
            Death(this.gameObject);
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
            enemyMoveClass = collision.gameObject.GetComponent<EnemyMovement>();
            enemyMoveClass.TakeDamage();
            score = score + (100 * scoreMultiplier);
            enemyMoveClass = null; //???

        }
    }

    void Death(GameObject obj)
    {
        if (dead == false)
        {
            obj.SetActive(false);
            AudioManager.Instance.PlaySFX("S5KilledORKnockedout");
            lives -= 1;
            dead = true;
        }
    }

    IEnumerator GravPowerup(int seconds)
    {
        yield return new WaitForSeconds(seconds);

        playMoveClass.PlayerRB.gravityScale = playMoveClass.PlayerRB.gravityScale / gravMultiplier;
    }

    IEnumerator SpeedPowerup(int seconds)
    {
        yield return new WaitForSeconds(seconds);

        playMoveClass.speed = playMoveClass.speed * speedMultiplier;
    }
}
