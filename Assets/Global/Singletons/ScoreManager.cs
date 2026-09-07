using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float score = 0f;
    public static ScoreManager Instance;
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void AddScore(float score)
    {
        this.score += score;
        print($"Score: {this.score}");
    }
}
