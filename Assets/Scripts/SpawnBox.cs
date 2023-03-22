using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBox : MonoBehaviour
{
    [SerializeField] GameObject[] SpawnPoint;
    [SerializeField] GameObject objToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        int index = Random.Range(0, (SpawnPoint.Length - 1));
        Instantiate(objToSpawn, SpawnPoint[index].transform.position, Quaternion.identity);
        AudioManager.Instance.PlaySFX("S9Spawn");
    }
}
