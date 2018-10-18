using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    private Transform follow;
    private Vector3 followCameraOffset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    public float animationDuration;
    private Vector3 animationOffset = new Vector3(0, 5, 5);

	// Use this for initialization
	void Start () {
        follow = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        followCameraOffset = transform.position - follow.position;
	}
	
	// Update is called once per frame
	void Update () {
        moveVector = follow.position + followCameraOffset;

        // X axis
        moveVector.x = 0;

        // Y axis
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);

        if(transition > 1.0f)
        {
            transform.position = moveVector;
        }
        else
        {
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(follow.position + Vector3.up);
        }
	}
}
