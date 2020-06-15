using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] int scorePerHit = 20;
    int score = 0;
    Text scoreText = null;
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        
    }
    public void ScoreHit()
    {
        score = score + scorePerHit;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
