using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Creature : MonoBehaviour {

    protected string name;
    protected int health;
    protected int maxHealth;
    protected GameObject player;
    public Image healthBar;
    public Image healthBG;
    public GameObject drop;

    public abstract void Interact();
    protected abstract void Attack(); //Only neccesary on hostiles
    protected abstract void Death();
    protected abstract void Drop();

    protected Vector3 wayPoint;
    protected float Speed = 3;   
    protected int Range = 10;

    protected void Wander()
    {
        wayPoint = new Vector3(Random.Range(transform.position.x - Range, transform.position.x + Range), 
                               0, 
                               Random.Range(transform.position.z - Range, transform.position.z + Range));
        transform.LookAt(wayPoint);
    }

    protected void UpdateUI()
    {
        healthBar.transform.LookAt(player.transform);
        healthBG.transform.LookAt(player.transform);
        healthBar.fillAmount = (float)health / (float)maxHealth;
        healthBG.fillAmount = 1 - healthBar.fillAmount;
    }


}
