using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private CollisionManager colM;
    [SerializeField] 
    private GameObject player;
    public Vector2 spawnPos = new Vector3(-15, 1);
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        colM = player.GetComponent<CollisionManager>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (colM.dead == true)
            StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        if (colM.lives > 0)
        {
            yield return new WaitForSeconds(1);
            player.transform.position = spawnPos;
            player.SetActive(true);
            colM.dead = false;
        }
    }
}