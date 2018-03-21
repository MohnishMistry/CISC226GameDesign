using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy_Collection : MonoBehaviour
{
    public Object_Pooler candyPool;
    public float distanceBetweenCandy;

    public void SpawnCandy(Vector3 startingPosition)
    {
        GameObject candyOne = candyPool.GetPooledObject();
        candyOne.transform.position = new Vector3(startingPosition.x - 0.2f, startingPosition.y, startingPosition.z); ;
        candyOne.SetActive(true);

        GameObject candyTwo = candyPool.GetPooledObject();
        candyTwo.transform.position = new Vector3(startingPosition.x - distanceBetweenCandy - 0.2f, startingPosition.y, startingPosition.z);
        candyTwo.SetActive(true);

        GameObject candyThree = candyPool.GetPooledObject();
        candyThree.transform.position = new Vector3(startingPosition.x + distanceBetweenCandy - 0.2f, startingPosition.y, startingPosition.z);
        candyThree.SetActive(true);
    }
} 
