using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    [SerializeField]
    private Collider2D playerCol;
    // Start is called before the first frame update
    private void Awake()
    {
        playerCol = player.GetComponent<CapsuleCollider2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
