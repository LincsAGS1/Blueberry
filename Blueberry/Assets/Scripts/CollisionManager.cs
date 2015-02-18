using UnityEngine;
using System.Collections;

public class CollisionManager : MonoBehaviour 
{

    public bool collisions = false;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
        

	}

    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.name.Contains("Enemy") || collision.collider.name.Contains("Player"))
        {
            if (this.GetComponent<VirusScript>().Blueberry == true)
            {
                if (collisions == false)
                {
                    GameObject virusScript = collision.collider.gameObject;

                    virusScript.GetComponent<VirusScript>().Blueberry = true;

                    this.GetComponent<VirusScript>().Blueberry = false;

                    Debug.Log("Passing to " + collision.collider.name.ToString());

                    virusScript.GetComponent<CollisionManager>().collisions = true;

                    StartCoroutine(virusScript.GetComponent<CollisionManager>().wait());
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
}