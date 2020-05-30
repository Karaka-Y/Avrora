using UnityEngine;
using UnityEngine.UI;

public class PowerBank : MonoBehaviour
{
    public Slider _slider;
    public float HPCount;
    private void OnTriggerEnter2D(Collider2D other) {
        if( other.gameObject.tag == "Player"){
            _slider.value += HPCount;
            this.gameObject.SetActive(false);
            Audio.StaticFxAudioSource2.pitch = 1;
            Audio.StaticFxAudioSource2.clip = Audio.StaticFxAudioClips[0];
            Audio.StaticFxAudioSource2.Play();
        }
    }
}
