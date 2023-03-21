using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOrb : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPowerLvls;
    public GameObject prevPower;
    [SerializeField] float moveSpeed = 100.0f;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce((new Vector2(1, 1) * moveSpeed), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartCountdown()
    {
        StartCoroutine(Transform(5));
    }

    IEnumerator Transform(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(this);
        switch(prevPower.tag)
        {
            case "Lvl1Enemy":
                Instantiate(enemyPowerLvls[1], this.transform.position, Quaternion.identity);
                break;
            case "Lvl2Enemy":
                Instantiate(enemyPowerLvls[2], this.transform.position, Quaternion.identity);
                break;
            case "Lvl3Enemy":
                Instantiate(enemyPowerLvls[2], this.transform.position, Quaternion.identity);
                break;
            default:
                break;
        }
    }
}
