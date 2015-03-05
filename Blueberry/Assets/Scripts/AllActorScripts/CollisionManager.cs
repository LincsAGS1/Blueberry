using UnityEngine;
using System.Collections;

public class CollisionManager : MonoBehaviour 
{
    public bool collisions = false;
    public bool blueberry = false;
    public bool infected = false;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {      

	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("pass 0");
        if (collision.collider.name.Contains("Enemy") || collision.collider.name.Contains("Player"))
        {
            Debug.Log("pass 1");
            if (infected == true)
            {
                Debug.Log("pass 2");
                if (collisions == false)
                {
                    Debug.Log("pass 3");
                    GameObject otherObject = collision.collider.gameObject;

                    otherObject.GetComponent<CollisionManager>().infected = true;

                    //Only lose infected status 
                    if (!blueberry)
                    { infected = false; } 

                    Debug.Log("Passing to " + collision.collider.name.ToString());

                    otherObject.GetComponent<CollisionManager>().collisions = true;

                    StartCoroutine(otherObject.GetComponent<CollisionManager>().wait());

                    if (otherObject.name.Contains("Player"))
                    {
                        otherObject.GetComponent<PlayerMove>().canMove = false;

                        StartCoroutine(waitHolderPlayer(otherObject));
                    }

                    if (otherObject.name.Contains("Enemy"))
                    {
                        otherObject.GetComponent<EnemyAI>().canMove = false;

                        StartCoroutine(waitHolderAI(otherObject));
                    }
                }
            }
        }
    }

    public IEnumerator wait() // Runs methods every 10 seconds
    {
        yield return new WaitForSeconds(6.0f);

        collisions = false;

        Debug.Log(this.name + " Reset");
    }

    public IEnumerator waitHolderAI(GameObject virusScript) // Runs methods every 10 seconds
    {
        yield return new WaitForSeconds(6.0f);

        virusScript.GetComponent<EnemyAI>().canMove = true;
    }

    public IEnumerator waitHolderPlayer(GameObject virusScript) // Runs methods every 10 seconds
    {
        yield return new WaitForSeconds(6.0f);

        virusScript.GetComponent<PlayerMove>().canMove = true;
    }
}