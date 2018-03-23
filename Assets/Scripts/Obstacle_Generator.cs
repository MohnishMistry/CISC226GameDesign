﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Generator : MonoBehaviour {

    public Transform generationPoint;
    public GameObject platformGenerator;
    private Platform_Generator platformGeneratorScript;
    public Object_Pooler[] obstaclePool;
    public int obstacleSelector;


    public float obstacleDistance;
    public float platformWidth;
    private float spaceBetweenPlatforms;
    private float distanceBetweenMax; 
    private Vector3 obstaclePosition;

    public Candy_Collection candyCollector;

    // Use this for initialization
    void Start () {
        platformGeneratorScript = platformGenerator.GetComponent<Platform_Generator>();
    }

    public void Spawn()
    {
        if (Random.value > 0.25)
        {
            obstacleSelector = Random.Range(0, obstaclePool.Length);
            GameObject newObstacle = obstaclePool[obstacleSelector].GetPooledObject();
           
            distanceBetweenMax = platformGeneratorScript.distanceBetweenMax;
            spaceBetweenPlatforms = platformGeneratorScript.distanceBetween;
            platformWidth = platformGeneratorScript.platformWidths[platformGeneratorScript.platformSelector];
            obstacleDistance = Random.Range(0.4f * platformWidth, 0.6f * platformWidth);

            if (newObstacle.tag == "Thorns")
            {
                obstaclePosition = new Vector3((transform.position.x + obstacleDistance), -2.67f, transform.position.z); //Move Obstacle Generator to a random distance on the platform
                candyCollector.SpawnCandy(new Vector3((transform.position.x + obstacleDistance), -2.47f, transform.position.z));
            }
            else if (newObstacle.tag == "Dummy")
            {
                obstaclePosition = new Vector3((transform.position.x + obstacleDistance), transform.position.y, transform.position.z); //Move Obstacle Generator to a random distance on the platform            }
            }
            else if (newObstacle.tag == "Large Ghost Wall")
            {
                obstaclePosition = new Vector3((transform.position.x + obstacleDistance), transform.position.y, transform.position.z); //Move Obstacle Generator to a random distance on the platform

            }
            else if (newObstacle.tag == "Small Ghost Wall")
            {
                obstaclePosition = new Vector3((transform.position.x + obstacleDistance), transform.position.y - 0.55f, transform.position.z); //Move Obstacle Generator to a random distance on the platform
                candyCollector.SpawnCandy(new Vector3((transform.position.x - 1.7f + obstacleDistance), transform.position.y - 0.55f, transform.position.z));
            }
            else if (newObstacle.tag == "Robot Wall")
            {
                obstaclePosition = new Vector3((transform.position.x + obstacleDistance), 3.52f, transform.position.z); //Move Obstacle Generator to a random distance on the platform
            }
            else if (newObstacle.tag == "Robot Floor")
            {
                if ((spaceBetweenPlatforms < distanceBetweenMax) && (spaceBetweenPlatforms > 2.1) && Random.value >= 0.1)
                {
                    obstaclePosition = new Vector3((transform.position.x - 2), -2.736f, transform.position.z); //Move Obstacle Generator to a random distance on the platform
                    candyCollector.SpawnCandy(new Vector3((transform.position.x - 2.5f), -2.4f, transform.position.z));
                } 
                else
                    return;
            }
            else if (newObstacle.tag == "Troll")
            {
                obstaclePosition = new Vector3((transform.position.x + obstacleDistance), -0.2f, transform.position.z); //Move Obstacle Generator to a random distance on the platform
            }
            else if (newObstacle.tag == "Wolf")
            {
                obstaclePosition = new Vector3((transform.position.x + obstacleDistance), 0, transform.position.z); //Move Obstacle Generator to a random distance on the platform
            }

            newObstacle.transform.position = obstaclePosition;
            newObstacle.SetActiveRecursively(true);
            
        }
    }

}

