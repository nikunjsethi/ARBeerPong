using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeScript : MonoBehaviour {

	Vector2 startPos, endPos, direction; // touch start position, touch end position, swipe direction
	float touchTimeStart, touchTimeFinish, timeInterval; // to calculate swipe time to sontrol throw force in Z direction
	[SerializeField]
	BallManager ballManager;
	bool isBallCreated = false;

	[SerializeField]
	float throwForceInXandY = 1f; // to control throw force in X and Y directions

	[SerializeField]
	float throwForceInZ = 50f; // to control throw force in Z direction

	Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {

			touchTimeStart = Time.time;
			startPos = Input.GetTouch (0).position;
		}

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended) {

			touchTimeFinish = Time.time;

			timeInterval = touchTimeFinish - touchTimeStart;

			endPos = Input.GetTouch (0).position;

			direction = startPos - endPos;

			rb.useGravity = true;
			rb.AddForce (- direction.x * throwForceInXandY, - direction.y * throwForceInXandY, throwForceInZ / timeInterval);
			if (!isBallCreated)
			{
				isBallCreated = true;
				ballManager.SpawnBall();
			}
		}
			
	}

}
