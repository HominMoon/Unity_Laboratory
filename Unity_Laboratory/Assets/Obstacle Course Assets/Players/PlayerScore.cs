using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerScore : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    int score = 0;
    
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Hit!!");
        if (other.gameObject.tag != "Hit" && other.gameObject.tag != "Plane")
        {
            score++;
            scoreText.SetText($"Score: {score}");
        }
    }
}
