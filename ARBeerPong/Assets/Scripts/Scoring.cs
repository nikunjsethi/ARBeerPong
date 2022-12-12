using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoring : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI score;
    public int scoreUpdate = 0;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BeerCups"))
        {
            scoreUpdate++;
            score.text = scoreUpdate.ToString();

        }
    }
}
