using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestory : MonoBehaviour
{
    float time = 0f;
    // Start is called before the first frame update
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Floor"))
            time+= Time.deltaTime;
    }
    private void Update()
    {
        if (time > 2f)
        {
            Destroy(this.gameObject);
        }
    }
}
