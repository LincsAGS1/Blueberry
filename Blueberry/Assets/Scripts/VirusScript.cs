using UnityEngine;
using System.Collections;

public class VirusScript : MonoBehaviour
{

    public bool Blueberry = false;


    public float maxSpeed = 3f;
    float moveH;
    float moveV;
    public float powertimer = 0f;
    public float invinctimer = 0f;
    GameObject pickerupper;
    public float speedtimer = 0f;
    public GameObject[] Players;
    public float slowtimer = 0f;
    public GameObject gamecontroller;
    public GameObject holder;
    public float invistimer = 0f;
    public bool invis = false;


    // Use this for initialization
    void Start()
    {
        //this.SendMessage ("Blueberry", false);
        gamecontroller = GameObject.FindGameObjectWithTag("GameController");


    }

    // Update is called once per frame
    void Update()
    {

        invistimer -= Time.deltaTime;
        if (invistimer <= 0f)
        {
            invistimer = 0f;
            invis = false;
        }
        Players = gamecontroller.GetComponent<RandomVirus>().players;
        slowtimer -= Time.deltaTime;
        speedtimer -= Time.deltaTime;
        powertimer -= Time.deltaTime;
        invinctimer -= Time.deltaTime;
        if (speedtimer == 0.1f && this.tag == ("Player"))
            this.GetComponent<PlayerMove>().maxSpeed = 5f;

        else if (speedtimer > 0f && this.tag == ("Player"))
            this.GetComponent<PlayerMove>().maxSpeed = 10f;

        if (slowtimer == 0.1f)
        {
            for (int i = 0; i < Players.Length; i++)
            {
                if (Players[i].tag == ("AI"))
                {
                    Players[i].GetComponent<EnemyAI>().moveSpeed = 4;
                }
                this.GetComponent<PlayerMove>().maxSpeed = 5f;
            }
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Pickup")
        {
            Destroy(col.gameObject);
            //this.gameObject.GetComponent<VirusScript>().
            this.gameObject.GetComponent<PlayerMove>().maxSpeed = 10f;

            speedtimer = 9.5f;
            powertimer = 10f;
        }

        if (col.gameObject.tag == "Invincible")
        {
            Destroy(col.gameObject);
            //this.gameObject.GetComponent<VirusScript>().
            //powertimer = 10f;
            invinctimer = 10f;
        }

        if (col.gameObject.tag == "SlowTime")
        {
            Destroy(col.gameObject);
            //this.gameObject.GetComponent<VirusScript>().
            for (int i = 0; i < Players.Length; i++)
            {
                slowtimer = 9.5f;
                powertimer = 10f;
                if (Players[i].tag == ("AI"))
                {
                    Players[i].GetComponent<EnemyAI>().moveSpeed = 2;
                }
                this.GetComponent<PlayerMove>().maxSpeed = 5f;
            }
        }
        if (col.gameObject.tag == "Invisible")
        {
            Destroy(col.gameObject);
            //this.gameObject.GetComponent<VirusScript>().

            invis = true;
            invistimer = 10f;
            powertimer = 10f;
        }

        powertimer = 10f;

    }
}