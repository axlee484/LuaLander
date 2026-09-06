using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float score = 0f;
    public static ScoreManager Instance;
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        print("ScoreMnagre +" + Instance);
    }
    public void AddScore(float score)
    {
        this.score += score;
        print($"Score: {score}");
    }
}
