using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Creature {

    private Transform target = null;
    private float attackValue = 20f;
    private float knockback = 300;
    private float attackTimer = 0f;

    // Use this for initialization
    void Start()
    {
        name = "Bear";
        health = 150;
        maxHealth = health;
        player = GameObject.FindGameObjectWithTag("Player");

        Wander();
        transform.LookAt(wayPoint);
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
            Death();

        UpdateUI();

        transform.position += transform.TransformDirection(Vector3.forward) * speed * Time.deltaTime;

        if (Vector3.Distance(this.transform.position, player.transform.position) <= 10)
        {
            target = player.transform;
            speed = 2;
        }

        if (target != null)
        {
            transform.LookAt(target);
            Attack();
        }
        else
        {
            if ((transform.position - wayPoint).magnitude < 3)
            {
                Wander();
                transform.LookAt(wayPoint);
            }
        }
    }

    protected override void Attack()
    {
        RaycastHit hit;

        attackTimer += Time.deltaTime;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 2))
        {
            if (hit.transform.gameObject.tag == "Player")
            {
                if (attackTimer >= 2f)
                {
                    hit.collider.gameObject.GetComponent<PlayerController>().Damage(attackValue, knockback, transform);
                    attackTimer = 0f;
                }
            }
        }

        if (Vector3.Distance(this.transform.position, player.transform.position) >= 15)
        {
            target = null;
            speed = 1;
            Wander();
        }
    }

    protected override void Death()
    {
        Drop();
        Destroy(this);
    }

    protected override void Drop()
    {
        Instantiate(drop, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
    }

    public override void Interact(Transform player, float knockback)
    {
        health -= 10;

        Vector3 direction = (transform.position - player.position).normalized;

        GetComponent<Rigidbody>().AddForce(direction * knockback);
    }

}
