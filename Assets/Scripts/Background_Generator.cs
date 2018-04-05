using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Generator : MonoBehaviour {

    public Transform BackGroundGenerationPoint;
    private float backgroundWidth;
    public Object_Pooler[] obstaclePool;
    public Object_Pooler[] cloudsPool;
    public int backgroundSelector;

    // Use this for initialization
    void Start () {
        backgroundWidth = 14.4F;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(transform.position.x < BackGroundGenerationPoint.position.x)
        {
            backgroundSelector = Random.Range(0, obstaclePool.Length);
            GameObject newBackground = obstaclePool[backgroundSelector].GetPooledObject();
            GameObject newCloud = cloudsPool[backgroundSelector].GetPooledObject();

            transform.position = new Vector3(transform.position.x + backgroundWidth, 0.1f, transform.position.z);
            Vector3 cloudsLocation = new Vector3(transform.position.x + backgroundWidth+3f, 5f, transform.position.z);

            newBackground.transform.position = transform.position;
            newBackground.SetActive(true);
            newCloud.transform.position = cloudsLocation;
            newCloud.SetActive(true);
        }
    }
}
