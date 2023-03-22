using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerups : MonoBehaviour
{
    [SerializeField] GameObject[] SpawnPoint;
    [SerializeField] GameObject[] powerToSpawn;
    [SerializeField] float spawnTime = 20f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPowerup", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPowerup()
    {
        int spawnIndex = Random.Range(0, (SpawnPoint.Length));
        int powerIndex = Random.Range(0, (powerToSpawn.Length));
        Instantiate(powerToSpawn[powerIndex], SpawnPoint[spawnIndex].transform.position, Quaternion.identity);
        //AudioManager.Instance.PlaySFX("S9Spawn");
    }
}
