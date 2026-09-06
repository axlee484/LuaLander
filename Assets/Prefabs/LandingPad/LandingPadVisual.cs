using TMPro;
using UnityEngine;

public class LandingPadVisual : MonoBehaviour
{
    [SerializeField] private TextMeshPro multiplierText;
    private LandingPad landingPad;
    
    void Awake()
    {
        landingPad = GetComponent<LandingPad>();
        multiplierText.text = "x" + landingPad.Multiplier.ToString();
    }

    
}
