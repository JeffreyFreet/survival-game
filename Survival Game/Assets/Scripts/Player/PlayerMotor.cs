using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    private float movementSpeed= 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float translation = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        float strafe = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;

        transform.Translate(strafe, 0, translation);
    }
}
