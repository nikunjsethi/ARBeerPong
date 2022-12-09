using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject blubberBallPrefab;
    [SerializeField] private float throwForce = 2.0f;
    private Touch touchPoint;

    private void Update()
    {
        if (Input.touchCount>0)
        {
            touchPoint = Input.GetTouch(0);
            //Debug.Log(Input.mousePosition);
           // Vector3 mousePos = Input.mousePosition;
            Vector3 worldMousePos = mainCamera.ScreenToWorldPoint(new Vector3(touchPoint.position.x, touchPoint.position.y, mainCamera.nearClipPlane));
            Debug.Log("World Mouse Position: " + worldMousePos);
            Vector3 directionVector = worldMousePos - mainCamera.transform.position;
            directionVector = new Vector3(directionVector.x, directionVector.y, 0f).normalized;
            Debug.Log("Direction Vector: " + directionVector);
            Vector3 forceVector = new Vector3(directionVector.x, directionVector.y, 1.0f * throwForce);

            GameObject blubberBall = Instantiate(blubberBallPrefab, mainCamera.transform.position, Quaternion.identity);
            Rigidbody rigidBlubber = blubberBall.GetComponent<Rigidbody>();
            rigidBlubber.AddForce(forceVector, ForceMode.Impulse);
        }
    }

}
