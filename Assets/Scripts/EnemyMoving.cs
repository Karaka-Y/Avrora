using UnityEngine;

public class EnemyMoving : MonoBehaviour
{

    private SpriteRenderer _enemySprite;
    
    public Vector3 finishPos = Vector3.zero;
    public float speed = 0.5f;

    private Vector3 _startPos;
    private float _trackPercent = 0;
    private int _direction = 1;
    
    void Start()
    {
        _startPos = transform.position;
        _enemySprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {   
        _trackPercent += _direction * speed * Time.deltaTime;
        float x = (finishPos.x - _startPos.x) * _trackPercent + _startPos.x;
        float y = (finishPos.y - _startPos.y) * _trackPercent + _startPos.y;
        
        transform.position = new Vector3(x,y,_startPos.z);

        if ((_direction == 1 && _trackPercent >= 1f) || (_direction == -1 && _trackPercent <= 0f)){
            _direction *= -1;
        }
        if(_direction == 1){
            _enemySprite.flipX = true;
        }
        else if(_direction == -1){
            _enemySprite.flipX = false;
        }
        
    }
    
}
