using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
	public BallManager _ballManager;
	public Timer _timer;
	static float scoreData;
	static float cupsDown;
	[SerializeField] TextMeshProUGUI scoreUI;
	[SerializeField] GameObject mainCanvas;
	[SerializeField] GameObject winCanvas;
	[SerializeField] GameObject loseCanvas;
	[SerializeField] GameObject[] arCamerasToDisable;
	[SerializeField] GameObject uiCamera;
	[SerializeField] GameObject particleEff;


	private void Start()
    {
		scoreData = 0;
		scoreUI.text = "Score : " + scoreData.ToString();
	}

    private void Update()
    {
		if(_timer.timeOver==true)
        {
			StartCoroutine(LoseUI());
        }
    }

    void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Ball"))
		{
			// Nikunj Add Score Here
			FindObjectOfType<AudioManager>().Play("HitInside");
			particleEff.SetActive(true);
			scoreData++;
			cupsDown++;
			_timer.loseCupCount++;
			scoreUI.text = "Score : " + scoreData.ToString();

			if (cupsDown >= 10)
			{
				_timer.win = true;
				StartCoroutine(WinUI());
			}
			Destroy(other.transform.gameObject);
			Invoke("DestroyThis", .5f);
		}
	}
	void DestroyThis()
    {

		Destroy(this.transform.parent.gameObject, 1.5f);
	}

	IEnumerator WinUI()
    {
		yield return new WaitForSeconds(1.4f);
		for (int i = 0; i < arCamerasToDisable.Length; i++)
			arCamerasToDisable[i].SetActive(false);
		mainCanvas.SetActive(false);
		uiCamera.SetActive(true);
		winCanvas.SetActive(true);
		cupsDown = 0;
		scoreData = 0;
	}

	IEnumerator LoseUI()
	{
		yield return new WaitForSeconds(1.2f);
		for (int i = 0; i < arCamerasToDisable.Length; i++)
			arCamerasToDisable[i].SetActive(false);
		mainCanvas.SetActive(false);
		uiCamera.SetActive(true);
		loseCanvas.SetActive(true);
		cupsDown = 0;
		scoreData = 0;
	}
}
