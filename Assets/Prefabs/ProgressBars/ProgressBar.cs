using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image progress;
    [SerializeField] private Image indicator;
    public virtual float MaxValue {get;} = 1.0f;
    public virtual float Value {get;} = 0.0f;
    private void Awake()
    {
        slider.maxValue = MaxValue;
        UpdateSlider();
    }
    private void UpdateIndicator()
    {
        if(indicator == null) return;
        if(Value == 0) indicator.enabled = false;
        else indicator.enabled = true;
    }
    private void UpdateSlider()
    {
        slider.value = Value;
        progress.color = gradient.Evaluate(slider.normalizedValue);

    }
    void Update()
    {
        UpdateSlider();
    }
}
