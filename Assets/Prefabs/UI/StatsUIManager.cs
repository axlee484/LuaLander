using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
enum STAT_TYPE
{
    SCORE,
    TIME,
    SPEEDX,
    SPEEDY,
    FUEL,
    HEALTH
    
};

[Serializable]
internal struct Stat
{
    public STAT_TYPE Name;
    public TextMeshProUGUI Text;
}

public class StatsUIManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private List<Stat> stats;
    [SerializeField] private GameObject speedXArrow;
    [SerializeField] private GameObject speedXArrowN;

    [SerializeField] private GameObject speedYArrow;
    [SerializeField] private GameObject speedYArrowN;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image fuelBar;


    private Dictionary<STAT_TYPE, TextMeshProUGUI> statMap;
    private Rigidbody2D playerBody;
    ScoreManager scoreManager;
    GameManager gameManager;

    private FuelManager fuelManager;
    private Health health;
    void Awake()
    {
        statMap = new Dictionary<STAT_TYPE, TextMeshProUGUI>();
        foreach (var stat in stats)
        {
            statMap.Add(stat.Name, stat.Text);
        }
    }
    void Start()
    {
        scoreManager = ScoreManager.Instance;
        gameManager = GameManager.Instance;
        playerBody = playerController.GetComponent<Rigidbody2D>();
        fuelManager = playerController.GetComponent<FuelManager>();
        health = playerController.GetComponent<Health>();
    }

    private void UpdateScore()
    {
        var score = scoreManager.Score;
        statMap[STAT_TYPE.SCORE].text = score.ToString();
    }

    private void UpdateTime()
    {
        var time = gameManager.TimeElapsed;
        statMap[STAT_TYPE.TIME].text = time.ToString("F2");
    }

    private void SetArrowX(Vector2 linearVelocity)
    {
        if(linearVelocity.x == 0)
        {
            speedXArrow.SetActive(false);
            speedXArrowN.SetActive(false);
        }
        if(linearVelocity.x < 0)
        {
            speedXArrow.SetActive(false);
            speedXArrowN.SetActive(true);
            return;
        }
        speedXArrow.SetActive(true);
        speedXArrowN.SetActive(false);
        
    }
    private void SetArrowY(Vector2 linearVelocity)
    {
        if(linearVelocity.y == 0)
        {
            speedYArrow.SetActive(false);
            speedYArrowN.SetActive(false);
            return;
        }
        if(linearVelocity.y < 0)
        {
            speedYArrow.SetActive(false);
            speedYArrowN.SetActive(true);
            return;
        }
        speedYArrow.SetActive(true);
        speedYArrowN.SetActive(false);
        
    }
    private void UpdateSpeed()
    {
        var linearVelocity = playerBody.linearVelocity;

        SetArrowX(linearVelocity);
        SetArrowY(linearVelocity);

        var speedX = Mathf.Abs(linearVelocity.x);
        var speedY = Mathf.Abs(linearVelocity.y);

        statMap[STAT_TYPE.SPEEDX].text = speedX.ToString("F2");
        statMap[STAT_TYPE.SPEEDY].text = speedY.ToString("F2");


    }

    private void UpdateFuel()
    {
        var fuelRemaining = fuelManager.FuelRemaning;
        var percentage = fuelRemaining/fuelManager.MaxFuel;
        fuelBar.fillAmount = percentage;
        // statMap[STAT_TYPE.FUEL].text = fuelRemaining.ToString("F2");
    }

    private void UpdateHealth()
    {
        var healthRemainig = health.CurrentHealth;
        var percentage = healthRemainig/health.MaxHealth;
        healthBar.fillAmount = percentage;
        // statMap[STAT_TYPE.SCORE].text = healthRemainig.ToString("F2");
    }

    public void UpdateStats()
    {
        UpdateScore();
        UpdateTime();
        UpdateSpeed();
        UpdateFuel();
        UpdateHealth();
    }

    void Update()
    {
        UpdateStats();
    }

}
