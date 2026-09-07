using UnityEngine;

public class FuelManager : MonoBehaviour
{
    [SerializeField] private float fuelAmount = 100f;
    [SerializeField] private float fuelPerSecond = 10f;
    public float FuelAmount => fuelAmount;
    public float FuelPerSecond => fuelPerSecond;
    private EventManager eventManager;
    void Start()
    {
        eventManager = EventManager.Instance;
        eventManager.FuelPickupEvent += OnFuelPickup;
    }
    public void DepleteFuel(float depleteAmount)
    {
        fuelAmount -= depleteAmount;
        if(fuelAmount < 0) fuelAmount = 0;
        print("fuelAmount left: "+fuelAmount);
    }

    void OnFuelPickup(Fuel fuel, Collider2D otherCollider)
    {
        fuelAmount += fuel.FuelAmount;
        print($"Fuel Amount: {fuelAmount}");
    }

}
