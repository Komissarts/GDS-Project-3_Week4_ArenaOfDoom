using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOrb : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPowerLvls;
    GameObject prevPower;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Transform(5));
    }

    // Update is called once per frame
    void Update()
    {
        
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
