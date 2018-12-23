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

    public abstract void Interact(Transform player, float knockback);
    protected abstract void Attack(); //Only neccesary on hostiles
    protected abstract void Death();
    protected abstract void Drop();

    protected float speed = 1;
    protected Vector3 wayPoint;
    protected int range = 7;

    protected void Wander()
    {
        wayPoint = new Vector3(Random.Range(transform.position.x - range, transform.position.x + range), 1, Random.Range(transform.position.z - range, transform.position.z + range));
        wayPoint.y = 0;
    }

    protected void SmoothLook(Vector3 newDirection)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection), Time.deltaTime);
    }

    protected void UpdateUI()
    {
        healthBar.transform.LookAt(player.transform);
        healthBG.transform.LookAt(player.transform);
        healthBar.fillAmount = (float)health / (float)maxHealth;
        healthBG.fillAmount = 1 - healthBar.fillAmount;
    }


}
