using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Die _die;
    private Slider _slider;
    public int changeSpeed;
    public static float HP;

    void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.minValue = _minValue;
        _slider.maxValue = _maxValue;
        _slider.value = _maxValue;
    }
    public float _minValue = 0;
    public float _maxValue = 1000;
    void Update()
    {
        HP = _slider.value / _maxValue;
        _slider.value -= changeSpeed * Time.deltaTime;
        if(_slider.value == _minValue){
            _die.CharacterDie();
        }
    }
}
