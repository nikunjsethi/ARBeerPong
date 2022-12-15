using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySwipeScript : MonoBehaviour {

	Vector2 startPos, endPos,  SwipeDistance; // touch start position, touch end position, swipe direction
	float touchTimeStart, touchTimeFinish, timeInterval; // to calculate swipe time to sontrol throw force in Z direction
	Vector3 direction;
	public BallManager ballManager;
	bool isBallCreated = false;
	[SerializeField]
	float throwForceInXandY = 1f; // to control throw force in X and Y directions

	[SerializeField]
	float throwForceInZ = 50f; // to control throw force in Z direction

	Rigidbody rb;

	bool ballThrown = false;
	SwipeScript swipeScript;


	Camera mainCamera;


	void Start()
	{
		rb = GetComponent<Rigidbody>();
		mainCamera = Camera.main;
	}

	// Update is called once per frame
	void Update () {

		if (!ballThrown)
		{
			// if you touch the screen
			if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
			{

				// getting touch position and marking time when you touch the screen
				touchTimeStart = Time.time;
				startPos = Input.GetTouch(0).position;
			}

			// if you release your finger
			if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
			{

				// marking time when you release it
				touchTimeFinish = Time.time;

				// calculate swipe time interval 
				timeInterval = touchTimeFinish - touchTimeStart;

				// getting release finger position
				endPos = Input.GetTouch(0).position;

				// calculating swipe direction in 2D space
				direction = (startPos - endPos) * -1;
				SwipeDistance = (startPos - endPos) * -1 / 100;

				// add force to balls rigidbody in 3D space depending on swipe time, direction and throw forces
				rb.isKinematic = false;
			
				Vector3 forceToAddZ = mainCamera.transform.forward * throwForceInZ * SwipeDistance.y + (direction * throwForceInXandY);
			
				rb.AddForce(forceToAddZ);
				ballManager.UnparentMe();
				ballThrown = true;
	
				if (!isBallCreated)
				{
					isBallCreated = true;
					ballManager.SpawnBall();
				}

			}
		}

	}


    int hitCount = 0;
	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.tag == "Floor")
        {
			hitCount++;
			if (hitCount >= 5)
			{
				hitCount = 5;
			}
			FindObjectOfType<AudioManager>().Play("Hit"+hitCount);
			
		} 
		else if (collision.collider.tag == "Cup")
		{
			FindObjectOfType<AudioManager>().Play("Cup");
		}

	}






}
