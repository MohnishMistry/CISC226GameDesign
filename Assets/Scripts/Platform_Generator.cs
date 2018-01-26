using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Generator : MonoBehaviour {

    public GameObject thePlatform;
    public Transform generationPoint;
    private float distanceBetween;

    private float platformWidth;
    public float distanceBetweenMin;
    public float distanceBetweenMax;

    public Object_Pooler objectPool;

    private int firstPlatform = 0; 
	// Use this for initialization
	void Start () {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            if (firstPlatform == 0)
            {
                transform.position = new Vector3((transform.position.x + platformWidth - 2 + distanceBetween), transform.position.y, transform.position.z);
                firstPlatform = 1; 
            }
            else {
                transform.position = new Vector3((transform.position.x + platformWidth + distanceBetween), transform.position.y, transform.position.z);
            }
            GameObject newPlatform = objectPool.GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;

            newPlatform.SetActive(true); 
        }
	}
}
