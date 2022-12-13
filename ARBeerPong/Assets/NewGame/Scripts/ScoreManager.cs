using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
	public BallManager _ballManager;
	static float scoreData;
	static float cupsDown;
	[SerializeField] TextMeshProUGUI scoreUI;
	[SerializeField] GameObject mainCanvas;
	[SerializeField] GameObject winCanvas;
	[SerializeField] GameObject loseCanvas;
	[SerializeField] GameObject[] arCamerasToDisable;
	[SerializeField] GameObject uiCamera;

    private void Start()
    {
		scoreUI.enabled = true;
		scoreData = 0;
		scoreUI.text = "Score : " + scoreData.ToString();
	}
    void OnTriggerEnter(Collider other)
	{
		// Nikunj Add Score Here
		FindObjectOfType<AudioManager>().Play("HitInside");
		Destroy(this.transform.parent.gameObject,1.5f);
		scoreData++;
		cupsDown++;
		scoreUI.text = "Score : "+scoreData.ToString();
		Destroy(_ballManager._newBall.gameObject);

		if(cupsDown>=2)
        {
            StartCoroutine(ChangeUI());
            //for (int i = 0; i < arCamerasToDisable.Length; i++)
            //    arCamerasToDisable[i].SetActive(false);
            //mainCanvas.SetActive(false);
            //uiCamera.SetActive(true);
            //winCanvas.SetActive(true);
            //cupsDown = 0;
            //scoreData = 0;
        }
	}

	IEnumerator ChangeUI()
    {
		yield return new WaitForSeconds(0f);
		for (int i = 0; i < arCamerasToDisable.Length; i++)
			arCamerasToDisable[i].SetActive(false);
		mainCanvas.SetActive(false);
		uiCamera.SetActive(true);
		winCanvas.SetActive(true);
		cupsDown = 0;
		scoreData = 0;
	}
}
