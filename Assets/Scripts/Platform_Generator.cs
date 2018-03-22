using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Generator : MonoBehaviour {

    public Transform generationPoint;
    public float distanceBetween;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    public int platformSelector;
    public float[] platformWidths;
    public Object_Pooler[] objectsPool;

    private Obstacle_Generator obstacleGeneratorScript;
    public GameObject obstacleGenerator;

    public Candy_Collection candyCollector; 
    // Use this for initialization
    void Start () {
        platformWidths = new float[objectsPool.Length];

        for (int i = 0; i < objectsPool.Length; i++)
        {
            platformWidths[i] = objectsPool[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        obstacleGeneratorScript = obstacleGenerator.GetComponent<Obstacle_Generator>();
    }

    // Update is called once per frame
    void Update () {
        if(transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            platformSelector = Random.Range(0, objectsPool.Length);

            transform.position = new Vector3((transform.position.x + distanceBetween) , transform.position.y, transform.position.z);
            
            GameObject newPlatform = objectsPool[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;

            newPlatform.SetActiveRecursively(true);

            if (platformWidths[platformSelector] > 3)
            {
                obstacleGeneratorScript.Spawn();
            }
            else
            {
                candyCollector.SpawnCandy(transform.position);
            }

            transform.position = new Vector3((transform.position.x + (platformWidths[platformSelector])), transform.position.y, transform.position.z);

        }
    }
}
