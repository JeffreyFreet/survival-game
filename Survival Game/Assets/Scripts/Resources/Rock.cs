using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Resource {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    override
    public void Interact()
    {
        print("Interacting with Rock");
    }

}
