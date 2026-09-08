using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    public int Score => score;
    public static ScoreManager Instance;
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void AddScore(float score)
    {
        this.score += (int) Math.Round(score);
        print($"Score: {this.score}");
    }
}
