using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToBike : MonoBehaviour
{
    private float speed = 20f;
    private float destroyBound = 10f;
    private GameManager gameManagerScripti;
    private PlayerController playerControllerScripti;

    void Start()
    {
        gameManagerScripti = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        playerControllerScripti = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManagerScripti.isGameActive == true && playerControllerScripti.speed != 0)
        {
            transform.Translate(speed * Time.deltaTime * new Vector3(0, 1, 0f));
        }

        if(transform.position.z < -destroyBound)
        {
            Destroy(gameObject);
        }
    }
}
