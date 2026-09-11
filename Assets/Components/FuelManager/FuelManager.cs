using UnityEngine;

public class FuelManager : MonoBehaviour
{
    [SerializeField] private float maxFuel = 100f;
    public float MaxFuel => maxFuel;
    private float fuelRemaining;
    [SerializeField] private float fuelPerSecond = 10f;
    [SerializeField] private float fuelPerSecondOnRotate = 0f;
    public float FuelPerSecondOnRotate => fuelPerSecondOnRotate;
    public float FuelRemaning => fuelRemaining;
    public float FuelPerSecond => fuelPerSecond;
    private EventManager eventManager;
    void Awake()
    {
        fuelRemaining = maxFuel;
    }
    void Start()
    {
        eventManager = EventManager.Instance;
        eventManager.FuelPickupEvent += OnFuelPickup;
    }

    public void DepleteFuel(float depleteAmount)
    {
        fuelRemaining -= depleteAmount;
        if(fuelRemaining < 0) fuelRemaining = 0;
        // print("fuelAmount left: "+fuelRemaining);
    }

    void OnFuelPickup(Fuel fuel, Collider2D otherCollider)
    {
        fuelRemaining += fuel.FuelAmount;
        print($"Fuel Amount: {fuelRemaining}");
    }

}
