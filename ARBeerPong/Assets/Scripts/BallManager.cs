using TMPro;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _cups;
    [HideInInspector] public GameObject _newBall, _ballReleased;
    private float _distance;

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

    public void UnparentMe()
    {
        _newBall.transform.parent = null;
        _ballReleased = _newBall;
        // need to remove parent after ball is thrown so it doesnt move with the camera
    }
    
    private void Update()
    {
        if (transform.childCount > 0)
        {
            _distance = Vector3.Distance(this.transform.position, _cups.transform.position);

            if (_distance < 1f)
            {
                if (gameObject.transform.GetChild(0).gameObject.activeInHierarchy)
                    gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {

                if (!gameObject.transform.GetChild(0).gameObject.activeInHierarchy)
                    gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
        }

    }

}
