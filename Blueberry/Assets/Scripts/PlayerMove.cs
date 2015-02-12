using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {



	public float maxSpeed = 10f;
	float moveH;
	float moveV;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void FixedUpdate () 
	{
		moveH = Input.GetAxis ("Horizontal");
		moveV = Input.GetAxis ("Vertical");

	
		transform.position += Vector3.right * moveH * maxSpeed * Time.deltaTime;
		transform.position += Vector3.up * moveV * maxSpeed * Time.deltaTime;
		rigidbody.velocity = Vector3.zero;
	}
}
