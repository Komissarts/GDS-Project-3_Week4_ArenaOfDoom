using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private CollisionManager colM;
    [SerializeField] 
    private GameObject player;
    public Vector2 spawnPos = new Vector3(-15, 1);
    public GameObject[] enemySpawnPoints;
    public GameObject enemy;
    private bool enemySpawned = false;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        colM = player.GetComponent<CollisionManager>();
    }

    void Start()
    {
        SpawnEnemy();
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (colM.dead == true && colM.lives > 0)
            StartCoroutine(Respawn());
        if (colM.dead == true && colM.lives == 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        if (colM.enemyCount > 0 && colM.enemyCount < 2 )
           StartCoroutine(RespawnEnemy());
        else if (colM.enemyCount == 0)
        {
            Debug.Log("Congrats!");
        }
    }

    IEnumerator Respawn()
    {
        Debug.Log("Remaining Life: " + colM.lives);
        yield return new WaitForSeconds(1);
        player.transform.position = spawnPos;
        player.SetActive(true);
        colM.dead = false;
        AudioManager.Instance.PlaySFX("S6Respawn");
    }

    void SpawnEnemy()
    {
        int index = Random.Range(0, enemySpawnPoints.Length);
        Instantiate(enemy, enemySpawnPoints[index].transform.position, Quaternion.identity);
        AudioManager.Instance.PlaySFX("S9Spawn");
    }

    IEnumerator RespawnEnemy()
    {
        yield return new WaitForSeconds(3);
        if (enemySpawned == false)
        {
            SpawnEnemy();
            colM.enemyCount += 1;
            enemySpawned = true;
            StartCoroutine(SetEnemySpawned());
        }   
    }

    IEnumerator SetEnemySpawned()
    {
        yield return new WaitForSeconds(2);
        enemySpawned = false;
    }
}
