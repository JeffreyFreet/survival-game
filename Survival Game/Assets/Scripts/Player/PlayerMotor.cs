using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    private float movementSpeed;
    private float jumpSpeed = 250;
    private float jumpTimer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        jumpTimer -= Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftShift))
            movementSpeed = 10f;
        else
            movementSpeed = 5f;


        //Jumping will be figured out once Terrain is figured out, I just wanted a skeleton for now

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(jumpTimer <= 0)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpSpeed);
                jumpTimer = 1f;
            }
        }

        float translation = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        float strafe = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;

        transform.Translate(strafe, 0, translation);
    }
}
