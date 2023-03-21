using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject enemyOrb;
    EnemyOrb enemyOrbClass;

    // Start is called before the first frame update
    void Start()
    {
        
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
