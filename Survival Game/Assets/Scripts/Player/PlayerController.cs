using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private float playerHealth, playerMaxHealth;
    private float playerHunger, PlayerMaxHunger;
    private float playerThirst, playerMaxThirst;
    private float knockback = 750;

    public Image healthBar;
    public Image hungerBar;
    public Image thirstBar;


	// Use this for initialization
	void Start () {
        playerMaxHealth = 100f;
        PlayerMaxHunger = 100f;
        playerMaxThirst = 100f;
        playerHealth = 100f;
        playerHunger = 100f;
        playerThirst = 100f;
	}
	
	// Update is called once per frame
	void Update () {

        UpdateHunger();
        UpdateThirst();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Resource")
                {
                    hit.collider.gameObject.GetComponent<Resource>().Interact();
                }
            }

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Creature")
                {
                    hit.collider.gameObject.GetComponent<Creature>().Interact(transform, knockback);
                }
            }
        }
	}

    public void Damage(float damageValue, float knockback, Transform enemyPosition)
    {
        playerHealth -= damageValue;
        UpdateHealth();

        Vector3 direction = (transform.position - enemyPosition.position).normalized;

        GetComponent<Rigidbody>().AddForce(direction * knockback);
    }

    private void UpdateHunger()
    {
        playerHunger -= Time.deltaTime * .16f;   //.16 makes 100 -> 0 in 10 mins
        hungerBar.fillAmount = playerHunger / PlayerMaxHunger;
        //print(playerHunger);

    }

    private void UpdateThirst()
    {
        playerThirst -= Time.deltaTime * .16f;   //.16 makes 100 -> 0 in 10 mins
        thirstBar.fillAmount = playerThirst / playerMaxThirst;
        //print(playerThirst);
    }

    private void UpdateHealth()
    {
        healthBar.fillAmount = playerHealth / playerMaxHealth;
    }
}
