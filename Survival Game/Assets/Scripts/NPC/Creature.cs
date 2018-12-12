using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Creature : MonoBehaviour {

    protected string name;
    protected int health;
    protected int maxHealth;
    [SerializeField]
    protected GameObject player;
    public Image healthBar;
    public Image healthBG;

    public abstract void Interact();
    public abstract void Attack(); //Only neccesary on hostiles
    public abstract void Death();
    public abstract void Drop();


}
