using UnityEngine;

public class CharacterMoving : MonoBehaviour
{
    public bool canMove = true;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private int _jumpForce;
    private Rigidbody2D _body;
    private BoxCollider2D _box;
    private SpriteRenderer _playerSprite;
    [SerializeField]
    private AudioSource FxAudioSource;
    [SerializeField]
    private AudioClip[] StepClips;
    [SerializeField]
    private AudioClip JumpClip;
    private Animator _anim;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _box = GetComponent<BoxCollider2D>();
        _playerSprite = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * _speed;

        //Изменение поворота спрайта
        if (deltaX < -0.2f)
        {
            _playerSprite.flipX = true;
        }
        else if (deltaX > 0.2f)
        {
            _playerSprite.flipX = false;
        }
        if (_playerSprite.flipX)
        {
            SparkMoving.characterPositionX = transform.position.x - 0.6f;
        }
        else
        {
            SparkMoving.characterPositionX = transform.position.x + 0.6f;
        }

        Vector2 movement = new Vector2 (deltaX, _body.velocity.y);

        //для возможности отключения передвижения игрока
        if(canMove)
        {
            _body.velocity = movement;
        }

        //проверка на наличие поверхности под персонажем
        Vector3 max = _box.bounds.max;
        Vector3 min = _box.bounds.min;

        Vector2 Corner1 = new Vector2(max.x - 0.1f, min.y - 0.1f);
        Vector2 Corner2 = new Vector2(min.x + 0.1f, min.y - .2f);

        Collider2D hit = Physics2D.OverlapArea(Corner1, Corner2);

        bool isGrounded = false;

        if(hit != null && hit.gameObject.tag != "Checkpoint")
        {
            isGrounded = true;
        }

        //прыжок
        if(isGrounded && Input.GetKeyDown(KeyCode.Space) && canMove)
        {
           _body.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            FxAudioSource.pitch = Random.Range(0.9f, 1.1f);
            FxAudioSource.clip = JumpClip;
            FxAudioSource.Play();
        }
        
        //привязка персонажа к движущимся платформам
        MovingPlatform platform = null;
        if (hit != null){
            platform = hit.GetComponent<MovingPlatform>();
        }
        if(platform != null){
            transform.parent = platform.transform;
        }
        else {
            transform.parent = null;
        }
        
        //Звук шагов с рандомным питчем и из массива из 4 звуков. 
        if ((Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("Horizontal") < -0.5f) && !FxAudioSource.isPlaying && isGrounded == true)
        {
            FxAudioSource.pitch = Random.Range(0.8f, 1.2f);
            FxAudioSource.clip = StepClips[Random.Range(0, StepClips.Length)];
            FxAudioSource.Play();
        }
    }
}
