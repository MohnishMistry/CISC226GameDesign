using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Generator : MonoBehaviour {

    public Transform BackGroundGenerationPoint;
    private float backgroundWidth;
    public Object_Pooler[] obstaclePool;
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

            transform.position = new Vector3(transform.position.x + backgroundWidth, 0.15f, transform.position.z);

            newBackground.transform.position = transform.position;
            newBackground.SetActive(true);

        }
    }
}
