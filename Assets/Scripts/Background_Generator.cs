using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Generator : MonoBehaviour {

    public GameObject background;
    public Transform BackGroundGenerationPoint;
    private float backgroundWidth;

	// Use this for initialization
	void Start () {
        backgroundWidth = 14.4F;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(transform.position.x < BackGroundGenerationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + backgroundWidth, transform.position.y, transform.position.z);
            Instantiate(background, transform.position, transform.rotation);
        }
	}
}
