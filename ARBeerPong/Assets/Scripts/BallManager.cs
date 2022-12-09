using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    private GameObject _newBall;
    public void SpawnBall()
    {
        Invoke("CreateBall", 2f);
    }
    private void CreateBall()
    {
        _newBall = Instantiate(_ball, this.transform.position, Quaternion.identity);
        _newBall.transform.parent = this.transform;
        _newBall.SetActive(true);

    }
}
