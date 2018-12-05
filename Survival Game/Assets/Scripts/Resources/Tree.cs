using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Resource {

    [SerializeField]
    private GameObject stump;
    [SerializeField]
    private GameObject tree;



	// Use this for initialization
	void Start () {
        stump.SetActive(false);
        tree.SetActive(true);
        name = "Tree";
        durability = 3;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    override
    public void Interact()
    {
        print("Interacting with Tree");

        stump.SetActive(true);
        tree.SetActive(false);
    }
}
