using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour
{
    public float timer = 5;
    public GameObject GameManager;

    // Use this for initialization
    void Start()
    {
        GameManager = GameObject.FindWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
            Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        { }
        //	GameManager.GetComponent<RandomVirus>().points += 15;
    }
}
