using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Die : MonoBehaviour
{
    [SerializeField]
    private int spikesDamage;
    [SerializeField]
    private int enemyDamage;
    private bool canTakeDamage = true;
    public Vector3 checkPointPosition = new Vector3(-95.74f, -9.63f, 0f);  //позиция в начале первого уровня
    [SerializeField]
    private Transform characterTransform;
    [SerializeField]
    private Slider _slider;
    private SpriteRenderer _sprite;
    private Color standartColor = new Color(1,1,1);
    private Color blincColor = new Color(0,0,0);
    
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CharacterDie(){
        characterTransform.position = checkPointPosition;
        _slider.value = _slider.maxValue;
    }

    //получение урона от шипов и монстров
    private void OnTriggerEnter2D(Collider2D other) {
        Spikes _spikes = other.GetComponent<Spikes>();
        EnemyMoving _enemy = other.GetComponent<EnemyMoving>();
        if(_spikes != null && canTakeDamage == true){
            _slider.value -= spikesDamage;
            canTakeDamage = false;
            StartCoroutine("SpriteChanger");
            Audio.StaticFxAudioSource2.pitch = Random.Range(0.9f, 1.1f);
            Audio.StaticFxAudioSource2.clip = Audio.StaticFxAudioClips[1];
            Audio.StaticFxAudioSource2.Play();
            StartCoroutine("WaitToDamage");
        }
        if(_enemy != null && canTakeDamage == true){
            _slider.value -= enemyDamage;
            canTakeDamage = false;
            StartCoroutine("SpriteChanger");
            Audio.StaticFxAudioSource2.pitch = Random.Range(0.9f, 1.1f);
            Audio.StaticFxAudioSource2.clip = Audio.StaticFxAudioClips[1];
            Audio.StaticFxAudioSource2.Play();
            StartCoroutine("WaitToDamage");
        }
    }
    //задержка перед повторным получением урона
    IEnumerator WaitToDamage(){
        yield return new WaitForSeconds(1f);
        canTakeDamage = true;
    }
    //анимация получения урона
    IEnumerator SpriteChanger(){
        for(int i = 1; i<8; i++){
            if(i%2 == 0){
                _sprite.color = blincColor;
            }
            else {
                _sprite.color = standartColor;
            }
        yield return new WaitForSeconds(0.15f);
        }
    }
}
