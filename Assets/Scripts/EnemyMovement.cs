using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject enemyOrb;
    [SerializeField] EnemyOrb enemyOrbClass;

    float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlaySFX("S8OminousEnemy");

        switch(this.gameObject.tag)
        {
            case "Lvl1Enemy":
                moveSpeed = 6.0f;
                break;
            case "Lvl2Enemy":
                moveSpeed = 8.0f;
                break;
            case "Lvl3Enemy":
                moveSpeed = 10.0f;
                break;
            default:
                break;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        Instantiate(enemyOrb, this.transform.position, Quaternion.identity);
        enemyOrbClass.StartCountdown();
        enemyOrbClass.prevPower = this.gameObject;
    }
}
