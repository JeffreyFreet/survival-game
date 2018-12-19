using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Creature {

    private GameObject target;

    // Use this for initialization
    void Start()
    {
        name = "Bear";
        health = 15;
        maxHealth = health;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
            Death();

        UpdateUI();

        transform.position += transform.TransformDirection(Vector3.forward) * Speed * Time.deltaTime;
        if ((transform.position - wayPoint).magnitude < 3)
        {
            Wander();
        }

        if ((transform.position - player.transform.position).magnitude < 10)
            target = player;

        if ((transform.position - player.transform.position).magnitude > 15)
            target = null;

        if (target != null)
        {
            wayPoint = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
            transform.LookAt(wayPoint);
        }
    }

    protected override void Attack()
    {
        throw new System.NotImplementedException();
    }

    protected override void Death()
    {
        Drop();
        Destroy(this.gameObject);
    }

    protected override void Drop()
    {
        Instantiate(drop, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
    }

    public override void Interact()
    {
        health--;
    }

}
