using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveVector;

    public float speed;
    public float verticalVelocity;
    public float gravity;

    public float animationDuration;
    
    // Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.time < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero;

        if(controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        // x axis
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

        // y axis
        moveVector.y = verticalVelocity;

        // z axis
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
	}
}
