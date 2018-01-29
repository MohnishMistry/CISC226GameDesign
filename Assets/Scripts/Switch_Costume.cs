using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Costume : MonoBehaviour {

    public GameObject originalCostume;
    public GameObject nextCostume;
    int costume = 1;

    // Use this for initialization
    void Start () {
        originalCostume.SetActive(true);
        nextCostume.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeCostume();
        }
	}

    void ChangeCostume ()
    {
        if (costume == 1)
        {
            nextCostume.SetActive(true);
            originalCostume.SetActive(false);
            //Instantiate(nextCostume, transform.position, transform.rotation);
            //DestroyImmediate(originalCostume, true);
            costume = 2;
        }

        else if (costume == 2)
        {
            originalCostume.SetActive(true);
            nextCostume.SetActive(false);
            //Instantiate(originalCostume, transform.position, transform.rotation);
            //DestroyImmediate(nextCostume, true);
            costume = 1;
        }
    }
}
    