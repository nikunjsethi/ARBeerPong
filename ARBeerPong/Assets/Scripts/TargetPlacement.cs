using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using TMPro;

public class TargetPlacement : MonoBehaviour
{
    [SerializeField]
    private ARRaycastManager _raycastManager;
    [SerializeField]
    private GameObject _target;
    [SerializeField]
    private GameObject _object;
    [SerializeField]
    private GameObject CameraBtn;
    private Pose _hitPose;
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();
    private Vector2 _ray;
    // Start is called before the first frame update
    void Start()
    {
        _target.SetActive(false);
        _ray = new Vector2(Screen.width / 2, Screen.height / 2);
        CameraBtn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(_raycastManager.Raycast(_ray,_hits,TrackableType.Planes))
        {
            _hitPose = _hits[0].pose;
            transform.position = _hitPose.position;
            transform.rotation = _hitPose.rotation;
            if (!_target.activeInHierarchy)
                _target.SetActive(true);
            CameraBtn.SetActive(true);
        }
        //if (Input.touchCount > 0 && _target.activeInHierarchy)
        //{
        //    _object.transform.position = transform.position;
        //    _object.SetActive(true);
        //    this.gameObject.SetActive(false);
        //}
    }

    public void BeerCupInstantiator()
    {
        _object.transform.position = transform.position;
        _object.SetActive(true);
        this.gameObject.SetActive(false);
        
    }
}
