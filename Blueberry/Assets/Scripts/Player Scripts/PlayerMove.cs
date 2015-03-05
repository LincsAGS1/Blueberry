using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour 
{
	public float maxSpeed = 10f;
	float moveH;
	float moveV;

    public bool canMove = true;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

	void FixedUpdate () 
	{
        if (canMove == true)
        {
            moveH = Input.GetAxis("Horizontal");
            moveV = Input.GetAxis("Vertical");
            
            transform.position += Vector3.right * moveH * maxSpeed * Time.deltaTime;
            transform.position += Vector3.up * moveV * maxSpeed * Time.deltaTime;
            rigidbody2D.velocity = Vector3.zero;
        }
	}
}
