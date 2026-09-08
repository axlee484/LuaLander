using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private EventManager eventManager;
    private ScoreManager scoreManager;
    private AudioManager audioManager;
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
        audioManager = AudioManager.Instance;

        eventManager = EventManager.Instance;
        eventManager.CoinPickupEvent += OnCoinPickup;
    }

    void OnCoinPickup(Coin coin, Collider2D otherCollider)
    {
        scoreManager.AddScore(coin.Value);
        coin.TryGetComponent<InstantPickup>(out var instantPickup);
        audioManager.PlaySfx(instantPickup.PickupSound);
    }

    public void Update()
    {
        time+=Time.deltaTime;
    }


}
