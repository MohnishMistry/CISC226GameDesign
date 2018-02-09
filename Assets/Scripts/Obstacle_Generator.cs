using System.Collections;
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

    private Vector3 obstaclePosition; 
    // Use this for initialization
    void Start () {
        platformGeneratorScript = platformGenerator.GetComponent<Platform_Generator>();
    }

    public void Spawn()
    {
        if (Random.value > 0.2)
        {
            obstacleSelector = Random.Range(0, obstaclePool.Length);
            GameObject newObstacle = obstaclePool[obstacleSelector].GetPooledObject();

            platformWidth = platformGeneratorScript.platformWidths[platformGeneratorScript.platformSelector];
            obstacleDistance = Random.Range(0.33f * platformWidth, 0.66f * platformWidth);

            if (newObstacle.tag == "Thorns")
            {
                obstaclePosition = new Vector3((transform.position.x + obstacleDistance), -2.67f, transform.position.z); //Move Obstacle Generator to a random distance on the platform
            }
            else if (newObstacle.tag == "Dummy")
            {
                obstaclePosition = new Vector3((transform.position.x + obstacleDistance), transform.position.y, transform.position.z); //Move Obstacle Generator to a random distance on the platform

            }
            else if (newObstacle.tag == "Large Ghost Wall")
            {
                obstaclePosition = new Vector3((transform.position.x + obstacleDistance), transform.position.y, transform.position.z); //Move Obstacle Generator to a random distance on the platform

            }
            else if (newObstacle.tag == "Small Ghost Wall")
            {
                obstaclePosition = new Vector3((transform.position.x + obstacleDistance), transform.position.y-0.55f, transform.position.z); //Move Obstacle Generator to a random distance on the platform

            }

            newObstacle.transform.position = obstaclePosition; 
            newObstacle.SetActiveRecursively(true);

        }
    }

}

