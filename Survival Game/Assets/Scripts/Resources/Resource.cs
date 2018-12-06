using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resource : MonoBehaviour {

    protected int durability;
    protected string name;
    protected bool isHarvested;
    protected float respawn = 5f;
    protected float timer = 5f;

    public abstract void Interact();
}
