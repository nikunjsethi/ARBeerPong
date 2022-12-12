using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{

		// Nikunj Add Score Here
		FindObjectOfType<AudioManager>().Play("HitInside");


	}
}
