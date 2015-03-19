using UnityEngine;
using System.Collections;

public class Delay : MonoBehaviour 
{

	private float Seconds = 5f; 
	public int Seconds2Wait = 3;
	public int[] totalSeconds = new int[3];


	// Use this for initialization
	void Start () 
	
	{
		InvokeRepeating ("EnvokeTimer", 1, 1);
		StartCoroutine(EnumeratorTimer());
	}

	void EnvokeTimer()

	{
		if (totalSeconds [0] < Seconds2Wait)
		totalSeconds [0]++;
		else
		CancelInvoke("EnvokeTimer");
	}

	IEnumerator EnumeratorTimer()

	{
		for (int ii = 0; ii < Seconds2Wait; ii++) 
		{

		yield return new WaitForSeconds (3f);
		totalSeconds [1]++;

		}
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		TimerUpdate ();
	}

	void TimerUpdate()

	{
		if (totalSeconds [2] < Seconds2Wait) 
		{
			if (Seconds > 0)
			Seconds -= Time.deltaTime;
			else if (Seconds <= 0) {
			totalSeconds [2]++;
			Seconds = 1f;


			}
		}
	}
}
