using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public float intensitySpeed;
    public float blastSpeed;
    private Light2D _greatLight;
    private float outerRadius;
    private float innerRadius;
    public GameObject panel;
    public SpriteRenderer _charSprite;
    public CharacterMoving _movable;
    public Text text;
    private bool startText = false;
    public AudioSource MusicAudio;
    public AudioSource Fontan;
    public AudioSource OutroMusic;
    
    
    void Start()
    {
        _greatLight = GetComponentInChildren<Light2D>();
        outerRadius = _greatLight.pointLightOuterRadius;
        innerRadius = _greatLight.pointLightInnerRadius;
    }

    void Update()
    {

        if(_greatLight.intensity > 100){
            StopCoroutine("Boom");
            _charSprite.enabled = false;
            _movable.canMove = false;
            panel.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other != null && other.gameObject.tag == "Player")
        {
            StartCoroutine("Wait");
        }
    }
    IEnumerator Boom(){
        StartCoroutine(Outro());
        StartCoroutine(OffMusic());
        while (true){
            _greatLight.pointLightOuterRadius += blastSpeed;
            _greatLight.pointLightInnerRadius += blastSpeed;
            _greatLight.intensity += intensitySpeed;
        yield return new WaitForSeconds(0.05f);
        }

    }
    IEnumerator Wait(){
        yield return new WaitForSeconds(4f);
        _greatLight.intensity = 20f;
        StartCoroutine("Boom");
    }

    IEnumerator OffMusic()
    {
        while (MusicAudio.volume > 0 || Fontan.volume > 0)
        {
            yield return new WaitForSeconds(0.2f);
            MusicAudio.volume -= 0.1f;
            Fontan.volume -= 0.1f;
            if (Fontan.volume < 0.01f)
            {
                OutroMusic.Play();
            }
        }
    }

    IEnumerator Outro()
    {
            yield return new WaitForSeconds(6f);
            text.enabled = true;
            text.text = "Подземелья были полны опасностей.";
            yield return new WaitForSeconds(8f);
            text.text = "Пройдя через холод и мрак, преодолев все препятствия и ловушки, Аврора добралась до самого сердца Запретной Горы.";
            yield return new WaitForSeconds(12f);
            text.text = "Благодаря магии светлячка и храбрости девочки, потухший когда-то в чугунных чашах огонь разгорелся вновь.";
            yield return new WaitForSeconds(11f);
            text.text = "Аврора не только нашла своих родителей, но и подарила миру долгожданный рассвет.";
            yield return new WaitForSeconds(8f);
            text.text = "Конец";
            yield return new WaitForSeconds(5f);
            text.text = "Конец?";
            yield return new WaitForSeconds(12f);
            SceneManager.LoadScene(0);
        
    }

}
