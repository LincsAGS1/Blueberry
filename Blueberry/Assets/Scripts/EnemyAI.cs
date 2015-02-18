using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public Transform target;
	public int moveSpeed;
	public float rotationSpeed;
	public int maxDistance;
	public int alertDistance;
	public GameObject go;

    public bool canMove = true;

	//float distance;

	private Transform myTransform;
	//int alertDistance11;
	//int alertDistance14;


	void Awake() {
		myTransform = transform;
		
	}
	
	// Use this for initialization
	void Start () {
		 go = GameObject.FindGameObjectWithTag("Player");
		target = go.transform;
		//Find the player and get their position. Will need to be made more advanced later as other people may get the virus.

	}
	
	// Update is called once per frame
    void Update()
    {

        if (canMove == true)
        {

            Debug.DrawLine(target.position, myTransform.position, Color.yellow);
            //distance = Vector3.Distance(target.position, myTransform.position);

            if (go.GetComponent<VirusScript>().Blueberry == false)
            {
                if (Vector3.Distance(target.position, myTransform.position) < alertDistance)
                {
                    //If the AI is close enough to notice the player. Will be used for selecting of who to chase after, when that feature is implemented.
                    //This ensure the AI locks onto the player and moves towards him correctly.
                    bool needsWeirdAngThing = Vector3.Angle(Vector3.right, target.position - this.transform.position) > 90;
                    transform.rotation = Quaternion.Lerp(myTransform.rotation, Quaternion.RotateTowards(myTransform.rotation, Quaternion.LookRotation(target.position - transform.position), 90), rotationSpeed);
                    //transform.LookAt(target.position);
                    transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, 90, 270);

                    if (needsWeirdAngThing == true)
                        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 270, 90);
                    else
                        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, 270);
                }
            }
            if (go.GetComponent<VirusScript>().Blueberry == true)
            {
                if (Vector3.Distance(target.position, myTransform.position) < alertDistance)
                {
                    //If the AI is close enough to notice the player. Will be used for selecting of who to chase after, when that feature is implemented.
                    //This ensure the AI locks onto the player and moves towards him correctly.
                    bool needsWeirdAngThing = Vector3.Angle(Vector3.right, target.position - this.transform.position) > 90;
                    transform.rotation = Quaternion.Lerp(myTransform.rotation, Quaternion.RotateTowards(myTransform.rotation, Quaternion.LookRotation(target.position - transform.position), 90), rotationSpeed);
                    //transform.LookAt(target.position);
                    transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, 90, 270);

                    if (needsWeirdAngThing == true)
                        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 270, 90);
                    else
                        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, 270);

                    transform.Rotate(0, 180, 0);
                }
            }
            //Move towards the player's position.
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
        }
    }
		
	}
