using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawn : MonoBehaviour
{
	
	public GameObject ball;

	public void Spawn()
	{
		var instance = Instantiate(ball, new Vector3(0f, 1-0.17f, -10 +0.5300001f), Quaternion.identity);
		instance.transform.SetParent(transform);
	}
}
