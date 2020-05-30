using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class LightChange : MonoBehaviour
{
    private float lightOutRadius;
    private float lightInnerRadius;
    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private Light2D _light;
    
    void Start()
    {
        lightOutRadius = _light.pointLightOuterRadius;
        lightInnerRadius = _light.pointLightInnerRadius;
    }

    void Update()
    {
        _light.pointLightOuterRadius = (_slider.value / 1000) * lightOutRadius;
        _light.pointLightInnerRadius = (_slider.value / 1000) * lightInnerRadius;
    }
}
