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
        print("Gamemanager "+Instance);
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
    
    void OnPickup(Collider2D collider)
    {
        var gameObject = collider.gameObject;
        if(gameObject.TryGetComponent<Coin>(out var coin))
        {
            HandleCoinCollection(coin);
        }
    }

}
