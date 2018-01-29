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

    // Use this for initialization
    void Start () {
        platformGeneratorScript = platformGenerator.GetComponent<Platform_Generator>();
    }

// Update is called once per frame
void Update () {
        if (transform.position.x < generationPoint.transform.position.x)
        {
            transform.position = new Vector3((transform.position.x + platformGeneratorScript.distanceBetween), transform.position.y, transform.position.z); //Move Obstacle Generator to the start of the newly generated platform
            platformWidth = platformGeneratorScript.platformWidths[platformGeneratorScript.platformSelector];

            if ((platformWidth > 3))
            {
                obstacleDistance = Random.Range(0.33f*platformWidth, 0.66f*platformWidth);

                transform.position = new Vector3((transform.position.x + obstacleDistance), transform.position.y, transform.position.z); //Move Obstacle Generator to a random distance on the platform
                Instantiate(obstacle, transform.position, transform.rotation);

                transform.position = platformGenerator.transform.position; 
            }
        }

    }
}
