using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {
	public float timer = 5;
	public GameObject GameManager;
	public AudioClip sound;

	// Use this for initialization
	void Start () {
		GameManager  = GameObject.FindWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0f)
			Destroy (gameObject);
	}

	void OnCollisionEnter2D (Collision2D other)
	{


		if (other.gameObject.tag == "Player")
		{
			AudioSource.PlayClipAtPoint(sound,transform.position);
			Destroy(gameObject);
		}
		//	GameManager.GetComponent<RandomVirus>().points += 15;
	}
}
