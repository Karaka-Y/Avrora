using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;
public class Checkpoint : MonoBehaviour
{
    public float onDelay = 0.1f;
    private ParticleSystem _particles;
    private Light2D _light;
    private bool setRespawn = true;
    public float fontanPower = 150;
    public Slider _slider;
    private BoxCollider2D _box;
    void Start()
    {
        _box = GetComponent<BoxCollider2D>();
        _light = GetComponentInChildren<Light2D>();
        _particles = GetComponentInChildren<ParticleSystem>();
        _particles.Stop();

    }

    void Update()
    {
        Vector3 max = _box.bounds.max;
        Vector3 min = _box.bounds.min;
        Vector2 Corner1 = new Vector2(min.x, min.y);
        Vector2 Corner2 = new Vector2(max.x, max.y);
        Collider2D hit = Physics2D.OverlapArea(Corner1, Corner2);
        if(hit != null && hit.gameObject.tag == "Player"){
            _slider.value += fontanPower * Time.deltaTime;
        }
    }
    //Первая активация фонтана и установка чекпоинта
    private void OnTriggerEnter2D(Collider2D other) {
        Die _die = other.GetComponent<Die>();
        if(_die != null && setRespawn){
            StartCoroutine("ActivateCup");
            setRespawn = false;
            _die.checkPointPosition = this.transform.position;
            Debug.Log(_die.checkPointPosition);
            
        }
    }
    //Включаем фонтан после короткой задержки
    IEnumerator ActivateCup(){
        yield return new WaitForSeconds(onDelay);
        Audio.StaticFxAudioSource2.pitch = 1;
        Audio.StaticFxAudioSource2.clip = Audio.StaticFxAudioClips[2];
        Audio.StaticFxAudioSource2.Play();
        _light.enabled = true;
        _particles.Play();
    }
}
