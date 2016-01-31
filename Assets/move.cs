using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
    private Vector3 moveDirection = Vector3.zero;
    CharacterController controller;
    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        moveDirection = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal")*-1);
        moveDirection = transform.TransformDirection(moveDirection);
       
        moveDirection *= 400;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
