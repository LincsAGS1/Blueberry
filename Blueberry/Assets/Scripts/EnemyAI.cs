using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{

    public Transform target;
    public int moveSpeed;
    public float rotationSpeed;
    public int maxDistance;
    public int alertDistance;
    public List<GameObject> playerslist;
    public GameObject[] players;
    public GameObject go;
    public Transform[] playerslocation;
    public float VirusTimer = 1f;
    public GameObject player;

    public bool canMove = true;


    //float distance;

    private Transform myTransform;
    //int alertDistance11;
    //int alertDistance14;


    void Awake()
    {
        myTransform = transform;

    }

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerslist = new List<GameObject>();
        playerslist.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        playerslist.AddRange(GameObject.FindGameObjectsWithTag("AI"));
        players = playerslist.ToArray();
        playerslocation = new Transform[players.Length];

        go = GameObject.FindGameObjectWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].GetComponent<VirusScript>().Blueberry == true)
                go = players[i];
            playerslocation[i] = players[i].transform;
        }


        target = go.transform;
        //Find the player and get their position. Will need to be made more advanced later as other people may get the virus.

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {

            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].GetComponent<VirusScript>().Blueberry == true)

                    go = players[i];

                playerslocation[i] = players[i].transform;

            }

            Debug.DrawLine(target.position, myTransform.position, Color.yellow);
            //distance = Vector3.Distance(target.position, myTransform.position);
            VirusTimer -= Time.deltaTime;
            if (this.VirusTimer < 0f && player.GetComponent<VirusScript>().slowtimer <= 0f)
            {
                this.moveSpeed = 4;
                this.VirusTimer = 0f;
            }

            //	bool needsWeirdAngThing = Vector3.Angle (Vector3.right, target.position - this.transform.position) > 90;
            //transform.rotation = Quaternion.Lerp (myTransform.rotation, Quaternion.RotateTowards (myTransform.rotation, Quaternion.LookRotation (target.position - transform.position), 90), rotationSpeed);
            //transform.LookAt(target.position);
            //transform.rotation = Quaternion.Euler (transform.localEulerAngles.x, 90, 270);

            //if (needsWeirdAngThing == true)
            //	transform.eulerAngles = new Vector3 (transform.eulerAngles.x, 270, 90);
            //else
            //	transform.eulerAngles = new Vector3 (transform.eulerAngles.x, 90, 270);

            if (this.GetComponent<VirusScript>().Blueberry == true)
            {
                //target = go.transform;
                target = GetClosestEnemy(playerslocation);


                if (target.GetComponent<VirusScript>().invis == false)
                    myTransform.LookAt(target.position);

            }
            //if (go.GetComponent<VirusScript>().Blueberry == true)
            else
            {

                for (int i = 0; i < players.Length; i++)
                {
                    if (players[i].GetComponent<VirusScript>().Blueberry == true)

                        go = players[i];
                    //playerslocation[i] = players[i].transform;
                    if (target.GetComponent<VirusScript>().invis == false)
                        target = go.transform;
                }



                myTransform.LookAt(target.position);
                transform.Rotate(0, 180, 0);
            }
            //Move towards the player's position.

            //myTransform.rigidbody2D.position += myTransform.up * moveSpeed * Time.deltaTime;
            this.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            //	myTransform.rigidbody.AddForce(myTransform.forward*moveSpeed*Time.deltaTime);
            //	myTransform.position += myTransform.forward*moveSpeed*Time.deltaTime;

        }
    }

    Transform GetClosestEnemy(Transform[] enemies)
    {
        ;
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform t in enemies)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist && dist > 0.01)
            {
                tMin = t;
                minDist = dist;

            }
        }
        return tMin;
    }

    //void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.GetComponent<VirusScript>().Blueberry == true && VirusTimer <= 0.1f && gameObject.GetComponent<VirusScript>().invinctimer <= 0.1f && gameObject.GetComponent<VirusScript>().Blueberry == false)
    //    {
    //        VirusTimer = 1f;
    //        gameObject.GetComponent<VirusScript>().Blueberry = true;
    //        other.gameObject.GetComponent<VirusScript>().Blueberry = false;
    //        other.gameObject.GetComponent<EnemyAI>().moveSpeed = 4;
    //        if (other.gameObject.tag == "Player")
    //        {
    //            other.gameObject.GetComponent<PlayerMove>().Virustimer = 1f;
    //            other.gameObject.GetComponent<PlayerMove>().maxSpeed = 0f;
    //        }

    //        this.moveSpeed = 0;
    //    }

    //    if (gameObject.GetComponent<VirusScript>().Blueberry == true && VirusTimer <= 0.1f && other.gameObject.GetComponent<VirusScript>().invinctimer <= 0f && other.gameObject.tag == "Player")
    //    {
    //        other.gameObject.GetComponent<VirusScript>().Blueberry = true;
    //        gameObject.GetComponent<VirusScript>().Blueberry = false;



    //        moveSpeed = 4;
    //    }



    //}


}