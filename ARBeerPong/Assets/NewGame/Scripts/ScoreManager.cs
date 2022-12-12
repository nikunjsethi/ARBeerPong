using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
	public BallManager _ballManager;
	static float scoreData;
	[SerializeField] TextMeshProUGUI scoreUI;
	void OnTriggerEnter(Collider other)
	{
		// Nikunj Add Score Here
		FindObjectOfType<AudioManager>().Play("HitInside");
		Destroy(this.transform.parent.gameObject);
		scoreData++;
		scoreUI.text = "Score : "+scoreData.ToString();
		Destroy(_ballManager._newBall.gameObject);

	}
}
