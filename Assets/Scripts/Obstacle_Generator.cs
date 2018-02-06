using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Generator : MonoBehaviour {

    public Transform generationPoint;
    public GameObject platformGenerator;
    private Platform_Generator platformGeneratorScript;
    public GameObject obstacle; 

    public float obstacleDistance;
    public float platformWidth;

    private Vector3 obstaclePosition; 
    // Use this for initialization
    void Start () {
        platformGeneratorScript = platformGenerator.GetComponent<Platform_Generator>();
    }

    public void Spawn()
    {
        if (Random.value > 0.3)
        {
            platformWidth = platformGeneratorScript.platformWidths[platformGeneratorScript.platformSelector];
            obstacleDistance = Random.Range(0.33f * platformWidth, 0.66f * platformWidth);
            obstaclePosition = new Vector3((transform.position.x + obstacleDistance), transform.position.y, transform.position.z); //Move Obstacle Generator to a random distance on the platform
            obstacle.layer = 10;
            Instantiate(obstacle, obstaclePosition, transform.rotation);
        } 
    }

}

