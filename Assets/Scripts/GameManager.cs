using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    ArcadeKart playerKart;

    [SerializeField]
    List<Transform> levelCheckpoints;

    [Header("Method related variables")]

    //distance related variables
    [SerializeField] float result;
    [SerializeField] float currD;
    float startD;

    //middle point related variables
    private float middleZ;
    private float middleX;
    private float middleY;

    //common method variables
    [SerializeField] Transform player;
    private Transform firstCheckpoint;
    private Transform secondCheckpoint;
    private Transform goalCheckpoint;

    void Start()
    {
        if (!playerKart)
        {
            playerKart = FindObjectOfType<ArcadeKart>();
        }
    }

    void Update()
    {
        //Set all player checkpoints to transforms
        for (int i = 0; i < levelCheckpoints.Count; i++)
        {
            levelCheckpoints[i].GetComponent<Transform>();
        }

        //calculate the different differences between the two relevant checkpoints
        for (int i = 0; i <= levelCheckpoints.Count; i++)
        {
            DistanceFormula(player, levelCheckpoints[i], levelCheckpoints[i + 1 % levelCheckpoints.Count]);
            MiddlePointFormula(levelCheckpoints[i], levelCheckpoints[i + 1 % levelCheckpoints.Count], player);
            Debug.Log($"This is currD: {currD}\n And this is startD; {startD}\n This is the level checkpoint index: {i}");
        }

        //startD aka the whole distance should be assigned here
    }

    void DistanceFormula(Transform player, Transform checkpoint1, Transform checkpoint2)
    {
        currD = Mathf.Sqrt(Mathf.Pow(checkpoint2.position.x - player.position.x, 2) + Mathf.Pow(checkpoint2.position.y - player.position.y, 2) +
            Mathf.Pow(checkpoint2.position.z - player.position.z, 2));

        startD = Mathf.Sqrt(Mathf.Pow(checkpoint2.position.x - checkpoint1.position.x, 2) + Mathf.Pow(checkpoint2.position.y - checkpoint1.position.y, 2) +
           Mathf.Pow(checkpoint2.position.z - checkpoint1.position.z, 2));

        //const float startD = currD;
        result = currD / startD;
    }

    void MiddlePointFormula(Transform checkpoint1, Transform checkpoint2, Transform player)
    {
        middleX = (checkpoint1.position.x + checkpoint2.position.x) / 2;
        middleY = (checkpoint1.position.y + checkpoint2.position.y) / 2;
        middleZ = (checkpoint1.position.z + checkpoint2.position.z) / 2;

        if (player.position.x == middleX || player.position.y == middleY)
        {
            //update scoreboard
            Debug.Log("halfway there");
        }
    }
}