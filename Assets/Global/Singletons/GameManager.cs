using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private EventManager eventManager;
    private ScoreManager scoreManager;
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        scoreManager = ScoreManager.Instance;

        eventManager = EventManager.Instance;
        eventManager.PickupEvent += OnPickup;
    }

    void HandleCoinCollection(Coin coin)
    {
        scoreManager.AddScore(coin.Value);
    }
    
    void OnPickup(GameObject sender, Collider2D otherCollider)
    {
        if(sender.TryGetComponent<Coin>(out var coin))
        {
            HandleCoinCollection(coin);
        }
    }

}
