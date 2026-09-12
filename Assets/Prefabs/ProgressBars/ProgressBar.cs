using UnityEngine;
using UnityEngine.UI;

public abstract class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image progress;
    [SerializeField] private Image indicator;
    public virtual float MaxValue {get;} = 1.0f;
    public virtual float Value {get;} = 0.0f;
    [SerializeField] private bool resetOnFull;
    public bool ResetOnFull => resetOnFull;
    private void Awake()
    {
        slider.maxValue = MaxValue;
        UpdateSlider();
    }
    private void UpdateIndicator()
    {
        if(indicator == null) return;
        if(slider.value == 0) indicator.enabled = false;
        else indicator.enabled = true;
    }
    private void UpdateSlider()
    {
        slider.value = Value;
        progress.color = gradient.Evaluate(slider.normalizedValue);
        UpdateIndicator();
        if(resetOnFull && slider.value == MaxValue) slider.value = 0;
    }
    void Update()
    {
        UpdateSlider();
    }
}
