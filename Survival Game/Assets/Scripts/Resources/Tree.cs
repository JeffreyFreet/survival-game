﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Resource {

    [SerializeField]
    private GameObject tree, resourceDrop;

	// Use this for initialization
	void Start () {;
        tree.SetActive(true);
        name = "Tree";
        durability = 3;
        isHarvested = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (isHarvested)
        {
            respawn -= Time.deltaTime;
            if(respawn < 0)
            {
                isHarvested = false;
                respawn = timer;
                tree.SetActive(true);
            }
        }
	}

    override
    public void Interact()
    {
        print("Interacting with Tree");

        if(!isHarvested)
        {
            tree.SetActive(false);

            Instantiate(resourceDrop, new Vector3(this.transform.position.x + Random.Range(-2, 2) + 2, 0, this.transform.position.z + Random.Range(-2, 2) + 2), Quaternion.identity);
            isHarvested = true;
            
        }
;
    }
}
