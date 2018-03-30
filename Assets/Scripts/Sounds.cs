using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Sounds : MonoBehaviour {

    public AudioClip footstep;
    public AudioSource footstepSource;
    public AudioClip ability;
    public AudioSource abilitySource;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Footstep()
    {
        footstepSource.PlayOneShot(footstep);
    }

    void Ability()
    {
        abilitySource.PlayOneShot(ability);
    }
    
}
