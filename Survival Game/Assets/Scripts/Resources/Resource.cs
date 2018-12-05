using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resource : MonoBehaviour {

    protected int durability;
    protected string name;

    public abstract void Interact();
}
