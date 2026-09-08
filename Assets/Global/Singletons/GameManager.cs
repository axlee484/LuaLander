using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private EventManager eventManager;
    private ScoreManager scoreManager;
    private float time = 0f;
    public float TimeElapsed => time;
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        scoreManager = ScoreManager.Instance;

        eventManager = EventManager.Instance;
        eventManager.CoinPickupEvent += OnCoinPickup;
    }

    void OnCoinPickup(Coin coin, Collider2D otherCollider)
    {
        scoreManager.AddScore(coin.Value);
    }

    public void Update()
    {
        time+=Time.deltaTime;
    }


}
