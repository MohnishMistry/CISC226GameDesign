using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Send_Projectile : MonoBehaviour {

    public GameObject player;
    public GameObject projectile;
    private Player_Controller controller;
    public GameObject projectileNew; 

    //public Object_Pooler[] projectilePool;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        //projectile = projectilePool[0].GetPooledObject();
        controller = player.GetComponent<Player_Controller>();
    }
	
	// Update is called once per frame
	void Update () {
        if (controller.characterselect == 4 && controller.ability == true && projectileNew.activeSelf == false)
        {
            StartCoroutine(Delay());
        }
    }

    void Spawn_Projectile (Vector3 position)
    {
        Vector3 newPosition = new Vector3 (position.x+0.5f, position.y-0.5f, position.z);
        projectileNew.transform.position = newPosition;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.25f);
        Spawn_Projectile(player.transform.position);
        StartCoroutine(DelayView()); 
    }

    IEnumerator DelayView()
    {
        yield return new WaitForSeconds(0.35f);
        projectileNew.SetActive(true);
    }

}
