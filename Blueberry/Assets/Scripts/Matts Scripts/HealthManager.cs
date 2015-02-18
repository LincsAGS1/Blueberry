using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour 
{

    public float health = 100;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (this.GetComponent<VirusScript>().Blueberry == true && health > 0)
        {
            health -= 0.1f;
        }

        if (health <=  0)
        {
            Debug.Log(this.name + " Died");
        }
	}
}
