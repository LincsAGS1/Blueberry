using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour 
{
	public AudioClip [] songs;

	//AudioSource audioplaylist;
	int currentsong = 0;
	
    // Use this for initialization
	void Start () 
	{
		//audioplaylist = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GetComponent<AudioSource>().isPlaying == false)
		{
			currentsong++;
			if (currentsong >= songs.Length)
			{
				currentsong = 0;
			}

		    GetComponent<AudioSource>().clip = songs[currentsong];
		    GetComponent<AudioSource>().Play();
		}
	}
}

