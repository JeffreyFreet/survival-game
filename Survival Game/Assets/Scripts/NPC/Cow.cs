using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cow : Creature {

    public GameObject lootDrop;

    // Use this for initialization
    void Start()
    {
        health = 10;
        maxHealth = 10;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.transform.LookAt(player.transform);
        healthBar.fillAmount = (float) health / (float) maxHealth;

        if (health <= 0)
        {
            Death();
        }
    }

    public override void Attack()
    {
        //Will literally never be called, no implementation needed. This will be a passive mob
        //TO DO: Make PAssive and Hostile Classes
        throw new System.NotImplementedException();
    }

    public override void Death()
    {
        Drop();
        Destroy(this.gameObject);
    }

    public override void Drop()
    {
        Instantiate(lootDrop, new Vector3(this.transform.position.x, 0, this.transform.position.z), Quaternion.identity);
    }

    public override void Interact()
    {
        health--;
    }

    
}
