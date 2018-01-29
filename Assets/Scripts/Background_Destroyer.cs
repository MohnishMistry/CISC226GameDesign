using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Destroyer : MonoBehaviour
{

    public GameObject BackgroundDestructionPoint;

    // Use this for initialization
    void Start()
    {
        BackgroundDestructionPoint = GameObject.Find("BackgroundDestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < BackgroundDestructionPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
